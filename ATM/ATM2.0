using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cajero
{
    class Cuenta
    {
        public string f_nAccount;
        public string f_nip;

        private string nAccount;
        private string nip;
        private string balance;

        private int money;
        public Cuenta(string f_nAccount, string f_nip)
        {
            this.f_nip = f_nip;
            this.f_nAccount = f_nAccount;
        }

        public bool autenticate()
        {
            int accountIndex;
            string textfilepath = @"C:\Users\ricar\Documents\GIT\Programacion-Avanzada\ATM\keys.txt";
            StreamReader freader = new StreamReader(textfilepath);

            string[] data = File.ReadAllLines(textfilepath);
            accountIndex = 0;
            foreach (string separar in data)
            {
                string[] separado = separar.Split(',');//Guarda en el arreglo todos los numeros de cuenta
                if (!(f_nAccount == separado[0]))
                    accountIndex++;
                else //Cuenta encontrada
                {
                    bool llamar = verifynip(data, accountIndex);
                    if (!llamar) return false;
                    else
                        return true;
                }
            }
            /*  foreach (string cuenta in data)
                  Console.WriteLine(cuenta);*/
            Console.WriteLine("Cuenta no encontrada, intente de nuevo");
            return false;
        }

        public bool verifynip(string[] data, int accountIndex)
        {
            string[] splitedaccountinfo = data[accountIndex].Split(',', 3, StringSplitOptions.None);

            //Cuenta c1 = new Cuenta(splitedaccountinfo[0], splitedaccountinfo[1], splitedaccountinfo[2]);
            nAccount = splitedaccountinfo[0];
            nip = splitedaccountinfo[1];
            balance = splitedaccountinfo[2];
            money = Int32.Parse(balance);
            if (f_nip == nip)
                return true;
            else
            {
                Console.WriteLine("NIP Incorrecto, intente de nuevo");
                return false;
            }
        }
        public bool Deposito()
        {
            return false;
        }
        public void Saldo()
        {
            Console.WriteLine("Tu saldo es de: $" + money);
        }
        public bool Retiro(int amount)
        {
            return false;
        }
        public bool verifyRetiro(int option)
        {
            switch (option)
            {
                default:
                    break;
                case 1: //$20
                    if (money < 20)
                        Console.WriteLine("Fondos Insuficientes");
                    else
                        Retiro(20);
                    break;
                case 2:
                    if (money < 40)
                        Console.WriteLine("Fondos Insuficientes");
                    else
                        Retiro(40);
                    break;
                case 3:
                    if (money < 60)
                        Console.WriteLine("Fondos Insuficientes");
                    else
                        Retiro(60);
                    break;
                case 4:
                    if (money < 100)
                        Console.WriteLine("Fondos Insuficientes");
                    else
                        Retiro(100);
                    break;
                case 5:
                    if (money < 200)
                        Console.WriteLine("Fondos Insuficientes");
                    else
                        Retiro(100);
                    break;
                case 6:
                    break;
            }
            return false;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            String nAccount;
            String typednip;
        inicio:
            Console.WriteLine("Bienvenido! Introduce tu Numero de Cuenta");
            nAccount = Convert.ToString(Console.ReadLine());
            //Console.WriteLine(data[accountIndex]);
            Console.WriteLine("Introduce tu NIP de acceso");
            typednip = Convert.ToString(Console.ReadLine());
            Console.WriteLine("NIP introducido: " + typednip);
            Cuenta c1 = new Cuenta(nAccount, typednip);
            bool verify = c1.autenticate();
            if (!verify) goto inicio;
            else
                MenuPrincipal(c1);
        }
        /*     private static bool verifynip(string[] data, int accountIndex)
             {

             }*/
        private static void MenuPrincipal(/*string[] data, string[] splitedaccountinfo, int accountIndex*/Cuenta c1)
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
                    c1.Saldo();
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
                    c1.verifyRetiro(option);
                    break;
                case 3:
                    break;
            }
        }
    }
}
