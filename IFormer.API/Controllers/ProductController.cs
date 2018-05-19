using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Online.Model;
using System.Threading.Tasks;

namespace onlinestore.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public async Task< List< Product>> Get()
        {
            return await productRepository.GetAllAsync();
        }
    }
}
