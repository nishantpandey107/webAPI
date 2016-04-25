﻿using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;

using System.Web.Http.Cors;
using SportsStoreWebAPI.Models;

namespace SportsStoreWebAPI.Controllers
{
    //[EnableCors(origins: "http://localhost:45561", headers: "*", methods: "*")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        IProductRepository _repository;
        public ProductController()
        {
            _repository = new EFProductRepository();
        }
        [Route("")]
        public IEnumerable<Product> GetProducts()
        {
            return _repository.GetProducts();
        }
        [Route("{productID}", Name = "GetProductByID")]
        public Product GetProduct(int productID)
        {
            return _repository.GetProduct(productID);
        }

        [Route("")]
        public HttpResponseMessage PostProduct(Product product)
        {
            product = _repository.AddProduct(product);
            var response = Request.CreateResponse<Product>(HttpStatusCode.Created, product);

            string uri = Url.Link("GetProductByID", new { productID = product.ProductID });
            response.Headers.Location = new Uri(uri);
            return response;

        }

        [Route("{productID}")]
        public void PutProduct(int productID, Product product)
        {
            product.ProductID = productID;
            if (!_repository.UpdateProduct(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        [Route("{productID}")]
        public void DeleteProduct(int productID)
        {
            Product prod = _repository.GetProduct(productID);
            if (prod == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _repository.RemoveProduct(productID);
        }


    }

}
