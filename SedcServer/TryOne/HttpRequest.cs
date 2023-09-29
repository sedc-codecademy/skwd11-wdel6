internal class HttpRequest
{
    public Method Method { get; init; }
    public string Uri { get; init; }
    public Dictionary<string, string> Headers { get; init; }
    public string Body { get; init; }
}

internal class InvalidHttpRequest : HttpRequest
{
    private static readonly InvalidHttpRequest _request = new();
    private InvalidHttpRequest()
    {
        Method = Method.Invalid;
        Uri = string.Empty;
        Headers = new();
        Body = string.Empty;
    }

    public static InvalidHttpRequest Invalid { get { return _request; } }

}