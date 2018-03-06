using System.Net.Http;
using System.Web.Http;

using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;

using web_api_demo.Providers.Manager;

namespace web_api_demo.Controllers
{
    public class BaseController : ApiController
    {
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _userSignInManager;

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; set; }
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _userSignInManager ?? Request.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            }
            set
            {
                _userSignInManager = value;
            }
        }
    }
}
