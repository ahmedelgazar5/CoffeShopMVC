using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Coffe_Shop_MVC.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2)]  
        public string Name { get; set; }
        [Required]
        [MinLength(12)]
        public string Description { get; set; }
        [Required]
        public bool IsDeleted { get; set; } = false;
       

        public List<Item> Items { get; set; } = new List<Item>();
    }
}
