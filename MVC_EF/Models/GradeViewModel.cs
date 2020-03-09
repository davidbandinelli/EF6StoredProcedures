using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF.ViewModels {

    public class GradeViewModel {
        public List<GradeDtoVM> ListaVoti { get; set; }
        public int StudentId { get; set; }
    }

    public class GradeDtoVM {
        public int IdCorso { get; set; }
        public decimal Voto { get; set; }
        public string NomeStudente { get; set; }
        public string CognomeStudente { get; set; }
    }
}