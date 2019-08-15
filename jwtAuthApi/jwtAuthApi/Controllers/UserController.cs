using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jwtAuthApi.Domain.Entities;
using jwtAuthApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using jwtAuthApi.Infraestructure;

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
        public IActionResult Auth([FromBody] User user)
        {
            try
            {
                return Ok();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.ToLogString(Environment.StackTrace));
                return new StatusCodeResult(500);
            }
        }
    }
}