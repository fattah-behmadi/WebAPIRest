using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraReports.UI;
using System.IO;

namespace ReportDesigner
{
    public partial class frmReportDesignet : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmReportDesignet()
        {
            InitializeComponent();
            ExistsDirectory();
        }

        void ExistsDirectory()
        {
            string path = Application.StartupPath + "\\Report";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            DevExpress.XtraReports.Configuration.Settings.Default.StorageOptions.RootDirectory = path;
        }
        XtraReport reportDesign;
        public void showReport(XtraReport report)
        {
            reportDesign = report;
            reportDesigner1.OpenReport(reportDesign);
        }
   
        private void btnOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            string path = Application.StartupPath + "\\Report";    
            using (OpenFileDialog op = new OpenFileDialog())
            {
                op.InitialDirectory = path;
                op.Filter = "Report files (*.repx)|*.repx";
                op.FilterIndex = 2;
                op.RestoreDirectory = true;
                op.Title = "بازکردن فایل های فاکتور برای طراحی";
                if (op.ShowDialog() == DialogResult.OK)
                {
                    reportDesign = new XtraReport();
                    reportDesign.LoadLayout(op.FileName);
                    reportDesigner1.OpenReport(reportDesign);

                }
            }


        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            string path = Application.StartupPath + "\\Report";
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.InitialDirectory = path;
                saveFile.Filter = "Report files (*.repx)|*.repx";
                saveFile.FilterIndex = 2;
                saveFile.RestoreDirectory = true;
                saveFile.Title = "ذخیره فایل های فاکتور برای طراحی";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    reportDesign.SaveLayout(saveFile.FileName);
                    //reportDesigner1.OpenReport(report);

                }
            }

        }


    }
}