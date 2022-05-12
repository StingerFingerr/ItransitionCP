using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using CP.MVC.Models;

namespace CP.MVC.Middleware
{
    public class UserLockCheckerMiddleware
    {
        private readonly RequestDelegate _next;

        public UserLockCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            if (!string.IsNullOrEmpty(httpContext.User.Identity.Name))
            {
                var user = await userManager.FindByNameAsync(httpContext.User.Identity.Name);
                if(user == null)
                {
                    await signInManager.SignOutAsync();
                    httpContext.Response.Redirect("/Identity/Account/Login");
                }
                else
                {
                    if (await userManager.GetLockoutEndDateAsync(user) > System.DateTime.Now)
                    {
                        await signInManager.SignOutAsync();
                        httpContext.Response.Redirect("/Identity/Account/Login");
                    }
                }
                
            }
            await _next(httpContext);
        }
    }
}
