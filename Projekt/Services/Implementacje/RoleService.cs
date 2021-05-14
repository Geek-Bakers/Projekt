using Projekt.Models;
using Projekt.ModelsDTO;
using Projekt.Services.Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Services.Implementacje
{
    public class RoleService : IRoleService
    {
        private readonly SDBContext context;

        public RoleService(SDBContext context)
        {
            this.context = context;
        }

        public ResponseDTO Add(Role role)
        {
            try
            {
                context.Roles.Add(role);
                context.SaveChanges();

                return new ResponseDTO() { Code = "200", Status = "Success", Message = "Added role" };
            }
            catch (Exception exception)
            {
                return new ResponseDTO() { Code = "400", Status = "Failed", Message = $"Adding role failed. Error messages: {exception.Message}" };
            }
        }

        public RolesDTO GetAllRoles()
        {
            var roles = new RolesDTO() { Roles = new List<Role>() };
            roles.Roles = context.Roles.ToList();
            return roles;
        }
    }
}
