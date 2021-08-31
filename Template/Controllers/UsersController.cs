using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.Application.ViewModels;
using Template.Auth.Services;

namespace Template.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
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


        [HttpPost, AllowAnonymous]
        public IActionResult Post(UserViewModel userViewMOdel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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

        //[HttpDelete("{id}")]
        //public IActionResult Delete(string id)
        //{
        //    return Ok(this.userService.Delete(id));
        //}
        
        [HttpDelete]
        public IActionResult Delete()
        {
            string _userId = TokenService.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier);
            
            return Ok(this.userService.Delete(_userId));
        }

        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult Authenticate(UserAuthenticateRequestViewModel userViewModel)
        {
            return Ok(this.userService.Authenticate(userViewModel));
        }
    }
}
