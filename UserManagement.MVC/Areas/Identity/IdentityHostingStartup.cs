using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CP.MVC.Areas.Identity.IdentityHostingStartup))]
namespace CP.MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}