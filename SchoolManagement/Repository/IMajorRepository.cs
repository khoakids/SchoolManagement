using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public interface IMajorRepository
    {
        int CreateMajor(Majors majors);
        IEnumerable<ViewMajor> GetMajors();
        Majors GetMajor(int id);
        int UpdateMajor(UpdateMajor model);
        int DeleteMajor(int id);
    }
}
