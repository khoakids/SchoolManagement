using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels
{
    public class AddMajor
    {
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Tên Khoa")]
        public string MajorName { get; set; }
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Năm thành lập")]
        public int FoundedYear { get; set; }
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Số điện thoại")]
        [RegularExpression(@"(09|01[2|6|8|9])+([0-9]{8})\b", ErrorMessage = "Số điện thoại không đúng định dạng")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }
    }
}
