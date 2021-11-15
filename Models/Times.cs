using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace loginAPI.Models
{
    public class Times
    {
        [ForeignKey("ID")]
        public int ID { set; get; }
        [Required]
        public DateTime StartTime { set; get; }
        [Required]
        public DateTime EndTime { set; get; }
        [Required]
        public String Type { set; get; }
        public Times()
        {
        }
    }
}
