using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parthenon
{
    public partial class FormMonsters : Form
    {
        setare setariUtilizator;

        public FormMonsters()
        {
            InitializeComponent();
        }

        private void FormMonsters_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            ClassParthenon.IncarcaDateUtilizator(ref setariUtilizator);
            IncarcaPagina();
        }

        public void IncarcaPagina()
        {
            if (setariUtilizator.language == 1) Englezifica();
        }

        public void Englezifica()
        {

        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            FormInvata frm = new FormInvata();
            frm.Show();
            this.Close();
        }

        public void deschideVideo(string nume)
        {
            string cale = AppDomain.CurrentDomain.BaseDirectory;
            cale = cale.Remove(cale.Length - 10) + @"Resources\";
            nume = cale + nume + ".mp4";
            FormPlayVideo formpv = new FormPlayVideo(nume);
            formpv.Show();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            deschideVideo("Arachne");
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            deschideVideo("ErosPsyche");
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            deschideVideo("Midas");
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            deschideVideo("Sisyphus");
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_default;
        }
    }
}
