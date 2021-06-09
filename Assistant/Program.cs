using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assistant
{
    static class Program
    {
        private static Mutex mutex;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Cheack_User());
            mutex = new Mutex(true, "OnlyRun");
            if (mutex.WaitOne(0, false))
            {
                //Application.Run(new Cheack_user());
                Application.Run(new Main());
            }
            else
            {
                MessageBox.Show("程序已经运行了，在右下角找找！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
    }
}
