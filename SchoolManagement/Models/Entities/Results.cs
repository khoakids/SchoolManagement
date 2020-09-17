using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Results
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int ExamTime { get; set; }
        public double? TestScore { get; set; }

        public virtual Students Student { get; set; }
        public virtual Subjects Subject { get; set; }
    }
}
