using AuthenticationLibrary.Extensions;
using externalProfile.Helpers;

namespace externalProfile
{
    public class UserData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string GivenName { get; set; }
        public string EmailId { get; set; }

        public static UserData GetUserData()
        {
            var httpContext = HttpContextHandler.Current;
            if (httpContext.User == null)
            {
                return null;
            }
           
            return new UserData
            {
                Id = UserClaims.GetClaimByForContext(httpContext, "nameidentifier"),
                Name = UserClaims.GetClaimByForContext(httpContext, "name"),
                SurName = UserClaims.GetClaimByForContext(httpContext, "surname"),
                EmailId = UserClaims.GetClaimByForContext(httpContext, "emailaddress"),
                GivenName= UserClaims.GetClaimByForContext(httpContext, "givenname")
                
        };

        }
    }

}
