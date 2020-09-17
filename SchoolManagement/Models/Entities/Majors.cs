using System.Collections.Generic;

namespace SchoolManagement.Models
{
    public partial class Majors 
    {
       /* public Majors()
        {
            Classes = new HashSet<Classes>();
            InfomationSubjects = new HashSet<InfomationSubjects>();
            Subjects = new HashSet<Subjects>();
        }*/
        public int MajorId { get; set; }
        public string MajorName { get; set; }
        public int? FoundedYear { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Classes> Classes { get; set; }
        public virtual ICollection<InfomationSubjects> InfomationSubjects { get; set; }
        public virtual ICollection<Subjects> Subjects { get; set; }
    }
}
