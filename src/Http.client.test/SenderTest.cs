using System;
using Xunit;
using Http.client;

namespace Http.client.test
{
    public class SenderTest
    {
        [Fact]
        public void GetTest()
        {
            string getResult = Sender.Get("http://localhost:5000/api/values/1");
            Assert.Equal("value",getResult);
        }
    }
}
