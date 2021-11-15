using System;
using System.ComponentModel.DataAnnotations;

namespace loginAPI.Models
{
    public class Interview
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public String CandidateName { set; get; }
        [Required]
        public String Position { set; get; }
        [Required]
        public String InterViewerName { set; get;  }
        [Required]
        public DateTime Time { set; get; }
        [Required]
        public int HallID { set; get; }
        [Required]
        public String Branch { set; get; }
        public Interview()
        {
        }
    }
}
