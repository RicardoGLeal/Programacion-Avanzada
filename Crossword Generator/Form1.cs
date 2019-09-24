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
        int lalalala;
        Pistas ventanaPistas = new Pistas();
        List<Word> wordsList = new List<Word>();
        Random random = new Random();
        int indice = 0;
        private string textfilepath = "..\\..\\words.txt";
        Dictionary<string, string> wordsDic = new Dictionary<string, string>();
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
            InicializeBoard();
            InicializePistas();
            GenerateWords(5);
        }

        private void GenerateWords(int difficulty)
        {
            String readLiner = "";
            char[] sep = { ':' };
            using (StreamReader fileWords = new StreamReader(textfilepath))
            {
                while ((readLiner = fileWords.ReadLine()) != null)
                {
                    String[] words = readLiner.Split(sep, 2);
                    wordsDic.Add(words[0], words[1]);
                }

                Random rand = new Random();
                wordsDic = wordsDic.OrderBy(x => rand.Next())
                .ToDictionary(item => item.Key, item => item.Value);
                Word[] word = new Word[difficulty];
                // WriteWords(word, difficulty);

                switch (difficulty)
                {
                    case 7:
                        difficulty = RandomNumber(difficulty, 9);
                        break;
                    case 10:
                        difficulty = RandomNumber(difficulty, 20);
                        break;
                }

                int i = difficulty;
                foreach (var cheque in wordsDic)
                {
                    if (i > 0)
                    {
                       // ventanaPistas.mainTable.Rows.Add(new String[] { null, cheque.Key, cheque.Value });
                        wordsList.Add(new Word(cheque.Key, cheque.Value));
                        i--;

                    }
                }
                WriteWords(wordsList, difficulty);
                DeleteRows();
            }
        }

        private bool WriteWords(List<Word> wordsList, int difficulty)
        {
            String biggestWord;
            biggestWord = wordsList[0].word;

            for (int i = 0; i < wordsList.Count; i++)
            {
                if (wordsList[i].word.Length > biggestWord.Length)
                {
                    Word ac = new Word();
                    ac = wordsList[i];
                    wordsList[i] = wordsList[0];
                    wordsList[0] = ac;
                }
            }
            int indice = 1;
            foreach (var item in wordsList)
            {
                item.indice = indice++;
            }

            String orientation = RandomOrientation();
            wordsList[0].orientation = orientation;

            WriteBiggestWord(ref orientation);

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
            if (orientation == "horizontal")
            {
                wordsList[0].xInicial = board.Columns.Count/2 - (wordsList[0].word.Length / 2);
                wordsList[0].yInicial = board.Rows.Count/2;
            }
            else //Si la orientación es vertical: 
            {
                wordsList[0].yInicial = board.Rows.Count / 2 - (wordsList[0].word.Length / 2);
                wordsList[0].xInicial = board.Columns.Count / 2;
            }
            int x = wordsList[0].xInicial;
            int y = wordsList[0].yInicial;

            if (orientation == "horizontal")
            {
                for (int i = 0; i < wordsList[0].word.Length; i++)
                    EditableCell(wordsList[0].yInicial, x++, "" + wordsList[0].word[i]);
            }
            else
                for (int i = 0; i < wordsList[0].word.Length; i++)
                    EditableCell(y++, wordsList[0].xInicial, "" + wordsList[0].word[i]);
            wordsList[0].written = true;
            wordsList[0].orientation = orientation;
            indice++;
            ventanaPistas.mainTable.Rows.Add(new String[] { ""+indice, wordsList[0].orientation, wordsList[0].pista });
            board[wordsList[0].xInicial, wordsList[0].yInicial].Value = "" + indice;
        }
        private bool CompleteWritting(ref string orientation)
        {
            int previousWord = 0;

        startwriting:
            if (orientation == "horizontal")
                orientation = "vertical";
            else orientation = "horizontal";

            int randomWord = 0;

        randomizeBox:
            int posRandomBox = RandomNumber(0, wordsList[previousWord].word.Count());
            char randomBox = wordsList[previousWord].word[posRandomBox];
            int randomwordIntersect = 0;

        randomizeword:
            if (GetRandomWord(wordsList, randomBox, ref randomwordIntersect, ref randomWord))
                if (AcomodarPalabra(wordsList, posRandomBox, randomWord, randomwordIntersect, orientation, previousWord))
                {
                    if (!IsItOver())
                    {
                        previousWord = randomWord;
                        goto startwriting;
                    }
                    else
                        return true;
                }
                else
                {
                    lalalala++;
                    if (lalalala > 10)
                        previousWord = GetRandomWritterWord(orientation);
                    goto randomizeBox;
                }

            else
            {
                lalalala++;
                if (lalalala > 10)
                    previousWord = GetRandomWritterWord(orientation);
                goto randomizeBox;
            }
        }

        private int GetRandomWritterWord(string orientation)
        {
            int pos;
        here:
            pos = RandomNumber(0, wordsList.Count());
            if (wordsList[pos].written == true)
            {
                if (wordsList[pos].orientation != orientation)
                    return pos;
                else
                    goto here;
            }
            else
                goto here;
        }
        private bool IsItOver()
        {
            foreach (var item in wordsList)
            {
                if (item.written == false)
                    return false;
            }
            return true;
        }

        private bool GetRandomWord(List<Word> wordsList, char randomBox, ref int randomwordIntersect, ref int randomWord)
        {
            randomWord = 0;
            foreach (var item in wordsList)
            {
                if (item.written == false)
                {
                    for (int i = 0; i < item.word.Length; i++)
                    {
                        if ((item.word[i] == randomBox))
                        {
                            randomwordIntersect = i;
                            return true;
                        }
                    }
                }
                randomWord++;
            }
            return false;
        }

        private bool AcomodarPalabra(List<Word> wordsList, int posRandomBox, int randomWord, int intersectPos, string orientation, int previousWord)
        {
            if (orientation == "vertical")
            {
                wordsList[randomWord].xInicial = wordsList[previousWord].xInicial + posRandomBox;
                wordsList[randomWord].yInicial = wordsList[previousWord].yInicial - intersectPos;
                int y = wordsList[randomWord].yInicial;
                for (int i = 0; i < wordsList[randomWord].word.Length; i++)
                {
                    if (!(CheckCell(y++, wordsList[randomWord].xInicial, "" + wordsList[randomWord].word[i],orientation, intersectPos, previousWord)))
                        return false;
                }
                y = wordsList[randomWord].yInicial;
                for (int i = 0; i < wordsList[randomWord].word.Length; i++)
                {
                    if (!(EditableCell(y++, wordsList[randomWord].xInicial, "" + wordsList[randomWord].word[i])))
                        return false;
                }
                wordsList[randomWord].written = true;
                wordsList[randomWord].orientation = "vertical";
                indice++;
                ventanaPistas.mainTable.Rows.Add(new String[] { "" + indice, wordsList[randomWord].orientation, wordsList[randomWord].pista});
                board[wordsList[randomWord].xInicial, wordsList[randomWord].yInicial].Value = "" + indice;
                return true;
            }
            else
            if (orientation == "horizontal")
            {
                wordsList[randomWord].xInicial = wordsList[previousWord].xInicial - intersectPos;
                wordsList[randomWord].yInicial = wordsList[previousWord].yInicial + posRandomBox;
                int x = wordsList[randomWord].xInicial;
                for (   int i = 0; i < wordsList[randomWord].word.Length; i++)
                {
                    if (!(CheckCell(wordsList[randomWord].yInicial, x++, "" + wordsList[randomWord].word[i], orientation, intersectPos, previousWord)))
                        return false;
                }
                x = wordsList[randomWord].xInicial;
                for (int i = 0; i < wordsList[randomWord].word.Length; i++)
                {
                    if (!(EditableCell(wordsList[randomWord].yInicial, x++, "" + wordsList[randomWord].word[i])))
                        return false;
                }
                wordsList[randomWord].written = true;
                wordsList[randomWord].orientation = "horizontal";
                indice++;
                ventanaPistas.mainTable.Rows.Add(new String[] { "" + indice, wordsList[randomWord].orientation, wordsList[randomWord].pista });
                board[wordsList[randomWord].xInicial, wordsList[randomWord].yInicial].Value = "" + indice;
                return true;
            }
            return false;
        }



        private void InicializePistas()
        {
            ventanaPistas.Show();
        }

        private void InicializeBoard()
        {
            board.Enabled = true;
            but_easy.Hide();
            but_middle.Hide();
            but_hard.Hide();
            board.Show();
            board.BackgroundColor = Color.White;

            for (int i = 0; i < 40; i++)
            {
                board.Columns.Add("Columna" + i, "");
                board.Rows.Add();
            }
            foreach (DataGridViewColumn columna in board.Columns)
                columna.Width = board.Width / board.Columns.Count;
            foreach (DataGridViewRow fila in board.Rows)
                fila.Height = board.Height / board.Columns.Count;
            for (int row = 0; row < board.Rows.Count; row++)
                for (int col = 0; col < board.Columns.Count; col++)
                    board[col, row].ReadOnly = true;
        }

        private bool CheckCell(int row, int col, string letter, string orientation, int intersect, int previousWord)
        {
            //DataGridViewCell celda = board[col, row];
            int cole = col, rowe = row;
            if (board[col, row].Tag == null)
            {
                if (orientation == "vertical")
                {
                    cole--;
                    if (board[cole, row].Tag == null || wordsList[previousWord].yInicial == row)
                    {
                        cole += 2;
                        if (board[cole, row].Tag == null || wordsList[previousWord].yInicial == row)
                            return true;
                        else return false;
                    }
                    else return false;
                
                }
                else if (orientation == "horizontal")
                {
                    rowe--;
                    if (board[col, rowe].Tag == null || wordsList[previousWord].xInicial == col)
                    {
                        rowe += 2;
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
                if ("" + board[col, row].Tag == letter)
                {
                    if (orientation == "vertical")
                    {
                        cole--;
                        if (board[cole, row].Tag == null || wordsList[previousWord].yInicial == row)
                        {
                            cole += 2;
                            if (board[cole, row].Tag == null || wordsList[previousWord].yInicial == row)
                                return true;
                            else return false;
                        }
                        else return false;

                    }
                    else if (orientation == "horizontal")
                    {
                        rowe--;
                        if (board[col, rowe].Tag == null || wordsList[previousWord].xInicial == col)
                        {
                            rowe += 2;
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
            DataGridViewCell celda = board[col, row];
            celda.ReadOnly = false;
                celda.Tag = letter;
            if (letter != "" + celda.Tag)
                return false;
            else
            {
                celda.Style.BackColor = Color.Black;
                celda.Style.ForeColor = Color.White;
                celda.Style.SelectionBackColor = Color.Blue;
                return true;
            }

        }
        private void But_middle_Click(object sender, EventArgs e)
        {
            InicializeBoard();
            InicializePistas();
            GenerateWords(7);
        }

        private void But_hard_Click(object sender, EventArgs e)
        {
            InicializeBoard();
            InicializePistas();
            GenerateWords(10);
        }
        public int RandomNumber(int min, int max)
        {

            return random.Next(min, max);
        }

        public string RandomOrientation()
        {
            var names = new List<string> { "horizontal", "vertical" };
            Random random = new Random();
            int index = random.Next(names.Count);
            var orientation = names[index];
            names.RemoveAt(index);
            return orientation;
        }

        public void DeleteRows()
        {
            bool eliminar = false;
            for (int i = 0; i < board.Columns.Count; i++)
            {
                for (int a = 0; a < board.Rows.Count; a++)                    
                {
                    if (board[i, a].Style.BackColor == Color.Black)
                    {
                        eliminar = false;
                        break;
                    }
                    else eliminar = true;
                }
                if(eliminar)
                    board.Columns.RemoveAt(i);
            }

            foreach (DataGridViewColumn columna in board.Columns)
                columna.Width = board.Width / board.Columns.Count;
            foreach (DataGridViewRow fila in board.Rows)
                fila.Height = board.Height / board.Columns.Count;

        }
        public class Word
        {
            public String word;
            public int xInicial;
            public int yInicial;
            public string orientation;
            public int indice;
            public string pista;
            public bool written = false;

            public Word()
            {
            }

            public Word(string word, string pista)
            {
                this.word = word;
                this.pista = pista;
            }
        }
    }
}

