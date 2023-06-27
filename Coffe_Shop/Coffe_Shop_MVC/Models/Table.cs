namespace Coffe_Shop_MVC.Models
{
    public class Table
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Cheque> Cheques { get; set; } = new List<Cheque>();
    }
}
