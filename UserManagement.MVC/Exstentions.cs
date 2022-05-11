using Microsoft.AspNetCore.Builder;
using UserManagement.MVC.Middleware;

namespace UserManagement.MVC
{
    public static class Exstentions
    {
        public static IApplicationBuilder UseUserLockChecker(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserLockCheckerMiddleware>();
        }
    }
}
