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
using System.IO;

namespace Parthenon
{
    public partial class FormQuiz : Form
    {
        int timpCurent = 0;
        int intrebareCurenta = 0;
        int scorCurent = 0;
        string[,] intrebari = new string[11, 5];
        string[] raspunsuri = new string[11];

        public FormQuiz()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            IncarcaIntrebari();
            timer1.Start();
        }

        public void IncarcaIntrebari()
        {
            //calea bazei de date
            string connString = AppDomain.CurrentDomain.BaseDirectory;
            connString = connString.Remove(connString.Length - 10) + "GodsDatabase.mdf";

            //conectare la baza de date
            connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + connString + @";Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            //extragere intrebari in ordine aleatorie
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM IntrebariQuiz ORDER BY NEWID()";
            SqlDataReader reader = cmd.ExecuteReader();

            for (int i = 1; i <= 10; i++)
            {
                reader.Read();
                intrebari[i, 0] = Convert.ToString(reader[1]);
                for (int j = 1; j <= 4; j++) intrebari[i, j] = Convert.ToString(reader[j + 2]);
                raspunsuri[i] = Convert.ToString(reader[2]);
            }

            //inchidere conexiune
            reader.Close();
            con.Close();

            //incarcare prima intrebare
            label3.Text = "Întrebare 1: " + intrebari[1, 0];
            intrebareCurenta++;
            checkBox1.Text = intrebari[intrebareCurenta, 1];
            checkBox2.Text = intrebari[intrebareCurenta, 2];
            checkBox3.Text = intrebari[intrebareCurenta, 3];
            checkBox4.Text = intrebari[intrebareCurenta, 4];
            label4.Text = "Întrebare curenta: " + intrebareCurenta + "/10";
        }

        public void UrmatoareaIntrebare()
        {
            int rasp = 0, raspC = 0;
            if (checkBox1.Checked) rasp += 1;
            if (checkBox2.Checked) rasp += 10;
            if (checkBox3.Checked) rasp += 100;
            if (checkBox4.Checked) rasp += 1000;
            switch(raspunsuri[intrebareCurenta])
            {
                case "A":
                    raspC = 1;
                    break;
                case "B":
                    raspC = 10;
                    break;
                case "C":
                    raspC = 100;
                    break;
                default:
                    raspC = 1000;
                    break;
            }

            if(rasp == raspC)
            {
                label1.Text = "Scor curent: " + ++scorCurent + "/" + intrebareCurenta;
                //TODO mesaj rasp corect
            }
            else
            {
                label1.Text = "Scor curent: " + scorCurent + "/" + intrebareCurenta;
                //TODO mesaj rasp gresit
            }

            label4.Text = "Întrebare curentă: " + ++intrebareCurenta + "/10";
            label3.Text = "Întrebare " + intrebareCurenta + ": " + intrebari[intrebareCurenta, 0];
            checkBox1.Text = intrebari[intrebareCurenta, 1];
            checkBox2.Text = intrebari[intrebareCurenta, 2];
            checkBox3.Text = intrebari[intrebareCurenta, 3];
            checkBox4.Text = intrebari[intrebareCurenta, 4];
            checkBox1.Checked = checkBox2.Checked = checkBox3.Checked = checkBox4.Checked = false;
        }

        private void FormQuiz_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            this.ControlBox = false;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = "Timp: " + FaData(timpCurent);
            timpCurent++;
        }

        public string FaData(int timp)
        {
            int min = 0, s = 0;
            while(timp >= 60)
            {
                min++;
                timp -= 60;
            }

            s = timp;

            return Convert.ToString(min) + "min " + Convert.ToString(s) + "s";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked == checkBox2.Checked && checkBox2.Checked == checkBox3.Checked && checkBox3.Checked == checkBox4.Checked)
            {
                MessageBox.Show("Măcar încearcă!");
                return;
            }
            if (intrebareCurenta == 9) button2.Text = "Finalizare test";
            if (intrebareCurenta < 10) UrmatoareaIntrebare();
            else TerminaTest();
        }

        public void TerminaTest()
        {
            //calea bazei de date
            string connString = AppDomain.CurrentDomain.BaseDirectory;
            connString = connString.Remove(connString.Length - 10) + "GodsDatabase.mdf";

            //conectare la baza de date
            connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + connString + @";Integrated Security=True";
            SqlConnection con = new SqlConnection(connString);
            con.Open();

            //adaugare inregistrare noua
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = string.Format("INSERT INTO IncercariQuiz (Scor, Timp, Data) VALUES ({0}, {1}, '{2}')", scorCurent, timpCurent, DateTime.Now);
            cmd.ExecuteNonQuery();

            //inchidere baza de date
            con.Close();

            //finalizare test
            MessageBox.Show("Test finalizat. Punctajul meu: " + scorCurent + "/10");
            buttonExit_Click(button1, new EventArgs());
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Parthenon.Properties.Resources.button_default;

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            FormTest frm = new FormTest();
            frm.Show();
            this.Close();
        }
    }
}
