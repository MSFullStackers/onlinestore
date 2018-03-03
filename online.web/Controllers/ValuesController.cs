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

        private readonly IStudents students;

        public ValuesController(IItems items, IStudents students)
        {
            this.items = items;
            this.students = students;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {            
            var myItems = this.items.Get();
            var myStudents = this.students.Get();

            return new string[] 
            {
                 myItems.First().Name , 
                 myItems.Last().Name ,
                 myStudents.First().Name,
                 myStudents.Last().Name 
            };
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
