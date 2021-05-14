using Projekt.Models;
using Projekt.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Services.Interfejsy
{
    public interface IRoleService
    {
        RolesDTO GetAllRoles();
        ResponseDTO Add(Role role);
    }
}
