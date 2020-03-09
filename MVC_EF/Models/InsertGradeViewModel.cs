using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF.ViewModels {

    public class InsertGradeViewModel {
        public int IdStudente { get; set; }
        public int IdCorso { get; set; }
        public decimal Voto { get; set; }
    }

}