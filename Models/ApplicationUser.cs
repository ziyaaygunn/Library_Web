﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Library_Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int StudentNo { get; set; }  
        public string? Adress {  get; set; }    
        public string? Faculty { get; set; }
        public string? Department { get; set; }
    }
}
