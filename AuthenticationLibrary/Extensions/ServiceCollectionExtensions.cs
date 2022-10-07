
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AuthenticationLibrary.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAuthService(
           this IServiceCollection services, string googleClientId,string googleSecretId
          )
        {
            services
               .AddAuthentication(o =>
               {

                   o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                   o.DefaultForbidScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
                   o.DefaultChallengeScheme = GoogleOpenIdConnectDefaults.AuthenticationScheme;
               })
               .AddCookie()
               .AddGoogleOpenIdConnect(options =>
               {
                   options.ClientId = googleClientId;
                   options.ClientSecret = googleSecretId;
               });
            

            return services;
        }
        public static IServiceCollection InjectOtherSerives(
           this IServiceCollection services
          )
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUserProfileService,UserProfileService>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
