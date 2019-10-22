using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATMCore
{
    class Transacciones
    {
        [Key]
        public int Folio { get; set; }
        public int opeID { get; set; }
        public int cuentaOr { get; set; }
        public DateTime dateTime { get; set; }
    }

        
}

