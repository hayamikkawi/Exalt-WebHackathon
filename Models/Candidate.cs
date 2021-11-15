using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace loginAPI.Models
{
    public class Candidate
    {
        [Required]
        public int ID { set; get; }
        [Required]
        public String Name { set; get; }
        [Required]
        public String Email { set; get; }
        [Required]
        public String Position { set; get; }
        [Required]
        public String City { set; get; }
        [Required]
        public int PhoneNumber { set; get; }
        public int CVID { get; set; }

        public Candidate()
        {
        }
    }
}


