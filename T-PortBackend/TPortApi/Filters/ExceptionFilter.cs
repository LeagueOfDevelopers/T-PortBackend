using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TPort.Domain.Exceptions;

namespace TPortApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                    case InvalidTokenException _:
                        context.Result = new BadRequestResult();
                        context.ExceptionHandled = true;
                        break;
                    case UnregisteredPhoneNumberException _:
                        context.Result = new NotFoundResult();
                        context.ExceptionHandled = true;
                        break;
            }
        }
    }
}