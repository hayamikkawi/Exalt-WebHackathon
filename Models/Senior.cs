using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loginAPI.Models
{
    public class Senior
    {

        [Key]
        public int ID { get; set;  }
        [Required]
        public String Name { set; get; }
        [Required]
        public String Position { set; get; }
        [Required]
        public int  PhoneNumber { get; set; }
        [Required]
        public String Email { set; get; }

        public Senior()
        {
        }
    }
}
