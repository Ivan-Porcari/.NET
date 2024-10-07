﻿using Application.Interfaces;
using Application.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDiscoManiacos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ICustomAuthenticationService _customAuthenticationService;

        public AuthenticationController(IConfiguration config, ICustomAuthenticationService autenticacionService)
        {
            _config = config;
            _customAuthenticationService = autenticacionService;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Autenticar(AuthenticationRequest authenticationRequest)
        {
            string token = _customAuthenticationService.Autenticar(authenticationRequest);

            return Ok(token);
        }
    }
}
