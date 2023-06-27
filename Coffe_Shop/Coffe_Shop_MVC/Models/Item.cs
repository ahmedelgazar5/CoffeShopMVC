using System.ComponentModel.DataAnnotations.Schema;

namespace Coffe_Shop_MVC.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime Created_At { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Order_Item> Order_Items { get; set; } = new List<Order_Item>();
    }
}
