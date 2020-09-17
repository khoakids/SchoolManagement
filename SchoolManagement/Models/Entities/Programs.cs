using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Programs
    {
        public Programs()
        {
            InfomationSubjects = new HashSet<InfomationSubjects>();
        }

        public int ProgramId { get; set; }
        public string ProgramName { get; set; }

        public virtual ICollection<InfomationSubjects> InfomationSubjects { get; set; }
    }
}
