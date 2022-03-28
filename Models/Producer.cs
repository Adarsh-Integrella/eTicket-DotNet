using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; } = string.Empty;
        public string  FullName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; }
    }
}