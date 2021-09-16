using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SkolaWebAPI.Database.Entities
{
    public enum DepartmentType
    {
        Primary,
        Secondary,
        JuniorCollege
    }
    public class Term
    {
        [Key]
        public Guid TermId { get; set; }

        [Required]
        public int Grade { get; set; }

        [Required]
        public DepartmentType Department { get; set; }

        public string UserId { get; set; }
        
        [JsonIgnore]
        public User User { get; set; }

        public ICollection<Subject> subjects { get; set; }
    }
}
