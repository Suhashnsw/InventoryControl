using System;
using System.Collections.Generic;
using System.Net.Http;
using InventoryControl.Web.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InventoryControl.Web.Controllers
{
    //ToDO - Logger injection
    
    public class ProductsController : Controller
    {
        IServiceRepository _repository;

        public ProductsController(IServiceRepository repository)
        {
            _repository = repository;
        }

        public ActionResult GetAllProducts()  
            {  
                try  
                {  
                    HttpResponseMessage response = _repository.GetResponse("/products");  
                    response.EnsureSuccessStatusCode();  
                    List<Models.Product> products = JsonConvert.DeserializeObject<List<Models.Product>>(response.Content.ReadAsStringAsync().Result);  
                    ViewBag.Title = "All Inventory Products"; 
                    return View(products);  
                }  
                catch (Exception)  
                {  
                    //ToDo Log
                    throw;
                }  
            }  
            //[HttpGet]  
            public ActionResult EditProduct(int id)  
            {  
                try
                {
                    HttpResponseMessage response = _repository.GetResponse(String.Format("/products/{0}", id));  
                    response.EnsureSuccessStatusCode();  
                    Models.Product product = JsonConvert.DeserializeObject<Models.Product>(response.Content.ReadAsStringAsync().Result);  
                    ViewBag.Title = "All Products";  
                    return View(product);  
                }
                 catch (Exception)  
                {  
                    //ToDo Log
                    throw;     
                 }           
            }   

            public ActionResult Update(Models.Product product)  
            {  
                try
                {
                    HttpResponseMessage response = _repository.PutResponse(String.Format("/products/{0}", product.Id), product);  
                    response.EnsureSuccessStatusCode();  
                    return RedirectToAction("GetAllProducts");  
                }
                catch (Exception)  
                {  
                    //ToDo Log
                    throw;                 
                    
                 } 
            }  


            public ActionResult Details(int id)  
            {  
                try
                {
                    HttpResponseMessage response = _repository.GetResponse(String.Format("/products/{0}", id));  
                    response.EnsureSuccessStatusCode();  
                    Models.Product product =  JsonConvert.DeserializeObject<Models.Product>(response.Content.ReadAsStringAsync().Result);  
                    ViewBag.Title = "All Products";  
                    return View(product);
                }  
                catch (Exception)  
                {  
                    //ToDo Log
                    throw; 
                }                 
             }  

            [HttpGet] 
            public ActionResult Create()  
            {  
                return View();  
            }  
            [HttpPost]  
            public ActionResult Create(Models.Product product)  
            {  
                try
                {
                    HttpResponseMessage response = _repository.PostResponse("/products", product);  
                    response.EnsureSuccessStatusCode();  
                    return RedirectToAction("GetAllProducts");  

                }
                catch (Exception)  
                {  
                    //ToDo Log
                    throw;                
              } 
            }  
            public ActionResult Delete(int id)  
            {  
                
                   HttpResponseMessage response = _repository.DeleteResponse(String.Format("/products/{0}", id));  
                   response.EnsureSuccessStatusCode();  
                   return RedirectToAction("GetAllProducts"); 
            }  
    }
}