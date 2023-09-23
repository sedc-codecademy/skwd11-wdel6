
using System.Text.RegularExpressions;

public static class RequestProcessor
{
    private static readonly Regex requestLineRegex = new("^[A-Z]+ /[^ ]+ HTTP/1.1$");

    public static bool IsRequestValid(string request)
    {
        var isValidRequest = requestLineRegex.IsMatch(request);
        return isValidRequest;
    }

    internal static object ProcessRequest(string request)
    {
        var isValidRequest = IsRequestValid(request);
        Console.WriteLine($"This request is {(isValidRequest ? "valid" : "invalid")}");
        return null;
    }
}