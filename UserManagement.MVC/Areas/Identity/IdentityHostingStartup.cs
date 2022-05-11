using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(UserManagement.MVC.Areas.Identity.IdentityHostingStartup))]
namespace UserManagement.MVC.Areas.Identity
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