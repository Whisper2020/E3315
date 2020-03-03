using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortControlDemo
{
    static class Program
    {
       //主程序入口
        [STAThread]
        static void main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Send_and_Receive());
        }
    }
}
