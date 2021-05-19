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
    public partial class FormStatistici : Form
    {
        public FormStatistici()
        {
            InitializeComponent();
        }

        private void FormStatistici_Load(object sender, EventArgs e)
        {
            IncarcaChart1();
            IncarcaChart2();
            IncarcaChart3();
        }

        public void IncarcaChart1()
        {
            chart1.ChartAreas[0].AxisX.Title = "Data";
            chart1.ChartAreas[0].AxisY.Title = "Numar Jocuri";


            string cale = Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 23);
            cale = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                cale + @"GodsDatabase.mdf" +
                @";Integrated Security=True";
            var con = new SqlConnection(cale);
            con.Open();

            var cmd = new SqlCommand();
            cmd.CommandText = "SELECT Data, COUNT(Data) FROM IncercariQuiz GROUP BY Data";
            cmd.Connection = con;

            var reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                chart1.Series[0].Points.AddXY(reader[0], reader[1]);
            }

            con.Close();
        }

        public void IncarcaChart2()
        {
            chart2.ChartAreas[0].AxisX.Title = "Timp";
            chart2.ChartAreas[0].AxisY.Title = "Scor";


            string cale = Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 23);
            cale = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                cale + @"GodsDatabase.mdf" +
                @";Integrated Security=True";
            var con = new SqlConnection(cale);
            con.Open();

            var cmd = new SqlCommand();
            cmd.CommandText = "SELECT Timp, Scor FROM IncercariQuiz";
            cmd.Connection = con;

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                chart2.Series[0].Points.AddXY(reader[0], reader[1]);
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int rasp = 13, r1 = 0, r2 = 0;
            CheckBox[] cb = new CheckBox[5];
            cb[1] = checkBox1;
            cb[2] = checkBox2;
            cb[3] = checkBox3;
            cb[4] = checkBox4;

            for (int i = 1; i <= 4; i++) if(cb[i].Checked) r1++;
            while(rasp != 0)
            {
                if (cb[rasp % 10].Checked) r2++;
                rasp /= 10;
            }

            if (r1 == r2 && r1 != 0) RaspunsCorect();
            else RaspunsGresit();
        }

        private bool RaspunsGresit()
        {
            //ce se intampla daca ai gresit raspunsul
            MessageBox.Show("gresit");

            return false;
        }

        private bool RaspunsCorect()
        {
            //actiuni daca e raspunsul corect
            MessageBox.Show("sex");

            return true;
        }

        public void IncarcaChart3()
        {
            string cale = Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 23);
            cale = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                cale + @"GodsDatabase.mdf" +
                @";Integrated Security=True";
            var con = new SqlConnection(cale);
            con.Open();

            var cmd = new SqlCommand();
            cmd.CommandText = "SELECT COUNT(*), Data FROM IncercariQuiz GROUP BY Data";
            cmd.Connection = con;

            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                chart3.Series[0].Points.AddXY(reader[1], reader[0]);
            }

            con.Close();
        }
    }
}
