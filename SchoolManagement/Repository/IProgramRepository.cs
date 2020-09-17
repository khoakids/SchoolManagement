using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public interface IProgramRepository
    {
        int CreateProgram(Programs program);
        IEnumerable<ViewProgram> GetPrograms();
        Programs GetProgram(int id);
        int UpdateProgram(UpdateProgram model);
        int DeleteProgram(int id);
    }
}
