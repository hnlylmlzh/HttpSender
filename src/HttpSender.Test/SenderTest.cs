using System;
using Xunit;
using HttpSender;
using System.Collections.Generic;

namespace HttpSender.Test
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

        [Fact]
        public void PostDictionaryTest()
        {
            Dictionary<string, string> test = new Dictionary<string, string> { { "b", "3" } };
            string postResult = Sender.Post("http://localhost:5000/home/contact", test);
            Assert.Equal("Post 3", postResult);
        }

        [Fact]
        public void PutUrlTest()
        {
            string putResult = Sender.Put("http://localhost:5000/home/testput?c=4");
            Assert.Equal("Put 4", putResult);
        }

        [Fact]
        public void PutTest()
        {
            Dictionary<string, string> test = new Dictionary<string, string> { { "c", "5" } };
            string putResult = Sender.Put("http://localhost:5000/home/testput", test);
            Assert.Equal("Put 5", putResult);
        }

        [Fact]
        public void DeleteTest()
        {
            string deleteResult = Sender.Delete("http://localhost:5000/home/testdelete?d=6");
            Assert.Equal("Delete 6", deleteResult);
        }

        [Fact]
        public void WaitTest()
        {
            Assert.Throws<AggregateException>(()=>Sender.Get("http://localhost:5000/home/wait?a=1"));
        }
    }
}
