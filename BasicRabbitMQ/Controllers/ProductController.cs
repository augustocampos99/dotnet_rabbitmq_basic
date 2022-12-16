using BasicRabbitMQ.Models;
using BasicRabbitMQ.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicRabbitMQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductMessage _productMessage;

        public ProductController(IProductMessage productMessage)
        {
            _productMessage= productMessage;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new Product());
        }


        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _productMessage.Send(product);
            return Ok(product);
        }
    }
}
