using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Library_Web.Utility;
using Library_Web.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
namespace Library_Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


           

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            builder.Services.AddRazorPages();

       
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();

            builder.Services.AddScoped<IBookRepository, BookRepository>();

            builder.Services.AddScoped<IHireRepository, HireRepository>();
            
            builder.Services.AddScoped<IEmailSender, EmailSender>();




            var app = builder.Build();

           
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
               
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
