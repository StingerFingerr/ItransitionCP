using Microsoft.AspNetCore.Builder;
using CP.Middleware;

namespace CP
{
    public static class Exstentions
    {
        public static IApplicationBuilder UseUserLockChecker(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserLockCheckerMiddleware>();
        }
    }
}
