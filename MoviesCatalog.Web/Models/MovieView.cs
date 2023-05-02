using System.ComponentModel.DataAnnotations;

namespace MoviesCatalog.Web.Models
{
    public class MovieView
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int ReleaseYear { get; set; }
        [Required]
        public string Categorie { get; set; }
        [Required]
        public string Synapsis { get; set; }
    }
}
