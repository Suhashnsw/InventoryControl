namespace InventoryControl.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableQuantity { get; set; }
        public float UnitPrice { get; set; }
        public int ReorderLimit { get; set; }
        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }
    }
}