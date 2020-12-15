using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECinema.Models
{
    public class Producer
    {
        [Key]
        public int ProducerID { get; set; }
        [DisplayName("Profile Picture")]
        public string ProfilePictureURL { get; set; }
        [DisplayName("Full name")]
        public string FullName { get; set; }
        public string Bio { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
