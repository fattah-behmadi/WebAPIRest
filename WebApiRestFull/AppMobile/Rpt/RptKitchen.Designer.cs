namespace AppMobile.Rpt
{
    partial class RptKitchen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RptKitchen));
            this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
            this.XrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageInfo = new DevExpress.XtraReports.UI.XRControlStyle();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.XrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.XrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrLabel46 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.DataField = new DevExpress.XtraReports.UI.XRControlStyle();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.XrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
            this.Title = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ObjectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.label7 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.XrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeaderBand1 = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.FieldCaption = new DevExpress.XtraReports.UI.XRControlStyle();
            this.XrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.XrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.XrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.XrControlStyle1 = new DevExpress.XtraReports.UI.XRControlStyle();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.XrTableCell17 = new DevExpress.XtraReports.UI.XRTableCell();
            this.XrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.XrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail1
            // 
            this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrTable2});
            this.Detail1.Dpi = 100F;
            this.Detail1.HeightF = 20.75733F;
            this.Detail1.Name = "Detail1";
            // 
            // XrTableCell3
            // 
            this.XrTableCell3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SaleInvoiceDetaile.Qty")});
            this.XrTableCell3.Dpi = 100F;
            this.XrTableCell3.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 8.999999F, System.Drawing.FontStyle.Bold);
            this.XrTableCell3.ForeColor = System.Drawing.Color.Black;
            this.XrTableCell3.Name = "XrTableCell3";
            this.XrTableCell3.StylePriority.UseFont = false;
            this.XrTableCell3.StylePriority.UseForeColor = false;
            this.XrTableCell3.Text = "مقدار";
            this.XrTableCell3.Weight = 0.29458183917033154D;
            // 
            // XrLabel4
            // 
            this.XrLabel4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SaleInvoice.NumberOrder")});
            this.XrLabel4.Dpi = 100F;
            this.XrLabel4.Font = new System.Drawing.Font("B Titr", 14F, System.Drawing.FontStyle.Bold);
            this.XrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(62.75689F, 59.29571F);
            this.XrLabel4.Name = "XrLabel4";
            this.XrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel4.SizeF = new System.Drawing.SizeF(148.2639F, 32.375F);
            this.XrLabel4.StylePriority.UseFont = false;
            this.XrLabel4.StylePriority.UseTextAlignment = false;
            this.XrLabel4.Text = "XrLabel4";
            this.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.Expanded = false;
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.StyleName = "DataField";
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrTableRow1
            // 
            this.XrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.XrTableCell5,
            this.XrTableCell17,
            this.XrTableCell2});
            this.XrTableRow1.Dpi = 100F;
            this.XrTableRow1.Name = "XrTableRow1";
            this.XrTableRow1.Weight = 1D;
            // 
            // XrTableCell1
            // 
            this.XrTableCell1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SaleInvoiceDetaile.Description")});
            this.XrTableCell1.Dpi = 100F;
            this.XrTableCell1.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 8.999999F, System.Drawing.FontStyle.Bold);
            this.XrTableCell1.ForeColor = System.Drawing.Color.Black;
            this.XrTableCell1.Name = "XrTableCell1";
            this.XrTableCell1.StylePriority.UseFont = false;
            this.XrTableCell1.StylePriority.UseForeColor = false;
            this.XrTableCell1.Text = "توضــیحات";
            this.XrTableCell1.Weight = 0.77176183388841491D;
            // 
            // XrTableCell2
            // 
            this.XrTableCell2.Dpi = 100F;
            this.XrTableCell2.Font = new System.Drawing.Font("B Titr", 9.5F, System.Drawing.FontStyle.Bold);
            this.XrTableCell2.ForeColor = System.Drawing.Color.Black;
            this.XrTableCell2.Name = "XrTableCell2";
            this.XrTableCell2.StylePriority.UseFont = false;
            this.XrTableCell2.StylePriority.UseForeColor = false;
            this.XrTableCell2.Text = "عـــنـــوان";
            this.XrTableCell2.Weight = 1.5296800231315491D;
            // 
            // XrLabel46
            // 
            this.XrLabel46.BackColor = System.Drawing.Color.Transparent;
            this.XrLabel46.BorderColor = System.Drawing.Color.White;
            this.XrLabel46.Dpi = 100F;
            this.XrLabel46.Font = new System.Drawing.Font("B Titr", 11F, System.Drawing.FontStyle.Bold);
            this.XrLabel46.ForeColor = System.Drawing.Color.White;
            this.XrLabel46.LocationFloat = new DevExpress.Utils.PointFloat(173.7452F, 14.43811F);
            this.XrLabel46.Name = "XrLabel46";
            this.XrLabel46.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel46.SizeF = new System.Drawing.SizeF(91.08426F, 28.18582F);
            this.XrLabel46.StyleName = "Title";
            this.XrLabel46.StylePriority.UseBackColor = false;
            this.XrLabel46.StylePriority.UseBorderColor = false;
            this.XrLabel46.StylePriority.UseFont = false;
            this.XrLabel46.StylePriority.UseForeColor = false;
            this.XrLabel46.StylePriority.UseTextAlignment = false;
            this.XrLabel46.Text = " نسخه آشپزخانه";
            this.XrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // XrLabel3
            // 
            this.XrLabel3.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SaleInvoice.SaleInvoice_Type")});
            this.XrLabel3.Dpi = 100F;
            this.XrLabel3.Font = new System.Drawing.Font("B Titr", 14F, System.Drawing.FontStyle.Bold);
            this.XrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(10.06563F, 91.67071F);
            this.XrLabel3.Name = "XrLabel3";
            this.XrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel3.SizeF = new System.Drawing.SizeF(131.3188F, 33.56071F);
            this.XrLabel3.StylePriority.UseFont = false;
            this.XrLabel3.StylePriority.UseTextAlignment = false;
            this.XrLabel3.Text = "XrLabel3";
            this.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
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
            this.DataField.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel2});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 27.77777F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // XrTableCell4
            // 
            this.XrTableCell4.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SaleInvoiceDetaile.ProductName")});
            this.XrTableCell4.Dpi = 100F;
            this.XrTableCell4.Font = new System.Drawing.Font("IRANSansWeb(FaNum)", 8.999999F, System.Drawing.FontStyle.Bold);
            this.XrTableCell4.ForeColor = System.Drawing.Color.Black;
            this.XrTableCell4.Name = "XrTableCell4";
            this.XrTableCell4.StylePriority.UseBorders = false;
            this.XrTableCell4.StylePriority.UseFont = false;
            this.XrTableCell4.StylePriority.UseForeColor = false;
            this.XrTableCell4.Text = "عـــنـــوان";
            this.XrTableCell4.Weight = 1.5296800231315491D;
            // 
            // XrLabel5
            // 
            this.XrLabel5.Dpi = 100F;
            this.XrLabel5.Font = new System.Drawing.Font("B Titr", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.XrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(141.3844F, 91.67071F);
            this.XrLabel5.Name = "XrLabel5";
            this.XrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.XrLabel5.SizeF = new System.Drawing.SizeF(115.6155F, 32.03394F);
            this.XrLabel5.StylePriority.UseFont = false;
            this.XrLabel5.StylePriority.UsePadding = false;
            this.XrLabel5.StylePriority.UseTextAlignment = false;
            this.XrLabel5.Text = "وضعیت سفارش :";
            this.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // DetailReport
            // 
            this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1,
            this.GroupFooter1});
            this.DetailReport.DataMember = "SaleInvoiceDetaile";
            this.DetailReport.DataSource = this.ObjectDataSource1;
            this.DetailReport.Dpi = 100F;
            this.DetailReport.Level = 0;
            this.DetailReport.Name = "DetailReport";
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
            // ObjectDataSource1
            // 
            this.ObjectDataSource1.DataSource = typeof(Model.SaleInvoicePrint);
            this.ObjectDataSource1.Name = "ObjectDataSource1";
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // label7
            // 
            this.label7.Dpi = 100F;
            this.label7.Font = new System.Drawing.Font("B Titr", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label7.LocationFloat = new DevExpress.Utils.PointFloat(211.0208F, 59.63677F);
            this.label7.Name = "label7";
            this.label7.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.label7.SizeF = new System.Drawing.SizeF(45.97922F, 32.03395F);
            this.label7.StylePriority.UseFont = false;
            this.label7.StylePriority.UsePadding = false;
            this.label7.StylePriority.UseTextAlignment = false;
            this.label7.Text = "فیش :";
            this.label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrTable2
            // 
            this.XrTable2.BorderColor = System.Drawing.Color.Black;
            this.XrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.XrTable2.Dpi = 100F;
            this.XrTable2.Font = new System.Drawing.Font("B Nazanin", 9F);
            this.XrTable2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.XrTable2.Name = "XrTable2";
            this.XrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.XrTableRow2});
            this.XrTable2.SizeF = new System.Drawing.SizeF(264.7332F, 20.75733F);
            this.XrTable2.StylePriority.UseBackColor = false;
            this.XrTable2.StylePriority.UseBorderColor = false;
            this.XrTable2.StylePriority.UseBorders = false;
            this.XrTable2.StylePriority.UseFont = false;
            this.XrTable2.StylePriority.UseForeColor = false;
            this.XrTable2.StylePriority.UseTextAlignment = false;
            this.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrLabel2
            // 
            this.XrLabel2.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SaleInvoice.Description")});
            this.XrLabel2.Dpi = 100F;
            this.XrLabel2.Font = new System.Drawing.Font("B Nazanin", 14F);
            this.XrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(0.06561279F, 0F);
            this.XrLabel2.Name = "XrLabel2";
            this.XrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel2.SizeF = new System.Drawing.SizeF(264.6676F, 23F);
            this.XrLabel2.StylePriority.UseFont = false;
            this.XrLabel2.Text = "XrLabel2";
            // 
            // ReportHeaderBand1
            // 
            this.ReportHeaderBand1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel5,
            this.label7,
            this.XrLabel4,
            this.XrLabel3,
            this.XrPanel1,
            this.XrTable1});
            this.ReportHeaderBand1.Dpi = 100F;
            this.ReportHeaderBand1.HeightF = 147.0263F;
            this.ReportHeaderBand1.Name = "ReportHeaderBand1";
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
            // XrTableCell5
            // 
            this.XrTableCell5.Dpi = 100F;
            this.XrTableCell5.Font = new System.Drawing.Font("B Titr", 9.25F, System.Drawing.FontStyle.Bold);
            this.XrTableCell5.ForeColor = System.Drawing.Color.Black;
            this.XrTableCell5.Name = "XrTableCell5";
            this.XrTableCell5.StylePriority.UseFont = false;
            this.XrTableCell5.StylePriority.UseForeColor = false;
            this.XrTableCell5.Text = "توضــیحات";
            this.XrTableCell5.Weight = 0.77176183388841491D;
            // 
            // XrTableRow2
            // 
            this.XrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.XrTableCell1,
            this.XrTableCell3,
            this.XrTableCell4});
            this.XrTableRow2.Dpi = 100F;
            this.XrTableRow2.Name = "XrTableRow2";
            this.XrTableRow2.Weight = 1D;
            // 
            // XrTable1
            // 
            this.XrTable1.BackColor = System.Drawing.Color.Silver;
            this.XrTable1.BorderColor = System.Drawing.Color.Black;
            this.XrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.XrTable1.Dpi = 100F;
            this.XrTable1.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold);
            this.XrTable1.ForeColor = System.Drawing.Color.Black;
            this.XrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 125.2314F);
            this.XrTable1.Name = "XrTable1";
            this.XrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.XrTableRow1});
            this.XrTable1.SizeF = new System.Drawing.SizeF(264.7332F, 20.75733F);
            this.XrTable1.StylePriority.UseBackColor = false;
            this.XrTable1.StylePriority.UseBorderColor = false;
            this.XrTable1.StylePriority.UseBorders = false;
            this.XrTable1.StylePriority.UseFont = false;
            this.XrTable1.StylePriority.UseForeColor = false;
            this.XrTable1.StylePriority.UseTextAlignment = false;
            this.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrPictureBox2
            // 
            this.XrPictureBox2.Dpi = 100F;
            this.XrPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("XrPictureBox2.Image")));
            this.XrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(165.6244F, 15.48077F);
            this.XrPictureBox2.Name = "XrPictureBox2";
            this.XrPictureBox2.SizeF = new System.Drawing.SizeF(109.0475F, 32.08864F);
            this.XrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            // 
            // XrControlStyle1
            // 
            this.XrControlStyle1.BackColor = System.Drawing.Color.Silver;
            this.XrControlStyle1.Name = "XrControlStyle1";
            this.XrControlStyle1.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // XrTableCell17
            // 
            this.XrTableCell17.Dpi = 100F;
            this.XrTableCell17.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold);
            this.XrTableCell17.ForeColor = System.Drawing.Color.Black;
            this.XrTableCell17.Name = "XrTableCell17";
            this.XrTableCell17.StylePriority.UseFont = false;
            this.XrTableCell17.StylePriority.UseForeColor = false;
            this.XrTableCell17.Text = "مقدار";
            this.XrTableCell17.Weight = 0.29458183917033154D;
            // 
            // XrLabel1
            // 
            this.XrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SettingPrint.StateSale")});
            this.XrLabel1.Dpi = 100F;
            this.XrLabel1.Font = new System.Drawing.Font("B Titr", 11F, System.Drawing.FontStyle.Bold);
            this.XrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(10.00002F, 14.43811F);
            this.XrLabel1.Name = "XrLabel1";
            this.XrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.XrLabel1.SizeF = new System.Drawing.SizeF(155.6244F, 32.62392F);
            this.XrLabel1.StylePriority.UseFont = false;
            this.XrLabel1.StylePriority.UseTextAlignment = false;
            this.XrLabel1.Text = "XrLabel1";
            this.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // XrPanel1
            // 
            this.XrPanel1.BackColor = System.Drawing.Color.Silver;
            this.XrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.XrLabel1,
            this.XrLabel46,
            this.XrPictureBox2});
            this.XrPanel1.Dpi = 100F;
            this.XrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(0.06561543F, 0F);
            this.XrPanel1.Name = "XrPanel1";
            this.XrPanel1.SizeF = new System.Drawing.SizeF(264.895F, 47.56941F);
            this.XrPanel1.StylePriority.UseBackColor = false;
            // 
            // RptKitchen
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportHeaderBand1,
            this.DetailReport});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.ObjectDataSource1});
            this.DataSource = this.ObjectDataSource1;
            this.Margins = new System.Drawing.Printing.Margins(0, 1, 0, 0);
            this.PageHeight = 1969;
            this.PageWidth = 268;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes;
            this.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic;
            this.ShowPrintMarginsWarning = false;
            this.ShowPrintStatusDialog = false;
            this.SnapGridSize = 9.84252F;
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.Title,
            this.FieldCaption,
            this.PageInfo,
            this.DataField,
            this.XrControlStyle1});
            this.Version = "16.1";
            ((System.ComponentModel.ISupportInitialize)(this.ObjectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail1;
        private DevExpress.XtraReports.UI.XRTable XrTable2;
        private DevExpress.XtraReports.UI.XRTableRow XrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell1;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell3;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell4;
        private DevExpress.XtraReports.UI.XRLabel XrLabel4;
        private DevExpress.XtraReports.UI.XRControlStyle PageInfo;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRTableRow XrTableRow1;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell5;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell17;
        private DevExpress.XtraReports.UI.XRTableCell XrTableCell2;
        private DevExpress.XtraReports.UI.XRLabel XrLabel46;
        private DevExpress.XtraReports.UI.XRLabel XrLabel3;
        private DevExpress.XtraReports.UI.XRControlStyle DataField;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel XrLabel2;
        private DevExpress.XtraReports.UI.XRLabel XrLabel5;
        private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource ObjectDataSource1;
        private DevExpress.XtraReports.UI.XRControlStyle Title;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.XRLabel label7;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeaderBand1;
        private DevExpress.XtraReports.UI.XRPanel XrPanel1;
        private DevExpress.XtraReports.UI.XRLabel XrLabel1;
        private DevExpress.XtraReports.UI.XRPictureBox XrPictureBox2;
        private DevExpress.XtraReports.UI.XRTable XrTable1;
        private DevExpress.XtraReports.UI.XRControlStyle FieldCaption;
        private DevExpress.XtraReports.UI.XRControlStyle XrControlStyle1;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    }
}
