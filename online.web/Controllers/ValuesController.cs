using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Online.Model;

namespace onlinestore.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IProductRepository productRepository;

        public ValuesController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public Products[] Get()
        {
            var allProducts = productRepository.GetAllAsync().Result.ToArray();

            return allProducts;
        }
    }
}
