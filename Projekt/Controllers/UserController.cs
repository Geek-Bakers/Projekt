using Microsoft.AspNetCore.Mvc;
using Projekt.Models;
using Projekt.ModelsDTO;
using Projekt.Services.Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Controllers
{
    [Produces("application/json")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("api/user/getAllUsers")]
        [HttpGet]
        public UsersDTO GetAllUsers()
        {
            return userService.GetAllUser();
        }

        [Route("api/user/login/{email}/{password}")]
        [HttpGet]
        public ResponseDTO Login(string email, string password)
        {
            var result = userService.Login(email, password);
            return result;
        }

        [Route("api/user/register")]
        [HttpPost]
        public ResponseDTO Register([FromBody] User user)
        {
            var result = userService.Register(user);
            return result;
        }
    }
}
