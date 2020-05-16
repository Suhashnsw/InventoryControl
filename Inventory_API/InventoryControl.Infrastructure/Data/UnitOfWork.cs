using System;
using InventoryControl.Core.Entities;
using InventoryControl.Infrastructure.Data.Repository;

namespace InventoryControl.Infrastructure.Data
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
  
    public UnitOfWork(IRepository<Product> productRepository, IRepository<ProductCategory> productCategoryRepository)
    {
        this.productRepository = productRepository;
        this.productCategoryRepository = productCategoryRepository;
    }
    private IRepository<Product> productRepository;
    private IRepository<ProductCategory> productCategoryRepository;
        public IRepository<Product> ProductRepository
        {
            get
            {
                return productRepository;
            }
        }

        public IRepository<ProductCategory> ProductCategoryRepository
        {
            get
            {
                return productCategoryRepository;
            }
        }

       public void Save()
        {
            productRepository.Save();
            ProductCategoryRepository.Save();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    productRepository.Dispose();
                    ProductCategoryRepository.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}