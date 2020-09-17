using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Models.ViewModels.Program
{
    public class AddProgram
    {
        [Required(ErrorMessage = "Đây là trường bắt buộc")]
        [Display(Name = "Tên chương trình")]
        public string ProgramName { get; set; }
    }
}
