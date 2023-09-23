var runTest = (string request, bool expected) =>
{
    var actual = RequestProcessor.IsRequestValid(request);
    return actual == expected;
};


var requestText2 = @"POST /from-postman HTTP/1.1";

Console.WriteLine(runTest(requestText1, true));
Console.WriteLine(runTest(requestText2, true));

