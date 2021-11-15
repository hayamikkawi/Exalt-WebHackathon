using System;
using System.Collections.Generic;
using loginAPI.Models;

namespace loginAPI.Data
{
    public interface IUsers
    {
        bool SaveChanges();
        IEnumerable<User> GetUsers();
        User GetUserbyUsername(String Username);
        String ValidateUser(User user);
        bool DeleteUser(string username);
        String EditUser(string username, User newUser);
        String AddUser(User u); 

    }
}
