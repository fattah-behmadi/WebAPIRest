namespace AppMobile.Rpt.small
{
    partial class RptKitchenSmall
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo objectConstructorInfo1 = new DevExpress.DataAccess.ObjectBinding.ObjectConstructorInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptKitchenSmall));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.XrTableCell22 = new DevExpress.XtraReports.UI.XRTableCell();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.XrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.XrTableCell23 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.XrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.XrTableRow6 = new DevExpress.XtraReports.UI.XRTableRow();
            this.ReportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.XrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.XrTable5 = new DevExpress.XtraReports.UI.XRTable();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.table1 = new DevExpress.XtraReports.UI.XRTable();
            this.XrTableCell19 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableRow7 = new DevExpress.XtraReports.UI.XRTableRow();
            this.tableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.XrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.XrTableCell21 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.XrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.XrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
            this.tableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.tableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.XrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Dpi = 254F;
            this.GroupFooter1.HeightF = 10.58333F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.table1});
            this.Detail1.Dpi = 254F;
            this.Detail1.HeightF = 68.79166F;
            this.Detail1.Name = "Detail1";
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.GroupFooter1});
            this.DetailReport.DataMember = "SaleInvoiceDetaile";
            this.DetailReport.DataSource = this.objectDataSource1;
            this.DetailReport.Dpi = 254F;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
            // 
            // XrTableCell22
            // 
            this.XrTableCell22.BackColor = System.Drawing.Color.Silver;
            this.XrTableCell22.Dpi = 254F;
            this.XrTableCell22.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold);
            this.XrTableCell22.ForeColor = System.Drawing.Color.Black;
            this.XrTableCell22.Name = "XrTableCell22";
            this.XrTableCell22.StylePriority.UseBackColor = false;
            this.XrTableCell22.StylePriority.UseFont = false;
            this.XrTableCell22.StylePriority.UseForeColor = false;
            this.XrTableCell22.StylePriority.UseTextAlignment = false;
            this.XrTableCell22.Text = "شماره فیش";
            this.XrTableCell22.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrTableCell22.Weight = 0.77073133068016786D;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.Constructor = objectConstructorInfo1;
            this.objectDataSource1.DataSource = typeof(System.Collections.Generic.List<Model.SaleInvoicePrint>);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // XrControlStyle1
            // 
            this.XrControlStyle1.BackColor = System.Drawing.Color.Silver;
            this.XrControlStyle1.Name = "XrControlStyle1";
            this.XrControlStyle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            // 
            // XrTableCell23
            // 
            this.XrTableCell23.BackColor = System.Drawing.Color.Silver;
            this.XrTableCell23.Dpi = 254F;
            this.XrTableCell23.Font = new System.Drawing.Font("B Titr", 8.25F, System.Drawing.FontStyle.Bold);
            this.XrTableCell23.Name = "XrTableCell23";
            this.XrTableCell23.StylePriority.UseBackColor = false;
            this.XrTableCell23.StylePriority.UseFont = false;
            this.XrTableCell23.StylePriority.UseTextAlignment = false;
            this.XrTableCell23.Text = "تاریخ";
            this.XrTableCell23.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.XrTableCell23.Weight = 0.7707313342697597D;
            // 
            // tableCell1
            // 
            this.tableCell1.BackColor = System.Drawing.Color.White;
            this.tableCell1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SaleInvoiceDetaile.NetPrice", "{0:#,#}")});
            this.tableCell1.Dpi = 254F;
            this.tableCell1.Font = new System.Drawing.Font("B Titr", 6F, System.Drawing.FontStyle.Bold);
            this.tableCell1.Name = "tableCell1";
            this.tableCell1.StylePriority.UseBackColor = false;
            this.tableCell1.StylePriority.UseFont = false;
            this.tableCell1.Weight = 0.71418808991639837D;
            // 
            // XrTable1
            // 
            this.XrTable1.BackColor = System.Drawing.Color.Silver;
            this.XrTable1.BorderColor = System.Drawing.Color.Black;
            this.XrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.XrTable1.Dpi = 254F;
            this.XrTable1.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold);
            this.XrTable1.ForeColor = System.Drawing.Color.Black;
            this.XrTable1.LocationFloat = new DevExpress.Utils.PointFloat(5.863176F, 248.7385F);
            this.XrTable1.Name = "XrTable1";
            this.XrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.XrTableRow1});
            this.XrTable1.SizeF = new System.Drawing.SizeF(514.1881F, 47.55063F);
            this.XrTable1.StylePriority.UseBackColor = false;
            this.XrTable1.StylePriority.UseBorderColor = false;
            this.XrTable1.StylePriority.UseBorders = false;
            this.XrTable1.StylePriority.UseFont = false;
            this.XrTable1.StylePriority.UseForeColor = false;
            this.XrTable1.StylePriority.UseTextAlignment = false;
            this.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrTableCell5
            // 
            this.XrTableCell5.Dpi = 254F;
            this.XrTableCell5.Font = new System.Drawing.Font("B Titr", 6F, System.Drawing.FontStyle.Bold);
            this.XrTableCell5.ForeColor = System.Drawing.Color.Black;
            this.XrTableCell5.Name = "XrTableCell5";
            this.XrTableCell5.StylePriority.UseFont = false;
            this.XrTableCell5.StylePriority.UseForeColor = false;
            this.XrTableCell5.Text = "توضیحات";
            this.XrTableCell5.Weight = 0.840326228077982D;
            // 
            // FieldCaption
            // 
            this.FieldCaption.BackColor = System.Drawing.Color.Transparent;
            this.FieldCaption.BorderColor = System.Drawing.Color.Black;
            this.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.FieldCaption.BorderWidth = 1F;
            this.FieldCaption.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.FieldCaption.ForeColor = System.Drawing.Color.Black;
            this.FieldCaption.Name = "FieldCaption";
            // 
            // XrTableRow6
            // 
            this.XrTableRow6.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.XrTableCell19,
            this.XrTableCell22});
            this.XrTableRow6.Dpi = 254F;
            this.XrTableRow6.Name = "XrTableRow6";
            this.XrTableRow6.Weight = 1D;
            // 
            // ReportHeaderBand1
            // 
            this.ReportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrPanel1,
            this.XrTable1,
            this.XrTable5});
            this.ReportHeaderBand1.Dpi = 254F;
            this.ReportHeaderBand1.HeightF = 296.2892F;
            this.ReportHeaderBand1.Name = "ReportHeaderBand1";
            // 
            // Detail
            // 
            this.Detail.Dpi = 254F;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrLabel46
            // 
            this.XrLabel46.BackColor = System.Drawing.Color.Transparent;
            this.XrLabel46.BorderColor = System.Drawing.Color.White;
            this.XrLabel46.Dpi = 254F;
            this.XrLabel46.Font = new System.Drawing.Font("B Titr", 8F, System.Drawing.FontStyle.Bold);
            this.XrLabel46.ForeColor = System.Drawing.Color.White;
            this.XrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(343.9627F, 44.08842F);
            this.XrLabel46.Name = "XrLabel46";
            this.XrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.XrLabel46.SizeF = new System.Drawing.SizeF(170.2253F, 71.59198F);
            this.XrLabel46.StyleName = "Title";
            this.XrLabel46.StylePriority.UseBackColor = false;
            this.XrLabel46.StylePriority.UseBorderColor = false;
            this.XrLabel46.StylePriority.UseFont = false;
            this.XrLabel46.StylePriority.UseForeColor = false;
            this.XrLabel46.StylePriority.UseTextAlignment = false;
            this.XrLabel46.Text = " نسخه آشپزخانه";
            this.XrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrTable5
            // 
            this.XrTable5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTable5.Dpi = 254F;
            this.XrTable5.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 8F);
            this.XrTable5.LocationFloat = new DevExpress.Utils.PointFloat(6.360077F, 130.365F);
            this.XrTable5.Name = "XrTable5";
            this.XrTable5.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.XrTableRow6,
            this.XrTableRow7});
            this.XrTable5.SizeF = new System.Drawing.SizeF(514.188F, 99.63501F);
            this.XrTable5.StylePriority.UseBorders = false;
            this.XrTable5.StylePriority.UseFont = false;
            this.XrTable5.StylePriority.UseTextAlignment = false;
            this.XrTable5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // table1
            // 
            this.table1.BackColor = System.Drawing.Color.Transparent;
            this.table1.BorderColor = System.Drawing.Color.Black;
            this.table1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
            this.table1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.table1.Dpi = 254F;
            this.table1.EvenStyleName = "XrControlStyle1";
            this.table1.Font = new System.Drawing.Font("B Nazanin", 8.25F);
            this.table1.LocationFloat = new DevExpress.Utils.PointFloat(6.360077F, 0F);
            this.table1.Name = "table1";
            this.table1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.tableRow1});
            this.table1.SizeF = new System.Drawing.SizeF(500.6399F, 68.63F);
            this.table1.StyleName = "XrControlStyle1";
            this.table1.StylePriority.UseBackColor = false;
            this.table1.StylePriority.UseBorderColor = false;
            this.table1.StylePriority.UseBorderDashStyle = false;
            this.table1.StylePriority.UseBorders = false;
            this.table1.StylePriority.UseFont = false;
            this.table1.StylePriority.UseTextAlignment = false;
            this.table1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrTableCell19
            // 
            this.XrTableCell19.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SaleInvoice.NumberOrder")});
            this.XrTableCell19.Dpi = 254F;
            this.XrTableCell19.Font = new System.Drawing.Font("B Titr", 11F, System.Drawing.FontStyle.Bold);
            this.XrTableCell19.ForeColor = System.Drawing.Color.Black;
            this.XrTableCell19.Name = "XrTableCell19";
            this.XrTableCell19.StylePriority.UseBackColor = false;
            this.XrTableCell19.StylePriority.UseFont = false;
            this.XrTableCell19.StylePriority.UseForeColor = false;
            this.XrTableCell19.Weight = 1.2292686693198323D;
            // 
            // XrTableRow7
            // 
            this.XrTableRow7.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.XrTableCell21,
            this.XrTableCell23});
            this.XrTableRow7.Dpi = 254F;
            this.XrTableRow7.Name = "XrTableRow7";
            this.XrTableRow7.Weight = 1D;
            // 
            // tableRow1
            // 
            this.tableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.tableCell1,
            this.tableCell2,
            this.tableCell4});
            this.tableRow1.Dpi = 254F;
            this.tableRow1.Name = "tableRow1";
            this.tableRow1.Weight = 1D;
            // 
            // XrTableCell2
            // 
            this.XrTableCell2.Dpi = 254F;
            this.XrTableCell2.Font = new System.Drawing.Font("B Titr", 6F, System.Drawing.FontStyle.Bold);
            this.XrTableCell2.ForeColor = System.Drawing.Color.Black;
            this.XrTableCell2.Name = "XrTableCell2";
            this.XrTableCell2.StylePriority.UseFont = false;
            this.XrTableCell2.StylePriority.UseForeColor = false;
            this.XrTableCell2.Text = "عـــنـــوان";
            this.XrTableCell2.Weight = 1.1524239554533287D;
            // 
            // XrPictureBox2
            // 
            this.XrPictureBox2.Dpi = 254F;
            this.XrPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("XrPictureBox2.Image")));
            this.XrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(328.0141F, 44.08842F);
            this.XrPictureBox2.Name = "XrPictureBox2";
            this.XrPictureBox2.SizeF = new System.Drawing.SizeF(186.1741F, 81.50517F);
            this.XrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // XrTableCell21
            // 
            this.XrTableCell21.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SaleInvoice.SaleInvoiceDate_SH")});
            this.XrTableCell21.Dpi = 254F;
            this.XrTableCell21.Font = new System.Drawing.Font("B Nazanin", 8.25F, System.Drawing.FontStyle.Bold);
            this.XrTableCell21.Name = "XrTableCell21";
            this.XrTableCell21.StylePriority.UseFont = false;
            this.XrTableCell21.Weight = 1.2292686657302405D;
            // 
            // XrTableCell4
            // 
            this.XrTableCell4.Dpi = 254F;
            this.XrTableCell4.Font = new System.Drawing.Font("B Titr", 6F, System.Drawing.FontStyle.Bold);
            this.XrTableCell4.ForeColor = System.Drawing.Color.Black;
            this.XrTableCell4.Name = "XrTableCell4";
            this.XrTableCell4.StylePriority.UseFont = false;
            this.XrTableCell4.StylePriority.UseForeColor = false;
            this.XrTableCell4.Text = "جمع کل";
            this.XrTableCell4.Weight = 0.77176183388841491D;
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.BorderColor = System.Drawing.Color.Black;
            this.Title.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Title.BorderWidth = 1F;
            this.Title.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.Title.ForeColor = System.Drawing.Color.Teal;
            this.Title.Name = "Title";
            // 
            // XrTableRow1
            // 
            this.XrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.XrTableCell4,
            this.XrTableCell5,
            this.XrTableCell2});
            this.XrTableRow1.Dpi = 254F;
            this.XrTableRow1.Name = "XrTableRow1";
            this.XrTableRow1.Weight = 1D;
            // 
            // XrLabel15
            // 
            this.XrLabel15.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SaleInvoice.SaleInvoice_Type")});
            this.XrLabel15.Dpi = 254F;
            this.XrLabel15.Font = new System.Drawing.Font("B Titr", 8F, System.Drawing.FontStyle.Bold);
            this.XrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(0.4967801F, 19.8541F);
            this.XrLabel15.Name = "XrLabel15";
            this.XrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.XrLabel15.SizeF = new System.Drawing.SizeF(316.0376F, 95.82631F);
            this.XrLabel15.StylePriority.UseFont = false;
            this.XrLabel15.StylePriority.UseTextAlignment = false;
            this.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // tableCell4
            // 
            this.tableCell4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SaleInvoiceDetaile.ProductName")});
            this.tableCell4.Dpi = 254F;
            this.tableCell4.Font = new System.Drawing.Font("B Titr", 6F, System.Drawing.FontStyle.Bold);
            this.tableCell4.Name = "tableCell4";
            this.tableCell4.StylePriority.UseFont = false;
            xrSummary1.FormatString = "{0:#}";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            this.tableCell4.Summary = xrSummary1;
            this.tableCell4.Weight = 1.0667636349217813D;
            // 
            // tableCell2
            // 
            this.tableCell2.BackColor = System.Drawing.Color.White;
            this.tableCell2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SaleInvoiceDetaile.Description")});
            this.tableCell2.Dpi = 254F;
            this.tableCell2.Font = new System.Drawing.Font("B Titr", 6F, System.Drawing.FontStyle.Bold);
            this.tableCell2.Name = "tableCell2";
            this.tableCell2.StylePriority.UseBackColor = false;
            this.tableCell2.StylePriority.UseFont = false;
            this.tableCell2.Weight = 0.77907880615641945D;
            // 
            // DataField
            // 
            this.DataField.BackColor = System.Drawing.Color.Transparent;
            this.DataField.BorderColor = System.Drawing.Color.Black;
            this.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.DataField.BorderWidth = 1F;
            this.DataField.Font = new System.Drawing.Font("Arial", 10F);
            this.DataField.ForeColor = System.Drawing.Color.Black;
            this.DataField.Name = "DataField";
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            // 
            // PageInfo
            // 
            this.PageInfo.BackColor = System.Drawing.Color.Transparent;
            this.PageInfo.BorderColor = System.Drawing.Color.Black;
            this.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.PageInfo.BorderWidth = 1F;
            this.PageInfo.Font = new System.Drawing.Font("Arial", 9F);
            this.PageInfo.ForeColor = System.Drawing.Color.Black;
            this.PageInfo.Name = "PageInfo";
            // 
            // XrPanel1
            // 
            this.XrPanel1.BackColor = System.Drawing.Color.Silver;
            this.XrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel46,
            this.XrPictureBox2,
            this.XrLabel15});
            this.XrPanel1.Dpi = 254F;
            this.XrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(5.863281F, 0F);
            this.XrPanel1.Name = "XrPanel1";
            this.XrPanel1.SizeF = new System.Drawing.SizeF(526.8115F, 120.8263F);
            this.XrPanel1.StylePriority.UseBackColor = false;
            // 
            // RptKitchenSmall
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeaderBand1,
            this.DetailReport});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Dpi = 254F;
            this.Margins = new System.Drawing.Printing.Margins(0, 5, 0, 0);
            this.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 2, 2, 254F);
            this.PageHeight = 5001;
            this.PageWidth = 537;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PrinterName = "Microsoft Print to PDF";
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.RequestParameters = false;
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic;
            this.ShowPrintMarginsWarning = false;
            this.ShowPrintStatusDialog = false;
            this.SnapGridSize = 25F;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField,
            this.XrControlStyle1});
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.XRTable table1;
        private DevExpress.XtraReports.UI.XRTableRow tableRow1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell1;
        private DevExpress.XtraReports.UI.XRTableCell tableCell2;
        private DevExpress.XtraReports.UI.XRTableCell tableCell4;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell22;
        private DevExpress.XtraReports.UI.XRControlStyle XrControlStyle1;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell23;
        private DevExpress.XtraReports.UI.XRTable XrTable1;
        private DevExpress.XtraReports.UI.XRTableRow XrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell4;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell2;
        private DevExpress.XtraReports.UI.XRControlStyle FieldCaption;
        private DevExpress.XtraReports.UI.XRTableRow XrTableRow6;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell19;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeaderBand1;
        private DevExpress.XtraReports.UI.XRPanel XrPanel1;
        private DevExpress.XtraReports.UI.XRLabel XrLabel46;
        private DevExpress.XtraReports.UI.XRPictureBox XrPictureBox2;
        private DevExpress.XtraReports.UI.XRLabel XrLabel15;
        private DevExpress.XtraReports.UI.XRTable XrTable5;
        private DevExpress.XtraReports.UI.XRTableRow XrTableRow7;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell21;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.XRControlStyle DataField;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
    }
}
