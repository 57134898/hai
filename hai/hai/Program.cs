using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hai
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += Application_ThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("功能未实现{0}{1}", Environment.NewLine, ex.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(string.Format("功能未实现{0}{1}", Environment.NewLine, (e.ExceptionObject as Exception).Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show(string.Format("功能未实现{0}{1}", Environment.NewLine, e.Exception.Message), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
