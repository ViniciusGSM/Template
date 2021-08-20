using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Application.Interfaces;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService userService; // estanciei a variavel aqui

        public UsersController(IUserService userService) //construtor que ira criar o objeto que preciso
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            
            return Ok(this.userService.Get());
        }

    }
}
