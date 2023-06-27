using Coffe_Shop_MVC.Models;
using Coffe_Shop_MVC.Repository.CategoryRepo;
using Microsoft.EntityFrameworkCore;

namespace Coffe_Shop_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            // Register IRepository
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            // Register Context
            builder.Services.AddDbContext<CoffeContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("CS"))
            );

              
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}