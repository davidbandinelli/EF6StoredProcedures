﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF.Domain {
    public class VotoStudente {
        public int IdStudente { get; set; }
        public int IdCorso { get; set; }
        public decimal Voto { get; set; }
        public string NomeStudente { get; set; }
        public string CognomeStudente { get; set; }
    }
}