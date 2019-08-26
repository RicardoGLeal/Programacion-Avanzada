using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Cesar
{
    internal class Password
    {
        private int mPassSize;
        private int mNumberofMayus;
        private int mNumberofMinus;
        private int mNumberofSpecChars;

        private List<string> passwdsList;
        private List<string> encryptedPasswds;
        private List<string> decryptedPasswds;
        public Password(int mPassSize, int mNumberofMayus, int mNumberofSpecChars)
        {
            this.mPassSize = mPassSize;
            this.mNumberofSpecChars = mNumberofSpecChars;
            this.mNumberofMayus = mNumberofMayus;
        }

        public void generatePassword(int numberofPasswords)
        {
            passwdsList = new List<string>();
            int ascii;
            int fPassSize, fNumberofMayus, fNumberofSpecChars, fNumberofMinus;//Estas variables adquieren los mismos valores que los que se mandaron al constructor del objeto.
            char c;
            for (var i = 0; i < numberofPasswords; i++)
            {
                fPassSize = mPassSize;
                fNumberofSpecChars = mNumberofSpecChars;
                fNumberofMayus = mNumberofMayus;
                mNumberofMinus = mPassSize - mNumberofMayus - mNumberofSpecChars;
                fNumberofMinus = mNumberofMinus;
                const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!#$%&/()=?.,:+-*<>@"; //Todos los posibles caracteres para las contraseñas
                var res = new StringBuilder(); //Se crea un stringbuilder que es el que va a conformar las contraseñas.
                var rnd = new Random();

                while (fPassSize > 0)
                {
                    fPassSize--;
                    ascii = (int)valid[rnd.Next(valid.Length)];//Guarda el codigo ascii del caracter generado
                    c = Convert.ToChar(ascii);
                    if (ascii > 64 && ascii < 90) //Se verifica si el char generado es una mayúscula
                    {
                        if (fNumberofMayus > 0) // Se verifica si todavía faltas mayúsculas por generar en la contraseña.
                        {
                            fNumberofMayus--; // Se resta 1 por la mayúscula que se generó
                            res.Append(c); // Se agrega la mayúscula a la string.
                        }
                        else
                        {
                            fPassSize++;
                        }
                    }
                    else if (ascii > 96 && ascii < 123) //Se verifica si el char generado es una minúscula
                    {
                        if (fNumberofMinus > 0)// Se verifica si todavía faltas minúsculas por generar en la contraseña.
                        {
                            fNumberofMinus--; // Se resta 1 por la minúscula que se generó 
                            res.Append(c);
                        }
                        else
                        {
                            fPassSize++;
                        }
                    }
                    else if (ascii > 32 && ascii < 65) //Se verifica si el char generado es caracter especial
                    {
                        if (fNumberofSpecChars > 0)// Se verifica si todavía faltas carácteres especiales por generar en la contraseña.
                        {
                            fNumberofSpecChars--;// Se resta 1 por el caracter especial que se generó
                            res.Append(c);
                        }
                        else
                        {
                            fPassSize++;
                        }

                        //Si el caracter que se generó no se trata de minúsculas, mayúsculas o caracteres especiales,
                        //se descarta y le añade 1 a la variable que lleva el control de cuántos caracteres faltan por agregar
                    }
                    else
                    {
                        fPassSize++;
                    }
                }
                passwdsList.Add(res.ToString()); //Se agrega la contraseña a la lista de contraseñas.
                Console.WriteLine(res.ToString());
                Thread.Sleep(100);//Para que el random funcione adecuadamente se tiene que establecer un tiempo para poder proceder al siguiente random.
            }

        }


        public void encryptPasswds(int interval)
        {
            string password;
            char passwordChar;
            char encryptedChar;
            int newInterval;
            encryptedPasswds = new List<string>();

            for (var i = 0; i < passwdsList.Count; i++)
            {
                var encryptedStr = new StringBuilder();
                password = passwdsList[i]; //String que almacena la contraseña que se está manejando.
                for (var a = 0; a < mPassSize; a++)
                {
                    passwordChar = password[a]; //passwordChar es la variable char que va a tomando el valor de todos los caracteres que conforman las contraseñas.
                    encryptedChar = passwordChar;
                    encryptedChar += Convert.ToChar(interval); //Se le suma el intervalo al caracter.
                    if (passwordChar > 64 && passwordChar < 91) //Se revisa si el caracter es una letra mayúscula.
                    {
                        if (encryptedChar > 90) //Una vez que se le sumó el intervalo al caracter, se comprueba si este rebasa el abacedario, (si rebasa la 'Z').
                        {
                            newInterval = interval - (90 - passwordChar); //Se calcula el intervalo restante, que iniciará a partir de la letra 'A'
                            encryptedChar = Convert.ToChar(64);  //Se especifica que el caracter inicie a contar desde un caracter antes de la 'A'.
                            encryptedChar += Convert.ToChar(newInterval); //Se le suma el intervalo restante a el caracter
                        }
                        encryptedStr.Append(encryptedChar);

                    }
                    else if (passwordChar > 96 && passwordChar < 123)//Se revisa si el caracter es una letra minúscula.
                    {
                        if (encryptedChar > 122)
                        {
                            newInterval = interval - (122 - passwordChar); //Se calcula el intervalo restante, que iniciará a partir de la letra 'a'
                            encryptedChar = Convert.ToChar(96); //Se especifica que el caracter inicie a contar desde un caracter antes de la 'a'.
                            encryptedChar += Convert.ToChar(newInterval);
                        }
                        encryptedStr.Append(encryptedChar);

                    }
                    else
                    {
                        encryptedStr.Append(passwordChar);
                    }
                }
                encryptedPasswds.Add(encryptedStr.ToString()); //Se añade la contraseña encriptada a la lista de contraseñas encriptadas.
                Console.WriteLine(/*"Contraseña encriptada "+i+": "+ */encryptedStr.ToString());
            }
        }
        public void decryptPasswds(int interval)
        {
            string password;
            char passwordChar;
            char decryptedChar;
            int newInterval;
            decryptedPasswds = new List<string>();

            for (var i = 0; i < passwdsList.Count; i++)
            {
                var encryptedStr = new StringBuilder();
                password = encryptedPasswds[i];
                for (var a = 0; a < mPassSize; a++)
                {
                    passwordChar = password[a];
                    decryptedChar = passwordChar;
                    decryptedChar -= Convert.ToChar(interval); //Se genera la desencriptación del caracter, restándole a este su intervalo.
                    if (passwordChar > 64 && passwordChar < 91) //Se revisa si el caracter es una letra mayúscula.
                    {
                        if (decryptedChar < 65) //Una vez que se le resta el intervalo al caracter, se comprueba si este superó a la letra 'A'
                        {
                            newInterval = interval - (passwordChar - 65); //Se calcula el intervalo faltante, el cual iniciará a contar desde una posición antes de la letra 'A'
                            decryptedChar = Convert.ToChar(91);
                            decryptedChar -= Convert.ToChar(newInterval);
                        }
                        encryptedStr.Append(decryptedChar);
                    }
                    else if (passwordChar > 96 && passwordChar < 123)//Se revisa si el caracter es una letra minúscula.
                    {
                        if (decryptedChar < 97) //Una vez que se le resta el intervalo al caracter, se comprueba si este superó a la letra 'a'
                        {
                            newInterval = interval - (passwordChar - 97);
                            decryptedChar = Convert.ToChar(123);
                            decryptedChar -= Convert.ToChar(newInterval);
                        }
                        encryptedStr.Append(decryptedChar);
                    }
                    else
                    {
                        encryptedStr.Append(passwordChar);
                    }
                }
                decryptedPasswds.Add(encryptedStr.ToString());
                Console.WriteLine(/*"Contraseña desencriptada "+i+": "+ */encryptedStr.ToString());
            }
        }

    }

    internal class Program
    {
        private static void Main(string[] args)
        {

            int numberofPasswords;
            int ePassSize;
            int eNumberofMayus;
            int eNumberofSpecChars;
            int interval;

        StartPetition:
            Console.WriteLine("Cuantos passwords desea generar?");
            numberofPasswords = int.Parse(Console.ReadLine());
            Console.WriteLine("De que tamaño será cada password?");
            ePassSize = int.Parse(Console.ReadLine());
            if (ePassSize <= 0)
            {
                Console.Clear();
                Console.WriteLine("El tamaño de la constraseña no puede ser menor a 1");
                Console.WriteLine("Intente nuevamente");
                goto StartPetition;
            }
            else
            {
            MayusPetition:
                Console.WriteLine("Cuántas mayúsculas debo poner en los passwords?");
                eNumberofMayus = int.Parse(Console.ReadLine());
                if (eNumberofMayus > ePassSize)
                {
                    Console.Clear();
                    Console.WriteLine("El número de mayúsculas no puede ser mayor a el tamaño de la contraseña");
                    Console.WriteLine("Intente nuevamente");
                    goto MayusPetition;
                }
                else
                {
                SpecCharPetition:
                    Console.WriteLine("Cuántos caracteres especiales debo poner en los passwords?");
                    eNumberofSpecChars = int.Parse(Console.ReadLine());
                    if (eNumberofSpecChars > ePassSize)
                    {
                        Console.Clear();
                        Console.WriteLine("El número de carácteres especiales no puede ser mayor a el tamaño de la contraseña");
                        Console.WriteLine("Intente nuevamente");
                        goto SpecCharPetition;
                    }
                    else
                    {
                        var p1 = new Password(ePassSize, eNumberofMayus, eNumberofSpecChars);//Se le mandan al constructor los valores establecidos por el usuario.
                        p1.generatePassword(numberofPasswords);
                        Console.WriteLine("Escribe el intervalo para la encriptación");
                        interval = int.Parse(Console.ReadLine());
                        Console.WriteLine("Contraseñas Encriptada a intervalo: " + interval);
                        Console.WriteLine();
                        p1.encryptPasswds(interval);
                        Console.WriteLine("Contraseñas Desencriptadas a intervalo: " + interval);
                        Console.WriteLine();
                        p1.decryptPasswds(interval);
                        Console.WriteLine("Presiona una tecla para continuar...");
                        Console.ReadKey();
                        Console.Clear();
                        goto StartPetition;
                    }
                }
            }
        }
    }
}