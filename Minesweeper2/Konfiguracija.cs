using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IgraKlasa;

namespace Minesweeper2
{
    public partial class Konfiguracija : Form
    {
        private Button[,] matricaDugmica;
        int[,] matrica;
        int maxMine=10;
        int postMin = 0;
        Igra igra;
       
        public Konfiguracija(Igra mojaIgra)
        {
            this.Size = new Size(353, 120);
            igra = mojaIgra;
            InitializeComponent();
            label3.Visible = false;
            label4.Visible = false;
            panel1.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                label3.Visible = true;
                label4.Visible = true;
                panel1.Visible = true;
                postMin = 0;

                maxMine = (int)numericUpDown2.Value;
                label4.Text = maxMine.ToString();

                int dimenzija=(int)numericUpDown1.Value;
                panel1.Controls.Clear();

                matricaDugmica = new Button[dimenzija, dimenzija];

            for (int i = 0; i < dimenzija; i++)
                for (int j = 0; j < dimenzija; j++)
                {
                    matricaDugmica[i, j] = new Button();
                }

            panel1.Size = new Size(dimenzija * 25, dimenzija * 25);

            if (dimenzija * 25>=300)
                this.Size = new Size(panel1.Width+70, panel1.Height+150);
            else
                this.Size = new Size(353, panel1.Height + 150);

            for (int i = 0; i < dimenzija; i++)
                for (int j = 0; j < dimenzija; j++)
                {
                    Button polje = matricaDugmica[i, j];
                    polje.Width = 25;
                    polje.Height = 25;
                    polje.Name = i + "," + j;
                    polje.Text = ""; //matricaPolja[i,j].ToString();
                    polje.Location = new Point(i * 25, j * 25);

                    polje.MouseUp += polje_Click;

                    panel1.Controls.Add(polje);
                }
        
            }

            else
            {
                this.Size = new Size(353, 120);
                panel1.Controls.Clear();
                panel1.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
            }

        }

        private void polje_Click(object sender, EventArgs e)
        {
            Button dugme = (Button)sender;

            if (dugme.Text == "X") 
            {
                dugme.Text = "";
                postMin--;
            }

            else if (dugme.Text == "" && (maxMine - postMin)>0)
            {
                dugme.Text = "X";
                postMin++;
            }

            panel1.Focus();
            label4.Text = (maxMine - postMin).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)  
            {
                int maxm = (int)numericUpDown2.Value;
                int dimenzija=(int)numericUpDown1.Value;

                igra.Konfiguracija(dimenzija, maxm);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            else if (checkBox1.Checked && (maxMine - postMin) == 0)
            {
                int maxm = (int)numericUpDown2.Value;
                int dimenzija = (int)numericUpDown1.Value;

                matrica = new int[dimenzija, dimenzija];
                for (int i = 0; i < dimenzija; i++)
                    for (int j = 0; j < dimenzija; j++)
                    {
                        Button dugme = (Button)panel1.Controls[i + "," + j];

                        if (dugme.Text == "")
                            matrica[i, j] = 0;
                        else
                            matrica[i, j] = 9;
                    }
                igra.AdminKonfig(dimenzija, maxm, matrica);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            //nije dovoljan broj bombi
            else
            {
                MessageBox.Show("Potrebno je postaviti sve bombe.", "Greska",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                return;
            }
        }

    }
}
