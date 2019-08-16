using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtAuthApi.Application.Filters;
using jwtAuthApi.Domain.Entities;
using jwtAuthApi.Domain.ViewModel;
using jwtAuthApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using jwtAuthApi.Infraestructure;
using jwtAuthApi.Services.Layers;

namespace jwtAuthApi.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserServices _userServices;

        public UserController(ILogger<UserController> logger, IUserServices userServices)
        {
            _logger = logger;
            _userServices = userServices;
        }


        [HttpPost("auth")]
        public IActionResult Auth([FromBody] UserModel userModel)
        {
            try
            {
                _logger.LogInformation("Request data", userModel);

                if (userModel == null) return BadRequest("Requested object is null");
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var token = _userServices.Auth(userModel);

                if (token == null) return new StatusCodeResult(403);

                return Ok(token);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.ToLogString(Environment.StackTrace));
                return new StatusCodeResult(500);
            }
        }

        [HttpGet("validate")]
        public IActionResult ValidateToken([FromHeader] string userName, [FromHeader] string token)
        {
            try
            {
                _logger.LogInformation("Request data", $"{userName}/{token}");

                var result = _userServices.Validate(userName, token, out var message);

                if (!result) return BadRequest(message);

                return Ok(message);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.ToLogString(Environment.StackTrace));
                return new StatusCodeResult(500);
            }
        }
        [TokenAuthFilter]
        [HttpGet("auth/check")]
        public IActionResult ValidateByFilter([FromHeader] string userName, [FromHeader] string token)
        {
            return Ok($"username: {userName} / token: {token}");
        }

        [HttpPatch("refreshToken")]
        public IActionResult RefreshToken([FromHeader] string userName, [FromHeader] string token)
        {
            try
            {
                _logger.LogInformation("Request data", $"{userName}/{token}");

                var result = _userServices.RefreshToken(userName, token, out var message);

                if (result == null) return BadRequest(message);

                return Ok(result);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.ToLogString(Environment.StackTrace));
                return new StatusCodeResult(500);
            }
        }
    }
}