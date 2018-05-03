namespace onlinestore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using online.core;

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
    }
}
