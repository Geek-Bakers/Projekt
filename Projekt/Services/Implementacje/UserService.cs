using Projekt.Models;
using Projekt.ModelsDTO;
using Projekt.Services.Interfejsy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Services.Implementacje
{
    public class UserService : IUserService
    {
        private readonly SDBContext context;
        public UserService(SDBContext context)
        {
            this.context = context;
        }

        UsersDTO IUserService.GetAllUser()
        {
            var users = new UsersDTO() { Users = new List<User>() };
            users.Users = context.Users.ToList();
            return users;
        }

        ResponseDTO IUserService.Login(string email, string password)
        {
            if (email == null || password == null)
                return new ResponseDTO() { Code = "400", Status = "Failed", Message = $"Email or password is null" };

            var userExist = context.Users.Where(u => u.Name == email && u.Password == password).Any();

            if (userExist)
                return new ResponseDTO() { Code = "200", Status = "Success", Message = "Loged user" };
            else
                return new ResponseDTO() { Code = "400", Status = "Failed", Message = $"Loged user failed." };
        }

        ResponseDTO IUserService.Register(User user)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();

                return new ResponseDTO() { Code = "200", Status = "Success", Message = "Registered user" };
            }
            catch (Exception exception)
            {
                return new ResponseDTO() { Code = "400", Status = "Failed", Message = $"Registered user failed. Error messages: {exception.Message}" };
            }
        }
    }
}
