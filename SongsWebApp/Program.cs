using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SongsWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

       // need this or won't work on localhost:5001
         // public static IHostBuilder CreateHostBuilder(string[] args) =>
         //     Host.CreateDefaultBuilder(args)
         //         .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        
        //Tried this for kestrel heroku issue - not working
        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //         .ConfigureWebHostDefaults(webBuilder =>
        //         {
        //             webBuilder.UseStartup<Startup>();
        //             webBuilder.UseUrls("http://*:" + Environment.GetEnvironmentVariable("PORT")); 
        //         });
        
        //working with docker
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var port = Environment.GetEnvironmentVariable("PORT");
        
                    webBuilder.UseStartup<Startup>()
                        .UseUrls("http://*:" + port);
                });
        
        
    }
}