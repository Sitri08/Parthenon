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
    public partial class FormInvata : Form
    {
        setare setariUtilizator;

        public FormInvata()
        {
            InitializeComponent();
        }

        private void FormInvata_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            ClassParthenon.IncarcaDateUtilizator(ref setariUtilizator);
            AfiseazaDateUtilizator();
            IncarcaPagina();
        }

        public void IncarcaPagina()
        {
            if (setariUtilizator.language == 1) Englezifica();
        }

        public void AfiseazaDateUtilizator()
        {
            if (setariUtilizator.profilePicture == "N/A")
                pictureBoxUser.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"\profile_pictures\profile_default.png");
            else pictureBoxUser.Image = Image.FromFile(Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 14) + @"\profile_pictures\" + setariUtilizator.profilePicture);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            FormDeschidere frm = new FormDeschidere();
            frm.Show();
            this.Close();
        }

        private void ButtonStart_MouseHover(object sender, EventArgs e)
        {
            buttonStart.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void ButtonStart_MouseLeave(object sender, EventArgs e)
        {
            buttonStart.BackgroundImage = Parthenon.Properties.Resources.button_default;
        }

        private void ButtonLearn_MouseHover(object sender, EventArgs e)
        {
            buttonLearn.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void ButtonLearn_MouseLeave(object sender, EventArgs e)
        {
            buttonLearn.BackgroundImage = Parthenon.Properties.Resources.button_default;
        }

        private void ButtonTest_MouseHover(object sender, EventArgs e)
        {
            buttonTest.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void ButtonTest_MouseLeave(object sender, EventArgs e)
        {
            buttonTest.BackgroundImage = Parthenon.Properties.Resources.button_default;
        }

        private void ButtonAccount_MouseHover(object sender, EventArgs e)
        {
            buttonAccount.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void ButtonAccount_MouseLeave(object sender, EventArgs e)
        {
            buttonAccount.BackgroundImage = Parthenon.Properties.Resources.button_default;
        }

        private void PictureBoxUser_Click(object sender, EventArgs e)
        {
            ButtonAccount_Click(new object(), new EventArgs());
        }

        private void ButtonAccount_Click(object sender, EventArgs e)
        {
            var formCont = new FormCont();
            formCont.Show();
            this.Hide();
        }

        public void Englezifica()
        {
            label1.Text = "Improve your knowledge";
            buttonAccount.Text = "My account";
            buttonLearn.Text = "Learn more";
            buttonStart.Text = "Start page";
            buttonTest.Text = "Test my knowledge";
            buttonExit.Text = "Back";
            button1.Text = "Gods";
            button3.Text = "Men";
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            FormDeschidere frm = new FormDeschidere();
            frm.Show();
            this.Close();
        }

        private void ButtonExit_MouseHover(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void ButtonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_default;
        }

        private void ButtonLearn_Click(object sender, EventArgs e)
        {
            FormInvata forminv = new FormInvata();
            forminv.Show();
            this.Hide();
        }

        private void ButtonTest_Click(object sender, EventArgs e)
        {
            FormTest frm = new FormTest();
            frm.Show();
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FormGods formZei = new FormGods();
            formZei.Show();
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            var formZO = new FormMonsters();
            formZO.Show();
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Button1_MouseHover(object sender, EventArgs e)
        {
            button1.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Parthenon.Properties.Resources.button_default;
        }

        private void Button3_MouseHover(object sender, EventArgs e)
        {
            button3.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackgroundImage = Parthenon.Properties.Resources.button_default;
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void buttonStart_MouseEnter(object sender, EventArgs e)
        {
            buttonStart.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void buttonLearn_MouseEnter(object sender, EventArgs e)
        {
            buttonLearn.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void buttonTest_MouseEnter(object sender, EventArgs e)
        {
            buttonTest.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void buttonAccount_MouseEnter(object sender, EventArgs e)
        {
            buttonAccount.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void pictureBoxUser_Click_1(object sender, EventArgs e)
        {
            FormCont frm = new FormCont();
            frm.Show();
            this.Close();
        }
    }
}
