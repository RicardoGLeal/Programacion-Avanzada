using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Cajero
{
    internal class Cuenta
    {
        public string f_nAccount; //Cuenta Esperada
        public string f_nip; //NIP esperado
        private string nAccount;
        private string nip;
        private int accountIndex;
        private float money;
        private int atmMoney = 10000;
        private string textfilepath = "..\\..\\..\\keys.txt";
        private string accountData;
        public Cuenta(string f_nAccount, string f_nip)
        {//Constructor para las dos variables que se mandan desde el main (Cuenta esperada y NIP esperado)
            this.f_nip = f_nip;
            this.f_nAccount = f_nAccount;
        }
        public bool autenticate()
        {
            var data = File.ReadAllLines(textfilepath); //Guarda todos los datos de la BD en el arreglo string llamado data
            accountIndex = 0; //Indice que nos ayudará a comparar el numero de cuenta y nip introducidos por el usuario por los de todas las cuentas.

            foreach (var separar in data)
            {
                var separado = separar.Split(',');//Guarda en el arreglo todos los numeros de cuenta
                if (!(f_nAccount == separado[0]))
                {
                    accountIndex++;
                }
                else
                {   //Cuenta encontrada
                    var llamar = verifynip(data, accountIndex);
                    if (!llamar) return false;
                    else
                        return true;
                }
            }
            Console.WriteLine("Cuenta no encontrada, intente de nuevo");
            return false;
        }

        public bool verifynip(string[] data, int accountIndex)
        {
            accountData = File.ReadLines(textfilepath).Skip(accountIndex - 1).Take(1).First();//Se guarda toda la informacion de la cuenta 
            // accountData = data[accountIndex]; 
            char[] sep = { ',' };
            var splitedaccountinfo = data[accountIndex].Split(sep, 3); //Separa la informacion de la cuenta en 3 strings.
            Console.WriteLine(data[accountIndex]);
            nAccount = splitedaccountinfo[0];
            nip = splitedaccountinfo[1];
            money = float.Parse(splitedaccountinfo[2]);

            if (f_nip == nip)
            {
                return true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("NIP Incorrecto, intente de nuevo");
                return false;
            }
        }
        public bool Deposito(float depositBalance)
        {
            string espera;
            Console.WriteLine("Introduce en la bandeja un sobre con la cantidad de $" + depositBalance);
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

            var balance = "" + (money + depositBalance); //la variable balance guardara la nueva cantidad monetaria en string, para poder insertarla en el archivo de texto
            var lines = File.ReadAllLines(textfilepath);
            for (var i = 0; i < lines.Length; i++)
                if (lines[i].Contains(accountData)) //El ciclo for va a revisar cada linea del archivo, hasta que encuentre la linea en la que se encuentra la informacion de la cuenta que se esta manejando.
                {
                    lines[i] = lines[i].Remove(12); // Se borra el texto que se encuentra a partir de la posicion 12 de la linea, borra el balance previo al depósito
                    lines[i] = lines[i].Insert(12, balance); // A partir de la posicion 12 escribe el nuevo balance posterior al depósito.
                }

            File.WriteAllLines(textfilepath, lines);
            Console.Clear();
            Console.WriteLine("Deposito realizado exitosamente, por seguridad tiene que ingresar al sistema nuevamente para que se vea reflejado el deposito");
            return true;
        }
        public void Saldo()
        {
            Console.WriteLine("Tu saldo es de: $" + money);
        }
        public bool Retiro(int amount)
        {
            if (atmMoney < amount)
            {
                Console.Clear();
                Console.WriteLine("Lo sentimos, el cajero no cuenta con el dinero suficiente, escoge otro monto");
                return false;
            }

            atmMoney -= amount; //Se le resta el dinero al cajero
            money -= amount; //Se le resta el dinero a la cuenta del usuario
            var balance = "" + money;
            var lines = File.ReadAllLines(textfilepath);
            for (var i = 0; i < lines.Length; i++)
                if (lines[i].Contains(accountData)) //El ciclo for va a revisar cada linea del archivo, hasta que encuentre la linea en la que se encuentra la informacion de la cuenta que se esta manejando.
                {
                    lines[i] = lines[i].Remove(12); // Se borra el texto que se encuentra a partir de la posicion 12 de la linea, borra el balance previo al retiro
                    lines[i] = lines[i].Insert(12, balance); // A partir de la posicion 12 escribe el nuevo balance posterior al retiro.

                }

            File.WriteAllLines(textfilepath, lines);
            accountData = File.ReadLines(textfilepath).Skip(accountIndex - 1).Take(1).First();
            Console.Clear();
            Console.WriteLine("Puede tomar el efectivo");
            return true;
        }
        public bool verifyRetiro(int option)
        {
            switch (option)
            {
                default:
                    break;
                case 1: //$20
                    if (money < 20)
                    {
                        Console.Clear();
                        Console.WriteLine("Fondos Insuficientes, pruebe con una cantidad menor");
                        return false;
                    }
                    else
                       if (!Retiro(20))
                    {
                        return false;
                    }

                    break;
                case 2:
                    if (money < 40)
                    {
                        Console.Clear();
                        Console.WriteLine("Fondos Insuficientes, pruebe con una cantidad menor");
                        return false;
                    }
                    else
                        if (!Retiro(40))
                    {
                        return false;
                    }

                    break;
                case 3:
                    if (money < 60)
                    {
                        Console.Clear();
                        Console.WriteLine("Fondos Insuficientes, pruebe con una cantidad menor");
                        return false;
                    }
                    else
                        if (!Retiro(60))
                    {
                        return false;
                    }

                    break;
                case 4:
                    if (money < 100)
                    {
                        Console.Clear();
                        Console.WriteLine("Fondos Insuficientes, pruebe con una cantidad menor");
                        return false;
                    }
                    else
                        if (!Retiro(100))
                    {
                        return false;
                    }

                    break;
                case 5:
                    if (money < 200)
                    {
                        Console.Clear();
                        Console.WriteLine("Fondos Insuficientes, pruebe con una cantidad menor");
                        return false;
                    }
                    else
                        if (!Retiro(200))
                    {
                        return false;
                    }

                    break;
                case 6:
                    Console.Clear();
                    return false;
                    break;
            }
            return true;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            string nAccount;
            string typednip;
        inicio:
            Console.WriteLine("Bienvenido! Introduce tu Numero de Cuenta");
            nAccount = Convert.ToString(Console.ReadLine()); //nAccount guarda el numero de cuenta introducido por el usuario
            //Console.WriteLine(data[accountIndex]);
            Console.WriteLine("Introduce tu NIP de acceso");
            typednip = Convert.ToString(Console.ReadLine()); //typednip guarda el numero de cuenta introducido por el usuario
                                                             // Console.WriteLine("NIP introducido: " + typednip);
            var c1 = new Cuenta(nAccount, typednip); //Se crea el objeto c1 y se le manda como parámetro el numero de cuenta y el nip que introdujo el usuario
            var verify = c1.autenticate();

            if (!verify)
            {
                goto inicio;
            }
            else
            {
                Console.Clear();
                if (!MenuPrincipal(c1))
                    goto inicio;
            }

        }
        private static bool MenuPrincipal(/*string[] data, string[] splitedaccountinfo, int accountIndex*/Cuenta c1)
        {
            bool check;
            int depositBalance;
            int option;
        Menu:
            option = 0;
            Console.WriteLine("Introduce una opcion");
            Console.WriteLine("1: Consulta de Saldo");
            Console.WriteLine("2: Retiro de Saldo");
            Console.WriteLine("3: Deposito");
            Console.WriteLine("4: Salir");

            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                default:
                    Console.Clear();
                    Console.WriteLine("Opcion no valida");
                    goto Menu;
                    break;
                case 1:
                    Console.Clear();
                    c1.Saldo();
                    goto Menu;
                    break;
                case 2:
                    Console.WriteLine("Elige el monto a retirar");
                    Console.WriteLine("1: $20");
                    Console.WriteLine("2: $40");
                    Console.WriteLine("3: $60");
                    Console.WriteLine("4: $100");
                    Console.WriteLine("5: $200");
                    Console.WriteLine("6: Cancelar Operacion");
                    option = int.Parse(Console.ReadLine());

                    if (option == 6) //Caso para Cancelar Operacion
                    {
                        Console.Clear();
                        goto Menu;
                    }

                    if (!c1.verifyRetiro(option))
                        goto case 2;
                    else
                        goto Menu;
                    break;

                case 3:
                    Console.WriteLine("Introduce la cantidad a depositar, para cancelar introduzca 0");
                    depositBalance = int.Parse(Console.ReadLine());
                    float realDepositBalance;

                    if (depositBalance == 0)
                    {
                        Console.Clear();
                        goto Menu;
                    }
                    else
                    {
                        realDepositBalance = depositBalance;
                        realDepositBalance /= 100; //Se divide la cantidad ingresada a depositar entre 100, para contemplar los centavos
                        c1.Deposito(realDepositBalance);
                        goto Menu;
                    }
                    break;
                case 4:
                    return false;
                    break;
            }
            return true;
        }
    }
}