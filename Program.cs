using System;
using System.Windows.Forms;

namespace Metec.MVBDClient
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new FormMain());
            // Application.Run(new FormDrawing("192.168.14.74"));
            Application.Run(new FormDrawing("192.168.12.91"));
            //Application.Run(new FormDrawing("192.168.1.102"));
            // Application.Run(new FormDrawing("192.168.1.137"));
            // Application.Run(new FormDrawing("192.168.154.64"));
            // Application.Run(new Form1());
            // Application.Run(new MVBDClientReflection.FormReflection());
        }
    }
}