using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ReportDesigner;
using WebApiRestFull;
using Model;

namespace Designer
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        ReportDesigner.DesinerReports rpt = new DesinerReports();
        private void btnShowfrm_Click(object sender, EventArgs e)
        {
            SaleInvoicePrint datasource = new SaleInvoicePrint();
            datasource.SettingPrint = new SaleInvoicePrint.Setting();

            //RptKitchen report = new RptKitchen();
            //report = rpt.CreatReport<SaleInvoicePrint>(datasource, report);

            frmReportDesignet frm = new frmReportDesignet();
            //frm.showReport(report);
            frm.ShowDialog();
        }
    }
}
