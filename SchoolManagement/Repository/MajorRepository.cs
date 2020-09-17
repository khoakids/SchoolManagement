using Microsoft.AspNetCore.Mvc.ModelBinding;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Repository
{
    public class MajorRepository : IMajorRepository
    {
        private readonly SchoolDbContext context;

        public MajorRepository(SchoolDbContext context)
        {
            this.context = context;
        }

        public int CreateMajor(Majors majors)
        {
            context.Majors.Add(majors);
            return context.SaveChanges();
        }

        public int DeleteMajor(int id)
        {
            var delMajor = GetMajor(id);
            if (delMajor != null)
            {
                context.Majors.Remove(delMajor);
                return context.SaveChanges();
            }
            return -1;
        }

        public Majors GetMajor(int id)
        {
            return context.Majors.FirstOrDefault(e => e.MajorId == id);
        }

        public IEnumerable<ViewMajor> GetMajors()
        {
            IEnumerable<ViewMajor> majors = new List<ViewMajor>();
            majors = (from m in context.Majors
                      select (new ViewMajor()
                      {
                          MajorId = m.MajorId,
                          MajorName = m.MajorName,
                          FoundedYear = m.FoundedYear,
                          Email = m.Email,
                          PhoneNumber = m.PhoneNumber
                      }));
            return majors;
        }

        public int UpdateMajor(UpdateMajor model)
        {
            var major = GetMajor(model.MajorId);
            if (major == null)
            {
                return -1;
            }
            major.MajorName = model.MajorName;
            major.PhoneNumber = model.PhoneNumber;
            major.Email = model.Email;
            major.FoundedYear = model.FoundedYear;

            context.Update(major);
            return context.SaveChanges();
        }
    }
}
