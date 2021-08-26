using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Application.ViewModels;

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


        [HttpPost]
        public IActionResult Post(UserViewModel userViewMOdel)
        {
            return Ok(this.userService.Post(userViewMOdel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById (string id)
        {
            return Ok(this.userService.GetById(id));
        }

        [HttpPut]
        public IActionResult Put(UserViewModel userViewMOdel)
        {
            return Ok(this.userService.Put(userViewMOdel));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            return Ok(this.userService.Delete(id));
        }
    }
}
