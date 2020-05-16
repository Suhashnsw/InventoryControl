namespace InventoryControl.Infrastructure.Data
{
    public interface IUnitOfWork
    {
         public void Save();
         public void Dispose();
    }
}