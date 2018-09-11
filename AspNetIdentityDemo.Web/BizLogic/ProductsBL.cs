using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AspNetIdentityDemo.Web.BizEntities;

namespace AspNetIdentityDemo.Web.BizLogic
{
    public class ProductsBL
    {
        public List<Product> GetAllProducts()
        {
            return new List<Product>()
            {
                new Product(){ ProductId = 1,Name = "Producto 01",Price = 10},
                new Product(){ ProductId = 2,Name = "Producto 02",Price = 20},
                new Product(){ ProductId = 3,Name = "Producto 03",Price = 30},
                new Product(){ ProductId = 4,Name = "Producto 04",Price = 40},
                new Product(){ ProductId = 5,Name = "Producto 05",Price = 50},
            };
        }
    }
}