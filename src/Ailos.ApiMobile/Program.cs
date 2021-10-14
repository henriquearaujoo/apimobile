using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Ailos.ApiMobile
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((host, configure) =>
                {
                    configure.SetBasePath(host.HostingEnvironment.ContentRootPath);
                    configure.AddJsonFile("appsettings.json", true, true);
                    configure.AddJsonFile($"appsettings.{host.HostingEnvironment.EnvironmentName}.json", false, true);
                    configure.AddEnvironmentVariables();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
