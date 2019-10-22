using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATMCore
{
    class Usuarios
    {
        [Key]
        public int noCuenta { get; set; }
        public int tipoID { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string firstLastName { get; set; }
        public string secondLastName { get; set; }
        public string NIP { get; set; }
    }
}
