using AutoMapper;
using MVC_EF.DAL;
using MVC_EF.Domain;
using MVC_EF.Singleton;
using MVC_EF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_EF.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Visualizza(int id = 1) {
            var repo = new StudentGradeRepository();
            var gradeList = repo.GetStudentGrades(id);

            var gradeVM = new GradeViewModel();
            gradeVM.StudentId = id;
            gradeVM.ListaVoti = new List<GradeDtoVM>();
            foreach (var grade in gradeList) {
                var dto = MySingleton.GetAutoMapperInstance().Map<GradeDtoVM>(grade);
                gradeVM.ListaVoti.Add(dto);
            }
            return View(gradeVM);
        }

        public ActionResult Inserisci() {
            var repo = new StudentGradeRepository();
            var vs = new VotoStudente();
            vs.IdStudente = 3;
            vs.IdCorso = 3;
            vs.Voto = 3;
            repo.InsertStudentGrade(vs);
            return RedirectToAction("Visualizza");
        }

        public ActionResult Modifica() {
            var repo = new StudentGradeRepository();
            var vs = new VotoStudente();
            vs.IdStudente = 3;
            vs.IdCorso = 3;
            vs.Voto = 4;
            repo.EditStudentGrade(vs);
            return RedirectToAction("Visualizza");
        }

        public ActionResult Cancella() {
            var repo = new StudentGradeRepository();
            var vs = new VotoStudente();
            vs.IdStudente = 3;
            vs.IdCorso = 3;
            repo.DeleteStudentGrade(vs);
            return RedirectToAction("Visualizza");
        }

    }
}