using Microsoft.AspNetCore.Builder;
using CP.MVC.Middleware;

namespace CP.MVC
{
    public static class Exstentions
    {
        public static IApplicationBuilder UseUserLockChecker(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserLockCheckerMiddleware>();
        }
    }
}
