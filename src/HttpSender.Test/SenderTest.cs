using System;
using Xunit;
using HttpSender;
using System.Collections.Generic;

namespace HttpSender.Test
{
    public class PigeonTest
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

        [Fact]
        public void PutUrlTest()
        {
            Sender sender = new Sender();
            string putResult = sender.Put("http://localhost:5000/home/testput?c=4");
            Assert.Equal("Put 4", putResult);
        }

        [Fact]
        public void PutTest()
        {
            Sender sender = new Sender();
            Dictionary<string, string> test = new Dictionary<string, string> { { "c", "5" } };
            string putResult = sender.Put("http://localhost:5000/home/testput", test);
            Assert.Equal("Put 5", putResult);
        }

        [Fact]
        public void DeleteTest()
        {
            Sender sender = new Sender();
            string deleteResult = sender.Delete("http://localhost:5000/home/testdelete?d=6");
            Assert.Equal("Delete 6", deleteResult);
        }
    }
}
