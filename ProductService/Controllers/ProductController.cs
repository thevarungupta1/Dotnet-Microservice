using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Models;

namespace ProductService.Controllers
{
    
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        // api/product
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var data = _repository.GetAllProducts();
            return Ok(data);
        }

        // api/product/id
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(int id)
        {
            var data = _repository.GetProductById(id);
            if (data == null)
                return NotFound("No recprd found with id: " + id);
            return Ok(data);
        }

        // api/product - post
        // http://localhost:1234/product/1
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Post(Product product)
        {
            var data = _repository.AddProduct(product);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                "/" + HttpContext.Request.Path + "/" + product.Id, data);
        }
    }
}
