using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtAuthApi.BusinessCore;
using jwtAuthApi.Repository;
using jwtAuthApi.Services.Interfaces;
using jwtAuthApi.Services.Layers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Swagger;

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

            if(!result) context.Result = new BadRequestObjectResult(message);
        }

        public void OnActionExecuted(ActionExecutedContext context){}
    }
}
