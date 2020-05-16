using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryControl.Core.Entities;
using InventoryControl.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]  
    public class InventoryController : Controller  
    {  
        private IProductService _iproductService;   
        public InventoryController(IProductService iproductService)  
        {  
            _iproductService = iproductService;  
        }  
  
        // GET: api/values  
        [HttpGet]  
        [Route("/products")]
        public IEnumerable<Product> Get()  
        {  
            return _iproductService.GetAllProducts();  
        }  
  
        // GET api/values/5  
        [HttpGet]  
        [Route("/products/{id}")]
        public Product Get(int id)  
        {  
            return _iproductService.GetProduct(id);  
        }  
  
        // POST api/values  
        [HttpPost]  
        [Route("/products")]
        public void Post([FromBody]Product product)  
        {  
            _iproductService.AddProduct(product);  
        }  
  
        // POST api/values  
        [HttpPut]  
        [Route("/products/{id}")]
        public void Put([FromBody]Product product)  
        {  
            _iproductService.UpdateProduct(product.Id,product);  
        }  
  
        // DELETE api/values/5  
        [HttpDelete]  
        [Route("/products/{id}")]
        public long Delete(int id)  
        {  
             _iproductService.DeleteProduct(id); 
             return id; // ToDO-> returned the deleted object's ID 
        }  
    } 
}
