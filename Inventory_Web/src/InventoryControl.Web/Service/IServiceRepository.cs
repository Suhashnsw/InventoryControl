using System.Net.Http;

namespace InventoryControl.Web.Service
{
    public interface IServiceRepository
    {
         public HttpResponseMessage GetResponse(string url)  ;
         public HttpResponseMessage PutResponse(string url,object model) ;
         public HttpResponseMessage PostResponse(string url, object model) ;
         public HttpResponseMessage DeleteResponse(string url) ;

    }
}