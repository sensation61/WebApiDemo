using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace web_api_demo.Filte.Handler
{
    public class DebugExceptionFilter : ExceptionHandler
    {
        private class ErrorInformation : Exception
        {
            public string Message { get; set; }
            public DateTime ErrorDate { get; set; }
        }
        public override void Handle(ExceptionHandlerContext context)
        {
            base.Handle(context);

            var reqMethod = context.Request.Method.Method;
            var absoluteUri = context.Request.RequestUri.AbsoluteUri;
            var absolutePath = context.Request.RequestUri.AbsolutePath;
            var actionName = context.Request.GetActionDescriptor()?.ActionName;
            var controllerName = context.Request.GetActionDescriptor()?.ControllerDescriptor.ControllerType.Name;
            var controllerNamespace = context.Request.GetActionDescriptor()?.ControllerDescriptor.ControllerType.Namespace;


            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, new
            {
                Exception = context.Exception,
                Message = context.Exception.Message,
                Method = reqMethod,
                AbsoluteUri = absoluteUri,
                AbsolutePath = absolutePath,
                ActionName = actionName,
                ControllerName = controllerName,
                ControllerNamespace = controllerNamespace
            });

            response.Headers.Add("X-Error", context.Exception.Message);

            context.Result = new ResponseMessageResult(response);
        }
    }
}