using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Collections.Specialized;

namespace Parthenon
{
    public partial class FormHangman : Form
    {
        int jocCurent = 0, greseli = 0, timpCurent = 0;
        double nrMediuGreseli = 0;
        string cuvant = "", litereFolosite;

        //TODO incarca rezultatul in baza de date
        /*string litereFolosite = "";
        int greseli;
        int greseliTotale = 0;
        int jocCurent = 0;
        int timpCurent;
        string cuvant;*/

        public void IncarcaJocNou()
        {
            if(jocCurent != 0)
            {
                if (jocTerminat() == 1) MessageBox.Show("Ati ghicit!");
                if (jocTerminat() == -1) MessageBox.Show("Ati pierdut...");
                //adauga in baza de date
                //calea bazei de date
                string connString = AppDomain.CurrentDomain.BaseDirectory;
                connString = connString.Remove(connString.Length - 10) + "GodsDatabase.mdf";

                //conectare la baza de date
                connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + connString + @";Integrated Security=True";
                SqlConnection con = new SqlConnection(connString);
                con.Open();

                //extragere cuvant aleatoriu
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = string.Format("INSERT INTO IncercariHangman(Cuvant, Timp, Rezultat, NrGreseli) VALUES ('{0}',{1},{2},{3})", cuvant, timpCurent, jocTerminat(), greseli);

                cmd.ExecuteNonQuery();
                con.Close();

                //actualizeaza numar greseli
                if (jocTerminat() != 0)
                {
                    nrMediuGreseli = Math.Floor((nrMediuGreseli * (jocCurent - 1) + greseli) / jocCurent * 100) / 100;
                    label5.Text = "Numar mediu greseli: " + nrMediuGreseli;
                }
                else jocCurent--;
            }

            cuvant = AlegeCuvantNou();
            label1.Text = AscundeCuvant();
            timpCurent = 0;
            greseli = 0;
            //label6.Text in AscundeCuvant
            pictureBox1.Image = Parthenon.Properties.Resources.hangman11;
            label3.Text = "Joc curent: " + ++jocCurent;
            label2.Text = "Greseli curente: 0/5";


            return;

            /*if(jocCurent != 0) label5.Text = "Numar mediu greseli: " + ((greseli + greseliTotale * (jocCurent - 1)) / jocCurent);

            label3.Text = "Joc curent: " + ++jocCurent;
            label2.Text = "Greșeli curente: 0";
            label4.Text = "Timp: 0";
            label6.Text = "";

            litereFolosite = "";
            greseli = -1;
            timpCurent = 0;

            CautaCuvantNou();
            VerificaLitera(Convert.ToString(cuvant[0]));*/
        }

        public string AlegeCuvantNou()
        {
            string x = "";

            do
            {
                //calea bazei de date
                string connString = AppDomain.CurrentDomain.BaseDirectory;
                connString = connString.Remove(connString.Length - 10) + "GodsDatabase.mdf";

                //conectare la baza de date
                connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + connString + @";Integrated Security=True";
                SqlConnection con = new SqlConnection(connString);
                con.Open();

                //extragere cuvant aleatoriu
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Cuvant FROM IntrebariHangman ORDER BY NEWID()";
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                x = Convert.ToString(reader[0]);

                //inchide conexiunea
                reader.Close();
                con.Close();
            } while (x == cuvant);

            return x;
        }

        public string AscundeCuvant()
        {
            string x = "";

            litereFolosite = char.ToUpper(cuvant[0]) + " ";
            if (cuvant[0] != cuvant[cuvant.Length - 1]) litereFolosite += char.ToUpper(cuvant[cuvant.Length - 1]) + " ";

            label6.Text = "Litere folosite: " + litereFolosite;

            foreach(char c in cuvant)
            {
                if (c == cuvant[0] || c == cuvant[cuvant.Length - 1]) x += char.ToUpper(c) + " ";
                else if (c == ' ') x += "- ";
                else x += "_ ";
            }

            return x;
        }

        public int jocTerminat() //0 pentru joc in curs, 1 pentru joc castigat, -1 pentru joc pierdut
        {
            if (!label1.Text.Contains('_')) return 1;
            if (greseli >= 5) return -1;
            return 0;
        }

        /*public void CautaCuvantNou()
        {
            //calea bazei de date
            string connString = AppDomain.CurrentDomain.BaseDirectory;
            connString = connString.Remove(connString.Length - 10) + "GodsDatabase.mdf";

            //conectare la baza de date
            connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + connString + @";Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            //extragere cuvant aleatoriu
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Cuvant FROM IntrebariHangman ORDER BY NEWID()";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            cuvant = Convert.ToString(reader[0]);

            //inchide conexiunea
            reader.Close();
            con.Close();
        }*/

