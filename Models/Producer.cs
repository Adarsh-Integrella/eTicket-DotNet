using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "ProfilePicture")]
        public string ProfilePictureURL { get; set; } = string.Empty;
        [Display(Name = "FullName")]
        public string  FullName { get; set; } = string.Empty;
        [Display(Name = "Biography")]

        public string Bio { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; }
    }
}