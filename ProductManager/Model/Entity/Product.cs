
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManager.Model.Entity
{
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("price")]
        public decimal Price { get; set; }
        [Column("price_with_discount")]
        public decimal PriceWithDiscount { get; set; }
        [Column("image")]
        public string Image { get; set; }
    }
}
