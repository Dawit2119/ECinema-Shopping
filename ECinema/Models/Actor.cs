using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECinema.Models
{
    public class Actor
    { 
        [Key]
        public int Id { get; set; }
        [DisplayName("Profile Picture")]
        [Required(ErrorMessage ="Profile picture url is required")]
        public string ProfilePictureURL { get; set; }
        [DisplayName("Full name")]
        [Required(ErrorMessage ="Full name is required")]
        [StringLength(50,MinimumLength = 3,ErrorMessage ="Full name must be between 3 and 50 characters")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="little bio is required")]
        [StringLength(150,MinimumLength = 10,ErrorMessage ="Bio must be between 10 and 150 characters")]
        public string Bio { get; set; }

        public List<Actor_Movie> Movies { get; set; }
    }
}
