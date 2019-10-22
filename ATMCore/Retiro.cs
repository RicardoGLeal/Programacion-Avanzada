using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATMCore
{
    class Retiro
    {
        [Key]
        public int retID { get; set; }
        public int Folio { get; set; }
        public decimal monto { get; set; }
    }
}
