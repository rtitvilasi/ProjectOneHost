﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OneMits
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .CaptureStartupErrors(true)
            .UseSetting("DetailedErrors", "true")
            .UseWebRoot("h:\\root\\home\\rtitvilasi-001\\www\\hostingtest23\\wwwroot")
            .ConfigureLogging((hostingContext, builder) =>
            {
                builder.AddFile("Logs/myapp-{Date}.txt");
            })
                .UseStartup<Startup>();
    }
}