using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels;
using SchoolManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    public class MajorController : Controller
    {
        private readonly ILogger<MajorController> logger;
        private readonly IMajorRepository majorRepository;

        public MajorController(ILogger<MajorController> logger, IMajorRepository majorRepository)
        {
            this.logger = logger;
            this.majorRepository = majorRepository;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddMajor model)
        {
            if(ModelState.IsValid)
            {
                var major = new Majors()
                {
                    MajorName = model.MajorName,
                    FoundedYear = model.FoundedYear,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                var majorId = majorRepository.CreateMajor(major);
                if(majorId > 0)
                {
                    return RedirectToAction("Index", "Major");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var majorView = new AddMajor();
            return View(majorView);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var major = majorRepository.GetMajor(id);
            var editMajor = new UpdateMajor();
            if(major != null)
            {
                editMajor.MajorId = major.MajorId;
                editMajor.MajorName = major.MajorName;
                editMajor.Email = major.Email;
                editMajor.PhoneNumber = major.PhoneNumber;
                editMajor.FoundedYear = (int)major.FoundedYear;
            }
            return View(editMajor);
        }

        [HttpPost]
        public IActionResult Edit(UpdateMajor model)
        {
            if (ModelState.IsValid)
            {
                if (majorRepository.UpdateMajor(model) > 0)
                {
                    return RedirectToAction("Index", "Major");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var staffEdit = new UpdateMajor();
            return View(staffEdit);
        }

        [Route("/Program/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var deleteResult = majorRepository.DeleteMajor(id);
            return Json(new { deleteResult });
        }

        public IActionResult Index()
        { 
            var majors = new List<ViewMajor>();
            majors = majorRepository.GetMajors().ToList();
            return View(majors);
        }
    }
}
