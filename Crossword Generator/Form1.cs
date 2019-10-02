using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Threading;

namespace Crossword_Generator
{

    public partial class Form1 : Form
    {
        Pistas ventanaPistas = new Pistas();//Declaración de la ventana en la que se mostrarán las pistas y la orientación de las palabras.
        List<Word> wordsList = new List<Word>();
        Random random = new Random();
        private string textfilepath = "..\\..\\words.txt";//Ruta del archivo txt
        Dictionary<string, string> wordsDic = new Dictionary<string, string>();//Declaración de diccionario el cual contedrá las palabras y pistas.
        int wordTries;
        int indice = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            board.Hide();
        }

        private void But_easy_Click(object sender, EventArgs e)
        {
            InicializeBoard(5);
            InicializePistas();
            GenerateWords(5);
            validateButton.Visible = true;//Hacemos visible el botón para validar las respuestas.
        }
        private void But_middle_Click(object sender, EventArgs e)
        {
            InicializeBoard(7);
            InicializePistas();
            GenerateWords(7);
            validateButton.Visible = true;//Hacemos visible el botón para validar las respuestas.
        }
        private void But_hard_Click(object sender, EventArgs e)
        {
            InicializeBoard(10);
            InicializePistas();
            GenerateWords(10);
            validateButton.Visible = true;//Hacemos visible el botón para validar las respuestas.
        }
        private void InicializeBoard(int difficulty)
        {
            board.Enabled = true;//Habilitamos el gridview
            but_easy.Hide();//Escondemos el botón de fácil.
            but_middle.Hide();//Escondemos el botón de intermedio.
            but_hard.Hide();//Escondemos el botón de difícil.
            board.Show();//Mostramos el gridview.
            board.BackgroundColor = Color.White;//Establecemos el collor de fondo del gridview a blanco.
            int dimensionsGrid=40; //Esta variable va a definir cuantas filas y columnas existirán en el grid
            switch (difficulty)
            {
                case 5://Si la dificultad es fácil
                    dimensionsGrid = 40;//Habrán 40 filas y columnas
                    break;
                case 7:
                    dimensionsGrid = 50;//Habrán 50 filas y columnas
                    break;
                case 10:
                    dimensionsGrid = 55;//Habrán 55 filas y columnas
                    break;
            }

            for (int i = 0; i < dimensionsGrid; i++)
            {
                board.Columns.Add("Columna" + i, "");//Agregamos una columna nueva a la gridview
                board.Rows.Add();//Agregamos una fila nueva a la gridview
            }
            foreach (DataGridViewColumn columna in board.Columns)
                columna.Width = board.Width / board.Columns.Count;//Ajustamos el ancho de cada columna para que todas midan lo mismo.
            foreach (DataGridViewRow fila in board.Rows)
                fila.Height = board.Height / board.Columns.Count;//Ajustamos el alto de cada columna para que todas midan lo mismo.
            for (int row = 0; row < board.Rows.Count; row++)
                for (int col = 0; col < board.Columns.Count; col++)
                    board[col, row].ReadOnly = true;//Especificamos que las celdas sean sólo de lectura. 
        }
        private void GenerateWords(int difficulty)
        {
            String readLiner = "";
            char[] sep = { ':' }; //Esta variable guarda el delimitador que se utilizará para separar las palabras y las pistas en el txt.

            using (StreamReader fileWords = new StreamReader(textfilepath))
            {
                while ((readLiner = fileWords.ReadLine()) != null)
                {
                    String[] words = readLiner.Split(sep, 2);
                    wordsDic.Add(words[0], words[1]);//Agregamos a el diccionario las 20 palabras palabras junto con su pista correspondiente
                }

                //Las siguientes dos instrucciones se encargarán de mezclar el diccionario.
                Random rand = new Random();
                wordsDic = wordsDic.OrderBy(x => rand.Next()).ToDictionary(item => item.Key, item => item.Value);

                switch (difficulty)
                {
                    case 7:
                        difficulty = RandomNumber(difficulty, 9);//Si la dificultad es media:7, se obtendrá un número aleatorio del 7 al 9 el cual definirá cuantas palabras habrá en el crucigrama.
                        break;
                    case 10:
                        difficulty = RandomNumber(difficulty, 20);//Si la dificultad es elevada:10, se obtendrá un número aleatorio del 10 al 20 el cual definirá cuantas palabras habrá en el crucigrama.
                        break;
                }

                int i = difficulty;

                foreach (var cheque in wordsDic)
                {
                    if (i > 0)
                    {
                        wordsList.Add(new Word(cheque.Key, cheque.Value));//Añadimos a esta lista el número de palabras-pistas según la dificultad.
                        i--;
                    }
                }
                WriteWords();
                DeleteRows();
            }
        }
        private bool WriteWords()
        {
            String biggestWord = wordsList[0].word; //Declaramos una variable que nos ayudará a encontrar la palabra más
            //grande y así poder guardarla en la primer posición del arreglo.

            for (int i = 0; i < wordsList.Count; i++)//Este for nos servirá para poder encontrar la palabra más grande.
            {
                if (wordsList[i].word.Length > biggestWord.Length)//Comparamos si biggestWord es mayor que la palabra actual de la lista
                {
                    Word ac = new Word();
                    ac = wordsList[i];
                    //Invertimos las posiciones de ambas palabras, para que en la posición 0 pueda quedar la palabra mayor
                    wordsList[i] = wordsList[0];
                    wordsList[0] = ac;
                }
            }

            String orientation = RandomOrientation(); //Esta string define la orientación de la primer palabra, es aleatorio el valor.
            wordsList[0].orientation = orientation;//Guardamos la orientación en el objeto que corresponde a la primer palabra.

            WriteBiggestWord(ref orientation);//Mandamos llamar a la función que escribirá la primer palabra, le mandamos como parámetro su orientación.

            foreach (var item in wordsList)
            {
                if (item.written == false)
                    if (CompleteWritting(ref orientation))
                        return true;
            }
            return true;
        }
        private void WriteBiggestWord(ref string orientation)
        {
            if (orientation == "horizontal")//Si la orientación es horizontal...
            {
                wordsList[0].xInicial = board.Columns.Count / 2 - (wordsList[0].word.Length / 2); //La posicion x en la que se escribirá la primer palabra
                wordsList[0].yInicial = board.Rows.Count / 2; //La posicion t en la que se escribirá la primer palabra
            }
            else //Si la orientación es vertical: 
            {
                wordsList[0].yInicial = board.Rows.Count / 2 - (wordsList[0].word.Length / 2);//La posicion y en la que se escribirá la primer palabra
                wordsList[0].xInicial = board.Columns.Count / 2;//La posicion x en la que se escribirá la primer palabra
            }

            int x = wordsList[0].xInicial; //Asignamos a la variable x la coordenada inicial en x de la primer palabra.
            int y = wordsList[0].yInicial; //Asignamos a la variable y la coordenada inicial en y de la primer palabra.

            if (orientation == "horizontal")//Si la orientación de la palabra es horizontal...
            {
                for (int i = 0; i < wordsList[0].word.Length; i++)
                    EditableCell(wordsList[0].yInicial, x++, "" + wordsList[0].word[i]);//Por medio de un ciclo for llama a la función EditableCell, mandándole las coordenadas en las cuales se acomodará cada una de las letras que conforman la palabra. 
                wordsList[0].xFinal = x; //Se asigna la coordenada final en x de la palabra. 
            }
            else// Si la orientación de la palabra es vertical...
                for (int i = 0; i < wordsList[0].word.Length; i++)
                    EditableCell(y++, wordsList[0].xInicial, "" + wordsList[0].word[i]);//Por medio de un ciclo for llama a la función EditableCell, mandándole las coordenadas en las cuales se acomodará cada una de las letras que conforman la palabra. 
            wordsList[0].yFinal = y; //Se asigna la coordenada final en y de la palabra. 


            wordsList[0].written = true;//La variable written del objeto(la cual indica que la palabra ya se acomodó) se cambia a true.
            wordsList[0].orientation = orientation;//La variable orientation del objeto guarda la orientación utilizada para esta palabra.
            indice++;
            
            ventanaPistas.mainTable.Rows.Add(new String[] { "" + indice, wordsList[0].orientation, wordsList[0].pista });//A la gridview utilizada en la subventana para las pistas, se le agrega la pista de la palabra, junto con su índice y orientación.
            board[wordsList[0].xInicial, wordsList[0].yInicial].Value = ""+ board[wordsList[0].xInicial, wordsList[0].yInicial].Value + " " + indice;//En el crucigrama, insertamos el índice de la palabra en el primer cuadro de la palabra.
        }
        private bool CompleteWritting(ref string orientation)
        {
            int previousWord = 0;//Espeficiamos la posición de la palabra anterior, la cual es 0.

        startwriting:
            if (orientation == "horizontal") //Si la orientacion de la palabra anterior fue orizontal..
                orientation = "vertical";    //La orientacion de la nueva palabra será vertical
            else orientation = "horizontal"; //La orientacion de la nueva palabra será horizontal

            int randomWord = 0;

        randomizeBox:
            int posRandomBox = RandomNumber(0, wordsList[previousWord].word.Count());//Se elige una posición aleatoria de la palabra escrita anterior. 
            char randomBox = wordsList[previousWord].word[posRandomBox];//Se guarda el caracter de la posición aleatoria elegida.
            int randomwordIntersect = 0;

        randomizeword:
            if (GetRandomWord(wordsList, randomBox, ref randomwordIntersect, ref randomWord))//Esta funcion busca en la lista de palabras, una palabra que contenga la letra seleccionada.
                if (AcomodarPalabra(wordsList, posRandomBox, randomWord, randomwordIntersect, orientation, previousWord))//Una vez que se encontró una palabra compatible, se manda llamar a esta función para ver si la palabra puede ser acomodada.
                {
                    if (!IsItOver()) //Se llama a la función booleana IsItOver, la cual verifica si ya se escribieron todas las palabras.
                    {
                        previousWord = randomWord; //Ahora previousWord va a tomar el índice de la palabra que acabamos de acomodar, para que ahora pueda ser la base de la una nueva palabra.
                        goto startwriting;//Nos vamos a startwriting para escribir la siguiente palabra.
                    }
                    else
                        return true;
                }
                else//La palabra no se pudo acomodar
                {
                    wordTries++;//Se incrementa nuestra variable auxiliar la cual indica el número de intentos que se han hecho tomando la misma palabra como base.
                    if (wordTries > 10)
                    {
                        previousWord = GetRandomWritterWord(orientation);//Mandamos llamar a GetRandomWritterWord, la cual tomará otra palabra como base.
                        wordTries = 0;
                    }
                    goto randomizeBox;
                }

            else
            {
                wordTries++;//Se incrementa nuestra variable auxiliar la cual indica el número de intentos que se han hecho tomando la misma palabra como base.
                if (wordTries > 10)
                {
                    previousWord = GetRandomWritterWord(orientation);//Mandamos llamar a GetRandomWritterWord, la cual tomará otra palabra como base.
                    wordTries = 0;
                }
                goto randomizeBox;
            }
        }

