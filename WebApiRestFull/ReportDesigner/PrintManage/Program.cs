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
        static void Main()
        {
            SetConnection();
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);
        }

        public static void SetConnection()
        {
            string connstr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }
        static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            //Exception ex = e.Exception;
            //if (ex.InnerException == null)
            //    Utilities.WriteError(ex);
            //else
            //    Utilities.WriteError(ex.InnerException);
        }

    }
}
