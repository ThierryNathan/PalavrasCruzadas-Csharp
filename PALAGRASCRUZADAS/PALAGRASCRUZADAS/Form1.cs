using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PALAGRASCRUZADAS
{
    public partial class Form1 : Form
    {

        Dicas dicas = new Dicas();

        public string arquivoDicas = Application.StartupPath + "\\Palavras\\palavras_1.dicas";

        List<Palavra> palavras = new List<Palavra>();

        private void ConstruirListaDePalavras() 
        {
            string linha = "";
            using (StreamReader leitorDeLinhas = new StreamReader(arquivoDicas)) 
            {
                linha = leitorDeLinhas.ReadLine();
                while ((linha = leitorDeLinhas.ReadLine()) != null)
                {
                    string[] colunasSeparadas = linha.Split('|');

                    palavras.Add (new Palavra(int.Parse(colunasSeparadas[0]),
                                              int.Parse(colunasSeparadas[1]), 
                                                        colunasSeparadas[2],
                                                        colunasSeparadas[3],
                                                        colunasSeparadas[4], 
                                                        colunasSeparadas[5]));

                    dicas.tabelaDicas.Rows.Add(new string[] {colunasSeparadas[3],
                                                             colunasSeparadas[2],
                                                             colunasSeparadas[5]});
                }
            }
        }

        public Form1()
        {
            ConstruirListaDePalavras();
            InitializeComponent();
        }



        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Criado por: Thierry o_o", "Sobre");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializaJogo();
            dicas.SetDesktopLocation(this.Location.X + this.Width + 1, this.Location.Y);
            dicas.StartPosition = FormStartPosition.Manual;
            dicas.Show();
            dicas.tabelaDicas.AutoResizeColumns();
        }

        private void inicializaJogo()
        {
            tabuleiro.BackgroundColor = Color.Black;
            tabuleiro.DefaultCellStyle.BackColor = Color.Black;

            for (int i = 0; i < 22; i++)
            {
                tabuleiro.Rows.Add();
            }

            foreach (DataGridViewColumn coluna in tabuleiro.Columns)
            {
                coluna.Width = tabuleiro.Width / tabuleiro.Columns.Count;
            }

            foreach (DataGridViewRow linha in tabuleiro.Rows)
            {
                linha.Height = tabuleiro.Height / tabuleiro.Rows.Count;
            }

            for (int linha = 0; linha < tabuleiro.Rows.Count; linha++)
            {
                for (int coluna = 0; coluna < tabuleiro.Columns.Count; coluna++)
                {
                    tabuleiro[coluna, linha].ReadOnly = true;
                }

            }

            foreach (Palavra palavra in palavras)
            {
                int colunaInicial = palavra.X;
                int linhaInicial = palavra.Y;

                char[] letrasSeparadas = palavra.palavra.ToCharArray();

                for (int i = 0; i < letrasSeparadas.Length; i++)
                {
                    if (palavra.direcao.ToUpper() == "HORIZONTAL")
                    {
                        FormatarCelula(linhaInicial, colunaInicial + i, letrasSeparadas[i].ToString());
                    }
                    if (palavra.direcao.ToUpper() == "VERTICAL")
                    {
                        FormatarCelula(linhaInicial + i, colunaInicial, letrasSeparadas[i].ToString());
                    }
                }
            }
        }
        private void FormatarCelula(int linha, int coluna, string letra)
        {
            DataGridViewCell celula = tabuleiro[coluna, linha];
            celula.Style.BackColor = Color.White;
            celula.ReadOnly = false;
            celula.Style.SelectionBackColor = Color.Cyan;
            celula.Tag = letra;
        }

        private void tabuleiro_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tabuleiro[e.ColumnIndex, e.RowIndex].Value = tabuleiro[e.ColumnIndex, e.RowIndex].Value.ToString().ToUpper();
            }
            catch
            {

            }

            try
            {
                if (tabuleiro[e.ColumnIndex, e.RowIndex].Value.ToString().Length > 1)
                {
                    tabuleiro[e.ColumnIndex, e.RowIndex].Value = tabuleiro[e.ColumnIndex, e.RowIndex].Value.ToString().Substring(0,1);
                }
            }
            catch 
            {

            }

            try
            {
                if (tabuleiro[e.ColumnIndex, e.RowIndex].Value.ToString().Equals(tabuleiro[e.ColumnIndex, e.RowIndex].Tag.ToString().ToUpper()))
                {
                    tabuleiro[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.DarkGreen;
                }
                else
                {
                    tabuleiro[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red;
                }
            }
            catch
            {

            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog janelaDeAbrirArquivos = new OpenFileDialog();
            janelaDeAbrirArquivos.Filter = "Palavras Cruzadas |*.dicas";

            if (janelaDeAbrirArquivos.ShowDialog().Equals(DialogResult.OK))
            {
                arquivoDicas = janelaDeAbrirArquivos.FileName;

                tabuleiro.Rows.Clear();
                dicas.tabelaDicas.Rows.Clear();
                palavras.Clear();

                ConstruirListaDePalavras();
                inicializaJogo();
            }
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            dicas.SetDesktopLocation(this.Location.X + this.Width + 1, this.Location.Y);
        }

        private void tabuleiro_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            string numero = "";

            if (palavras.Any(c => (numero = c.numero) != "" && c.X == e.ColumnIndex && c.Y == e.RowIndex))
            {
                Rectangle r = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Height, e.CellBounds.Width);
                e.Graphics.FillRectangle(Brushes.White, r);
                Font f = new Font(e.CellStyle.Font.FontFamily, 7);
                e.Graphics.DrawString(numero, f, Brushes.Black, r);
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
        }
    }



    public class Palavra
    {
        public int X;
        public int Y;
        public string direcao;
        public string numero;
        public string palavra;
        public string dica;

        public Palavra(int x, int y, string dir, string n, string p, string dic)
        {
            this.X = x;
            this.Y = y;
            this.direcao = dir;
            this.numero = n;
            this.palavra = p;
            this.dica = dic; 
        }
    }
}
