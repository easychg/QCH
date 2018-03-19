using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QCHManage
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //ConnectionManger.G_FrmNew = new FrmNew();
            //ConnectionManger.G_FrmMain = new FrmMain();
            http h = new http();
            Application.Run(h);
            //Application.Run(new Frm_SystemSet());
        }
    }
}
