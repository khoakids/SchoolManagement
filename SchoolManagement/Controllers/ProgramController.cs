using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolManagement.Models;
using SchoolManagement.Models.ViewModels.Program;
using SchoolManagement.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Controllers
{
    public class ProgramController : Controller
    {
        private readonly ILogger<ProgramController> logger;
        private readonly IProgramRepository programRepository;

        public ProgramController(ILogger<ProgramController> logger, IProgramRepository programRepository)
        {
            this.logger = logger;
            this.programRepository = programRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AddProgram model)
        {
            if (ModelState.IsValid)
            {
                var program = new Programs()
                {
                    ProgramName = model.ProgramName
                };
                var programId = programRepository.CreateProgram(program);
                if (programId > 0)
                {
                    return RedirectToAction("Index", "Program");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var programView = new AddProgram();
            return View(programView);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var program = programRepository.GetProgram(id);
            var editprogram = new UpdateProgram();
            if (program != null)
            {
                editprogram.ProgramId = program.ProgramId;
                editprogram.ProgramName = program.ProgramName;
            }
            return View(editprogram);
        }

        [HttpPost]
        public IActionResult Edit(UpdateProgram model)
        {
            if (ModelState.IsValid)
            {
                if (programRepository.UpdateProgram(model) > 0)
                {
                    return RedirectToAction("Index", "Program");
                }
                ModelState.AddModelError("", "System error, please try again later!");
            }
            var programEdit = new UpdateProgram();
            return View(programEdit);
        }

        [Route("/Program/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var deleteProgram = programRepository.DeleteProgram(id);
            return Json(new { deleteProgram });
        }

        public IActionResult Index()
        {
            var programs = new List<ViewProgram>();
            programs = programRepository.GetPrograms().ToList();
            return View(programs);
        }
    }
}
