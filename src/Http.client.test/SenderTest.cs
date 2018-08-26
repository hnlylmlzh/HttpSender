using System;
using Xunit;
using Http.client;
using System.Collections.Generic;

namespace Http.client.test
{
    public class SenderTest
    {
        [Fact]
        public void GetTest()
        {
            Sender sender = new Sender();
            string getResult = sender.Get("http://localhost:5000/home/about?a=1");
            Assert.Equal("Get 1",getResult);
        }

        [Fact]
        public void PostTest()
        {
            Sender sender = new Sender();
            string postResult = sender.Post("http://localhost:5000/home/contact", "b=2");
            Assert.Equal("Post 2", postResult);
        }

        [Fact]
        public void PostDictionaryTest()
        {
            Sender sender = new Sender();
            Dictionary<string, string> test = new Dictionary<string, string> { { "b", "3" } };
            string postResult = sender.Post("http://localhost:5000/home/contact", test);
            Assert.Equal("Post 3", postResult);
        }
    }
}
