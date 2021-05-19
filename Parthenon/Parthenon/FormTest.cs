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
    public partial class FormTest : Form
    {
        setare setariUtilizator;
        public FormTest()
        {
            InitializeComponent();
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            FormDeschidere frm = new FormDeschidere();
            frm.Show();
            this.Close();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            ClassParthenon.IncarcaDateUtilizator(ref setariUtilizator);
            AfiseazaDateUtilizator();
            this.ControlBox = false;
        }

        public void AfiseazaDateUtilizator()
        {
            if (setariUtilizator.profilePicture == "N/A")
                pictureBoxUser.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"\profile_pictures\profile_default.png");
            else pictureBoxUser.Image = Image.FromFile(Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 14) + @"\profile_pictures\" + setariUtilizator.profilePicture);
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            FormQuiz formQ = new FormQuiz();
            formQ.Show();
            this.Close();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            FormHangman formh = new FormHangman();
            formh.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //nu e nevoie
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_default;
        }

        private void buttonStart_MouseEnter(object sender, EventArgs e)
        {
            buttonStart.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void buttonStart_MouseLeave(object sender, EventArgs e)
        {
            buttonStart.BackgroundImage = Parthenon.Properties.Resources.button_default;

        }

        private void buttonLearn_MouseEnter(object sender, EventArgs e)
        {
            buttonLearn.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void buttonLearn_MouseLeave(object sender, EventArgs e)
        {
            buttonLearn.BackgroundImage = Parthenon.Properties.Resources.button_default;

        }

        private void buttonTest_MouseEnter(object sender, EventArgs e)
        {
            buttonTest.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void buttonTest_MouseLeave(object sender, EventArgs e)
        {
            buttonTest.BackgroundImage = Parthenon.Properties.Resources.button_default;

        }

        private void buttonAccount_MouseEnter(object sender, EventArgs e)
        {
            buttonAccount.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void buttonAccount_MouseLeave(object sender, EventArgs e)
        {
            buttonAccount.BackgroundImage = Parthenon.Properties.Resources.button_default;

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            FormDeschidere frm = new FormDeschidere();
            frm.Show();
            this.Close();
        }

        private void buttonLearn_Click(object sender, EventArgs e)
        {
            FormInvata frm = new FormInvata();
            frm.Show();
            this.Close();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            FormTest frm = new FormTest();
            frm.Show();
            this.Close();
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            FormCont frm = new FormCont();
            frm.Show();
            this.Close();
        }

        private void pictureBoxUser_Click(object sender, EventArgs e)
        {
            FormCont frm = new FormCont();
            frm.Show();
            this.Close();
        }
    }
}
