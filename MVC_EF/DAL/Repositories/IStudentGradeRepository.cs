using MVC_EF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF.DAL {
    public interface IStudentGradeRepository {
        IEnumerable<VotoStudente> GetStudentGrades(int studentId);
        int InsertStudentGrade(VotoStudente vs);
        void EditStudentGrade(VotoStudente vs);
        void DeleteStudentGrade(VotoStudente vs);

    }
}