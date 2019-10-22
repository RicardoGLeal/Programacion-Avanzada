using System;
using System.Collections.Generic;
using System.IO;
namespace HistogramaFrecuencias
{
    class Histograma
    {
        public char letter;
        public bool encontrado = false;
        Dictionary<string, string> histoDic = new Dictionary<string, string>();
        public void Inicializa(string ruta)
        {
            using (StreamReader file = new StreamReader(ruta))
            {
                while (!file.EndOfStream)
                {
                    int letra = file.Read();
                    VerifyLetters(letra);
                }
            }
        }
        public void Imprime()
        {
            foreach (KeyValuePair<string, string> item in histoDic)
            {
                Console.WriteLine($"  {item.Key}: {item.Value}");
            }
        }

        public void VerifyLetters(int letra)
        {
            
            if ((letra >= 64 && letra <= 90)||letra>=97 && letra <=122)
            {
                
                letter = Convert.ToChar(letra);
                string letterString = "" + letter;

                if(histoDic.Count>0)
                {
                    foreach (KeyValuePair<string, string> item in histoDic)
                    {
                        if (item.Key == letterString)
                        {
                            histoDic[item.Key] += '*';
                            encontrado = true;
                            break;
                        }
                        else
                        {
                                encontrado = false;
                        }
                   }
                    if(encontrado == false)
                        histoDic.Add(letterString, "" + '*');
                }
                else
                {
                    histoDic.Add(letterString, "" + '*');
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Histograma h1 = new Histograma();
            string ruta = "..\\..\\..\\libro.txt";
            h1.Inicializa(ruta);
            h1.Imprime();
        }
    }
}
