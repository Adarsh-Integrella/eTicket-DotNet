using System.ComponentModel.DataAnnotations;
using eTickets.Base;

namespace eTickets.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string  FullName { get; set; }
        [Display(Name = "FullName")]
        [Required(ErrorMessage = "Full name is required")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "Full name must be minimum 3 and maximum 50 characters.")]

        public string Bio { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]


        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}