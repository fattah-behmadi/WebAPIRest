<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class RptKitchen
    Inherits DevExpress.XtraReports.UI.XtraReport

    'XtraReport overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Designer
    'It can be modified using the Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptKitchen))
        Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
        Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
        Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
        Me.ReportHeaderBand1 = New DevExpress.XtraReports.UI.ReportHeaderBand()
        Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPanel1 = New DevExpress.XtraReports.UI.XRPanel()
        Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel46 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrPictureBox2 = New DevExpress.XtraReports.UI.XRPictureBox()
        Me.XrTable1 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell17 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
        Me.ObjectDataSource1 = New DevExpress.DataAccess.ObjectBinding.ObjectDataSource(Me.components)
        Me.DetailReport = New DevExpress.XtraReports.UI.DetailReportBand()
        Me.Detail1 = New DevExpress.XtraReports.UI.DetailBand()
        Me.XrTable2 = New DevExpress.XtraReports.UI.XRTable()
        Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
        Me.XrTableCell1 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.XrTableCell4 = New DevExpress.XtraReports.UI.XRTableCell()
        Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
        Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
        Me.label7 = New DevExpress.XtraReports.UI.XRLabel()
        Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ObjectDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail
        '
        Me.Detail.Dpi = 100.0!
        Me.Detail.Expanded = False
        Me.Detail.HeightF = 25.0!
        Me.Detail.Name = "Detail"
        Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.Detail.StyleName = "DataField"
        Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'TopMargin
        '
        Me.TopMargin.Dpi = 100.0!
        Me.TopMargin.HeightF = 0!
        Me.TopMargin.Name = "TopMargin"
        Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'BottomMargin
        '
        Me.BottomMargin.Dpi = 100.0!
        Me.BottomMargin.HeightF = 0!
        Me.BottomMargin.Name = "BottomMargin"
        Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
        '
        'ReportHeaderBand1
        '
        Me.ReportHeaderBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel5, Me.label7, Me.XrLabel4, Me.XrLabel3, Me.XrPanel1, Me.XrTable1})
        Me.ReportHeaderBand1.Dpi = 100.0!
        Me.ReportHeaderBand1.HeightF = 147.0263!
        Me.ReportHeaderBand1.Name = "ReportHeaderBand1"
        '
        'XrLabel4
        '
        Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SaleInvoice.NumberOrder")})
        Me.XrLabel4.Dpi = 100.0!
        Me.XrLabel4.Font = New System.Drawing.Font("B Titr", 14.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(62.75689!, 59.29571!)
        Me.XrLabel4.Name = "XrLabel4"
        Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel4.SizeF = New System.Drawing.SizeF(148.2639!, 32.375!)
        Me.XrLabel4.StylePriority.UseFont = False
        Me.XrLabel4.StylePriority.UseTextAlignment = False
        Me.XrLabel4.Text = "XrLabel4"
        Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel3
        '
        Me.XrLabel3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SaleInvoice.SaleInvoice_Type")})
        Me.XrLabel3.Dpi = 100.0!
        Me.XrLabel3.Font = New System.Drawing.Font("B Titr", 14.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(10.06563!, 91.67071!)
        Me.XrLabel3.Name = "XrLabel3"
        Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel3.SizeF = New System.Drawing.SizeF(131.3188!, 33.56071!)
        Me.XrLabel3.StylePriority.UseFont = False
        Me.XrLabel3.StylePriority.UseTextAlignment = False
        Me.XrLabel3.Text = "XrLabel3"
        Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrPanel1
        '
        Me.XrPanel1.BackColor = System.Drawing.Color.Silver
        Me.XrPanel1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.XrLabel46, Me.XrPictureBox2})
        Me.XrPanel1.Dpi = 100.0!
        Me.XrPanel1.LocationFloat = New DevExpress.Utils.PointFloat(0.06561543!, 0!)
        Me.XrPanel1.Name = "XrPanel1"
        Me.XrPanel1.SizeF = New System.Drawing.SizeF(264.895!, 47.56941!)
        Me.XrPanel1.StylePriority.UseBackColor = False
        '
        'XrLabel1
        '
        Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SettingPrint.StateSale")})
        Me.XrLabel1.Dpi = 100.0!
        Me.XrLabel1.Font = New System.Drawing.Font("B Titr", 11.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(10.00002!, 14.43811!)
        Me.XrLabel1.Name = "XrLabel1"
        Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel1.SizeF = New System.Drawing.SizeF(155.6244!, 32.62392!)
        Me.XrLabel1.StylePriority.UseFont = False
        Me.XrLabel1.StylePriority.UseTextAlignment = False
        Me.XrLabel1.Text = "XrLabel1"
        Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel46
        '
        Me.XrLabel46.BackColor = System.Drawing.Color.Transparent
        Me.XrLabel46.BorderColor = System.Drawing.Color.White
        Me.XrLabel46.Dpi = 100.0!
        Me.XrLabel46.Font = New System.Drawing.Font("B Titr", 11.0!, System.Drawing.FontStyle.Bold)
        Me.XrLabel46.ForeColor = System.Drawing.Color.White
        Me.XrLabel46.LocationFloat = New DevExpress.Utils.PointFloat(173.7452!, 14.43811!)
        Me.XrLabel46.Name = "XrLabel46"
        Me.XrLabel46.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel46.SizeF = New System.Drawing.SizeF(91.08426!, 28.18582!)
        Me.XrLabel46.StyleName = "Title"
        Me.XrLabel46.StylePriority.UseBackColor = False
        Me.XrLabel46.StylePriority.UseBorderColor = False
        Me.XrLabel46.StylePriority.UseFont = False
        Me.XrLabel46.StylePriority.UseForeColor = False
        Me.XrLabel46.StylePriority.UseTextAlignment = False
        Me.XrLabel46.Text = " نسخه آشپزخانه"
        Me.XrLabel46.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
        '
        'XrPictureBox2
        '
        Me.XrPictureBox2.Dpi = 100.0!
        Me.XrPictureBox2.Image = CType(resources.GetObject("XrPictureBox2.Image"), System.Drawing.Image)
        Me.XrPictureBox2.LocationFloat = New DevExpress.Utils.PointFloat(165.6244!, 15.48077!)
        Me.XrPictureBox2.Name = "XrPictureBox2"
        Me.XrPictureBox2.SizeF = New System.Drawing.SizeF(109.0475!, 32.08864!)
        Me.XrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
        '
        'XrTable1
        '
        Me.XrTable1.BackColor = System.Drawing.Color.Silver
        Me.XrTable1.BorderColor = System.Drawing.Color.Black
        Me.XrTable1.Borders = CType(((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable1.Dpi = 100.0!
        Me.XrTable1.Font = New System.Drawing.Font("B Titr", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrTable1.ForeColor = System.Drawing.Color.Black
        Me.XrTable1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 125.2314!)
        Me.XrTable1.Name = "XrTable1"
        Me.XrTable1.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow1})
        Me.XrTable1.SizeF = New System.Drawing.SizeF(264.7332!, 20.75733!)
        Me.XrTable1.StylePriority.UseBackColor = False
        Me.XrTable1.StylePriority.UseBorderColor = False
        Me.XrTable1.StylePriority.UseBorders = False
        Me.XrTable1.StylePriority.UseFont = False
        Me.XrTable1.StylePriority.UseForeColor = False
        Me.XrTable1.StylePriority.UseTextAlignment = False
        Me.XrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow1
        '
        Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell5, Me.XrTableCell17, Me.XrTableCell2})
        Me.XrTableRow1.Dpi = 100.0!
        Me.XrTableRow1.Name = "XrTableRow1"
        Me.XrTableRow1.Weight = 1.0R
        '
        'XrTableCell5
        '
        Me.XrTableCell5.Dpi = 100.0!
        Me.XrTableCell5.Font = New System.Drawing.Font("B Titr", 9.25!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell5.ForeColor = System.Drawing.Color.Black
        Me.XrTableCell5.Name = "XrTableCell5"
        Me.XrTableCell5.StylePriority.UseFont = False
        Me.XrTableCell5.StylePriority.UseForeColor = False
        Me.XrTableCell5.Text = "توضــیحات"
        Me.XrTableCell5.Weight = 0.77176183388841491R
        '
        'XrTableCell17
        '
        Me.XrTableCell17.Dpi = 100.0!
        Me.XrTableCell17.Font = New System.Drawing.Font("B Titr", 9.0!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell17.ForeColor = System.Drawing.Color.Black
        Me.XrTableCell17.Name = "XrTableCell17"
        Me.XrTableCell17.StylePriority.UseFont = False
        Me.XrTableCell17.StylePriority.UseForeColor = False
        Me.XrTableCell17.Text = "مقدار"
        Me.XrTableCell17.Weight = 0.29458183917033154R
        '
        'XrTableCell2
        '
        Me.XrTableCell2.Dpi = 100.0!
        Me.XrTableCell2.Font = New System.Drawing.Font("B Titr", 9.5!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell2.ForeColor = System.Drawing.Color.Black
        Me.XrTableCell2.Name = "XrTableCell2"
        Me.XrTableCell2.StylePriority.UseFont = False
        Me.XrTableCell2.StylePriority.UseForeColor = False
        Me.XrTableCell2.Text = "عـــنـــوان"
        Me.XrTableCell2.Weight = 1.5296800231315491R
        '
        'Title
        '
        Me.Title.BackColor = System.Drawing.Color.Transparent
        Me.Title.BorderColor = System.Drawing.Color.Black
        Me.Title.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.Title.BorderWidth = 1.0!
        Me.Title.Font = New System.Drawing.Font("Tahoma", 24.0!, System.Drawing.FontStyle.Bold)
        Me.Title.ForeColor = System.Drawing.Color.Teal
        Me.Title.Name = "Title"
        '
        'FieldCaption
        '
        Me.FieldCaption.BackColor = System.Drawing.Color.Transparent
        Me.FieldCaption.BorderColor = System.Drawing.Color.Black
        Me.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.FieldCaption.BorderWidth = 1.0!
        Me.FieldCaption.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
        Me.FieldCaption.ForeColor = System.Drawing.Color.Black
        Me.FieldCaption.Name = "FieldCaption"
        '
        'PageInfo
        '
        Me.PageInfo.BackColor = System.Drawing.Color.Transparent
        Me.PageInfo.BorderColor = System.Drawing.Color.Black
        Me.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.PageInfo.BorderWidth = 1.0!
        Me.PageInfo.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.PageInfo.ForeColor = System.Drawing.Color.Black
        Me.PageInfo.Name = "PageInfo"
        '
        'DataField
        '
        Me.DataField.BackColor = System.Drawing.Color.Transparent
        Me.DataField.BorderColor = System.Drawing.Color.Black
        Me.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None
        Me.DataField.BorderWidth = 1.0!
        Me.DataField.Font = New System.Drawing.Font("Arial", 10.0!)
        Me.DataField.ForeColor = System.Drawing.Color.Black
        Me.DataField.Name = "DataField"
        Me.DataField.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        '
        'XrControlStyle1
        '
        Me.XrControlStyle1.BackColor = System.Drawing.Color.Silver
        Me.XrControlStyle1.Name = "XrControlStyle1"
        Me.XrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        '
        'ObjectDataSource1
        '
        Me.ObjectDataSource1.DataSource = GetType(Model.SaleInvoicePrint)
        Me.ObjectDataSource1.Name = "ObjectDataSource1"
        '
        'DetailReport
        '
        Me.DetailReport.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail1, Me.GroupFooter1})
        Me.DetailReport.DataMember = "SaleInvoiceDetaile"
        Me.DetailReport.DataSource = Me.ObjectDataSource1
        Me.DetailReport.Dpi = 100.0!
        Me.DetailReport.Level = 0
        Me.DetailReport.Name = "DetailReport"
        '
        'Detail1
        '
        Me.Detail1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTable2})
        Me.Detail1.Dpi = 100.0!
        Me.Detail1.HeightF = 20.75733!
        Me.Detail1.Name = "Detail1"
        '
        'XrTable2
        '
        Me.XrTable2.BorderColor = System.Drawing.Color.Black
        Me.XrTable2.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
        Me.XrTable2.Dpi = 100.0!
        Me.XrTable2.Font = New System.Drawing.Font("B Nazanin", 9.0!)
        Me.XrTable2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
        Me.XrTable2.Name = "XrTable2"
        Me.XrTable2.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRow2})
        Me.XrTable2.SizeF = New System.Drawing.SizeF(264.7332!, 20.75733!)
        Me.XrTable2.StylePriority.UseBackColor = False
        Me.XrTable2.StylePriority.UseBorderColor = False
        Me.XrTable2.StylePriority.UseBorders = False
        Me.XrTable2.StylePriority.UseFont = False
        Me.XrTable2.StylePriority.UseForeColor = False
        Me.XrTable2.StylePriority.UseTextAlignment = False
        Me.XrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrTableRow2
        '
        Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell1, Me.XrTableCell3, Me.XrTableCell4})
        Me.XrTableRow2.Dpi = 100.0!
        Me.XrTableRow2.Name = "XrTableRow2"
        Me.XrTableRow2.Weight = 1.0R
        '
        'XrTableCell1
        '
        Me.XrTableCell1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SaleInvoiceDetaile.Description")})
        Me.XrTableCell1.Dpi = 100.0!
        Me.XrTableCell1.Font = New System.Drawing.Font("IRANSansWeb(FaNum)", 8.999999!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell1.ForeColor = System.Drawing.Color.Black
        Me.XrTableCell1.Name = "XrTableCell1"
        Me.XrTableCell1.StylePriority.UseFont = False
        Me.XrTableCell1.StylePriority.UseForeColor = False
        Me.XrTableCell1.Text = "توضــیحات"
        Me.XrTableCell1.Weight = 0.77176183388841491R
        '
        'XrTableCell3
        '
        Me.XrTableCell3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SaleInvoiceDetaile.Qty")})
        Me.XrTableCell3.Dpi = 100.0!
        Me.XrTableCell3.Font = New System.Drawing.Font("IRANSansWeb(FaNum)", 8.999999!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell3.ForeColor = System.Drawing.Color.Black
        Me.XrTableCell3.Name = "XrTableCell3"
        Me.XrTableCell3.StylePriority.UseFont = False
        Me.XrTableCell3.StylePriority.UseForeColor = False
        Me.XrTableCell3.Text = "مقدار"
        Me.XrTableCell3.Weight = 0.29458183917033154R
        '
        'XrTableCell4
        '
        Me.XrTableCell4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SaleInvoiceDetaile.ProductName")})
        Me.XrTableCell4.Dpi = 100.0!
        Me.XrTableCell4.Font = New System.Drawing.Font("IRANSansWeb(FaNum)", 8.999999!, System.Drawing.FontStyle.Bold)
        Me.XrTableCell4.ForeColor = System.Drawing.Color.Black
        Me.XrTableCell4.Name = "XrTableCell4"
        Me.XrTableCell4.StylePriority.UseBorders = False
        Me.XrTableCell4.StylePriority.UseFont = False
        Me.XrTableCell4.StylePriority.UseForeColor = False
        Me.XrTableCell4.Text = "عـــنـــوان"
        Me.XrTableCell4.Weight = 1.5296800231315491R
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel2})
        Me.GroupFooter1.Dpi = 100.0!
        Me.GroupFooter1.HeightF = 27.77777!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'XrLabel2
        '
        Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SaleInvoice.Description")})
        Me.XrLabel2.Dpi = 100.0!
        Me.XrLabel2.Font = New System.Drawing.Font("B Nazanin", 14.0!)
        Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.06561279!, 0!)
        Me.XrLabel2.Name = "XrLabel2"
        Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
        Me.XrLabel2.SizeF = New System.Drawing.SizeF(264.6676!, 23.0!)
        Me.XrLabel2.StylePriority.UseFont = False
        Me.XrLabel2.Text = "XrLabel2"
        '
        'label7
        '
        Me.label7.Dpi = 100.0!
        Me.label7.Font = New System.Drawing.Font("B Titr", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label7.LocationFloat = New DevExpress.Utils.PointFloat(211.0208!, 59.63677!)
        Me.label7.Name = "label7"
        Me.label7.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.label7.SizeF = New System.Drawing.SizeF(45.97922!, 32.03395!)
        Me.label7.StylePriority.UseFont = False
        Me.label7.StylePriority.UsePadding = False
        Me.label7.StylePriority.UseTextAlignment = False
        Me.label7.Text = "فیش :"
        Me.label7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'XrLabel5
        '
        Me.XrLabel5.Dpi = 100.0!
        Me.XrLabel5.Font = New System.Drawing.Font("B Titr", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(141.3844!, 91.67071!)
        Me.XrLabel5.Name = "XrLabel5"
        Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
        Me.XrLabel5.SizeF = New System.Drawing.SizeF(115.6155!, 32.03394!)
        Me.XrLabel5.StylePriority.UseFont = False
        Me.XrLabel5.StylePriority.UsePadding = False
        Me.XrLabel5.StylePriority.UseTextAlignment = False
        Me.XrLabel5.Text = "وضعیت سفارش :"
        Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
        '
        'RptKitchen
        '
        Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.ReportHeaderBand1, Me.DetailReport})
        Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.ObjectDataSource1})
        Me.DataSource = Me.ObjectDataSource1
        Me.Margins = New System.Drawing.Printing.Margins(0, 1, 0, 0)
        Me.PageHeight = 1969
        Me.PageWidth = 268
        Me.PaperKind = System.Drawing.Printing.PaperKind.Custom
        Me.RightToLeft = DevExpress.XtraReports.UI.RightToLeft.Yes
        Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
        Me.ShowPrintMarginsWarning = False
        Me.ShowPrintStatusDialog = False
        Me.SnapGridSize = 9.84252!
        Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField, Me.XrControlStyle1})
        Me.Version = "16.1"
        CType(Me.XrTable1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ObjectDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XrTable2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
    Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
    Friend WithEvents ReportHeaderBand1 As DevExpress.XtraReports.UI.ReportHeaderBand
    Friend WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents XrTable1 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell17 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
    Friend WithEvents XrPanel1 As DevExpress.XtraReports.UI.XRPanel
    Friend WithEvents XrLabel46 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrPictureBox2 As DevExpress.XtraReports.UI.XRPictureBox
    Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents ObjectDataSource1 As DevExpress.DataAccess.ObjectBinding.ObjectDataSource
    Friend WithEvents DetailReport As DevExpress.XtraReports.UI.DetailReportBand
    Friend WithEvents Detail1 As DevExpress.XtraReports.UI.DetailBand
    Friend WithEvents XrTable2 As DevExpress.XtraReports.UI.XRTable
    Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
    Friend WithEvents XrTableCell1 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents XrTableCell4 As DevExpress.XtraReports.UI.XRTableCell
    Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
    Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
    Friend WithEvents label7 As DevExpress.XtraReports.UI.XRLabel
End Class
