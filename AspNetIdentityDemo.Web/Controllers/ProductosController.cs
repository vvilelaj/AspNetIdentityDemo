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
    public class ProductosController : ApiController
    {
        public ProductsBL ProductsBl { get; set; }

        public ProductosController()
        {
            ProductsBl = new ProductsBL();
        }

        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            return Ok(ProductsBl.GetAllProducts());
        }
    }
}
