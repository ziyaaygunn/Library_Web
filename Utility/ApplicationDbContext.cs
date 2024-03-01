
using Library_Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Library_Web.Utility
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Categories> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Hire> Hires { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
