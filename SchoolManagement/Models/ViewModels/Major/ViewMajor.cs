using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels
{
    public class ViewMajor
    {
        public int MajorId { get; set; }
        public string MajorName { get; set; }
        public int? FoundedYear { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
