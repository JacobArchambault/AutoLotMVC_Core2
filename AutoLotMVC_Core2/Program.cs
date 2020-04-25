using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoLotDAL_Core2.DataInitialization;
using AutoLotDAL_Core2.EF;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;

namespace AutoLotMVC_Core2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //var webHost = BuildWebHost(args);
            //using (var scope = webHost.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<AutoLotContext>();
            //    MyDataInitializer.RecreateDatabase(context);
            //    MyDataInitializer.InitializeData(context);
            //}
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //    .UseStartup<Startup>()
        //    .Build();

    }
}
