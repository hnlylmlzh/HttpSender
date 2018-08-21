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
            string getResult = Sender.Get("http://localhost:5000/home/about?a=1");
            Assert.Equal("Get 1",getResult);
        }

        [Fact]
        public void PostTest()
        {
            string postResult = Sender.Post("http://localhost:5000/home/contact", "b=2");
            Assert.Equal("Post 2", postResult);
        }
    }
}
