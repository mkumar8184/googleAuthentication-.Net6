using Microsoft.AspNetCore.Http;

namespace AuthenticationLibrary.Extensions
{
    public static class HttpContextHandler
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static HttpContext Current => _httpContextAccessor.HttpContext;
       
    }

}
