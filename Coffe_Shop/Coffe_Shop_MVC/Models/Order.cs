using System.ComponentModel.DataAnnotations.Schema;

namespace Coffe_Shop_MVC.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Order_Number { get; set; }
        public DateTime Ordered_At { get; set; }
        [ForeignKey("Table")]
        public int Table_Id { get; set; }
        public Table Table { get; set; }
        [ForeignKey("Cheque")]
        public int Cheque_Id { get; set; }
        public Cheque Cheque { get; set; }
        public List<Order_Item> Order_Items { get; set; } = new List<Order_Item>();
        
    }
}
