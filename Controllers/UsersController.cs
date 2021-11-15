using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using loginAPI.Data;
using loginAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace loginAPI.Controllers
{
    //api/users
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
    public class UsersController: ControllerBase
    {
        private readonly IUsers _repository;
        private IConfiguration _config;
        public UsersController(IUsers repository, IConfiguration config)
        {
          
            _repository = repository;
            _config = config; 
        }

        //[Authorize]
        [HttpGet]
        

        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var UsersItems = _repository.GetUsers();
            return Ok(UsersItems); 
        }
        [HttpGet("{username}")]
        public ActionResult <User> GetUserByUsername(String username)
        {
            var userFound = _repository.GetUserbyUsername(username);
            if (userFound == null) return NotFound(); 
            return Ok(userFound);
        }
        [HttpPost("[action]"), ActionName("Login")]
        public ActionResult<String> Validate(User u )
        {
            //working code
            //var response = _repository.ValidateUser(u);
            //if (response == null) return NotFound();
            //return Ok(response);
            //////////////////////////////////////////////////////
            //if (_repository.ValidateUser(u)!= null)
            //{
            //    return u;
            //}
            //return "NOOO";
            var response = _repository.ValidateUser(u);
            if (response == null) return NotFound();
            else
            {
                return Ok(response); 
 
            }


        }
        [HttpPost("[action]"), ActionName("register")]
        public ActionResult<User> AddUser(User u)
        {
           var u1 = _repository.GetUserbyUsername(u.Username);
            if (u1 != null) return NotFound(u);
            _repository.AddUser(u);
            _repository.SaveChanges();
            return Ok(u.Username);


        }
        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //var header = new JwtHeader(credentials); 

            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              null,
              expires: DateTime.Now.AddDays(120),
              signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [HttpDelete("{username}")]
        public string DeleteUser(String username)
        {
          
                var userToDelete = _repository.GetUserbyUsername(username);
                if (userToDelete == null)
                {
                    return "not found!!!";
                }

                var res = _repository.DeleteUser(username);
                _repository.SaveChanges();
                return res.ToString();
        }
        [HttpPut("{username}")]
        public string EditUser (string username, User user)
        {
            var userToEdit = _repository.GetUserbyUsername(username);
            if (userToEdit == null) return "not found!";
            string res = _repository.EditUser(username, user);
            _repository.SaveChanges();
            return res; 
        }
    }
}
