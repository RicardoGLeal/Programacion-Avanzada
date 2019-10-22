using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ATMCore
{
    class Program
    {
        static void Main(string[] args)
        {
            int atmMoney = 10000;//La variable atmMoney es la cantidad de dinero con el que cuenta el cajero.
            int opt;
            int n_Account;
            DateTime n_dateTime = DateTime.Now;//n_dateTime guarda la fecha y hora actual.
            int n_Month = n_dateTime.Month;//n_Month guarda el numero del mes actual.
            string month;
            Login:
            Console.Clear();
            n_Account = Login();//n_Account guarda el número de cuenta del usuario una vez que inició sesión.
            if (n_Account != 0)
            {
                if (verifyIfGerente(n_Account))//Se llama a esta función para verificar si la cuenta introducida pertenece a un gerente o no.
                {
                    MenuGerente:
                    Console.WriteLine("Selecciona una opcion\n1:Generar reporte\n2:Consultar Historial\n3:Logout");
                    try { opt = Convert.ToInt32(Console.ReadLine()); }
                    catch//Si el usuario introduce un valor que no sea numérico...
                    {
                        Console.Clear();
                        Console.WriteLine("Opción Inválida");
                        goto MenuGerente;
                    }
                    decimal totalAmount=0;
                    var Counter=0;//Se utiliza en la función para generar los reportes. Esta variable guarda el número de consultas, depósitos y retiros.
                    switch (opt)
                    {
                        default:
                            Console.Clear();
                            Console.WriteLine("Opción Inválida");
                            goto MenuGerente;
                        case 1:
                            month = getMonthHistorial(ref n_Month);
                            Console.WriteLine("Reporte del Mes: "+month);
                            using (var db = new ATMdb())
                            {
                                //Cuenta el Número de Consultas.
                                Counter = db.Transacciones//select(count) Folio from Transacciones WHERE opeID = 1;
                                     .Where(s => s.opeID == 1 && s.dateTime.Month == n_Month).Count();
                                Console.WriteLine("Numero de consultas: " + Counter);

                                //Cuenta el número de depósitos.
                                Counter = db.Transacciones//select(count) Folio from Transacciones WHERE opeID = 2;
                                    .Where(s => s.opeID == 2 && s.dateTime.Month == n_Month).Count();
                                Console.WriteLine("Numero de depositos: " + Counter);

                                //Cuenta el número de retiros.
                                Counter = db.Transacciones//select(count) Folio from Transacciones WHERE opeID = 3;
                                    .Where(s => s.opeID == 3 && s.dateTime.Month == n_Month).Count();
                                Console.WriteLine("Numero de retiros: " + Counter);

                                //Selecciona el monto de cada uno de los retiros.
                                //select Retiro.Monto FROM Retiro INNER JOIN Transacciones WHERE Transacciones.Folio = Retiro.Folio;
                                var retamount = (from ret in db.Retiro
                                              join tran in db.Transacciones on ret.Folio equals tran.Folio
                                              where tran.dateTime.Month == n_Month
                                              select new
                                              {
                                                  Monto = ret.monto
                                              }).ToList();
                                foreach (var item in retamount)
                                    totalAmount += item.Monto; //Se le suma a totalAmount el monto de cada uno de los retiros.

                                Console.WriteLine("Cantidad de dinero retirado: " + totalAmount);

                                totalAmount = 0;//Se igual totalAmount a 0 para ahora poder ser reutilizada esta variable en el monto de los depósitos.
                                              
                                //select Deposito.Monto FROM Deposito INNER JOIN Transacciones WHERE Transacciones.Folio = Deposito.Folio;
                                var depamount = (from ret in db.Deposito
                                                 join tran in db.Transacciones on ret.Folio equals tran.Folio
                                                 where tran.dateTime.Month == n_Month
                                                 select new
                                                 {
                                                     Monto = ret.monto
                                                 }).ToList();
                                foreach (var item in depamount)
                                    totalAmount += item.Monto;//Se le suma a totalAmount el monto de cada uno de los depósitos.
                                Console.WriteLine("Cantidad de dinero depositado: " + totalAmount+"\n");
                                goto MenuGerente;
                            }
                        case 2:
                            Console.WriteLine("Introduce el numero de la cuenta de la que deseas ver su historial");
                           
                            int cuentaDest = Convert.ToInt32(Console.ReadLine());//cuentaDest guarda el número de cuenta elegido por el Gerente.

                            month = getMonthHistorial(ref n_Month);//Se llama a la funcion getMonthHistorial, cuya función es que el gerente seleccione el mes del que quiere ver el historial.
                            HistorialForUsers(cuentaDest, n_Month, month);////Se llama a la función HistorialForUsers, la cual se encarga de generar el historial del usuario,
                            //como parámetros se le manda el número de la cuenta, el mes(int) y el nombre del mes(string).
                            goto MenuGerente;

                        case 3:
                            goto Login;
                    }
                }
                else
                {
                    Menu:
                    Console.WriteLine("Selecciona una opcion\n1:Realizar Transacción \n2:Consultar Historial\n3:Logout");
                    try { opt = Convert.ToInt32(Console.ReadLine()); }
                    catch//Si el usuario introduce un valor que no sea numérico...
                    {
                        Console.Clear();
                        Console.WriteLine("Opción Inválida");
                            goto Menu;
                    }
                    switch (opt)
                    {
                        case 1:
                            Console.WriteLine("1:Consulta de Saldo\n2:Depósito\n3:Retiro\n4:Regresar");
                            opt = Convert.ToInt32(Console.ReadLine());
                            switch (opt)
                            {
                                case 1:
                                    Console.Clear();
                                    Transaccion(1, n_Account, ref atmMoney);//Insertar registro en transaccion
                                    goto Menu;
                                case 2:
                                    Console.Clear();
                                    Transaccion(2, n_Account, ref atmMoney);//Insertar registro en transaccion
                                    goto Menu;
                                case 3:
                                    Console.Clear();
                                    Transaccion(3, n_Account, ref atmMoney);//Insertar registro en transaccion
                                    goto Menu;
                                case 4:
                                    Console.Clear();
                                    goto Menu;
                                default:
                                    break;
                            }
                            break;
                        case 2:
                            month = getMonthHistorial(ref n_Month);//Se llama a la funcion getMonthHistorial, cuya función es que el usuario seleccione el mes del que quiere ver el historial.
                            HistorialForUsers(n_Account, n_Month, month);///Se llama a la función HistorialForUsers, la cual se encarga de generar el historial del usuario,
                            //como parámetros se le manda el número de la cuenta, el mes(int) y el nombre del mes(string).
                            goto Menu;
                        case 3:
                            Console.Clear();
                            goto Login;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opción Inválida");
                            goto Menu;
                    }
                }
            }
        }
        private static string getMonthHistorial(ref int n_Month)
        {
            Console.Clear();
            Console.WriteLine("1:Visualizar historial del mes en curso\n2:Visualizar historial de otro mes");
            int opt = Convert.ToInt32(Console.ReadLine());
            DateTime act = new DateTime();
            act = DateTime.Now;//act adquiere el valor de la fecha actual.
            if (opt == 1)//mes en curso
                n_Month = act.Month;//n_Month se iguala al mes que tiene act.
            else
            {
                Console.Clear();
                Console.WriteLine("Introduce el número del mes del que deseas conocer tu historial");
                n_Month = Convert.ToInt32(Console.ReadLine());//n_Month guarda el numero del mes deseado.
            }
            string month = DateTimeFormatInfo.CurrentInfo.GetMonthName(n_Month);//Convierte el número del mes en su nombre.
            month = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(month.ToLower());//Hace mayúscula la primer letra del mes.
            return (month);
        }
        private static bool HistorialForUsers(int n_Account, int n_Month, string month)
        {
            using (var db = new ATMdb())
            {
                //Se selecciona el Folio, la fecha, y el tipo de operaccion realizado para cada una de las transacciones.
                /*Select Transacciones.Folio, Transacciones.dateTime, Concepto.Operaciones FROM Transacciones
                INNER JOIN Operaciones WHERE Transacciones.opeID = Operaciones.opeID;
                 */
                var query = (from s in db.Transacciones
                             join sa in db.Operaciones on s.opeID equals sa.opeID
                             where s.dateTime.Month == n_Month && s.cuentaOr == n_Account
                             select new
                             {
                                 Folio = s.Folio,
                                 dateTime = s.dateTime,
                                 concepto = sa.concepto
                             }).ToList();

                if (query.Count == 0)//Si no se encontró ninguna transacción...
                    Console.WriteLine("No se encontro ningún movimiento\n");

                foreach (var item in query)
                {
                    Console.WriteLine("Mes: " + month);
                    Console.Write(item.concepto + " ");
                    if (item.concepto == "Deposito  ")
                    {
                        Deposito dep = db.Deposito.SingleOrDefault(p => p.Folio == item.Folio);//Se selecciona el Depósito que cuenta con el Folio generado de Transacción
                        Console.Write("a N° de cuenta " + dep.cuentaDest);//Numero de cuenta destino
                        Console.Write(" | Monto: " + dep.monto);//Monto
                    }
                    if (item.concepto == "Retiro    ")
                    { 
                        Retiro ret = db.Retiro.Single(p => p.Folio == item.Folio);// Se selecciona el Retiro que cuenta con el Folio generado de Transacción
                        Console.Write("Monto: " + ret.monto);//Monto
                    }
                    Console.WriteLine("\n" + item.dateTime + "\n");//Fecha
                }
                int affected = db.SaveChanges();
                return (affected == 1);
            }
        }
       
        private static bool Transaccion(int type, int n_Account, ref int atmMoney)
        {
            using (var db = new ATMdb())
            {
                DateTime localDate = DateTime.Now;//Se crea la variable localdate con la fecha y hora actual.

                var newTrans = new Transacciones//Se crea una nueva variable tipo Transacciones y se le introducen todos los datos
                //de la transaccion.
                {
                    opeID = type, //tipo de transaccion, consulta, depósito o retiro.
                    cuentaOr = n_Account, //cuenta de origen
                    dateTime = localDate //fecha y hora de la transacción.
                };
                if (type == 2) //si la operación es Depósito..
                {
                    Deposito(newTrans); //se llama a la función Deposito mandándole la nueva variable tipo Transacción.
                    return true;
                }
                if (type == 3)//si la operación es Retiro..
                {
                    Retiro(n_Account, newTrans, ref atmMoney);//se llama a la función Retiro mandándole la nueva variable tipo Transacción.
                    return true;
                }
                else//si la operación es Consulta...
                {
                    Consulta(n_Account);//Se llama a la función Consulta mandándole el número de cuenta del usuario.
                    db.Transacciones.Add(newTrans); //Se inserta el registro en Transacciones.
                    int affected = db.SaveChanges(); //Se guardan cambios.
                    return (affected == 1);
                }      
            }
        }
        private static bool Deposito(Transacciones newTrans)
        {
            int n_AccountDest;//Variable utilizada para guardar el número de cuenta a la que se depositará
            decimal n_Monto;//Variable que almacena el monto a depositar.
            Deposito:
            Console.WriteLine("Ingresa el numero de cuenta a la que deseas depositar");
            n_AccountDest = Convert.ToInt32(Console.ReadLine()); //Se guarda el número de cuenta destino.

            using (var db = new ATMdb())
            {
                try
                { Usuarios us = db.Usuarios.Single(st => st.noCuenta == n_AccountDest);}//Se hace un select en la tabla Usuarios con e
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Cuenta no Encontrada!");
                    goto Deposito;
                }
            }

            using (var db = new ATMdb())
            {
                Monto:
                Console.WriteLine("Introduce la cantidad a depositar, para cancelar introduzca 0");
                n_Monto = Convert.ToInt32(Console.ReadLine());//n_Monto guarda el monto a depositar.
                if (n_Monto == 0)///Si n_Monto es 0... (Cancelar Operacion)
                {
                    Console.Clear();
                    return false;
                }
                n_Monto /= 100;//Se divide n_Monto entre 100 para contemplar los centavos.

                if (!DepositWaitTime(n_Monto))//Verifica que el usuario introduzca el dinero en en plazo de 2min.
                    goto Deposito;//Si excedió el tiempo se vuelve a iniciar el proceso de depósito.

                db.Transacciones.Add(newTrans);//Inserta el registro de la tabla transaccion.
                int affected = db.SaveChanges();//Guarda los cambios en la bd.
                int maxFolio = db.Transacciones.Max(p => p.Folio);//maxFolio adquiere el valor del folio que se acaba de insertar.
               
                var newDeposito = new Deposito
                {
                    Folio = maxFolio, //Deposito.Folio = maxFolio
                    cuentaDest = n_AccountDest, //Deposito.cuentaDest = n_AccountDest
                    monto = n_Monto //Deposito.monto = n_Monto
                };
                db.Deposito.Add(newDeposito);//Se inserta el registro en la Tabla Deposito

               // ActualizarSaldo(db, n_Account, n_Monto, '-');//Disminuye el saldo de la cuenta de origen (- Monto)
                ActualizarSaldo(db, n_AccountDest, n_Monto, '+');//Aumenta el saldo de la cuenta destino (+ Monto)

                affected = db.SaveChanges();
                return (affected == 1);
            }
        }
        private static bool Retiro(int n_Account, Transacciones newTrans, ref int atmMoney)
        {
            Dictionary<int, int> retCants = new Dictionary<int, int>();//Se crea un diccionario para relacionar el índice de cada retiro con su valor.
            retCants.Add(1, 20);//1: $20
            retCants.Add(2, 40);//2: $40
            retCants.Add(3, 60);//3: $60
            retCants.Add(4, 100);//4: $100
            retCants.Add(5, 200);//5: $200
            Console.Clear();
            aRetiro:
            Console.WriteLine("Elige el monto a retirar\n1:$20\n2:$40\n3:$60\n4:$100\n5:$200\n6:Cancelar Operación");
            int opt = Convert.ToInt32(Console.ReadLine());

            if (opt == 6)//Si opt es igual a 6(Cancelar Operacion)...
                return false;

            decimal n_Monto = retCants[opt];//n_Monto adquiere el valor del monto a retirar, a partir del diccionario.
              if (atmMoney < n_Monto)//Si la cantidad de dinero del cajero es menor que el monto a retirar...
              {
                  Console.Clear();
                  Console.WriteLine("Lo sentimos, el cajero no cuenta con el dinero suficiente, escoge otro monto");
                  return false;
              }

            using (var db = new ATMdb())
            {
                if (!VerifyEnoughBalance(db, n_Account, n_Monto))//Se llama a VerifyEnoughBalance para verificar si el Usuario cuenta
                    //con los fondos suficientes.
                {
                    Console.WriteLine("Fondos Insuficientes");
                    goto aRetiro;
                }
                ActualizarSaldo(db, n_Account, n_Monto, '-');//Se llama a esta función para restarle al usuario el monto que retiró.

                db.Transacciones.Add(newTrans);//Se inserta el registro en Transacciones.
                int affected = db.SaveChanges();//Se guardan los cambios.
                int maxFolio = db.Transacciones.Max(p => p.Folio);//Se obtiene el Folio de la Transacción generada.

                var newRetiro = new Retiro//Se crea la variable newRetiro de tipo retiro.
                {
                    Folio = maxFolio,
                    monto = n_Monto
                };
                db.Retiro.Add(newRetiro);//Se inserta el registro en Retiro.
                Console.WriteLine("Saldo Actualizado!");
                affected = db.SaveChanges();//Se guardan los cambios.
                return (affected == 1);
            }
        }
        private static bool DepositWaitTime(decimal n_Monto)
        {
            string espera;
            Console.WriteLine("Introduce en la bandeja un sobre con la cantidad de $" + n_Monto);
            var tiempo1 = DateTime.Now;
            var requerido = new TimeSpan(00, 00, 02, 00); //Se crea un timespan al cual se le asigna el tiempo maximo el cual es de 2 minutos, esto para posteriormente compararlo

            espera = Convert.ToString(Console.ReadKey());//El usuario debe presionar una tecla (depositar el efectivo) para poder continuar.
            var tiempo2 = DateTime.Now;// Se calcula la hora exacta de el momento en el que el usuario deposito el efectivo
            var total = new TimeSpan(tiempo2.Ticks - tiempo1.Ticks);// Se resta el tiempo en el que el usuario deposito menos el tiempo en el que inicio la operacion, para calcular el tiempo demorado.

            if (TimeSpan.Compare(total, requerido) == 1)
            {//Se comparada el tiempo demorado y el tiempo maximo, en dado caso de que el demorado(total) sea mayor, se le indica a el usuario que intente nuevamente. 
                Console.Clear();
                Console.WriteLine("Tiempo maximo en espera superado (2min) intenta nuevamente");
                return false;
            }
            return true;
        }

        private static bool VerifyEnoughBalance(ATMdb db, int n_Account, decimal n_Monto)
        {
            Clientes result = db.Clientes.SingleOrDefault(b => b.noCuenta == n_Account);//Se hace un select en la tabla Clientes con la condición de que noCuenta sea igual a n_Account.
            if (result.Monto >= n_Monto)//Si el Monto del usuario es mayor o igual que el monto que desea depositar, se retorna un true
                return true;
            else //El saldo del usuario es menor, se retorna un false.
                return false;
        }
        private static void ActualizarSaldo(ATMdb db, int n_Account, decimal n_Monto, char op)
        {
            var result = db.Clientes.SingleOrDefault(b => b.noCuenta == n_Account);//La variable result selecciona el registro de la cuenta especificada.
            if (result != null)
            {
                if (op == '+')
                    result.Monto = result.Monto + n_Monto;//Se suma el monto a la cuenta.
                else
                    result.Monto = result.Monto - n_Monto;//Se resta el monto a la cuenta
                db.SaveChanges();
            }
        }
        private static bool Consulta(int n_Account)
        {
            using (var db = new ATMdb())
            {
                //Se raliza un Queryable tipo Clientes que selecciona el registro de la cuenta especificada.
                IQueryable<Clientes> client = db.Clientes.Where(Clientes => Clientes.noCuenta == n_Account);
                foreach (var cl in client)
                    Console.WriteLine("Saldo Actual: $" + cl.Monto);//Se imprime el saldo de la cuenta.

                int affected = db.SaveChanges();//Se guardan los cambios.
                return (affected == 1);
            }
        }
        private static int Login()
        {
            int accountNumber;
            string password;
            Login:
            Console.WriteLine("Bienvenido, introduce tu número de cuenta");
            try { accountNumber = Convert.ToInt32(Console.ReadLine()); }//accountNumber guarda el número de cuenta introducido por el usuario.
            catch//Si accountNumber contiene valores nó numéricos...
            {
                Console.Clear();
                Console.WriteLine("Numero de cuenta o NIP incorrectos");
                goto Login;
            }
            Console.WriteLine("Introduce tu NIP de Acceso");
            password = Console.ReadLine();//password guarda el NIP introducido por el usuario.
            password = sha256(password);//Se llama a la función sha256 mandándole como parámetro la contraseña introducida, esta función la encriptará.

            using (var db = new ATMdb())
            {
                try
                { //Se realiza la consulta en la tabla Usuarios con la condición de que el número de cuenta introducido y la contraseña encriptada sean correctos.
                    Usuarios us = db.Usuarios.SingleOrDefault(st => st.noCuenta == accountNumber && st.NIP == password);
                    Console.Clear();
                    Console.WriteLine("Bienvenido " + us.firstName + " " + us.secondName + " " + us.firstLastName + " " + us.secondLastName);
                    return us.noCuenta;//Se retorna el número de cuenta de persona que acaba de iniciar sesión.
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Numero de cuenta o NIP incorrectos");
                    goto Login;
                }
            }
        }
        private static bool verifyIfGerente(int accountNumber)
        {
            using (var db = new ATMdb())
            {
                try
                { Gerentes ger = db.Gerentes.Single(g => g.noCuenta == accountNumber); }//Se hace un select en la tabla Gerentes verificando si el número de cuenta introducido existe en dicha tabla.
                catch
                { return false; }//Se retorna un false, ya que no se encontró el número de cuenta en la tabla Gerentes..
            }
             return true;    //Se retorna un true, ya que sí se encontró el número de cuenta en la tabla Gerentes.
        }
        static string sha256(string randomString)//Para encriptar la contraseña a sha256
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
