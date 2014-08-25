using System;
using System.Windows.Forms;

namespace MashBesh
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GeneralMenu());
        }


        
    }
}
