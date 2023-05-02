using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace MoviesCatalog.Core.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get;  set; }
        public string Name { get; set; }
        public int ReleaseYear { get; set; }

        [ForeignKey("MovieCategoryId")]
        public virtual MovieCategory MovieCategory { get; set; }
        public int MovieCategoryId { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("CreatedByAccountId")]
        public virtual UserAccount UserAccount { get; set; }
        public int CreatedByAccountId { get; set; }
        public string Synapsis { get; set; }
    }
}
