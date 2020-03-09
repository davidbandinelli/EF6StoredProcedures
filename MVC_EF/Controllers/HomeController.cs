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
            //var gradeList = repo.GetStudentGrades(id);
            var gradeList = repo.GetStudentGradesExt(id);

            var gradeVM = new GradeViewModel();
            gradeVM.StudentId = id;
            gradeVM.ListaVoti = new List<GradeDtoVM>();
            foreach (var grade in gradeList) {
                var dto = MySingleton.GetAutoMapperInstance().Map<GradeDtoVM>(grade);
                gradeVM.ListaVoti.Add(dto);
            }
            return View(gradeVM);
        }
        [HttpGet]
        public ActionResult Inserisci() {
            return View();
        }

        [HttpPost]
        public ActionResult Inserisci(InsertGradeViewModel vm) {
            var repo = new StudentGradeRepository();
            var vs = new VotoStudente();
            vs.IdStudente = vm.IdStudente;
            vs.IdCorso = vm.IdCorso;
            vs.Voto = vm.Voto;
            repo.InsertStudentGrade(vs);
            return RedirectToAction("Visualizza");
        }

        [HttpGet]
        public ActionResult Modifica(int id) {
            var repo = new StudentGradeRepository();
            var vs = new VotoStudente();
            vs = repo.GetVotoStudenteForEdit(id);
            var vmedit = new EditGradeViewModel();
            vmedit = MySingleton.GetAutoMapperInstance().Map<EditGradeViewModel>(vs);
            return View(vmedit);
        }

        [HttpPost]
        public ActionResult Modifica(EditGradeViewModel vm) {
            var repo = new StudentGradeRepository();
            var vs = new VotoStudente();
            vs.IdStudente = vm.IdStudente;
            vs.IdCorso = vm.IdCorso;
            vs.Voto = vm.Voto;
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