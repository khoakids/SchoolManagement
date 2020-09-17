using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Classes
    {
        public Classes()
        {
            Students = new HashSet<Students>();
        }

        public int ClassId { get; set; }
        public int MajorId { get; set; }
        public int CourseId { get; set; }
        public int SubjectId { get; set; }

        public virtual Courses Course { get; set; }
        public virtual Majors Major { get; set; }
        public virtual ICollection<Students> Students { get; set; } 
    }
}
