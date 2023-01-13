using DB.Models;
using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Converters
{
    public static class UserConverter
    {
        public static User? ToDomain(this UserModel model)
        {
            return new User
            {
                Id = model.Id,
                Login = model.Login,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Name = model.Name,
                Role = model.Role
            };
        }

        public static UserModel? ToModel(this User model)
        {
            return new UserModel
            {
                Id = model.Id,
                Login = model.Login,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Name = model.Name,
                Role = model.Role
            };
        }
    }
}
