using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Subjects
    {
        public Subjects()
        {
            InfomationSubjects = new HashSet<InfomationSubjects>();
            Results = new HashSet<Results>();
        }

        public int SubjectId { get; set; }
        public int MajorId { get; set; }
        public string SubjectName { get; set; }

        public virtual Majors Major { get; set; }
        public virtual ICollection<InfomationSubjects> InfomationSubjects { get; set; }
        public virtual ICollection<Results> Results { get; set; }
    }
}
