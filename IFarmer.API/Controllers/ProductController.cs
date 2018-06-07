using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IFarmer.Model;
using Microsoft.AspNetCore.Authorization;
using IFarmer.Entity;

namespace IFarmer.API
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
