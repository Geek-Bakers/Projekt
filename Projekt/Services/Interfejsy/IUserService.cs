using Projekt.Models;
using Projekt.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Services.Interfejsy
{
    public interface IUserService
    {
        ResponseDTO Register(User user);
        ResponseDTO Login(string email, string password);
        UsersDTO GetAllUser();
    }
}
