

using TryOne;

internal class ActualProcessor
{
    internal static HttpResponse Process(HttpRequest request)
    {
        // Code that displays the request object we got
        //Console.WriteLine($"Processing request: {request.Method} {request.Uri}");

        //foreach (var (key, value) in request.Headers)
        //{
        //    Console.WriteLine($"The value of {key} is {value}");
        //}

        //Console.WriteLine();

        //Console.WriteLine("Body is");
        //Console.WriteLine(request.Body);

        if (request is InvalidHttpRequest)
        {
            return new HttpResponse
            {
                StatusCode = 400,
                Body = "Bad request",
                Headers = new Dictionary<string, string>
                {
                    { "Content-Type", "text/plain" },
                    { "Content-Length", "11" }
                }
            };
        }

        var statusCode = 200;
        string body;
        string contentType;
        if (request.Method == Method.Get)
        {
            (body, contentType) = HtmlGenerator.GetHtml(request);
        } 
        else
        {
            body = "Hello world!";
            contentType = "text/plain";
        }
        var headers = new Dictionary<string, string>
        {
            { "Content-Type", contentType },
            { "Content-Length", body.Length.ToString() }
        };

        return new HttpResponse
        {
            Body = body,
            StatusCode = statusCode,
            Headers = headers
        };
    }
}