using Sedc.Server.Core.Responses;
using Sedc.Server.Interface.Attributes;
using Sedc.Server.Interface.Controllers;
using Sedc.Server.Interface.Entities;
using Sedc.Server.Interface.Logging;
using Sedc.Server.Interface.Requests;
using Sedc.Server.Interface.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Core.Processing
{
    internal class ApiResponseGenerator : IGenerator
    {
        public string SitePath { get; }
        public LoggerBase Logger { get; }

        public Type ControllerType { get; init; }
        public string Name { get => $"Api response generator at site {SitePath} using the {ControllerType.FullName} here"; }

        public ApiResponseGenerator(string sitePath, Type controllerType, LoggerBase logger)
        {
            SitePath = sitePath;
            Logger = logger;
            ControllerType = controllerType;
        }

        public HttpResponse Generate(HttpRequest request)
        {
            // 1. Create a controller instance (assume parameterless constructor)
            var ctor = ControllerType.GetConstructor([]);
            if (ctor == null)
            {
                string message = $"Unable to create controller {ControllerType.FullName}";
                Logger.Error(message);
                return new InvalidHttpResponse(500, message);
            }
            var controller = ctor.Invoke([]);

            // 2. Find the requested method
            var methods = ControllerType.GetMethods().Where(mi => mi.GetCustomAttribute<HttpGetAttribute>() != null);
            var methodName = GetMethodName(request.Uri);
            var method = methods.FirstOrDefault(mi => mi.Name.ToLowerInvariant() == methodName);
            if (method == null)
            {
                string message = $"Unable to find method {methodName} in controller {ControllerType.FullName}";
                Logger.Error(message);
                return new InvalidHttpResponse(404, message);
            }

            // 3. Match parameters by name and type
            var uriParameters = GetUriParameters(request.Uri);
            var methodParameters = method.GetParameters();

            if (uriParameters.Length < methodParameters.Length)
            {
                string message = $"Unable to match parameters for {methodName} in controller {ControllerType.FullName}";
                Logger.Error(message);
                return new InvalidHttpResponse(404, message);
            }

            // 4. Extract parameters in correct types
            List<object> parameterValues = new List<object>();
            for (int index = 0; index < methodParameters.Length; index++)
            {
                var mp = methodParameters[index];
                var up = uriParameters[index];
                if (mp.ParameterType == typeof(string))
                {
                    parameterValues.Add(up);
                }
                if (mp.ParameterType == typeof(int))
                {
                    if (int.TryParse(up, out int value))
                    {
                        parameterValues.Add(value);
                    }
                    else
                    {
                        string message = $"Unable to match value for parameter {index} for {methodName} in controller {ControllerType.FullName}";
                        Logger.Error(message);
                        return new InvalidHttpResponse(404, message);
                    }
                }
            }

            // 5. Call the method and get the result
            var result = method.Invoke(controller, parameterValues.ToArray());
            var response = result.ToString(); // Here we should deserialize the result
            var headers = new Dictionary<string, string> {
                    { "Content-Type", "text/plain" },
                    { "Content-Length", response.Length.ToString() }
                };

            return new StringHttpResponse
            {
                StatusCode = 200,
                Headers = HeaderCollection.FromDictionary(headers),
                Body = response
            };
        }

        private string[] GetUriParameters(SedcUri uri)
        {
            return uri.Paths.Skip(2).ToArray();
        }

        private string GetMethodName(SedcUri uri)
        {
            if (uri.Paths.Length < 2)
            {
                return string.Empty;
            }
            var methodName = uri.Paths[1];
            if (string.IsNullOrEmpty(methodName))
            {
                return string.Empty;
            }
            return methodName.ToLowerInvariant();
        }


        private bool CheckSitePath(SedcUri uri)
        {
            if (uri.Paths.Length < 1)
            {
                return false;
            }
            var sitePath = uri.Paths[0];
            if (string.IsNullOrEmpty(sitePath))
            {
                return false;
            }
            return sitePath == SitePath;
        }

        public bool WannaConsume(HttpRequest request)
        {
            return CheckSitePath(request.Uri);
        }

        internal static IGenerator Create<T>(string sitePath, LoggerBase logger) where T : IController
        {
            logger.Debug($"Creating a generator for the {typeof(T).FullName}");
            return new ApiResponseGenerator(sitePath, typeof(T), logger);
        }
    }
}
