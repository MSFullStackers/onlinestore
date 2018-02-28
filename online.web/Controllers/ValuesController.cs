using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using online.core;

namespace onlinestore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        private readonly IItems items;

        public ValuesController(IItems items)
        {
            this.items = items;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {            
            var myItems = this.items.Get();

            return new string[] { myItems.First().Name ,  myItems.Last().Name  };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
