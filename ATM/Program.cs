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
            int searcherpointer;
            Console.WriteLine("Bienvenido! Introduce tu Numero de Cuenta");
            naccount = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Cuenta: " + naccount);

            string textfilepath = @"C:\Users\ricar\Documents\GIT\Programacion-Avanzada\ATM\keys.txt";
            string[] data = File.ReadAllLines(textfilepath);

            searcherpointer = 0;
            foreach (string separar in data)
            {
                string[] separado = separar.Split(',');
                Console.WriteLine(separado[0]);
                if (!(naccount == separado[0]))
                {
                    Console.WriteLine("Cuenta no encontrada");
                    searcherpointer++;
                }
                else
                {
                    Console.WriteLine("INDICE: " + searcherpointer + "\n");
                    Console.WriteLine("Cuenta encontrada");
                    

                }

            }
            foreach (string cuenta in data)
                Console.WriteLine(cuenta);


            //Array.ForEach(lines, Console.WriteLine);





            // string[] strlist = lines[1].Split(',', 3, StringSplitOptions.None);
            //Console.WriteLine(strlist[1]);

            Console.Read();
        }
    }
}