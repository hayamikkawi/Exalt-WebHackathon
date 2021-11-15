using System;
using System.Collections.Generic;
using System.Linq;
using loginAPI.Models;

namespace loginAPI.Data
{
    public class MockUsers:IUsers
    {
        private readonly UserDBContext context;

        public MockUsers(UserDBContext _context)
        {
            context = _context;
        }

        public String AddUser(User u)
        {
            context.Users.Add(u);
            //context.SaveChangesAsync(); 
            return "done"; 
        }

        public bool DeleteUser(String username)
        {
            var result = context.Users.FirstOrDefault(e => e.Username== username);
            if (result != null)
            {
                context.Users.Remove(result);
                return true;
            }

            return false;
        }

        public String EditUser(String username, User newUser)
        {
            var u = context.Users.First(u => u.Username == username);
            if (u == null) return "not found";
            else
            {
               // u.Username = newUser.Username;
                u.Password = newUser.Password;
                u.role = newUser.role;
                context.SaveChangesAsync();
                return "done"; 
            }
        }

        public User GetUserbyUsername(String username)
        {

            return context.Users.FirstOrDefault(u => u.Username.Equals(username)); 
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public bool SaveChanges()
        {
           return (context.SaveChanges()>=0); 
        }

        public String ValidateUser(User user)
        {
            User x= context.Users.FirstOrDefault(u => (u.Username == user.Username && u.Password == user.Password));
            if (x == null) return null;
            return x.role;
        }
    }
}
