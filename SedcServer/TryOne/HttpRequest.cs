internal class HttpRequest
{
    public Method Method { get; init; }
    public object Uri { get; init; }
    public object Headers { get; init; }
    public object Body { get; init; }
}