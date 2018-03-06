using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace web_api_demo
{
    public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //base.OnException(context);

            var reqMethod = context.ActionContext.Request.Method.Method;
            var absoluteUri = context.ActionContext.Request.RequestUri.AbsoluteUri;
            var absolutePath = context.ActionContext.Request.RequestUri.AbsolutePath;
            var methodName = context.ActionContext.ActionDescriptor.ActionName;
            var controllerName = context.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            if (context.Exception is NotImplementedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
        }
    }
}