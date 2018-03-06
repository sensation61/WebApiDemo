using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using System.Web.Http.Description;

using web_api_demo.Models;
using web_api_demo.Filter.ActionFilter;
using web_api_demo.Filter.Authorize;
using Microsoft.AspNet.Identity;

namespace web_api_demo.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {

        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        /// <summary>
        /// Get all product
        /// </summary>
        /// <remarks>
        /// Get all product
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>

        [Authorize]
        [ResponseType(typeof(IEnumerable<Product>))]
        public IHttpActionResult GetAllProducts()
        {
            var user = User.Identity.GetUserId();

            return Ok(products);
        }

        /// <summary>
        /// Get single product
        /// </summary>
        /// <remarks>
        /// Get single product
        /// </remarks>
        /// <param name="id"></param>
        /// <returns>Product</returns>
        /// <response code="200"></response>
        [AuthorizeFilter]
        [DebugActionFilter]
        [Route("{id:int}")]
        [ResponseType(typeof(Product))]
        
        public Product GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                int a = int.Parse("adas");
            }
            return product;
        }

        [Route("{id:int}/details")]
        [AuthorizeFilter(Users="Ali")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetBookDetail(int id)
        {

            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }



    }
}
