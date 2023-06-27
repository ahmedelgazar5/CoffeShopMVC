using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffe_Shop_MVC.Models
{
    public class Cheque
    {
        public int Id { get; set; }
        public string Cheque_Number { get; set; }
        public int Cheque_Value { get; set; }
        public DateTime Cheque_Date { get; set;}
        [ForeignKey("Table")]
        public int Table_Id { get; set; }
        public Table Table { get; set; }
        public Order Order { get; set; }
    }
}
