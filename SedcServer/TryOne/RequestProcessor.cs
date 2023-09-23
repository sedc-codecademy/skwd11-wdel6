
using System.Text.RegularExpressions;

public static class RequestProcessor
{
    private static readonly Regex requestLineRegex = new("^([A-Z]+) /([^ ]+) HTTP/1.1$", RegexOptions.Multiline);

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
        var method = match.Groups[1].Value;
        var uri = match.Groups[2].Value;
        Console.WriteLine($"{method} {uri}");

        return true;
    }

    internal static object ProcessRequest(string request)
    {
        var isValidRequest = IsRequestValid(request);
        Console.WriteLine($"This request is {(isValidRequest ? "valid" : "invalid")}");
        return null;
    }
}