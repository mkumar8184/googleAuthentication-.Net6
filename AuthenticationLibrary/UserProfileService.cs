
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationLibrary
{
    public interface IUserProfileService
    {
        Task<Person> GetUserDetails();
    }
    public class UserProfileService: IUserProfileService
    {
       private readonly IGoogleAuthProvider _googleAuthProvider;
        public UserProfileService(
            IGoogleAuthProvider googleAuthProvider
            )
        {
           _googleAuthProvider = googleAuthProvider;
        }

        public async Task<Person> GetUserDetails()
        {
            try
            {
                GoogleCredential cred = await _googleAuthProvider.GetCredentialAsync();
                var service = new PeopleServiceService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = cred

                });
                var request = service.People.Get("people/me");
                request.PersonFields = "names";
                request.PersonFields = "photos*";
                request.PersonFields = "emailAddresses";
                var person = await request.ExecuteAsync();
                return person;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
