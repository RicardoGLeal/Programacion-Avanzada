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
        private int accountIndex;
        private int money;

        private int atmMoney = 10000;
        private string textfilepath = @"C:\Users\ricar\Documents\GIT\Programacion-Avanzada\ATM\keys.txt";
        private string accountData;
        public Cuenta(string f_nAccount, string f_nip)
        {
            this.f_nip = f_nip;
            this.f_nAccount = f_nAccount;
        }
        public bool autenticate()
        {   
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
            accountData = data[accountIndex];
            string[] splitedaccountinfo = data[accountIndex].Split(',', 3, StringSplitOptions.None);
            Console.WriteLine(data[accountIndex]);
            //Cuenta c1 = new Cuenta(splitedaccountinfo[0], splitedaccountinfo[1], splitedaccountinfo[2]);
            nAccount = splitedaccountinfo[0];
            nip = splitedaccountinfo[1];
            balance = splitedaccountinfo[2];
            money = Int32.Parse(balance);
            if (f_nip == nip)
                return true;
            else
            {
                Console.Clear();
                Console.WriteLine("NIP Incorrecto, intente de nuevo");
                return false;
            }
        }
        public bool Deposito(float depositBalance)
        {
            string introduce;
            Console.WriteLine("Introduce en la bandeja un sobre con la cantidad de $"+depositBalance);
            introduce = Convert.ToString(Console.Read());
            string balance = "" + (money + depositBalance);
            string[] lines = File.ReadAllLines(textfilepath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(accountData))
                {
                    lines[i] = lines[i].Remove(12);
                    lines[i] = lines[i].Insert(12, balance);

                }
            }
            File.WriteAllLines(textfilepath, lines);
            
            return true;
        }
        public void Saldo()
        {
            Console.WriteLine("Tu saldo es de: $" + money);
        }
        public bool Retiro(int amount)
        {
            if(atmMoney < amount)
            {
                Console.Clear();
                Console.WriteLine("Lo sentimos, el cajero no cuenta con el dinero suficiente, escoge otro monto");
                return false;
            }

            String balance = "" + (money - amount);
            string[] lines = File.ReadAllLines(textfilepath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(accountData))
                {
                    lines[i] = lines[i].Remove(12);
                    lines[i] = lines[i].Insert(12, balance);

                }
            }
            File.WriteAllLines(textfilepath, lines);
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
                        return false ;
                    }
                    else  
                       if(!Retiro(20))
                            return false;
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
                        return false;
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
                        return false;
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
                        return false;
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
                        return false;
                    break;
                case 6:
                    break;
            }
            return true;
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
            {
                Console.Clear();
                MenuPrincipal(c1);
            }
                
        }
        /*     private static bool verifynip(string[] data, int accountIndex)
             {

             }*/
        private static void MenuPrincipal(/*string[] data, string[] splitedaccountinfo, int accountIndex*/Cuenta c1)
        {
            int option;
            bool check;
            int depositBalance;
        Menu:
            Console.WriteLine("Introduce una opcion");
            Console.WriteLine("1: Consulta de Saldo");
            Console.WriteLine("2: Retiro de Saldo");
            Console.WriteLine("3: Deposito");
            Console.WriteLine("4: Salir");

            option = Int32.Parse(Console.ReadLine());
            switch (option)
            {
                default:
                    Console.Clear();
                    Console.WriteLine("Opcion no valida");
                    goto Menu;
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
                    if (!c1.verifyRetiro(option))
                        goto case 2;
                    break;
                case 3:
                    Console.WriteLine("Introduce la cantidad a depositar, para cancelar introduzca 0");
                    depositBalance = Int32.Parse(Console.ReadLine());
                    float realDepositBalance;
                    if (depositBalance == 0)
                    {
                        Console.Clear();
                        goto Menu;
                    }
                    else
                    {
                        realDepositBalance = depositBalance;
                        realDepositBalance /= 100;
                        if (c1.Deposito(realDepositBalance)) goto Menu;
                    }
                    break;
                case 4:
                    Console.WriteLine("Hasta luego!");
                    break;
            }
        }
    }
}