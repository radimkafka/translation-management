using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;
using TranslationManagement.Business.Exceptions;

namespace ZadusApi.Web
{
    internal class NotCertifiedTranslatorExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context?.Exception == null || context.ExceptionHandled)
            {
                return;
            }

            if (context.Exception is NotCertifiedTranslatorException notCertifiedTranslator)
            {
                var factory = context.HttpContext.RequestServices.GetService<ProblemDetailsFactory>();
                var problemDetail = factory.CreateProblemDetails(context.HttpContext, (int)HttpStatusCode.BadRequest, notCertifiedTranslator.Message);
                context.ExceptionHandled = true;
                context.Result = new ObjectResult(problemDetail);
            }
        }
    }
}