        private int GetRandomWritterWord(string orientation)
        {
            int pos;
        here:
            pos = RandomNumber(0, wordsList.Count());//Escogemos aleatoriamente el índice de una de las palabras.
            if (wordsList[pos].written == true)//Verificamos que la palabra ya se encuentre escrita.
            {
                if (wordsList[pos].orientation != orientation)//Verificamos que la orientación de la palabra sea contraria a la que va a tener la palabra que se está manejando.
                    return pos;//Retornamos el índice de esa palabra.
                else
                    goto here;//Regresamos a el punto en el que seleccionamos un índice aleatorio.
            }
            else
                goto here;//Regresamos a el punto en el que seleccionamos un índice aleatorio.
        }
        private bool IsItOver()
        {
            foreach (var item in wordsList) //Se verifica si ya fueron escritas todas las palabras.
            {
                if (item.written == false)//Si se encuentra una palabra que todavía no ha sido escrita, se retorna un false.
                    return false;
            }
            return true;//Si todas las palabras ya fueron escritas, se retorna un true.
        }

        private bool GetRandomWord(List<Word> wordsList, char randomBox, ref int randomwordIntersect, ref int randomWord)
        {
            randomWord = 0;
            foreach (var item in wordsList)//Este foreach va a navegar por todas las palabras
            {
                if (item.written == false)
                {
                    for (int i = 0; i < item.word.Length; i++)
                    {
                        if ((item.word[i] == randomBox))//Si la palabra cuenta con el carácter de la posición aleatoria elegida
                        {
                            randomwordIntersect = i;//La variable randomwordIntersect guarda la posición de la letra de la palabra actual que concuerda con la letra buscada.
                            return true;//Se retorna true ya que si se encontró una palabra con la letra buscada.
                        }
                    }
                }
                randomWord++;//Esta variable guarda el índice de la palabra de la cual se está navegando en el foreach
            }
            return false;
        }

