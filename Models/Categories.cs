using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library_Web.Models
{
    public class Categories
    {

        [Key] 
        public int Id { get; set; }
        
        [Required(ErrorMessage = "The Book Category Name cannot be  empty")] 
        [MaxLength(25)]
        [DisplayName("Book Type Name")] 
        public string Name { get; set; }    

    }
}
