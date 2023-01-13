using DB.Converters;
using Hospital.Models;
using Hospital.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class UserRepository : IUserRep
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public bool Create(User item)
        {
            _context.Users.Add(item.ToModel());
            return true;
        }

        public bool Delete(User item)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == item.Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                return true;
            }
            return false;
        }


        public IEnumerable<User> GetAll()
        {
            var _users = _context.Users.ToList();
            var users = _users.Select(x => x.ToDomain()).ToList();
            return users;
        }

        public User? GetUserByLogin(string login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login);
            return user?.ToDomain();
        }

        public bool IsUserExist(User user)
        {
            var users = _context.Users.FirstOrDefault(u => u.Login == user.Login);
            return users != null;
        }

        public bool IsUserExists(string login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Login == login);
            return user != null;
        }

        public void Save()
        {
            _context.SaveChanges();
            return;
        }
        public bool Update(User item)
        {
            _context.Users.Update(item.ToModel());
            return true;
        }
    }
}