        private bool AcomodarPalabra(List<Word> wordsList, int posRandomBox, int randomWord, int intersectPos, string orientation, int previousWord)
        {
            if (orientation == "vertical")//Si la orientación de la palabra es vertical..
            {
                wordsList[randomWord].xInicial = wordsList[previousWord].xInicial + posRandomBox;//Establecemos la coordenada inicial en x de ésta palabra, la cuál va a ser igual que la palabra anterior, pero
                //sumándole la posición en la cual se encuentra la letra con la cual va a encajar.
                wordsList[randomWord].yInicial = wordsList[previousWord].yInicial - intersectPos;
                int y = wordsList[randomWord].yInicial;

                for (int i = 0; i < wordsList[randomWord].word.Length; i++)
                {
                    if (!(CheckCell(y++, wordsList[randomWord].xInicial, "" + wordsList[randomWord].word[i], orientation, previousWord)))
                        return false;
                }

                wordsList[randomWord].yFinal = y;//Se establece la variable yfinal del objeto, la cual almacena la coordenada en y en la cual terminó la palabra.
                y = wordsList[randomWord].yInicial;//La variable auxiliar y se reinicia

                for (int i = 0; i < wordsList[randomWord].word.Length; i++)
                {
                    if (!(EditableCell(y++, wordsList[randomWord].xInicial, "" + wordsList[randomWord].word[i])))
                        return false;
                }
                wordsList[randomWord].written = true;//La variable written del objeto(la cual indica que la palabra ya se acomodó) se cambia a true.
                wordsList[randomWord].orientation = "vertical";
                indice++;
                ventanaPistas.mainTable.Rows.Add(new String[] { "" + indice, wordsList[randomWord].orientation, wordsList[randomWord].pista });
                board[wordsList[randomWord].xInicial, wordsList[randomWord].yInicial].Value = "" + board[wordsList[randomWord].xInicial, wordsList[randomWord].yInicial].Value + " " + indice;
                return true;
            }
            else
            if (orientation == "horizontal")//Si la orientación de la palabra es horizontal..
            {
                wordsList[randomWord].xInicial = wordsList[previousWord].xInicial - intersectPos;
                wordsList[randomWord].yInicial = wordsList[previousWord].yInicial + posRandomBox;

                int x = wordsList[randomWord].xInicial;

                for (int i = 0; i < wordsList[randomWord].word.Length; i++)
                {
                    if (!(CheckCell(wordsList[randomWord].yInicial, x++, "" + wordsList[randomWord].word[i], orientation, previousWord)))
                        return false;
                }
                wordsList[randomWord].xFinal = x;

                x = wordsList[randomWord].xInicial;

                for (int i = 0; i < wordsList[randomWord].word.Length; i++)
                {
                    if (!(EditableCell(wordsList[randomWord].yInicial, x++, "" + wordsList[randomWord].word[i])))
                        return false;
                }

                wordsList[randomWord].written = true; //La variable written del objeto(la cual indica que la palabra ya se acomodó) se cambia a true.
                wordsList[randomWord].orientation = "horizontal";
                indice++;
                ventanaPistas.mainTable.Rows.Add(new String[] { "" + indice, wordsList[randomWord].orientation, wordsList[randomWord].pista });
                board[wordsList[randomWord].xInicial, wordsList[randomWord].yInicial].Value = "" + board[wordsList[randomWord].xInicial, wordsList[randomWord].yInicial].Value + " " + indice;
                return true;
            }
            return false;
        }



