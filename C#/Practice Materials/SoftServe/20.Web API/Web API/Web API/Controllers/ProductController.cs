using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text;
using System.Net;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;

        public List<Product> myProducts = new List<Product>
        {
            new Product() {Id = 1, Name = "Product2", Description = "ProductDescription"},
            new Product() {Id = 2, Name = "Product3", Description = "ProductDescription"},
            new Product() {Id = 3, Name = "Product4", Description = "ProductDescription"},
            new Product() {Id = 4, Name = "Product5", Description = "ProductDescription"},
            new Product() {Id = 5, Name = "Product6", Description = "ProductDescription"},
            new Product() {Id = 6, Name = "Product1", Description = "ProductDescription"},
        };

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> NegotiationGet() => myProducts;


        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        public ActionResult<Product?> JsonGet(int id) =>
        myProducts.FirstOrDefault(p => p.Id ==id);

        [HttpGet]
        [Route("{id}/{format?}")]
        public IActionResult ParameterGet(int id, string format)
        {

            var prod = myProducts.Where(p => p.Id == id).FirstOrDefault();

            if (prod == null)
            {
                return NotFound();
            }
            else if (format == "json")
            {
                return new JsonResult(prod);
            }
            else if(format == "plain")
            {
                return Content($"Product:{prod.Name} with id: {prod.Id} ");
            }
            return Ok();
        }
    }
}