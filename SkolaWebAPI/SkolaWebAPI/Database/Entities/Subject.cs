using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SkolaWebAPI.Database.Entities
{
    public class Subject
    {
        public Guid subjectId { get; set; }
        public string subjectName { get; set; }
        public Guid termId { get; set; }
        [JsonIgnore]
        public Term term { get; set; }
        public ICollection<SubjectTask> Tasks { get; set; }
    }
}
