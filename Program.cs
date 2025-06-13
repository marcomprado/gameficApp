using System;
using System.Windows.Forms;
using GamificacaoApp.Forms; // Certifique-se do namespace correto

namespace GamificacaoApp
{
    static class Program
    {
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
