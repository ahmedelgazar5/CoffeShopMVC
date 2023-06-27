using System.ComponentModel.DataAnnotations.Schema;

namespace Coffe_Shop_MVC.Models
{
    public class Order_Item
    {
        [ForeignKey("Order")]
        public int Order_Id { get; set; }
        [ForeignKey("Item")]
        public int Item_Id { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
    }
}
