using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Courses
    {
        public Courses()
        {
            Classes = new HashSet<Classes>();
        }

        public int CourseId { get; set; }
        public DateTime? StartDay { get; set; }
        public DateTime? FinishDay { get; set; }

        public virtual ICollection<Classes> Classes { get; set; }
    }
}
