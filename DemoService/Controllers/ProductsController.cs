using DemoService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace DemoService.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class ProductsController : ApiController
    {
        ProductContext productContext;
        public ProductsController()
        {
            productContext = new ProductContext();
        }

        [Route("products")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            List<product> prod = new List<product>();
            prod = productContext.products.ToList();
            if (prod.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, prod);
            }
            else if (prod.Count == 0)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Products Available!");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Please try again later!");

            }
        }

        [Route("products/{id}")]
        [HttpGet]
        public HttpResponseMessage GetProductById(int id)
        {
            product prod = new product();
            prod = productContext.products.FirstOrDefault(e => e.product_id == id);
            if (prod != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, prod);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product Not Existing For Given Id:" + id + "!");
            }
        }

        [Route("products/registerProduct")]
        [HttpPost]
        public HttpResponseMessage Post(product prod)
        {
            try
            {
                if (prod != null)
                {
                    productContext.products.Add(prod);
                    productContext.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, prod);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Provide Valid Details");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }


        }
        
        [Route("products/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(int id, product prod)
        {
            var product = productContext.products.FirstOrDefault(e => e.product_id == id);
            if (product != null)
            {
                product.product_name = prod.product_name;
                product.Freshness_id = prod.Freshness_id;
                product.category_id = prod.category_id;
                product.Files_id = prod.Files_id;
                product.Additional_Des = prod.Additional_Des;
                product.Comments = prod.Comments;
                product.Price = prod.Price;

                productContext.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, product);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id " + id + " not found in our database");
            }

        }

 
        [Route("products/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var emp = productContext.products.FirstOrDefault(e => e.product_id == id);
            if (emp != null)
            {
                productContext.products.Remove(emp);
                productContext.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Delete Successful");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with Id " + id + " not found in our database");
            }
        }
    }
}
