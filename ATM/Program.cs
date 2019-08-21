using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
/*          String str = "15432,6423,93434";
          char[] spearator = { ',' };
          Int32 count = 3;
          string[] strlist = str.Split(spearator, count, StringSplitOptions.None);
          Console.WriteLine(strlist[1]);*/
namespace Cajero
{
    class Program
    {
        static void Main(string[] args)
        {
            String naccount;
            int accountindex;
            Console.WriteLine("Bienvenido! Introduce tu Numero de Cuenta");
            naccount = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Cuenta: " + naccount);

            string textfilepath = @"C:\Users\ricar\Documents\GIT\Programacion-Avanzada\ATM\keys.txt";
            string[] data = File.ReadAllLines(textfilepath);

            accountindex = 0;
            foreach (string separar in data)
            {
                string[] separado = separar.Split(',');
                Console.WriteLine(separado[0]);
                if (!(naccount == separado[0]))
                {
                    Console.WriteLine("Cuenta no encontrada");
                    accountindex++;
                }
                else
                {
                    Console.WriteLine("INDICE: " + accountindex + "\n");
                    Console.WriteLine("Cuenta encontrada");
                    verifynip(data, accountindex);
                    Console.Read();
                }
            }
            foreach (string cuenta in data)
                Console.WriteLine(cuenta);
            //Array.ForEach(lines, Console.WriteLine);
            Console.Read();
        }
        private static void verifynip(string[] data, int accountindex)
        {
            String typednip;
            Console.WriteLine(data[accountindex]);
            Console.WriteLine("Introduce tu NIP de acceso");
            typednip = Convert.ToString(Console.ReadLine());
            Console.WriteLine("NIP introducido: " + typednip);
            string[] splitedaccountinfo = data[accountindex].Split(',', 3, StringSplitOptions.None);
            Console.WriteLine("NIP real: " + splitedaccountinfo[1]);
            if (typednip == splitedaccountinfo[1])
            {
                MenuPrincipal(data, splitedaccountinfo, accountindex);
            }
            else
            {
                Console.WriteLine("NIP Incorrecto");
            }

        }
        private static void MenuPrincipal(string[] data, string[] splitedaccountinfo, int accountindex)
        {
            int option;
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
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
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