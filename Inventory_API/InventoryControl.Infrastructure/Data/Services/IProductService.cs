using System.Collections.Generic;
using InventoryControl.Core.Entities;

namespace InventoryControl.Infrastructure.Data
{
    public interface IProductService
    {
         Product GetProduct(int id);
         IEnumerable<Product> GetAllProducts();
         void AddProduct(Product product);
         void DeleteProduct(int id) ;
         void UpdateProduct(long id, Product product) ;
    }
}