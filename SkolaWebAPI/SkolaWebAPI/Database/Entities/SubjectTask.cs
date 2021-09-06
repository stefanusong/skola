using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Database.Entities
{
    public class SubjectTask
    {
        [Key]
        public Guid TaskId { get; set; }
        public string TaskName { get; set; }
        public bool isCompleted { get; set; }
        public bool isArchived { get; set; }

        public Guid subjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
