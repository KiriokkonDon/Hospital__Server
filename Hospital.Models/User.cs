using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public Role Role { get; set; }

        public User() : this(0, "", "", "", "", new Role()) { }

        public User(int id, string login, string password, string phoneNumber, string name, Role role)
        {
            Id = id;
            Login = login;
            Password = password;
            PhoneNumber = phoneNumber;
            Name = name;
            Role = role;
        }


        public Result IsValid()
        {
            if (string.IsNullOrEmpty(Login))
            {
                return Result.Fail("Invalid login");
            }
            if (string.IsNullOrEmpty(Password))
            {
                return Result.Fail("Invalid password");
            }
            if (string.IsNullOrEmpty(PhoneNumber))
            {
                return Result.Fail("Invalid phone number");
            }
            if (string.IsNullOrEmpty(Name))
            {
                return Result.Fail("Invalid full name");
            }

            return Result.Ok();
        }
    }
}