using System;
using Xunit;
using Http.Messenger;
using System.Collections.Generic;

namespace Http.Messenger.Test
{
    public class PigeonTest
    {
        [Fact]
        public void GetTest()
        {
            Pigeon sender = new Pigeon();
            string getResult = sender.Get("http://localhost:5000/home/about?a=1");
            Assert.Equal("Get 1",getResult);
        }

        [Fact]
        public void PostTest()
        {
            Pigeon sender = new Pigeon();
            string postResult = sender.Post("http://localhost:5000/home/contact", "b=2");
            Assert.Equal("Post 2", postResult);
        }

        [Fact]
        public void PostDictionaryTest()
        {
            Pigeon sender = new Pigeon();
            Dictionary<string, string> test = new Dictionary<string, string> { { "b", "3" } };
            string postResult = sender.Post("http://localhost:5000/home/contact", test);
            Assert.Equal("Post 3", postResult);
        }
    }
}
