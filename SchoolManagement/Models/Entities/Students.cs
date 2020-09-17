using System;
using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Students
    {
        public Students()
        {
            Results = new HashSet<Results>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public DateTime? BirthDay { get; set; }
        public int ClassId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual Classes Class { get; set; }
        public virtual ICollection<Results> Results { get; set; }
    }
}
