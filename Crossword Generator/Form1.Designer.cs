﻿namespace Crossword_Generator
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.but_easy = new System.Windows.Forms.Button();
            this.but_middle = new System.Windows.Forms.Button();
            this.but_hard = new System.Windows.Forms.Button();
            this.board = new System.Windows.Forms.DataGridView();
            this.validateButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            this.SuspendLayout();
            // 
            // but_easy
            // 
            this.but_easy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.but_easy.Location = new System.Drawing.Point(431, 165);
            this.but_easy.Name = "but_easy";
            this.but_easy.Size = new System.Drawing.Size(290, 77);
            this.but_easy.TabIndex = 0;
            this.but_easy.Text = "Fácil";
            this.but_easy.UseVisualStyleBackColor = false;
            this.but_easy.Click += new System.EventHandler(this.But_easy_Click);
            // 
            // but_middle
            // 
            this.but_middle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.but_middle.Location = new System.Drawing.Point(431, 268);
            this.but_middle.Name = "but_middle";
            this.but_middle.Size = new System.Drawing.Size(290, 74);
            this.but_middle.TabIndex = 1;
            this.but_middle.Text = "Intermedio";
            this.but_middle.UseVisualStyleBackColor = false;
            this.but_middle.Click += new System.EventHandler(this.But_middle_Click);
            // 
            // but_hard
            // 
            this.but_hard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.but_hard.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.but_hard.Location = new System.Drawing.Point(431, 382);
            this.but_hard.Name = "but_hard";
            this.but_hard.Size = new System.Drawing.Size(290, 74);
            this.but_hard.TabIndex = 2;
            this.but_hard.Text = "Difícil";
            this.but_hard.UseVisualStyleBackColor = false;
            this.but_hard.Click += new System.EventHandler(this.But_hard_Click);
            // 
            // board
            // 
            this.board.AllowUserToAddRows = false;
            this.board.AllowUserToDeleteRows = false;
            this.board.AllowUserToResizeColumns = false;
            this.board.AllowUserToResizeRows = false;
            this.board.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.board.ColumnHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.471698F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(1);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.board.DefaultCellStyle = dataGridViewCellStyle6;
            this.board.Dock = System.Windows.Forms.DockStyle.Fill;
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.RowHeadersVisible = false;
            this.board.RowHeadersWidth = 45;
            this.board.Size = new System.Drawing.Size(1397, 949);
            this.board.TabIndex = 3;
            // 
            // validateButton
            // 
            this.validateButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.validateButton.Location = new System.Drawing.Point(1247, 12);
            this.validateButton.Name = "validateButton";
            this.validateButton.Size = new System.Drawing.Size(124, 49);
            this.validateButton.TabIndex = 4;
            this.validateButton.Text = "Validar";
            this.validateButton.UseVisualStyleBackColor = false;
            this.validateButton.Visible = false;
            this.validateButton.Click += new System.EventHandler(this.validateButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 949);
            this.Controls.Add(this.validateButton);
            this.Controls.Add(this.but_hard);
            this.Controls.Add(this.but_middle);
            this.Controls.Add(this.but_easy);
            this.Controls.Add(this.board);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crossword Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button but_easy;
        private System.Windows.Forms.Button but_middle;
        private System.Windows.Forms.Button but_hard;
        private System.Windows.Forms.DataGridView board;
        private System.Windows.Forms.Button validateButton;
    }
}

