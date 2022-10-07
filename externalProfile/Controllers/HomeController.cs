using AuthenticationLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace externalProfile.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {      
        private readonly IUserProfileService _userProfileService;
        public HomeController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }
       
        [HttpGet]
        [Authorize]
        [Route("get-user")]
        public IActionResult GetUser()
        {
            var userId =UserData.GetUserData();
            return Ok(userId);
        }
        [HttpGet]
        [Authorize]
        [Route("profiles")]
        public async Task<IActionResult> GetProfilesAsync()
        
        {
            
            var userId =await _userProfileService.GetUserDetails();
            return Ok(userId);
        } 
    }
}