using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportDesigner
{
    static class Program
    {


        [STAThread]
        static void Main()
        {
            //Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);

            DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
            DevExpress.XtraEditors.WindowsFormsSettings.EnableFormSkins();
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultLookAndFeel.SetSkinStyle("Office 2016 Colorful");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmReportDesignet());
        }

        static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //    Exception ex = e.Exception;
            //    if (ex.InnerException == null)
            //        Utilities.WriteError(ex);
            //    else
            //        Utilities.WriteError(ex.InnerException);
        }

    }
}
