using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public class ProgramRepository : IProgramRepository
    {
        private readonly SchoolDbContext context;

        public ProgramRepository(SchoolDbContext context)
        {
            this.context = context;
        }

        public int CreateProgram(Programs program)
        {
            context.Programs.Add(program);
            return context.SaveChanges();
        }

        public int DeleteProgram(int id)
        {
            var delProgram = GetProgram(id);
            if (delProgram != null)
            {
                context.Programs.Remove(delProgram);
                return context.SaveChanges();
            }
            return -1;
        }

        public Programs GetProgram(int id)
        {
            return context.Programs.FirstOrDefault(e => e.ProgramId == id);
        }

        public IEnumerable<ViewProgram> GetPrograms()
        {
            IEnumerable<ViewProgram> programs = new List<ViewProgram>();
            programs = (from m in context.Programs
                        select (new ViewProgram()
                        {
                            ProgramId = m.ProgramId,
                            ProgramName = m.ProgramName
                        }));
            return programs;
        }

        public int UpdateProgram(UpdateProgram model)
        {
            var program = GetProgram(model.ProgramId);
            if(program == null)
            {
                return -1;
            }
            program.ProgramName = model.ProgramName;
            context.Update(program);
            return context.SaveChanges();
        }
    }
}
