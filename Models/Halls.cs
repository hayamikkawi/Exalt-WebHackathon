using System;
using System.ComponentModel.DataAnnotations;
namespace loginAPI.Models
{
    public class Halls
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public String City { set; get; }


        public Halls()
        {
        }
    }
}
