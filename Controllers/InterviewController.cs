using System;
using System.Collections.Generic;
using loginAPI.Data;
using loginAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;



namespace loginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyCorsPolicy")]
    public class InterviewController :ControllerBase
    {
        private readonly IInterview repository;
        private IConfiguration config;
        public InterviewController(IInterview _repository, IConfiguration _configuration)
        {
            repository = _repository;
            config = _configuration;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Interview>> GetAllInterview()
        {
            return Ok(repository.GetAllInterviews());
        }
        [HttpGet("{id}")]
        public ActionResult<Candidate> GetInterviewByID(int id)
        {
            var c = repository.GetInterviewByID(id);
            if (c != null) return Ok(c);
            else return NotFound();
        }
        [HttpPost]
        public ActionResult<String> AddNewInterview(Interview c)
        {
            if (repository.AddInterview(c))
            {
                return Ok("Interview Added Successfully");
            }
            else
            {
                return NotFound();
            }

        }
        [HttpDelete]
        public ActionResult<String> DeleteInterview(int id)
        {
            if (repository.DeleteInterview(id))
            {
                return Ok("Interview Deleted Successfully!");
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPut]
        public ActionResult<String> UpdateInterview(Interview UpdatedInterview)
        {
            var result = repository.EditInterview(UpdatedInterview);
            if (result) return Ok("Updated Successfully");
            else return NotFound();
        }
    }
}
