

internal class ActualProcessor
{
    internal static HttpResponse Process(HttpRequest request)
    {
        Console.WriteLine($"Processing request: {request.Method} {request.Uri}");

        foreach (var (key, value) in request.Headers)
        {
            Console.WriteLine($"The value of {key} is {value}");
        }

        Console.WriteLine();

        Console.WriteLine("Body is");
        Console.WriteLine(request.Body);

        return null;
    }
}