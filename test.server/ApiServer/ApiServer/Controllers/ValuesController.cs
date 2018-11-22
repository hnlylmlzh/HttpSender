using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using ApiServer.Models;
using System.Web.Http;

namespace ApiServer.Controllers
{
    public class ValuesController : ApiController
    {

        [HttpGet]
        public string Get(int id)
        {
            return "value"+id;
        }

        [HttpPost]
        public string Post(PostBody postBody)
        {
            return postBody.value;
        }
    }
}
