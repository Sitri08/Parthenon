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
    public partial class FormGods : Form
    {
        //setare setariUtilizator;
        string[] zei = { "Zeus", "Hera", "Atena", "Poseidon", "Demetria", "Apollo", "Artemis", "Ares", "Afrodita", "Hefaistos", "Hermes", "Hestia", "Dionisos", "Hades" };

        public FormGods()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            FormInvata frm = new FormInvata();
            frm.Show();
            this.Close();
        }

        private void ButtonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_default;

        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            button1_Click(button1, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (zei.Contains(comboBox1.Text.Trim())) incarcaZeu(comboBox1.Text.Trim());
            else MessageBox.Show("Trebuie să alegeți un zeu!");
        }

        public void incarcaZeu(string zeu)
        {
            label1.Visible = label3.Visible = richTextBox1.Visible = richTextBox2.Visible = richTextBox10.Visible = richTextBox3.Visible = richTextBox4.Visible = richTextBox5.Visible = richTextBox6.Visible = richTextBox7.Visible = richTextBox8.Visible = richTextBox9.Visible = pictureBox1.Visible = true;
            label1.Visible = label10.Visible = label11.Visible = label12.Visible = label13.Visible = label2.Visible = label3.Visible = label4.Visible = label5.Visible = label6.Visible = label7.Visible = label8.Visible = label9.Visible = true;

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
            cmd.CommandText = @"SELECT * FROM Gods WHERE Title LIKE '%" + zeu + @"%'";
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            //nume rulesover gender symbols parent consort siblings children romanname title subtitle info trivia
            //1       2        3       4       5      6       7         8        9       10     11     12    13

            label1.Text = Convert.ToString(reader[10]);
            label3.Text = Convert.ToString(reader[11]);
            richTextBox1.Text = Convert.ToString(reader[12]);
            richTextBox10.Text = Convert.ToString(reader[5]);
            richTextBox2.Text = Convert.ToString(reader[13]);
            richTextBox3.Text = Convert.ToString(reader[1]);
            richTextBox4.Text = Convert.ToString(reader[2]);
            richTextBox5.Text = Convert.ToString(reader[4]);
            richTextBox6.Text = Convert.ToString(reader[3]);
            richTextBox7.Text = Convert.ToString(reader[9]);
            richTextBox8.Text = Convert.ToString(reader[8]);
            richTextBox9.Text = Convert.ToString(reader[6]);
            pictureBox1.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.Length - 10) + "Resources\\" + zeu + ".jpg");
            //MessageBox.Show(AppDomain.CurrentDomain.BaseDirectory);

            //inchide conexiunea
            reader.Close();
            con.Close();
        }
    }
}
