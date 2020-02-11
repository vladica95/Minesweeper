using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace IgraKlasa
{
    public class Igra
    {
        private int dimMatrice;
        private int brojMina;
        private int postMine;
        private int protekloVreme;
        private int[,] matrica;
        private int[,] matricaZastOtvoreno;
        private bool krajIgre;
        private int dimPolja;

        #region Properties

        public int Dimenzija
        {
            get { return dimMatrice; }
            set { dimMatrice = value; }
        }

        public int BrojMina
        {
            get { return brojMina; }
            set { brojMina = value; }
        }

        public int Proteklovreme
        {
            get { return protekloVreme; }
            set { protekloVreme = value; }
        }

        public int[,] MatricaPolja
        {
            get { return matrica; }
            set { matrica = value; }
        }

        public bool KrajIgre
        {
            get { return krajIgre; }
            set { krajIgre = value; }
        }

        public int DimPolje
        {
            get { return dimPolja; }
            set { dimPolja = value; }
        }

        public int[,] MatricaOtvorenihPolja
        {
            get { return matricaZastOtvoreno; }
            set { matricaZastOtvoreno = value; }
        }

        public int PostMine
        {
            get { return postMine; }
            set { postMine = value; }
        }



        #endregion

        public Igra()
        {
            dimMatrice = 9;
            brojMina = 10;
            protekloVreme = 0;
            krajIgre = false;
            dimPolja = 25;
        }

        public void InstancirajIgruRandom()
        {
            KrajIgre = false;
            postMine = 0;
            MatricaRandom();
        }

        public void Konfiguracija(int dmatrice, int bmina, int pMine = 0, int pvreme = 0, bool kigre = false, int dpolja = 25)
        {
            dimMatrice = dmatrice;
            brojMina = bmina;
            protekloVreme = pvreme;
            krajIgre = kigre;
            postMine = pMine;
            dimPolja = dpolja;
            MatricaRandom();
        }

        public void AdminKonfig(int dmatrice, int bmina, int[,] marBombi, int pvreme = 0, bool kigre = false, int dpolja = 25)
        {
            dimMatrice = dmatrice;
            brojMina = bmina;
            protekloVreme = pvreme;
            krajIgre = kigre;
            dimPolja = dpolja;
            PraznaMatrica(); //prazne matrice
            matrica = marBombi; //ima samo 0 za prazno i 9 gde je bomba
            Dodajtezine();
        }

        private void PraznaMatrica()
        {
            matrica = new int[dimMatrice, dimMatrice];
            matricaZastOtvoreno = new int[dimMatrice, dimMatrice];
            for (int i = 0; i < dimMatrice; i++)
            {
                for (int j = 0; j < dimMatrice; j++)
                {
                    matrica[i, j] = 0;
                    matricaZastOtvoreno[i, j] = 0; //0 -zatvoreno polje, 1-otvoreno
                }
            }
        }

        private void MatricaRandom()
        {
            PraznaMatrica();
            int brGenerisanihMina = 0;
            Random rand = new Random();

            while (brGenerisanihMina < brojMina)
            {
                int x = rand.Next(0, dimMatrice - 1);
                int y = rand.Next(0, dimMatrice - 1);

                if (matrica[x, y] == 0)
                {
                    matrica[x, y] = 9;
                    brGenerisanihMina++;
                }
            }

            Dodajtezine();

        }

        private int ispitajPolje(int pozx, int pozy)
        {
            if (pozx < 0 || pozx >= dimMatrice || pozy < 0 || pozy >= dimMatrice)
            {
                return -1;
            }

            return matrica[pozx, pozy];
        }

        private void Dodajtezine()
        {

            for (int x = 0; x < dimMatrice; x++)
                for (int y = 0; y < dimMatrice; y++)
                    if (matrica[x, y] == 9)
                    {
                        int levo = ispitajPolje(x - 1, y);
                        int desno = ispitajPolje(x + 1, y);
                        int gore = ispitajPolje(x, y - 1);
                        int dole = ispitajPolje(x, y + 1);
                        int levogore = ispitajPolje(x - 1, y - 1);
                        int desnogore = ispitajPolje(x + 1, y - 1);
                        int levodole = ispitajPolje(x - 1, y + 1);
                        int desnodole = ispitajPolje(x + 1, y + 1);

                        if (levo != 9 && levo != -1)
                        {
                            matrica[x - 1, y]++;
                        }

                        if (desno != 9 && desno != -1)
                        {
                            matrica[x + 1, y]++;
                        }

                        if (gore != 9 && gore != -1)
                        {
                            matrica[x, y - 1]++;
                        }

                        if (dole != 9 && dole != -1)
                        {
                            matrica[x, y + 1]++;
                        }

                        if (levogore != 9 && levogore != -1)
                        {
                            matrica[x - 1, y - 1]++;
                        }

                        if (desnogore != 9 && desnogore != -1)
                        {
                            matrica[x + 1, y - 1]++;
                        }

                        if (levodole != 9 && levodole != -1)
                        {
                            matrica[x - 1, y + 1]++;
                        }

                        if (desnodole != 9 && desnodole != -1)
                        {
                            matrica[x + 1, y + 1]++;
                        }
                    }
        }

        public void SacuvajXML(string putanja)
        {
            XmlWriter xmlWriter = XmlWriter.Create(putanja);

            xmlWriter.WriteStartDocument();

            //Igra
            xmlWriter.WriteStartElement("igra");

            //Dimenzije matrice
            xmlWriter.WriteStartElement("dimenzije");
            xmlWriter.WriteString(dimMatrice.ToString());
            xmlWriter.WriteEndElement();

            //Broj mina
            xmlWriter.WriteStartElement("broj_mina");
            xmlWriter.WriteString(brojMina.ToString());
            xmlWriter.WriteEndElement();

            //Trenutno vreme
            xmlWriter.WriteStartElement("vreme");
            xmlWriter.WriteString(protekloVreme.ToString());
            xmlWriter.WriteEndElement();

            //Bombe
            xmlWriter.WriteStartElement("bombe");

            for (int i = 0; i < dimMatrice; i++)
            {
                for (int j = 0; j < dimMatrice; j++)
                {
                    if (matrica[i, j] == 9)
                    {
                        xmlWriter.WriteStartElement("bomba");
                        xmlWriter.WriteAttributeString("X", i.ToString());
                        xmlWriter.WriteAttributeString("Y", j.ToString());
                        xmlWriter.WriteString(" ");
                        xmlWriter.WriteEndElement();
                    }
                }
            }

            xmlWriter.WriteEndElement();

            //Otvorena polja i zastavice
            xmlWriter.WriteStartElement("polja");

            for (int i = 0; i < dimMatrice; i++)
            {
                for (int j = 0; j < dimMatrice; j++)
                {
                    if (matricaZastOtvoreno[i, j] > 0)
                    {
                        xmlWriter.WriteStartElement("polje");
                        xmlWriter.WriteAttributeString("X", i.ToString());
                        xmlWriter.WriteAttributeString("Y", j.ToString());
                        xmlWriter.WriteString(matricaZastOtvoreno[i, j].ToString());
                        xmlWriter.WriteEndElement();
                    }
                }
            }

            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }

        public bool UcitajXML(string putanja, bool conf = true)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(putanja);
            
            if (xmlDoc.DocumentElement.Name != "igra")
                return false; //vrati false ako je los fajl

             protekloVreme = 0;
             postMine = 0;

            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                if (node.Name == "dimenzije")
                {
                    dimMatrice = int.Parse(node.InnerText);
                    PraznaMatrica();
                    Console.WriteLine("Dimenzije matrice: " + node.InnerText);
                }

                if (node.Name == "broj_mina")
                {
                    brojMina = int.Parse(node.InnerText);
                    Console.WriteLine("Broj mina: " + brojMina);
                }
                if (conf)
                    if (node.Name == "vreme")
                    {
                        protekloVreme = int.Parse(node.InnerText);
                        Console.WriteLine("Proteklo vreme: " + protekloVreme);
                    }

                if (node.Name == "bombe")
                {
                    XmlNodeList bombe = node.ChildNodes;

                    for (int i = 0; i < bombe.Count; i++)
                    {
                        int poz_x = int.Parse(bombe[i].Attributes["X"].Value);
                        int poz_y = int.Parse(bombe[i].Attributes["Y"].Value);

                        matrica[poz_x, poz_y] = 9;
                        Console.WriteLine("Bomba (" + poz_x + "," + poz_y + ")");
                    }
                    Dodajtezine();

                }
                if (conf)
                    if (node.Name == "polja")
                    {
                        XmlNodeList lista_polja = node.ChildNodes;
                        int broj = 0;
                        for (int i = 0; i < lista_polja.Count; i++)
                        {
                            int poz_x = int.Parse(lista_polja[i].Attributes["X"].Value);
                            int poz_y = int.Parse(lista_polja[i].Attributes["Y"].Value);
                            int vrednost = int.Parse(lista_polja[i].InnerText);

                            if (vrednost == 2)
                                broj++;
                            matricaZastOtvoreno[poz_x, poz_y] = vrednost;

                            Console.WriteLine("Polje (" + poz_x + "," + poz_y + ") = " + vrednost);
                            matricaZastOtvoreno[poz_x, poz_y] = vrednost;
                        }
                        postMine = broj;
                    }
            }

            return true;

        }

    }
}