        private void InicializePistas()
        {
            ventanaPistas.Show();//Mostramos la ventana de pistas.
        }
        private bool CheckCell(int row, int col, string letter, string orientation, int previousWord)
        {
            int cole = col, rowe = row;//Estas variables serán utilizadas para verificar que se encuentren vacías las celdas que se encuentran a los lados de la celda en la que se quiere escribir.
            if (board[col, row].Tag == null)//Se comprueba el tag de la celda en la que se desea escribir sea nulo.
            {
                if (orientation == "vertical")//Si la orientación de la palabra es vertical...
                {
                    cole--;//Disminuimos cole en 1, para que éste apunte a la celda que está a la izquierda.
                    if (board[cole, row].Tag == null || wordsList[previousWord].yInicial == row)
                    {
                        cole += 2;//Aumentamos cole en 2, para que éste apunte a la celda que está a la derecha.
                        if (board[cole, row].Tag == null || wordsList[previousWord].yInicial == row)
                            return true;
                        else return false;
                    }
                    else return false;

                }
                else if (orientation == "horizontal")//Si la orientación de la palabra se horizontal...
                {
                    rowe--;//Disminuimos rowe en 1, para que éste apunte a la celda que está arriba.
                    if (board[col, rowe].Tag == null || wordsList[previousWord].xInicial == col)
                    {
                        rowe += 2;//Aumentamos rowe en 2, para que éste apunte a la celda que está abajo.
                        if (board[col, rowe].Tag == null || wordsList[previousWord].xInicial == col)
                            return true;
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else
            {
                if ("" + board[col, row].Tag == letter)//Si el tag de la celda coincide con el que el que se desea colocar...
                {
                    if (orientation == "vertical")//Si la orientación de la palabra se vertical...
                    {
                        cole--;//Disminuimos cole en 1, para que éste apunte a la celda que está a la izquierda.
                        if (board[cole, row].Tag == null || wordsList[previousWord].yInicial == row)
                        {
                            cole += 2;//Aumentamos cole en 2, para que éste apunte a la celda que está a la derecha
                            if (board[cole, row].Tag == null || wordsList[previousWord].yInicial == row)
                                return true;
                            else return false;
                        }
                        else return false;

                    }
                    else if (orientation == "horizontal")//Si la orientación de la palabra se horizontal...
                    {
                        rowe--;//Disminuimos rowe en 1, para que éste apunte a la celda que está arriba.
                        if (board[col, rowe].Tag == null || wordsList[previousWord].xInicial == col)
                        {
                            rowe += 2;//Aumentamos rowe en 2, para que éste apunte a la celda que está abajo.
                            if (board[col, rowe].Tag == null || wordsList[previousWord].xInicial == col)
                                return true;
                            else return false;
                        }
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
        }


        private bool EditableCell(int row, int col, string letter)
        {
            DataGridViewCell celda = board[col, row];//Creamos una variable celda de tipo datagridviewcell, ésta variable toma las coordenadas recibidas en esta función.
            celda.ReadOnly = false;//Especifica que la celda ahora ya no será de tipo solo lectura.
            celda.Tag = letter;//Especificamos el tag de la celda a el caracter que debería de ir en esa celda.
            if (letter != "" + celda.Tag)//Se verifica que 
                return false;
            else
            {
                celda.Style.BackColor = Color.White;//Se cambia el color de la celda a blanco.
                celda.Style.SelectionBackColor = Color.Blue;//Se cambia el color de cuando la celda está seleccionada a negro.
                return true;//Se retorna un true a la función, el cual indica que la letra ya se escribio correctamente.
            }

        }
        public int RandomNumber(int min, int max)
        {
            return random.Next(min, max);//Retornamos un número aleatorio con el rango de los valores recibidos.
        }

        public string RandomOrientation()//Esta función se encarga de generar una orientación aleatoria, ya sea horizontal o vertical.
        {
            var names = new List<string> { "horizontal", "vertical" };//Esta variable guarda las dos posibles opciones para la orientación de la palabra
            Random random = new Random();
            int index = random.Next(names.Count);
            var orientation = names[index];
            names.RemoveAt(index);
            return orientation;//Se retorna la orientación obtenida.
        }

        public void DeleteRows()
        {
            /*bool eliminar = false;
            for (int i = 0; i < board.Columns.Count; i++)
            {
                for (int a = 0; a < board.Rows.Count; a++)
                {
                    if (board[i, a].Style.BackColor == Color.White)
                    {
                        eliminar = false;
                        break;
                    }
                    else eliminar = true;
                }
                if (eliminar)
                    board.Columns.RemoveAt(i);
            }
            foreach (DataGridViewColumn columna in board.Columns)
                columna.Width = board.Width / board.Columns.Count;
            foreach (DataGridViewRow fila in board.Rows)
                fila.Height = board.Height / board.Columns.Count;*/

        }
        public class Word
        {
            public String word;
            public int xInicial;
            public int yInicial;
            public int xFinal;
            public int yFinal;
            public string orientation;
            public string pista;
            public bool written = false;

            public Word()
            {
            }

            public Word(string word, string pista)//Constructor que recibe la palabra y la pista.
            {
                this.word = word;
                this.pista = pista;
            }
        }

        private void validateButton_Click(object sender, EventArgs e)
        {
            DataGridViewCell celda;
            bool incorrect = false;
            foreach (var item in wordsList)
            {
                if (incorrect)//Si alguna celda estuvo incorrecta se terminan de revisar las demas y termina el foreach
                    break;

                if (item.orientation == "vertical")//Si la orientación de la palabra es vertical..
                {
                    for (int i = item.yInicial; i < item.yFinal; i++)
                    {
                        celda = board[item.xInicial, i];
                        if (celda.Tag as String != celda.Value as String)
                        {
                            MessageBox.Show("Incorrecto!");
                            incorrect = true;
                            break;
                        }
                        // celda.Style.BackColor = Color.Red;
                    }
                }
                else //Si la orientación de la palabra es vertical..
                {
                    for (int i = item.xInicial; i < item.xFinal; i++)
                    {
                        celda = board[i, item.yInicial];
                        if (celda.Tag as String != celda.Value as String)
                        {
                            MessageBox.Show("Incorrecto!");//Aparece una ventana emergente que muestra el mensaje "Incorrecto".
                            incorrect = true;
                            break;
                        }
                        //celda.Style.BackColor = Color.Red;
                    }
                }
            }
            if (incorrect == false)
                MessageBox.Show("Correcto, Felicitaciones!");//Aparece una ventana emergente que muestra un mensaje de felicitaciones.
        }
    }
}

