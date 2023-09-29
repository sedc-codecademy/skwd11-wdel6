
using System.Text.RegularExpressions;

public static class RequestProcessor
{
    private static readonly Regex requestLineRegex = new("^([A-Z]+) /([^ ]*) HTTP/1.1$", RegexOptions.Multiline);

    public static bool IsRequestValid(string request)
    {
        var requestLines = request.Split(Environment.NewLine);
        if (requestLines.Length == 0)
        {
            return false;
        }

        var match = requestLineRegex.Match(requestLines[0]);
        if (!match.Success)
        {
            return false;
        }
        return true;
    }

    internal static HttpRequest ProcessRequest(string request)
    {
        var isValidRequest = IsRequestValid(request);
        Console.WriteLine($"This request is {(isValidRequest ? "valid" : "invalid")}");
        if (!isValidRequest)
        {
            return InvalidHttpRequest.Invalid;
        }

        var requestLines = request.Split(Environment.NewLine);
        var match = requestLineRegex.Match(requestLines[0]);
        var method = new SedcMethod(match.Groups[1].Value);
        var uri = match.Groups[2].Value;
        var headers = new Dictionary<string, string>();

        var headerLines = requestLines.Skip(1).TakeWhile(line => !string.IsNullOrEmpty(line)).ToList();

        foreach (var line in headerLines)
        {
            var elements = line.Split(": ");
            var key = elements[0];
            var value = elements[1];
            headers.Add(key, value);
        }

        var body = requestLines
            .SkipWhile(line => !string.IsNullOrEmpty(line))
            .Skip(1)
            .Aggregate(string.Empty, (a, b) => $"{a}{Environment.NewLine}{b}");

        return new HttpRequest
        {
            Method = method,
            Uri = new SedcUri(uri),
            Headers = new HeaderCollection(headers),
            Body = body
        };
    }
}