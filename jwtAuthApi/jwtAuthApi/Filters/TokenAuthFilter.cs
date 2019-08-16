using jwtAuthApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace jwtAuthApi.Application.Filters
{
    public class TokenAuthFilterAttribute : Attribute, IActionFilter
    {
        private readonly IUserServices _userServices;

        public TokenAuthFilterAttribute(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Validate(context);
        }

        private void Validate(ActionExecutingContext context)
        {
            if ((!context.HttpContext.Request.Headers.ContainsKey("username"))
                || (!context.HttpContext.Request.Headers.ContainsKey("token")))
            {
                context.Result = new BadRequestObjectResult("Keys username/token not found on header");
                return;
            }

            ValidateToken(context);
        }

        private void ValidateToken(ActionExecutingContext context)
        {
            var userName = context.HttpContext.Request.Headers["username"];
            var token = context.HttpContext.Request.Headers["token"];

            var result = _userServices.Validate(userName, token, out var message);

            if (!result) context.Result = new BadRequestObjectResult(message);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}