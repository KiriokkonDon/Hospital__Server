using Hospital.Models;
using Hospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Servise
{
    public class UserService
    {
        private readonly IUserRep _db;

        public UserService(IUserRep db)
        {
            _db = db;
        }


        public Result<bool> IsUserExists(string login)
        {
            if (!_db.IsUserExists(login))
            {
                return Result.Fail<bool>("User does not exist");
            }
            else { return Result.Ok(_db.IsUserExists(login)); }
        }
        public Result<User> GetUserByLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
                return Result.Fail<User>("Invalid login");

            var user = _db.GetUserByLogin(login);
            return user != null ? Result.Ok(user) : Result.Fail<User>("User not found by login");
        }
        public Result<User> Register(User user)
        {
            var isValid = user.IsValid();
            if (isValid.IsFailure)
            {
                return Result.Fail<User>("Invalid input data:" + isValid.Error);
            }
            else if (_db.IsUserExists(user.Login))
            {
                return Result.Fail<User>("User is already exist");
            }
            else
            {
                try
                {
                    _db.Create(user);
                    return Result.Ok(user);
                }
                catch
                {
                    return Result.Fail<User>("Error while creating.");
                }
            }

        }
        public void Save()
        {
            _db.Save();
        }

    }
}
