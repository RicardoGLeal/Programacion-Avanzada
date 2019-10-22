using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATMCore
{
    class Operaciones
    {
        [Key]
        public int opeID { get; set; }
        public string concepto { get; set; }
    }
}
