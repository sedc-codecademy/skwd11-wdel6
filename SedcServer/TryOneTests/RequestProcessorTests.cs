namespace TryOneTests
{
    public class RequestProcessorTests
    {
        [Fact]
        public void IsValid_test_full_postman_request()
        {
            var requestText1 = @"POST /from-postman HTTP/1.1
Zdravo: SEDC
Content-Type: application/json
User-Agent: PostmanRuntime/7.32.3
Accept: */*
Postman-Token: a221cb58-888d-4603-be4d-643225ffcbd0
Host: localhost:668
Accept-Encoding: gzip, deflate, br
Connection: keep-alive
Content-Length: 27

{
    ""one"": ""еден""
}";
            var actual = RequestProcessor.IsRequestValid(requestText1);
            var expected = true;
            Assert.Equal(expected, actual);
        }
    }
}