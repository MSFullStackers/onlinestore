namespace onlinestore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using online.core;
    using onlinestore;

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IStudents students;

        private readonly IOnlineshopdataContext dbContext;

        public ValuesController(IStudents students,IOnlineshopdataContext dbContext)
        {
            this.students = students;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public Products[] Get()
        {  
            var someItems =  (IEnumerable<Products>) this.dbContext.GetList<Products>();
            
            return someItems.ToArray();
        }
    }
}
