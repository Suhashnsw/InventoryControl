using System;
using System.Net.Http;
using System.Text;
using InventoryControl.Web.Service;
using Newtonsoft.Json;

namespace InventoryControl.Web.Controllers
{
    internal class ServiceRepository : IServiceRepository
    {
      public HttpClient Client { get; set; }  
       public ServiceRepository(string baseURL)  
       {  
           Client = new HttpClient();  
           Client.BaseAddress = new Uri(baseURL);  
       }  
       public HttpResponseMessage GetResponse(string url)  
       {  
           return Client.GetAsync(url).Result;  
       }  
       public HttpResponseMessage PutResponse(string url,object model)  
       {  
          return Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8,"application/json")).Result;  
       }  
       public HttpResponseMessage PostResponse(string url, object model)  
       {  
          return Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8,"application/json")).Result;  
       }  
       public HttpResponseMessage DeleteResponse(string url)  
       {  
           return Client.DeleteAsync(url).Result;  
       }  
    }
}