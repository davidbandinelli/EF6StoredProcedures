using MVC_EF.Domain;
using MVC_EF.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF.DAL {
    public class StudentGradeRepository : IStudentGradeRepository {

        // chiama la stored procedure GetStudentGrades passando il parametro di input e mappando il risultato su di una lista di domain entities utilizzando l'automapper
        public IEnumerable<VotoStudente> GetStudentGrades(int studentId) {
            var listaVoti = new List<VotoStudente>();

            using (var context = new SchoolEntities()) {

                var studentGrades = context.GetStudentGrades(studentId);
                foreach (var sg in studentGrades) {
                    var vs = MySingleton.GetAutoMapperInstance().Map<VotoStudente>(sg);
                    // l'automapper sostituisce il codice sottostante
                    /*
                    var vs = new VotoStudente();
                    vs.IdStudente = studentId;
                    vs.IdCorso = sg.CourseID;
                    vs.Voto = (decimal)sg.Grade;
                    */
                    listaVoti.Add(vs);
                }
                return listaVoti;
            }
        }

        // chiama la stored procedure InsertStudentGrade
        public int InsertStudentGrade(VotoStudente vs) {
            using (var context = new SchoolEntities()) {
                var sg = MySingleton.GetAutoMapperInstance().Map<StudentGrade>(vs);
                context.StudentGrades.Add(sg);
                context.SaveChanges();
                return sg.EnrollmentID;
            }
        }

        // chiama la stored procedure UpdateStudentGrade
        public void EditStudentGrade(VotoStudente vs) {
            using (var context = new SchoolEntities()) {
                StudentGrade studentGrade = new StudentGrade();
                var sg = MySingleton.GetAutoMapperInstance().Map<StudentGrade>(vs);
                // per aggiornare un'entità dobbiamo prima "materializzarla" nel contesto EF
                var studentGradeToUpdate = context.StudentGrades.Where(x => x.CourseID == sg.CourseID && x.StudentID == sg.StudentID).FirstOrDefault();
                if (studentGradeToUpdate != null) {
                    studentGradeToUpdate.Grade = sg.Grade;
                }
                context.SaveChanges();
            }
        }

        // chiama la stored procedure DeleteStudentGrade
        public void DeleteStudentGrade(VotoStudente vs) {
            using (var context = new SchoolEntities()) {
                StudentGrade studentGrade = new StudentGrade();
                var sg = MySingleton.GetAutoMapperInstance().Map<StudentGrade>(vs);
                // per cancellare un'entità dobbiamo prima "materializzarla" nel contesto EF
                var studentGradeToDelete = context.StudentGrades.Where(x => x.CourseID == sg.CourseID && x.StudentID == sg.StudentID).FirstOrDefault();
                if (studentGradeToDelete != null) {
                    context.StudentGrades.Remove(studentGradeToDelete);
                }
                context.SaveChanges();
            }
        }

        public IEnumerable<VotoStudente> GetStudentGradesExt(int studentId) {
            var listaVoti = new List<VotoStudente>();

            using (var context = new SchoolEntities()) {

                var studentGrades = context.GetStudentGrades2(studentId);
                foreach (var sg in studentGrades) {
                    var vs = MySingleton.GetAutoMapperInstance().Map<VotoStudente>(sg);
                    // l'automapper sostituisce il codice sottostante
                    /*
                    var vs = new VotoStudente();
                    vs.IdStudente = studentId;
                    vs.IdCorso = sg.CourseID;
                    vs.Voto = (decimal)sg.Grade;
                    */
                    vs.CognomeStudente = sg.StudentSurname;
                    vs.NomeStudente = sg.StudentName;
                    listaVoti.Add(vs);
                }
                return listaVoti;
            }

        }

        public VotoStudente GetVotoStudenteForEdit(int idToEdit) {
            using (var context = new SchoolEntities()) {
                // per aggiornare un'entità dobbiamo prima "materializzarla" nel contesto EF
                var studentGradeToUpdate = context.StudentGrades.Where(x => x.EnrollmentID == idToEdit).FirstOrDefault();
                if (studentGradeToUpdate != null) {
                    var vs = MySingleton.GetAutoMapperInstance().Map<VotoStudente>(studentGradeToUpdate);
                    return vs;
                } else {
                    return null;
                }
            }

        }
    }
}