        public FormHangman()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            switch(literaGresita())
            {
                case -1:
                    litereFolosite += textBox1.Text + " ";
                    greseli++;
                    break;
                case 1:
                    litereFolosite += textBox1.Text + " ";
                    label1.Text = "";
                    foreach (char c in cuvant)
                        if (litereFolosite.Contains(char.ToUpper(c))) label1.Text += char.ToUpper(c) + " ";
                        else if (char.IsLetter(c)) label1.Text += "_ ";
                        else label1.Text += "- ";
                    break;
                case -2:
                    MessageBox.Show("Litera folosita deja!");
                    break;
                default:
                    MessageBox.Show("Trebuie sa introduceti exact o litera!");
                    break;
            }

            textBox1.Text = "";
            label2.Text = "Greseli curente: " + greseli + "/5";
            label6.Text = "Litere folosite: " + litereFolosite;

            ImagineDupaGreseala();
            if (jocTerminat() != 0) IncarcaJocNou();


            return;

            /*if(textBox1.Text.Length != 1)
            {
                MessageBox.Show("Trebuie să introduci exact o literă!");
                return;
            }

            if(LiteraFolosita(textBox1.Text))
            {
                MessageBox.Show("Litera folosită deja!");
                textBox1.Text = "";
                return;
            }

            VerificaLitera(textBox1.Text);
            textBox1.Text = "";

            if (Mort())
            {
                MessageBox.Show("Ai murit!");
                IncarcaJocNou();
                return;
            }

            string cuvantLabel = label1.Text;
            cuvantLabel = cuvantLabel.Replace(" ", "") ;
            cuvantLabel = cuvantLabel.Trim('-');

            if(cuvantLabel == cuvant)
            {
                MessageBox.Show("Cuvant completat!");
                Button1_Click(new object(), new EventArgs());
            }*/
        }

        public int literaGresita() //0 introdusa gresit, -1 gresita, 1 corecta, -2 folosita deja
        {
            if (textBox1.Text.Length != 1 || textBox1.Text[0] < 'A' || textBox1.Text[0] > 'Z') return 0;
            if (litereFolosite.Contains(textBox1.Text)) return -2;
            if (cuvant.ToUpper().Contains(textBox1.Text)) return 1;
            return -1;
        }

        public void ImagineDupaGreseala()
        {
            switch(greseli)
            {
                case 0:
                    pictureBox1.Image = Parthenon.Properties.Resources.hangman11;
                    break;
                case 1:
                    pictureBox1.Image = Parthenon.Properties.Resources.hangman2;
                    break;
                case 2:
                    pictureBox1.Image = Parthenon.Properties.Resources.hangman3;
                    break;
                case 3:
                    pictureBox1.Image = Parthenon.Properties.Resources.hangman4;
                    break;
                case 4:
                    pictureBox1.Image = Parthenon.Properties.Resources.hangman5;
                    break;
                case 5:
                    pictureBox1.Image = Parthenon.Properties.Resources.hangman6;
                    break;
            }
        }

        /*public bool Mort()
        {
            return greseli >= 6;
        }

        public void TaieL()
        {
            if (greseli==1) 
                pictureBox1.Image = Parthenon.Properties.Resources.hangman2;
            else if (greseli==2)
                pictureBox1.Image = Parthenon.Properties.Resources.hangman3;
            else if (greseli==3)
                pictureBox1.Image = Parthenon.Properties.Resources.hangman4;
            else if (greseli==4)
                pictureBox1.Image = Parthenon.Properties.Resources.hangman5;
            else if (greseli==5)
                pictureBox1.Image = Parthenon.Properties.Resources.hangman6;

        }

        public bool LiteraFolosita(string litera)
        {
            if (litereFolosite.IndexOf(litera) != -1) return true;
            return false;
        }

        public void VerificaLitera(string litera)
        {
            label1.Text = "";
            litereFolosite += litera;
            bool ok = false;

            foreach (char c in cuvant)
                if (c == ' ') { label1.Text += "- "; }
                else if (litereFolosite.IndexOf(c) != -1) { label1.Text += c + " ";}
                else label1.Text += "_ ";

            if (cuvant.IndexOf(litereFolosite[litereFolosite.Length - 1]) != -1) ok = true;

            if (!ok)
            {
                label2.Text = "Greseli curente: " + ++greseli;

                TaieL();
            }

            label6.Text += litera.ToUpper() + " ";
        }*/

        private void FormHangman_Load(object sender, EventArgs e)
        {
            timer1.Start();
            IncarcaJocNou();
            this.ControlBox = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            IncarcaJocNou();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = "Timp: " + timpCurent++ + "s";
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_default;

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Parthenon.Properties.Resources.button_default;

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackgroundImage = Parthenon.Properties.Resources.button_default;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Button2_Click(button2, new EventArgs());
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            FormTest frm = new FormTest();
            frm.Show();
            this.Close();
        }
    }
}
