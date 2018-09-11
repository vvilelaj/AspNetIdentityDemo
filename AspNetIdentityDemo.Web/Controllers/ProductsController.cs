using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AspNetIdentityDemo.Web.BizLogic;

namespace AspNetIdentityDemo.Web.Controllers
{
    [Authorize]
    public class ProductsController : ApiController
    {
        public ProductsBL ProductsBl { get; set; }

        public ProductsController()
        {
            ProductsBl = new ProductsBL();
        }

        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            var userName = User.Identity.Name;
            return Ok(ProductsBl.GetAllProducts());
        }
    }
}
