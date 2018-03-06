using System.Web.Http.Controllers;
using System.Web.Http;
using System.Security.Claims;

namespace web_api_demo.Filter.Authorize
{
    public class AuthorizeFilter : AuthorizeAttribute
    {

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return base.IsAuthorized(actionContext);
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                //bool IsAuthorized = this.IsAuthorized(actionContext);
                var principal = actionContext.RequestContext.Principal as ClaimsPrincipal;

                if (!principal.Identity.IsAuthenticated)
                {
                    base.HandleUnauthorizedRequest(actionContext);
                }
                else
                {
                    var userName = principal.FindFirst(ClaimTypes.Name).Value;
                }
            }
            catch (System.Exception)
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
        }
    }
}