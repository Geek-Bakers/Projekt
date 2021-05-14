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
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }

        [Route("api/role/getAllRoles")]
        [HttpGet]
        public RolesDTO GetAllUsers()
        {
            return roleService.GetAllRoles();
        }

        [Route("api/role/addRole")]
        [HttpPost]
        public ResponseDTO AddRole(Role role)
        {
            return roleService.Add(role);
        }
    }
}
