﻿using Sedc.Server.Core.Logging;
using Sedc.Server.Core.Requests;
using Sedc.Server.Core.Responses;
using Sedc.Server.Interface.Entities;
using Sedc.Server.Interface.Logging;
using Sedc.Server.Interface.Requests;
using Sedc.Server.Interface.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Core.Processing
{
    internal class ActualProcessor
    {
        public LoggerBase Logger { get; }

        private readonly List<IGenerator> generators;
        public ActualProcessor(LoggerBase logger)
        {
            this.Logger = logger;
            var htmlGenerator = new HtmlGenerator(Logger);
            var fileReader = new FileReader(Logger);
            var apiGenerator = new ApiResponseGenerator(Logger);

            this.generators = [
                fileReader,
                htmlGenerator,
                apiGenerator,
            ];
        }

        public void RegisterGenerator(IGenerator generator)
        {
            this.generators.Insert(0, generator);
        }


        internal HttpResponse Process(HttpRequest request)
        {
            if (request is InvalidHttpRequest)
            {
                return new InvalidHttpResponse();
            }

            int statusCode = 200;

            var generator = generators.First(g => g.WannaConsume(request));
            (string body, string contentType) = generator.Generate(request);

            var headers = new Dictionary<string, string>
            {
                { "Content-Type", contentType },
                { "Content-Length", body.Length.ToString() }
            };

            return new HttpResponse
            {
                Body = body,
                StatusCode = statusCode,
                Headers = HeaderCollection.FromDictionary(headers)
            };
        }
    }
}
