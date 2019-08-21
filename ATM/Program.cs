using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*          String str = "15432,6423,93434";
          char[] spearator = { ',' };
          Int32 count = 3;
          string[] strlist = str.Split(spearator, count, StringSplitOptions.None);
          Console.WriteLine(strlist[1]);*/
//Array.ForEach(lines, Console.WriteLine);
namespace Cajero
{
     class Cuenta
    {
        private string nAccount;
        private string nip;
        private string balance;

        public Cuenta(string nAccount, string nip, string balance)
        {
            this.nAccount = nAccount;
            this.nip = nip;
            this.balance = balance;
        }

        public void autenticate()
        {
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        inicio:

            String nAccount;
            int accountIndex;

            Console.WriteLine("Bienvenido! Introduce tu Numero de Cuenta");
            nAccount = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Cuenta: " + nAccount);

            string textfilepath = @"C:\Users\ricar\Documents\GIT\Programacion-Avanzada\ATM\keys.txt";
            StreamReader freader = new StreamReader(textfilepath);

            string[] data = File.ReadAllLines(textfilepath);

            accountIndex = 0;
            foreach (string separar in data)
            {
                string[] separado = separar.Split(',');//Guarda en el arreglo todos los numeros de cuenta
                if (!(nAccount == separado[0]))
                    accountIndex++;
                else //Cuenta encontrada
                {
                   bool llamar = verifynip(data, accountIndex);
                    if (!llamar) goto inicio;
                    Console.Read();
                }
            }
            /*  foreach (string cuenta in data)
                  Console.WriteLine(cuenta);*/
            Console.WriteLine("Cuenta no encontrada, intente de nuevo");
            goto inicio;
        }
        private static bool verifynip(string[] data, int accountIndex)
        {

            String typednip;
            //Console.WriteLine(data[accountIndex]);
            Console.WriteLine("Introduce tu NIP de acceso");
            typednip = Convert.ToString(Console.ReadLine());
            Console.WriteLine("NIP introducido: " + typednip);
            string[] splitedaccountinfo = data[accountIndex].Split(',', 3, StringSplitOptions.None);

            Cuenta c1 = new Cuenta(splitedaccountinfo[0], splitedaccountinfo[1], splitedaccountinfo[2]);
            if (typednip == splitedaccountinfo[1])
            {   
                MenuPrincipal(data, splitedaccountinfo, accountIndex);
                return true;
            }
            else
            {
                Console.WriteLine("NIP Incorrecto, intente de nuevo");
                return false;
            }
        }
        private static void MenuPrincipal(string[] data, string[] splitedaccountinfo, int accountIndex)
        {
            int option;
            int balance = Int32.Parse(splitedaccountinfo[2]);

            Console.WriteLine("Introduce una opcion");
            Console.WriteLine("1: Consulta de Saldo");
            Console.WriteLine("2: Retiro de Saldo");
            Console.WriteLine("3: Deposito");
            option = Int32.Parse(Console.ReadLine());
            switch (option)
            {
                default:
                    Console.WriteLine("Opcion no valida");
                    break;
                case 1:
                    Console.WriteLine("Tu saldo es de: $" + splitedaccountinfo[2]);
                    break;
                case 2:
                    Console.WriteLine("Elige el monto a retirar");
                    Console.WriteLine("1: $20");
                    Console.WriteLine("2: $40");
                    Console.WriteLine("3: $60");
                    Console.WriteLine("4: $100");
                    Console.WriteLine("5: $200");
                    Console.WriteLine("6: Cancelar Operacion");
                    option = Int32.Parse(Console.ReadLine());


                    switch (option)
                    {
                        default:
                            break;
                        case 1: //$20
                            if (balance < 20)
                            {
                                Console.WriteLine("Fondos Insuficientes");
                            }
                            else
                            {
                                // StreamWriter fwriter = new StreamWriter(textfilepath, true);
                            }
                            break;
                        case 2:
                            if (balance < 40)
                            {
                                Console.WriteLine("Fondos Insuficientes");
                            }
                            else
                            {

                            }
                            break;
                        case 3:
                            if (balance < 60)
                            {
                                Console.WriteLine("Fondos Insuficientes");
                            }
                            break;
                        case 4:
                            if (balance < 100)
                            {
                                Console.WriteLine("Fondos Insuficientes");
                            }
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                    }
                    break;
                case 3:
                    break;
            }
        }
    }
}
