using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MoviesCatalog.Core.Models
{
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get;  set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual AccountRole Roles { get; set; }
        [JsonIgnore]
        public int AccountRoleId { get; set; }

    }

}
