
using Microsoft.AspNetCore.Http;

namespace externalProfile.Helpers
{
    public class UserClaims
    {       
        public static string GetClaimByForContext(HttpContext httpContext, string claimname)
        {
            string claimValue = string.Empty;
            try
            {
                claimValue = httpContext.User?.Claims.Where(a => a.Type.ToLower().EndsWith(claimname.Trim().ToLower()))?.FirstOrDefault()?.Value;
            }
            catch (Exception ex)
            {
               
            }
            return claimValue??"";
        }
        
    }
}
