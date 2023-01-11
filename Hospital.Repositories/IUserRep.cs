using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories
{
    public interface IUserRep : IRep<User>
    {
        bool IsUserExists(string login);
        bool IsUserExist(User user);
        User? GetUserByLogin(string login);
    }
}