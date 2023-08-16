using Microsoft.AspNetCore.Mvc;
using Product_Integration.Models;
using Product_Integration.Repo;

namespace Product_Integration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IProduct _product;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IProduct product)
        {
            _logger = logger;
            _product = product;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("getproducts")]
        public Task<IList<Product>> GetProducts()
        {
            return _product.GetProducts();
        }

        [HttpGet("getproductbyid/{id}")]
        public Task<Product> GetProductById([FromRoute]string id)
        {
            return _product.GetProductById(id);
        }

        [HttpPost("addproduct")]
        public Task AddProduct([FromBody] Product product)
        {
            return _product.AddProduct(product);
        }

        [HttpPut("updateproduct")]
        public Task UpdateProduct([FromBody] Product product)
        {
            return _product.UpdateProduct(product);
        }

        [HttpDelete("deleteproduct")]
        public Task DeleteProduct([FromRoute] string id)
        {
            return _product.DeleteProduct(id);
        }

    }
}