internal class HttpResponse
{
    public int StatusCode { get; init; }
    public string Body { get; init; }
    public Dictionary<string, string> Headers { get; init; }

    public HttpResponse()
    {
        StatusCode = 200;
        Body = string.Empty;
        Headers = new();
    }
    public HttpResponse(int statusCode, string body, Dictionary<string, string> headers)
    {
        StatusCode = statusCode;
        Body = body;
        Headers = headers;
    }
}