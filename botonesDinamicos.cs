using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button botonDinamico = new Button();
            Label L1 = new Label();
            L1.Location = new Point(30, 120);
            L1.Text = "HOLA";
            Controls.Add(L1);

            Button b2 = new Button();
            b2.Width = 30;
            b2.Height = 120;
            b2.Location = new Point(30, 120);
            b2.Text = "aaa";
            Controls.Add(b2);

            botonDinamico.Location = new Point(30, 120);
            botonDinamico.Width = 30;
            botonDinamico.Height = 100;
            botonDinamico.Text = "Soy una tostadora";
            botonDinamico.BackColor = Color.Aqua;
            botonDinamico.Name = "Btntostadora";
            botonDinamico.Font = new Font("Georgia", 16);
            Controls.Add(botonDinamico);

            botonDinamico.Click += new EventHandler(Btntostadora_Click);
            {
            }


        }

        private void Btntostadora_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
