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
    public partial class FormDeschidere : Form
    {
        setare setariUtilizator;

        public FormDeschidere()
        {
            InitializeComponent();
        }

        private void FormDeschidere_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            ClassParthenon.IncarcaDateUtilizator(ref setariUtilizator);
            AfiseazaDateUtilizator();
            IncarcaPagina();

            //DeschideGrafic();
        }

        public void DeschideGrafic()
        {
            FormStatistici forms = new FormStatistici();
            forms.Show();
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
            return;
            /*var formStart = new FormDeschidere();
            this.Close();
            formStart.Show();*/
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
            label1.Text = "Welcome to Parthenon!";
            label2.Text = "What is Parthenon?";
            richTextBox1.Text =
                "Parthenon is an app written with the purpose of improving the user's knowledge in regards to Greek Mythology.\nThis app is designed to benefit both the student and the teacher, presenting various and complex information as to the life and beliefs of ancient Greece.";
            label3.Text = "How does it work?";
            richTextBox2.Text = "The app is divided in 2 main parts: learning and testing.\nThe first section presents extensive information on the chosen aspect of mythological Greece, and the second develops games with the purpose of reviewing the user's knowledge.";
            label4.Text = "What are you waiting for? Click on the sidebar and dive into the wonders of Ancient Greece!";
            buttonAccount.Text = "My account";
            buttonLearn.Text = "Learn more";
            buttonStart.Text = "Start page";
            buttonTest.Text = "Test my knowledge";
            buttonExit.Text = "Exit";
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            FormTest formT = new FormTest();
            formT.Show();
            this.Hide();
        }

        private void ButtonAccount_MouseEnter(object sender, EventArgs e)
        {
            buttonAccount.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void buttonTest_MouseEnter(object sender, EventArgs e)
        {
            buttonTest.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void buttonLearn_MouseEnter(object sender, EventArgs e)
        {
            buttonLearn.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void buttonStart_MouseEnter(object sender, EventArgs e)
        {
            buttonStart.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

    }
}
