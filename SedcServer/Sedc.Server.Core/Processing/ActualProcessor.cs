using Sedc.Server.Core.Logging;
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
            var apiGenerator = new DefaultResponseGenerator(Logger);

            this.generators = [
                fileReader,
                htmlGenerator,
                apiGenerator,
            ];
        }

        public void RegisterGenerator(IGenerator generator)
        {
            Logger.Info($"Registered new generator {generator.Name}");
            this.generators.Insert(0, generator);
        }


        internal HttpResponse Process(HttpRequest request)
        {
            if (request is InvalidHttpRequest)
            {
                return new InvalidHttpResponse();
            }

            var generator = generators.First(g => g.WannaConsume(request));
            Logger.Debug($"Selected {generator.Name} to respond");
            try
            {
                var response = generator.Generate(request);
                return response;
            }
            catch (Exception ex)
            {
                var message = $"Generator {generator.Name} threw an exception of type {ex.GetType().FullName} with a message {ex.Message}";
                Logger.Error(message);
                return new InvalidHttpResponse(500, message);
            }

        }
    }
}
