using System.ComponentModel.DataAnnotations;
using eTickets.Base;

namespace eTickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; } 
        [Display(Name = "Logo")]
        [Required(ErrorMessage = "logo is required")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength =3, ErrorMessage = "Name must be minimum 3 and maximum 50 characters.")]


        public string Description { get; set; } 
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]

        public List<Movie> Movies { get; set; }
    }
}