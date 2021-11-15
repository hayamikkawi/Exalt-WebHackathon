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
    public class CandidateController : ControllerBase
    {
        private readonly ICandidate repository;
        private IConfiguration config;
        public CandidateController(ICandidate _repository, IConfiguration _configuration)
        {
            repository = _repository;
            config = _configuration;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> GetAllCandidates()
        {
            return Ok(repository.GetAllCandidates());
        }
        [HttpGet("{id}")]
        public ActionResult<Candidate> GetCandidateByID(int id) {
            var c = repository.GetCandidateByID(id);
            if (c != null) return Ok(c);
            else return NotFound(); 
        }
        [HttpPost]
        public ActionResult<String> AddNewCandidate(Candidate c)
        {
            if (repository.AddCandidate(c))
            {
                return Ok("Candidate Added Successfully"); 
            }
            else
            {
                return NotFound(); 
            }

        }
        [HttpDelete]
        public ActionResult<String> DeleteCandidate (int id)
        {
            if (repository.DeleteCandidate(id))
            {
                return Ok("Candidate Deleted Successfully!"); 
            }
            else
            {
                return NotFound(); 
            }

        }
        [HttpPut]
        public ActionResult<String> UpdateCandidate(Candidate UpdatedCandidate)
        {
            var result = repository.EditCandidate(UpdatedCandidate);
            if (result) return Ok("Updated Successfully"); 
            else return NotFound();
        }
    }
}
