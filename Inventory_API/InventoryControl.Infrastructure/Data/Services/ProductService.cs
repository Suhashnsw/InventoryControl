using System.Collections.Generic;
using InventoryControl.Core.Entities;

namespace InventoryControl.Infrastructure.Data
{
    //TODO Logging
    public class ProductService : IProductService
    {
        IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }   
        public void AddProduct(Product product)
        {
            ((UnitOfWork)_unitOfWork).ProductRepository.Insert(product);
            _unitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            ((UnitOfWork)_unitOfWork).ProductRepository.Delete(id);
            _unitOfWork.Save();
        }

        public IEnumerable<Product> GetAllProducts()
        {
           return ((UnitOfWork)_unitOfWork).ProductRepository.Get();
           
        }

        public Product GetProduct(int id)
        {
           return ((UnitOfWork)_unitOfWork).ProductRepository.GetById(id);
        }

        public void UpdateProduct(long id, Product product)
        {
            ((UnitOfWork)_unitOfWork).ProductRepository.Update(product);
            _unitOfWork.Save();
        }
    }
}