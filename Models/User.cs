using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loginAPI.Models
{
    public class User
    {
        [Key]
        [ForeignKey("Username")]
        public String Username { set; get; }
        [Required]
        public String Password { set; get; }
        [Required]
        public String role { get; set;  }
        public User()
        {
        }
    }
}
