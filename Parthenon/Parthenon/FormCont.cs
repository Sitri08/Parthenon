using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parthenon
{
    public partial class FormCont : Form
    {
        setare setariUtilizator;

        public FormCont()
        {
            InitializeComponent();
        }

        private void FormCont_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            ClassParthenon.IncarcaDateUtilizator(ref setariUtilizator);
            AfiseazaDateUtilizator();
            IncarcaPagina();
            SelecteazaSetari();
        }

        public void IncarcaPagina()
        {
            if (setariUtilizator.language == 1) Englezifica();
        }

        public void Englezifica()
        {
            buttonAccount.Text = "My account";
            buttonLearn.Text = "Learn more";
            buttonStart.Text = "Start page";
            buttonTest.Text = "Test my knowledge";
            buttonExit.Text = "Back";

            label1.Text = "Account settings";
            label2.Text = "About me:";
            label4.Text = "Gender:";
            label5.Text = "Birthday:";
            buttonUpdateInfo.Text = "Update info";
            buttonResetImage.Text = "Reset";
            buttonChooseDifferentImage.Text = "Choose image\n(png/jpg/jpeg/gif)";
            checkBox3.Text = "Other";
        }

        //incarca setarile curente ale utilizatorului
        public void SelecteazaSetari()
        {
            if (setariUtilizator.gender[0] == 'M') checkBox2.Checked = true;
            else if (setariUtilizator.gender[0] == 'F') checkBox1.Checked = true;
            else checkBox3.Checked = true;
            string data = setariUtilizator.birthDate;
            dateTimePicker1.Value = Convert.ToDateTime(data);
            pictureBox1.Image = pictureBoxUser.Image;
        }

        public void AfiseazaDateUtilizator()
        {
            if (setariUtilizator.profilePicture == "N/A")
                pictureBoxUser.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + @"\profile_pictures\profile_default.png");
            else pictureBoxUser.Image = Image.FromFile(Application.ExecutablePath.Remove(Application.ExecutablePath.Length - 14) + @"\profile_pictures\" + setariUtilizator.profilePicture);
        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            var formStart = new FormDeschidere();
            this.Close();
            formStart.Show();
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
            return;
        }

        private void ButtonExit_MouseHover(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void ButtonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_default;
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            var formStart = new FormDeschidere();
            formStart.Show();
            this.Close();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = checkBox3.Checked = false;
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = checkBox3.Checked = false;
        }

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = checkBox2.Checked = false;
        }

        private void ButtonUpdateInfo_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked) setariUtilizator.gender = "F";
            else if (checkBox2.Checked) setariUtilizator.gender = "M";
            else setariUtilizator.gender = "Altele";
            setariUtilizator.birthDate = "" + dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Month + "/" + dateTimePicker1.Value.Year;
            ClassParthenon.ActualizeazaDateUtilizator(setariUtilizator);
            MessageBox.Show("Succes!");
        }

        private void ButtonChooseDifferentImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            if (dialog.FileName.IndexOf("jpg") == -1 &&
                dialog.FileName.IndexOf("jpeg") == -1 &&
                dialog.FileName.IndexOf("png") == -1 &&
                dialog.FileName.IndexOf("gif") == -1) return;
            string cale = dialog.FileName;
            Image img = Image.FromFile(cale);
            pictureBox1.Image = img;
            cale = cale.Split('\\')[cale.Split('\\').Length - 1];
            img.Save(AppDomain.CurrentDomain.BaseDirectory + @"\profile_pictures\" + cale);
            setariUtilizator.profilePicture = cale;
        }

        private void ButtonResetImage_Click(object sender, EventArgs e)
        {
            setariUtilizator.profilePicture = "N/A";
            pictureBox1.Image = Parthenon.Properties.Resources.profile_default;
        }

        private void ButtonChooseDifferentImage_MouseHover(object sender, EventArgs e)
        {
            buttonChooseDifferentImage.BackgroundImage = Parthenon.Properties.Resources.button_hover;
        }

        private void ButtonChooseDifferentImage_MouseLeave(object sender, EventArgs e)
        {
            buttonChooseDifferentImage.BackgroundImage = Parthenon.Properties.Resources.button_default;

        }

        private void ButtonResetImage_MouseHover(object sender, EventArgs e)
        {
            buttonResetImage.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void ButtonResetImage_MouseLeave(object sender, EventArgs e)
        {
            buttonResetImage.BackgroundImage = Parthenon.Properties.Resources.button_default;

        }

        private void ButtonUpdateInfo_MouseHover(object sender, EventArgs e)
        {
            buttonUpdateInfo.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void ButtonUpdateInfo_MouseLeave(object sender, EventArgs e)
        {
            buttonUpdateInfo.BackgroundImage = Parthenon.Properties.Resources.button_default;

        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void buttonUpdateInfo_MouseEnter(object sender, EventArgs e)
        {
            buttonUpdateInfo.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void buttonChooseDifferentImage_MouseEnter(object sender, EventArgs e)
        {
            buttonChooseDifferentImage.BackgroundImage = Parthenon.Properties.Resources.button_hover;

        }

        private void buttonResetImage_MouseEnter(object sender, EventArgs e)
        {
            buttonResetImage.BackgroundImage = Parthenon.Properties.Resources.button_hover;

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

        private void button1_Click(object sender, EventArgs e)
        {
            FormStatistici frm = new FormStatistici();
            frm.Show();
            this.Close();
        }


        private void buttonTest_Click(object sender, EventArgs e)
        {
            FormTest frm = new FormTest();
            frm.Show();
            this.Close();
        }

        private void buttonLearn_Click(object sender, EventArgs e)
        {
            FormInvata frm = new FormInvata();
            frm.Show();
            this.Close();
        }
    }
}
