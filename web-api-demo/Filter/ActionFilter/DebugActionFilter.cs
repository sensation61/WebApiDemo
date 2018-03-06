using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace web_api_demo.Filter.ActionFilter
{
    public class DebugActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var arg = actionContext.ActionArguments;
            
            Debug.WriteLine("ACTION 1 DEBUG pre-processing logging");

            //base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //base.OnActionExecuted(actionExecutedContext);  

            var arg = actionExecutedContext.ActionContext.ActionArguments;
            
            Debug.WriteLine("DEBUG  OnActionExecuted Response " + actionExecutedContext?.Response?.StatusCode.ToString());
        }
    }
}