using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATMCore
{
    class Clientes
    {
        [Key]
        public int noCliente { get; set; }
        public int noCuenta { get; set; }
        public decimal Monto { get; set; }
    }
}
