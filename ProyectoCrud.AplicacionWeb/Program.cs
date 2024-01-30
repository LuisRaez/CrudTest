using Microsoft.EntityFrameworkCore;
using ProyectoCrud.BLL.Services;
using ProyectoCrud.BLL.Services.Interfaces;
using ProyectoCrud.DAL.DataContext;
using ProyectoCrud.DAL.Repositories;
using ProyectoCrud.DAL.Repositories.Interfaces;
using ProyectoCrud.Models;

namespace ProyectoCrud.AplicacionWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<DbpruebasContext>(o =>
            {
                o.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
            });
            builder.Services.AddScoped<IContactoRepository<Contacto>, ContactoRepository>();
            builder.Services.AddScoped<IContactoService, ContactoService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
