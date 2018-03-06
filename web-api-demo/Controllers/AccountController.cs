using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using web_api_demo.Models;
using web_api_demo.Providers.Manager;

namespace web_api_demo.Controllers
{
    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : BaseController
    {
        public AccountController() { }
        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager userSignInMager, ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            SignInManager = userSignInMager;
            AccessTokenFormat = accessTokenFormat;
        }

        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {             
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IHttpActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var signStatus = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            switch (signStatus)
            {
                case SignInStatus.Success:
                    return Ok(SignInStatus.Success);
                default:
                    return NotFound();
            }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}