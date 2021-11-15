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
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
    public class TimeController : ControllerBase
    {
        private readonly ITime repository;
        private IConfiguration config;

        public TimeController(ITime _repository, IConfiguration _configuration)
        {
            repository = _repository;
            config = _configuration;
        }
        [HttpGet("[Action]/{dt}"), ActionName("Employees")]
        public ActionResult<IEnumerable<Times>> GetAllFreeEmployees(DateTime dt)
        {
            return Ok(repository.GetAllFreeEmployees(dt));
        }
        [HttpGet("[Action]/{dt}"), ActionName("Halls")]
        public ActionResult<IEnumerable<Times>> GetAllBusyHalls(DateTime dt)
        {
            return Ok(repository.GetAllReservedHall(dt));
        }

    }
}
