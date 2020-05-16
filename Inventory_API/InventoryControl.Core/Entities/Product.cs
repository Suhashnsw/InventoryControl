using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryControl.Core.Entities
{
    public class Product
    {
        [Key]  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AvailableQuantity { get; set; }
        public double UnitPrice { get; set; }
        public int ReorderLimit { get; set; }
      //  public int CategoryId { get; set; }
        //public ProductCategory Category { get; set; }
    }
}