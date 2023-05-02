using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.Core.Models
{
    public class Ratings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; protected set; }
        public int Rate { get; set; }
        public virtual Movie? RatedMovie { get; set; }
        public virtual UserAccount? RatedBy { get; set; }
    }
}
