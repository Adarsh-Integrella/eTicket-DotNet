using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; } 
        [Display(Name = "Logo")]
        public string Name { get; set; } 
        [Display(Name = "Name")]
        public string Description { get; set; } 
        [Display(Name = "Description")]
        public List<Movie> Movies { get; set; }
    }
}