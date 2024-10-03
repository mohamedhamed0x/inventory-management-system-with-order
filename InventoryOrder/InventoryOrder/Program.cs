using GlobalizationAndLocalizationInDotNetCore5;
using InventoryOrder.Models;
using InventoryOrder.Repository;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace InventoryOrder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region old Main
            //var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.
            //builder.Services.AddControllersWithViews()
            //    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            //    .AddDataAnnotationsLocalization();

            //builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            ////builder.Services.Configure<RequestLocalizationOptions>(options =>
            ////{
            ////    var supportedCultures = new[]
            ////    {
            ////      new CultureInfo("en"),
            ////      new CultureInfo("ar")
            ////    };
            ////    options.DefaultRequestCulture = new RequestCulture(culture: "en" , uiCulture:"en");
            ////    options.SupportedCultures = supportedCultures;
            ////    options.SupportedUICultures = supportedCultures;


            ////});

            //builder.Services.AddDbContext<AppDbContext>(option =>
            //   option.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
            //);

            //builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericsRepository<>));
            //builder.Services.AddScoped(typeof(InventoryService));
            //builder.Services.AddScoped(typeof(PaymentService));

            //var app = builder.Build();

            //// Configure the supported cultures
            //var supportedCultures = new[]
            //{
            //    new CultureInfo("en"),
            //    new CultureInfo("ar")
            //};

            //var localizationoptions = new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en"),
            //    SupportedCultures = supportedCultures,
            //    SupportedUICultures = supportedCultures,

            //};

            //// Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();

            //app.UseRouting();

            //// Enable localization
            //app.UseRequestLocalization(localizationoptions);

            //app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.Run();
            #endregion

            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
