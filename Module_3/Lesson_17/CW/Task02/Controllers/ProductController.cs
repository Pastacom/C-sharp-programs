using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task02.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController
    {
        private static List<Product> list = new List<Product>(new[]
        {
            new Product() {Id = 1, Name = "First", Price = 321},
            new Product() {Id = 2, Name = "Second", Price = 51},
            new Product() {Id = 3, Name = "Third", Price = 51222},
        });
        [HttpGet]
        public IEnumerable<Product> Get() => list;
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = list.SingleOrDefault(p => p.Id == id);
            if (product == null)
                return new NotFoundResult();
            return new OkObjectResult(product);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            list.Remove(list.SingleOrDefault(p => p.Id == id));
            return new OkResult();
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            product.Id = 123;
            list.Add(product);
            return new CreatedResult(nameof(Get), product);
        }
    }
}
