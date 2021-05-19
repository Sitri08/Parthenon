using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ParthenonMethods
{
    public class loadControls
    {

        public static void afiseazaMessageBox(string x)
        {
            MessageBox.Show(x);
        }
    }
}

namespace Parthenon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormDeschidere());
        }
    }
}
