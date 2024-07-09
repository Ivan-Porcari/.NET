using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDiscoManiacos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService; //falta el repository por eso tira error
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{name}")] // siempre lo que viene es un string
        public IActionResult Get([FromRoute]string name) 
        {
            return Ok(_userService.Get(name));
        }

    }
}
