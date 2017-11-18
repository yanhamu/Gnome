using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Gnome.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseSetting("detailedErrors", "true")
                .UseUrls("http://*:5000")
                .UseIISIntegration()
                .UseStartup<Startup>()
                .CaptureStartupErrors(true)
                .Build();

            host.Run();
        }
    }
}
