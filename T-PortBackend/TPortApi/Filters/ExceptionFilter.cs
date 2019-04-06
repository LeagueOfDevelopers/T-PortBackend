using System;
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
                case NonexistentCityException _:
                    context.Result = new ContentResult
                    {
                        Content = context.Exception.Message,
                        StatusCode = 404
                    };
                    context.ExceptionHandled = true;
                    break;
                case NotImplementedException _:
                    context.Result = new ContentResult
                    {
                        Content = context.Exception.Message,
                        StatusCode = 501
                    };
                    context.ExceptionHandled = true;
                    break;
                case ArgumentNullException _:
                    context.Result = new ContentResult
                    {
                        Content = context.Exception.Message,
                        StatusCode = 400
                    };
                    context.ExceptionHandled = true;
                    break;
                default:
                    context.Result = new ContentResult
                    {
                        Content = context.Exception.Message,
                        StatusCode = 500
                    };
                    context.ExceptionHandled = true;
                    break;

            }
        }
    }
}