using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WMPLib;

namespace Parthenon
{
    public partial class FormPlayVideo : Form
    {
        string caleFisier;
        public FormPlayVideo(string nume)
        {
            caleFisier = nume;
            InitializeComponent();
        }

        private void FormPlayVideo_Load(object sender, EventArgs e)
        {
            // TODO  Insert a valid path in the line below.
            PlayFile(caleFisier);
            WindowState = FormWindowState.Maximized;
            if (caleFisier.Contains("Midas")) this.Text = "Midas";
            else if (caleFisier.Contains("ErosPsyche")) this.Text = "Eros & Psyche";
            else if (caleFisier.Contains("Arachne")) this.Text = "Arachne";
            else this.Text = "Sisyphus";
        }

        public void PlayFile(string x)
        {
            Player.URL = x;
            Player.Ctlcontrols.play();
        }
    }
}
