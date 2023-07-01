using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffe_Shop_MVC.Models
{
    public class Cheque
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MinLength(4)]
        public string Cheque_Number { get; set; }
        [Required]
        public int Cheque_Value { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
        [Required]
        public DateTime Cheque_Date { get; set;} = DateTime.Now;
        [ForeignKey("Table")]
        public int Table_Id { get; set; }
        public Table Table { get; set; }
        public Order Order { get; set; }
    }
}
