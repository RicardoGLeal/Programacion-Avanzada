using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATMCore
{
    class Gerentes
    {
        [Key]
        public int noEmpleado { get; set; }
        public int noCuenta { get; set; }
    }
}
