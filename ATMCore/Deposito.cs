using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATMCore
{
    class Deposito
    {
        [Key]
        public int depID { get; set; }
        public int Folio { get; set; }
        public int cuentaDest { get; set; }
        public decimal monto { get; set; }
    }
}
