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
    public partial class Form1 : Form
    {
        public static Igra mojaIgra;
        private Button[,] matricaDugmica;
        private int proteklovreme;

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(289, 108);
            mojaIgra = new Igra();

            zavrsiIgruToolStripMenuItem.Enabled = false;
            sacuvajIgruToolStripMenuItem.Enabled = false;
        }
        private Boolean cheat=false;
        private int inovo = 0, jnovo = 0, istaro = 0, jstaro = 0;
        private void NovaIgraRandom()
        {
            proteklovreme = 0;
            lab_vreme.Text = "0:0";
            timer1.Start();
            button1.Text = ": )";
            inovo = 0; jnovo = 0; istaro = 0; jstaro = 0;
        mojaIgra.InstancirajIgruRandom();
            zavrsiIgruToolStripMenuItem.Enabled = true;
            sacuvajIgruToolStripMenuItem.Enabled = true;
            la_brMina.Text = mojaIgra.BrojMina.ToString();
            MatricaDugmica(false);  
            
        }

        private void NovaIgra()
        {
            proteklovreme = 0;
            lab_vreme.Text = "0:0";
            timer1.Start();
            button1.Text = ": )";
            mojaIgra.PostMine = 0;
            inovo = 0; jnovo = 0; istaro = 0; jstaro = 0; ;
            zavrsiIgruToolStripMenuItem.Enabled = true;
            sacuvajIgruToolStripMenuItem.Enabled = true;
            la_brMina.Text = mojaIgra.BrojMina.ToString();
            MatricaDugmica(false);
        }

        private void StaraIgra()
        {
            proteklovreme = mojaIgra.Proteklovreme;
            lab_vreme.Text = "x:x";
            timer1.Start();
            button1.Text = ": )";
            inovo = 0; jnovo = 0; istaro = 0; jstaro = 0;
            mojaIgra.KrajIgre = false;
            zavrsiIgruToolStripMenuItem.Enabled = true;
            sacuvajIgruToolStripMenuItem.Enabled = true;
            la_brMina.Text = (mojaIgra.BrojMina-mojaIgra.PostMine).ToString();
            MatricaDugmica(true);
        }

        private void vreme(object sender, EventArgs e)
        {
            

            int min = proteklovreme / 60;
            int sec = proteklovreme % 60;

            lab_vreme.Text = min.ToString() + ":" + sec.ToString();

            if (cheat)
            {
                funkcija(inovo, jnovo);

                inkrementiraj();
            }

            proteklovreme++;
        }

        private void funkcija(int i,int j)
        {
            Button dugme = (Button)panel.Controls[i + "," + j];
            Button otvoreno = (Button)panel.Controls[istaro + "," + jstaro];

            if (otvoreno.Enabled == false)
            {
                otvoreno.Enabled = true;
                otvoreno.Text = "";
            }

            if (dugme.Enabled == true && dugme.Text != "?")
            {
                dugme.Enabled = false;
                if (mojaIgra.MatricaPolja[i, j] == 9)
                    dugme.Text = "@";
                else if (mojaIgra.MatricaPolja[i, j] == 0)
                    dugme.Text = "";
                else
                    dugme.Text = mojaIgra.MatricaPolja[i, j].ToString();

                istaro = i;
                jstaro = j;
            }
            else
            {
                inkrementiraj();
                funkcija(inovo, jnovo);
            }

        }

        private void inkrementiraj()
        {
            jnovo++;
            int dim = mojaIgra.Dimenzija;
            if (jnovo == dim)
            {
                jnovo = 0;
                inovo++;
            }

            if (inovo == dim)
            {
                inovo = 0;
            }
        }

        private void MatricaDugmica(bool stara)
        {
            panel.Controls.Clear();
            matricaDugmica = new Button[mojaIgra.Dimenzija, mojaIgra.Dimenzija];

            for (int i = 0; i < mojaIgra.Dimenzija; i++)
                for (int j = 0; j < mojaIgra.Dimenzija; j++)
                {
                    matricaDugmica[i, j] = new Button();
                }

            panel.Size = new Size(mojaIgra.DimPolje * mojaIgra.Dimenzija, mojaIgra.DimPolje * mojaIgra.Dimenzija);
           
            this.Size = new Size(panel.Width + 40, panel.Height + 110);

            for (int i = 0; i < mojaIgra.Dimenzija; i++)
                for (int j = 0; j < mojaIgra.Dimenzija; j++)
                {
                    Button polje = matricaDugmica[i, j];
                    polje.Width = mojaIgra.DimPolje;
                    polje.Height = mojaIgra.DimPolje;
                    polje.Name = i + "," + j;
                    polje.Text = ""; //matricaPolja[i,j].ToString();
                    polje.Location = new Point(i * mojaIgra.DimPolje, j * mojaIgra.DimPolje);

                    if(stara)
                    {
                        if (mojaIgra.MatricaOtvorenihPolja[i, j] == 1)
                        {
                            polje.Text = mojaIgra.MatricaPolja[i, j].ToString();
                            polje.Enabled = false;
                        }
                        else if (mojaIgra.MatricaOtvorenihPolja[i, j] == 2)
                        {
                            polje.Text = "?";
                        }
                        
                    }

                    polje.MouseUp += polje_Click;

                    panel.Controls.Add(polje);
                }
        }

        private bool Pobeda()
        {
            for(int i=0;i<mojaIgra.Dimenzija;i++)
                for(int j=0;j<mojaIgra.Dimenzija;j++)
                {
                     Button dugme = (Button)panel.Controls[i + "," + j];
                    if (dugme.Enabled==true && dugme.Text=="")
                         return false;
                }
            return true;
        }

        private void polje_Click(object sender, EventArgs e)
        {
            if (mojaIgra.KrajIgre == true)
                return;

            Button dugme = (Button)sender;
            MouseEventArgs event1 = (MouseEventArgs)e;

            string[] podaci = dugme.Name.Split(',');
            int poz_x = int.Parse(podaci[0]);
            int poz_y = int.Parse(podaci[1]);

            if (event1.Button == MouseButtons.Left && dugme.Text != "?") //ako je levi
            {
                int tezinaPolja = mojaIgra.MatricaPolja[poz_x, poz_y];

                if (tezinaPolja == 9)
                {
                    //kraj igre
                    dugme.Text = "@";
                    dugme.Enabled = false;
                    mojaIgra.KrajIgre = true;
                    timer1.Stop();
                    otvoriSvaPolja();
                    button1.Text = ": (";
                    MessageBox.Show("BOMBA!", "Game Over :(",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                else if (tezinaPolja > 0)
                {
                    dugme.Text = tezinaPolja.ToString();
                    dugme.Enabled = false;
                    mojaIgra.MatricaOtvorenihPolja[poz_x, poz_y] = 1;
                }

                else
                {
                    otvoriPolje(poz_x, poz_y);
                }

            }

            else if (event1.Button == MouseButtons.Right) //desni klik
            {
                if (dugme.Text == "" && mojaIgra.PostMine<mojaIgra.BrojMina)
                {
                    dugme.Text = "?";
                    mojaIgra.MatricaOtvorenihPolja[poz_x, poz_y] = 2;
                    mojaIgra.PostMine++;
                }
                else if (dugme.Text == "?")
                {
                    dugme.Text = "";
                    mojaIgra.MatricaOtvorenihPolja[poz_x, poz_y] = 0;
                    mojaIgra.PostMine--;
                }
            }

            panel.Focus();
            la_brMina.Text = (mojaIgra.BrojMina-mojaIgra.PostMine).ToString();

            if (Pobeda() && mojaIgra.KrajIgre==false)
            {
                mojaIgra.KrajIgre = true;
                timer1.Stop();
                MessageBox.Show("BRAVO! Pobedili ste!", "Game Over :)",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void otvoriPolje(int x, int y)
        {
              //rekurzivno otvaranje polja 
            Button dugme2 = (Button)panel.Controls[x + "," + y];

            if (dugme2.Enabled == false) //ako je polje ispitano
                return;

            if (mojaIgra.MatricaPolja[x, y] == 0)
            {
                dugme2.Text = "";
                dugme2.Enabled = false;
                mojaIgra.MatricaOtvorenihPolja[x,y]=1; //1-otvoreno polje
            }
            else
            {
                dugme2.Text =mojaIgra.MatricaPolja[x, y].ToString();
                dugme2.Enabled = false;
                mojaIgra.MatricaOtvorenihPolja[x,y]=1;
            }

            if (mojaIgra.MatricaPolja[x, y] > 0) //ako je polje neki broj
                return;

            #region Rekurzivno otvaranje
            if (x != 0 && x != mojaIgra.Dimenzija - 1 && y != 0 && y != mojaIgra.Dimenzija - 1)
            {
                    otvoriPolje(x - 1, y);
                    otvoriPolje(x + 1, y);
                    otvoriPolje(x, y - 1);
                    otvoriPolje(x, y + 1);
                    otvoriPolje(x - 1, y - 1);
                    otvoriPolje(x + 1, y - 1);
                    otvoriPolje(x - 1, y + 1);
                    otvoriPolje(x + 1, y + 1); 
            }
            else if (x == 0 && y != 0 && y != mojaIgra.Dimenzija - 1)
            {
                    otvoriPolje(x + 1, y);
                    otvoriPolje(x, y - 1);
                    otvoriPolje(x, y + 1);
                    otvoriPolje(x + 1, y - 1);
                    otvoriPolje(x + 1, y + 1); 
            }
            else if (x == mojaIgra.Dimenzija - 1 && y != 0 && y != mojaIgra.Dimenzija - 1)
            {
                    otvoriPolje(x - 1, y);
                    otvoriPolje(x, y - 1);
                    otvoriPolje(x, y + 1);
                    otvoriPolje(x - 1, y - 1);
                    otvoriPolje(x - 1, y + 1);
            }
            else if (x != 0 && x != mojaIgra.Dimenzija - 1 && y == 0)
            {
                    otvoriPolje(x - 1, y);
                    otvoriPolje(x + 1, y);
                    otvoriPolje(x, y + 1);
                    otvoriPolje(x - 1, y + 1);
                    otvoriPolje(x + 1, y + 1); 
            }
            else if (x != 0 && x != mojaIgra.Dimenzija - 1 && y == mojaIgra.Dimenzija - 1)
            {
                    otvoriPolje(x - 1, y);
                    otvoriPolje(x + 1, y);
                    otvoriPolje(x, y - 1);
                    otvoriPolje(x - 1, y - 1);
                    otvoriPolje(x + 1, y - 1);
            }
            else if (x == 0 && y == 0)
            {
                    otvoriPolje(x + 1, y);
                    otvoriPolje(x, y + 1);       
                    otvoriPolje(x + 1, y + 1); 
            }
            else if (x == 0 && y == mojaIgra.Dimenzija - 1)
            {
                    otvoriPolje(x + 1, y);
                    otvoriPolje(x, y - 1);     
                    otvoriPolje(x + 1, y - 1);
            }
            else if (x == mojaIgra.Dimenzija - 1 && y == mojaIgra.Dimenzija - 1)
            {
                    otvoriPolje(x - 1, y);
                    otvoriPolje(x, y - 1);
                    otvoriPolje(x - 1, y - 1);
            }
            else if (x == mojaIgra.Dimenzija - 1 && y == 0)
            {
                    otvoriPolje(x - 1, y);
                    otvoriPolje(x, y + 1);
                    otvoriPolje(x - 1, y + 1);
            }
            return;

            #endregion
        }

        private void otvoriSvaPolja()
        {
            for (int i = 0; i < mojaIgra.Dimenzija; i++)
                for (int j = 0; j < mojaIgra.Dimenzija; j++)
                {
                    Button dugme = (Button)panel.Controls[i + "," + j];
                    if (dugme.Enabled == true)
                    {
                        if (mojaIgra.MatricaPolja[i, j] == 0)
                            dugme.Text = "";
                        else if (mojaIgra.MatricaPolja[i, j] == 9)
                            dugme.Text = "@";
                        else
                            dugme.Text = mojaIgra.MatricaPolja[i, j].ToString();

                        //menjaj deizajn dugmeta;
                        dugme.Enabled = false;
                    }

                }
        }
            
        private void novaIgraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NovaIgraRandom();
        }

        private void konfiguracijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Konfiguracija konf = new Konfiguracija(mojaIgra);
           
            if (konf.ShowDialog() == DialogResult.OK)
            {
                NovaIgra();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NovaIgraRandom();
        }

        private void zavrsiIgruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            otvoriSvaPolja();
            timer1.Stop();
        }

        private void sacuvajIgruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            mojaIgra.Proteklovreme = proteklovreme;
            timer1.Stop();
            dialog.Title = "Sacuvaj trenutnu igru";
            dialog.Filter = "XML fajl|*.xml";
            dialog.InitialDirectory = @"C:\";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    mojaIgra.SacuvajXML(dialog.FileName);
                }
            }
            
            timer1.Start();
        }

        private void ucitajIgruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Ucitaj igru";
            dialog.Filter = "XML fajl|*.xml";
            dialog.InitialDirectory = @"C:\";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    Console.WriteLine("Ucitavanje XML-a");
                    mojaIgra.UcitajXML(dialog.FileName);
                }
            }

            StaraIgra();
        }

        private void ucitajKonfiguracijuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Ucitaj konfiguraciju";
            dialog.Filter = "XML fajl|*.xml";
            dialog.InitialDirectory = @"C:\";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName != "")
                {
                    Console.WriteLine("Ucitavanje XML-a");
                    mojaIgra.UcitajXML(dialog.FileName,false);
                }
            }

            NovaIgra();
        }

       
    }
}
