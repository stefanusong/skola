using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkolaWebAPI.Database.Entities
{
    public class Subject
    {
        public Guid subjectId { get; set; }
        public string subjectName { get; set; }
        public Guid termId { get; set; }
        public Term term { get; set; }

        public ICollection<SubjectTask> Tasks { get; set; }
    }
}
