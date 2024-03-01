using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Web.Models
{
    public class Hire
    {
      
            public int Id { get; set; }

            [Required]
            public int StudenId { get; set; }


            [ValidateNever]
            public int BookId { get; set; }

            [ForeignKey("BookId")] 

            [ValidateNever]
            public Book Book { get; set; }
        }
    
}
