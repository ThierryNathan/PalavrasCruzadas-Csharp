﻿namespace PALAGRASCRUZADAS
{
    partial class Dicas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabelaDicas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaDicas)).BeginInit();
            this.SuspendLayout();
            // 
            // tabelaDicas
            // 
            this.tabelaDicas.AllowUserToAddRows = false;
            this.tabelaDicas.AllowUserToDeleteRows = false;
            this.tabelaDicas.AllowUserToResizeColumns = false;
            this.tabelaDicas.AllowUserToResizeRows = false;
            this.tabelaDicas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabelaDicas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.tabelaDicas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabelaDicas.Location = new System.Drawing.Point(0, 0);
            this.tabelaDicas.Name = "tabelaDicas";
            this.tabelaDicas.RowHeadersVisible = false;
            this.tabelaDicas.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tabelaDicas.Size = new System.Drawing.Size(384, 531);
            this.tabelaDicas.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nº";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 35;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Direção";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.HeaderText = "Dicas";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Dicas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 531);
            this.Controls.Add(this.tabelaDicas);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dicas";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Dicas";
            ((System.ComponentModel.ISupportInitialize)(this.tabelaDicas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        public System.Windows.Forms.DataGridView tabelaDicas;
    }
}