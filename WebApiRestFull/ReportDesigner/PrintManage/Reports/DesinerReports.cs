using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportDesigner
{
    public class DesinerReports
    {

        public DesinerReports()
        {
            ExistsDirectory();
        }

        void ExistsDirectory()
        {
            string path = Application.StartupPath + "\\Report";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = path;
        }
        /// <summary>
        /// چاپ یک لیست از فاکتورها
        /// </summary>
        /// <param name="liReport"></param>
        /// <returns></returns>
        public bool PrintListReport(ref List<XtraReport> liReport)
        {
            try
            {
                if (liReport.Count == 0) return false;
                foreach (XtraReport report in liReport)
                {
                    ReportPrintTool pts = new ReportPrintTool(report);
                    pts.Print();
                }
                liReport.Clear();
                liReport = new List<XtraReport>();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool PrintListReport(XtraReport report)
        {
            try
            {
                if (report == null) return false;
                ReportPrintTool pts = new ReportPrintTool(report);
                pts.Print();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        /// <summary>
        /// ارسال داده به ریپورت مورد نظر که اگر از قبل فایل آن طراحی شده بود آن را یافت کرده و اطلاعات را به ان ارسال میکند
        /// </summary>
        /// <typeparam name="T">نوع داده ارسالی</typeparam>
        /// <param name="data">داده ارسالی به ریپورت</param>
        /// <param name="report">ریپورت مورد نظر جهت مقدار دهی</param>
        /// <returns> ریپورت تنظیم شده </returns>
        public XtraReport CreatReport<T>(T data, XtraReport report)
        {
            List<T> li = new List<T>();
            li.Add(data);
            report = OpenReport(report);

            if (report != null)
            {

                report.DataSource = CreateObjectDataSource<T>(li);
                report.PrintingSystem.ShowMarginsWarning = false;
                report.ShowPrintStatusDialog = false;
                report.RequestParameters = false;
                report.PrintingSystem.ShowMarginsWarning = false;
                //report.FillDataSource();
            }
            return report;
        }

        /// <summary>
        /// ساخت منبع دیتا برای ریپورت
        /// </summary>
        /// <param name="li">دیتای ارسالی به فاکتور</param>
        /// <returns></returns>
        object CreateObjectDataSource<T>(List<T> li)
        {
            ObjectDataSource dataSource = new ObjectDataSource();
            dataSource.Name = typeof(T).FullName + "DataSource";
            dataSource.DataSource = li;
            //dataSource.DataSource = typeof(Employees.EmployeeList);
            //var parameterNoOfItems = new Parameter("noOfItems", typeof(int), 0);
            //dataSource.Parameters.Add(parameterNoOfItems);
            //dataSource.DataMember = "GetData";
            dataSource.Constructor = ObjectConstructorInfo.Default;
            return dataSource;
        }

        private XtraReport OpenReport(string ReportName)
        {
            XtraReport report = null;
            string path = Application.StartupPath + "\\Report";
            if (Directory.Exists(path))
            {
                path += string.Format($"\\{ReportName}.repx");
                if (File.Exists(path))
                {
                    report = new XtraReport();
                    report.LoadLayout(path);

                }
            }
            return report;


        }
     
        
        /// <summary>
        /// جستجوی فاکتور طراحی شده در سیستم
        /// </summary>
        /// <param name="report"></param>
        /// <returns></returns>
        private XtraReport OpenReport(XtraReport report)
        {
                Type objtype = report.GetType();
                string path = Application.StartupPath + "\\Report";
                if (Directory.Exists(path))
                {
                    path += string.Format($"\\{objtype.Name}.repx");
                    if (File.Exists(path))
                    {
                        //report= XtraReport.FromFile(path, true);
                        report.LoadLayout(path);
                    }
                }
            return report;

        }


    }
}
