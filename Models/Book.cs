using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library_Web.Models
{
    public class Book
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }

        public string Description { get; set; }

        [Required]

        public string Author { get; set; }

        [Required]
        [Range(10, 5000)] 
        public double Price { get; set; }

        [ValidateNever]
        public int CategoriesId { get; set; }

        [ForeignKey("CategoriesId")] 

        [ValidateNever]
        public Categories Categories { get; set; }

        [ValidateNever] 
        public string ImageUrl { get; set; }


    }
}
