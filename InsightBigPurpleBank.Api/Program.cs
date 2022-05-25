using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InsightBigPurpleBank.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                string outputTemplate = "{Timestamp:yyyy-MM-ddHH: mm: ss.fff} [{Level}] {Message}{ NewLine}{ Exception}";
                Log.Logger = new
                    LoggerConfiguration().WriteTo.File(
                        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Logs\\", "Log-.log"),
                        rollingInterval: RollingInterval.Day, 
                        fileSizeLimitBytes: 100000)
                    .CreateLogger();
                CreateHostBuilder(args).Build().Run();
            }
            catch
            {
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog();
    }
}
