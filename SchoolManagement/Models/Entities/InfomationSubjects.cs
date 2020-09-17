using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class InfomationSubjects
    {
        public int ProgramId { get; set; }
        public int MajorId { get; set; }
        public int SubjectId { get; set; }
        public int StudyYear { get; set; }
        public int? Semester { get; set; }
        public int? TheoreticalHour { get; set; }
        public int? PraticeHour { get; set; }

        public virtual Majors Major { get; set; }
        public virtual Programs Program { get; set; }
        public virtual Subjects Subject { get; set; }
    }
}
