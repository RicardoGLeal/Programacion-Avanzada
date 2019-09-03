using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PlacasAutos
{
    internal class Placa
    {
        private List<string> placas;
        private List<string> placasLote;
        
        public void Validacion()
        {
            placas = new List<string>();
            String placaInfo;
            int verifyIfNumber;
            int charString;
            string pathFile = "..\\..\\..\\sample.txt";
            using (StreamReader sr = new StreamReader(pathFile))
            {
                while (!sr.EndOfStream)
                {
                    placaInfo = sr.ReadLine();
                    if (placaInfo[0] == 'J' || placaInfo[0] == 'H')//VERIFICACION DE QUE EL EL PRIMER ELEMENTO DE LA TERCIA SEA UNA LETRA
                    {
                        charString = placaInfo[1];
                        if (charString >= 65 && charString <= 90)//VERIFICACION DE QUE EL SEGUNDO ELEMENTO DE LA TERCIA SEA UNA LETRA
                        {
                            charString = placaInfo[2];
                            if (charString >= 65 && charString <= 90)//VERIFICACION DE QUE EL TERCER ELEMENTO DE LA TERCIA SEA UNA LETRA
                            {
                                verifyIfNumber = placaInfo[4] - '0';
                                if (verifyIfNumber >= 0 && verifyIfNumber <= 9)//VERIFICACION DE QUE EL PRIMER ELEMENTO DEL LOTE SEA UN NUMERO
                                {
                                    verifyIfNumber = placaInfo[5] - '0';
                                    if (verifyIfNumber >= 0 && verifyIfNumber <= 9)//VERIFICACION DE QUE EL SEGUNDO ELEMENTO DEL LOTE SEA UN NUMERO
                                    {
                                        verifyIfNumber = placaInfo[7] - '0';
                                        if (verifyIfNumber >= 0 && verifyIfNumber <= 9)//VERIFICACION DE QUE EL PRIMER ELEMENTO DE LA TUPLA SEA UN NUMERO
                                        {
                                            verifyIfNumber = placaInfo[8] - '0';
                                            if (verifyIfNumber >= 0 && verifyIfNumber <= 9)//VERIFICACION DE QUE EL SEGUNDO ELEMENTO DEL LOTE SEA UN NUMERO
                                            {
                                                placas.Add(placaInfo);//SE AGREGA LA PLACA VALIDADA A LA LISTA
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                Acomodar();
            }
            
        }
        private void Acomodar()
        {
            String placaCortada;//ESTE STRING GUARDA DESDE LA TERCIA HASTA EL LOTE DE LAS PLACAS. 
            placas.Sort();//SE ORDENAN LAS PLACAS
            placasLote = new List<string>();
            Console.WriteLine("Placas de Jalisco:");
            foreach (var item in placas)
            {
                Console.WriteLine(item);//SE IMPRIMEN LAS PLACAS DE MANERA ORDENADA
                placaCortada = item.Substring(0, 6); //ESTO HACE QUE LA PLACA SE PARTA Y QUE SOLO SE CONSERVE DESDE LA TERCIA HASTA EL LOTE
                placasLote.Add(placaCortada);//SE AÑADE LA NUEVA PLACA CORTADA A LA LISTA QUE GUARDA LAS PLACAS CORTADAS
            }
            var placasDic = new Dictionary<string, string>();

            int copias = 1;
            for (int i = 0; i < placasLote.Count - 1; i++) //ESTOS FORS SON LOS QUE SE ENCARGAN DE REVISAR SI SE REPITEN LAS PLACAS
            {
                copias = 1;
                for (int b = i + 1; b < placasLote.Count - 1; b++)
                {
                    if (placasLote[i] == placasLote[b])//EN CASO DE QUE UNA PLACA SE REPITA..
                    {
                        placasLote.RemoveAt(b);//SE BORRA DE LA LISTA LA PLACA REPETIDA
                        copias++;//SE SUMA 1 A LA VARIABLE QUE LLEVA EL CONTROL DE CUANTAS PLACAS CON EL MISMO LOTE Y TERCIA HAY.
                        b--; //SE LE RESTA 1 AL INDICE, YA QUE COMO ELIMINAMOS UNA PLACA TODAS SE RECORREN
                    }
                }
                placasDic.Add(placasLote[i], "Placas encontradas:" + copias);//SE AGREGA A EL DICIONARIO LA PLACA Y EL NUMERO DE PLACAS EXISTENTES.
            }
            foreach (KeyValuePair<string, string> item in placasDic)
            {
                Console.WriteLine($"  {item.Key}: {item.Value}");//SE IMPRIME LA PLACA + EL NUMERO DE PLACAS IGUALES ENCONTRADAS
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Placa p1 = new Placa();
                p1.Validacion();
            }
        }
    }
}