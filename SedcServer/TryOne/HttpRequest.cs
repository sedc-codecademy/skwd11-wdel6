internal class HttpRequest
{
    public SedcMethod Method { get; init; } = SedcMethod.Invalid;
    public SedcUri Uri { get; init; } = SedcUri.Empty;
    public HeaderCollection Headers { get; init; }
    public string Body { get; init; }
}

internal class InvalidHttpRequest : HttpRequest
{
    private static readonly InvalidHttpRequest _request = new();
    private InvalidHttpRequest()
    {
        Method = SedcMethod.Invalid;
        Uri = SedcUri.Empty;
        Headers = new(new Dictionary<string, string>());
        Body = string.Empty;
    }

    public static InvalidHttpRequest Invalid { get { return _request; } }

}