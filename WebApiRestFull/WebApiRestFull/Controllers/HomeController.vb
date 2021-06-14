Imports System.Net
Imports System.Web.Http
Imports System.Data.SqlClient
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Security.Cryptography
Imports System.IO
Imports System.Threading
Imports JntNum2Text
Imports System.Globalization
Imports DevExpress.XtraReports.UI
Imports Model
Imports BL
Imports UtilitiesMethod
Imports System.Threading.Tasks
Imports System.ComponentModel

Public Class HomeController
    Inherits ApiController


    Dim DefaultContact As String
    Dim funcSql As New ConectToDatabaseSQL
    Dim reportDesign As New ReportDesigner.DesinerReports

    Dim IDUser As Integer
    Dim _SettingUser As tblPrinterUserSetting
    Dim _SettingFactor As tblSettingIDFactor
    Dim IdSandogh As String
    Dim bgw As BackgroundWorker

    Sub GetDefaultContact()
        Try
            Dim contact = funcSql.CellReader("tblSettingIDFactor", "DefultContact")
            If String.IsNullOrEmpty(contact) Then
                DefaultContact = 0
            Else
                DefaultContact = contact
            End If
        Catch ex As Exception
            WriteText("GetDefaultContact : " & ex.Message)
        End Try
    End Sub

#Region "ذخیره فاکتور"
    <HttpPost> <Route("api/home/SaveFactor/{NumberFact}/{NumFishUpdate}")>
    Public Function SaveFactor(NumberFact As String, NumFishUpdate As String, <FromBody> JsonString As List(Of ListFood)) As String
        Dim SaleInvoiceID As String = "0"
        Dim NumberFish As String = "0"
        Dim UpdateFact As Boolean = False
        Dim tahvilgirande As String = "تحویل گیرنده"
        Dim TozihatFactor = "ثبت فاکتور با تبلت"
        Dim TafziliMoshtari, ExpFood, IDUserGarson, SumMoney, NumberMiz As String
        Try

            Dim Listfood = JsonString(0)
            funcSql.Culture_EN()
            If NumberFact <> "0" Then
                UpdateFact = True
            End If
            If Not UpdateFact Then
                Dim TimeEnChange = DateTime.Now
                SaleInvoiceID = funcSql.GetFactID_Froosh()
                NumberFish = funcSql.GetFishNumber_Froosh(TimeEnChange.ToString("yyyy-MM-dd "))
            Else
                SaleInvoiceID = NumberFact
                NumberFish = NumFishUpdate
            End If

            Dim CountOFFood As Integer = Listfood.ChildForooshKala_TedadAsli

            NumberMiz = Listfood.Table_Number
            TafziliMoshtari = Listfood.Costumer_Code
            tahvilgirande = Listfood.Costumer_Name
            IDUserGarson = Listfood.User_Id
            IDUser = Listfood.User_Id.ToInt()
            SumMoney = Listfood.Price_Sum
            ExpFood = Listfood.ChildForooshKala_SharhKala
            IdSandogh = funcSql.CellReader("tblSandogh", "Tafzili_ID", "[User_ID]=" & Listfood.User_Id & "")
            Dim ValueVazeyat = Listfood.ForooshKalaParent_TypeFact

            If String.IsNullOrEmpty(TafziliMoshtari) Then
                If String.IsNullOrEmpty(DefaultContact) Then
                    GetDefaultContact()
                End If
                TafziliMoshtari = DefaultContact
            End If


            _SettingUser = localizationDBContext.SettingRepo.GetSettigPrinterUser(IDUser.ToInt())
            _SettingFactor = localizationDBContext.SettingRepo.GetSetting()

            If UpdateFact Then
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Update, " TblParent_FrooshKala", "[ForooshKalaParent_Tafzili]=" & TafziliMoshtari & ",[ForooshKalaParent_Date]='" & DateTime.Now & "',[ForooshKalaParent_Tozih]=N'" & TozihatFactor & "',[ForooshKalaParent_JameMablaghPaye]=" & SumMoney & ",[ForooshKalaParent_JameMaliyat]=" & Listfood.JameMablaghMaliat & ",[ForooshKalaParent_JameTakhfif]=" & Listfood.JameMablaghTakhfif & ",[ForooshKalaParent_JameMablaghPasTakhfif]=" & Listfood.JameMablaghKhales & ",[ForooshKalaParent_JameKol]=" & Listfood.JameMablaghKhales & ",[ForooshKalaParent_JameService]=" & Listfood.JameMablaghServic & ",[ForooshKalaParent_UserId]=" & IDUser & ",[ForooshKalaParent_ShomareMiz]=" & NumberMiz & ",[ForooshKalaParent_ModateEntezar]=0,[ForooshKalaParent_ShomareFish]=" & NumberFish & ",[ForooshKalaParent_StatusFact]=N'ویرایش شده',[ForooshKalaParent_Time]='" & TimeOfDay.ToString("h:mm:ss tt") & "',[ForooshKalaParent_TypeFact]=N'" & ValueVazeyat & "',[ForooshKalaParent_SelectedAdress]=N'" & Listfood.Address & "',[ForooshKalaParent_SelectedTell]=N'" & Listfood.Tell & "',[ForooshKalaParent_NumberPager]=0,[ForooshKalaParent_Tahvilgirande]=N'" & tahvilgirande & "',[ForooshKalaParent_TasvieFact]=0", "[ForooshKalaParent_ID]=" & NumberFact & "")
            Else
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, " TblParent_FrooshKala", "" & CLng(SaleInvoiceID) & "," & TafziliMoshtari & ",'" & DateTime.Now & "',N'" & TozihatFactor & "'," & SumMoney & "," & Listfood.JameMablaghMaliat & "," & Listfood.JameMablaghTakhfif & "," & Listfood.JameMablaghKhales & "," & Listfood.JameMablaghKhales & "," & Listfood.JameMablaghServic & "," & IDUser & "," & GetSerialSanad() & ",'" & NumberMiz & "',0," & NumberFish & ",N'عادی','" & TimeOfDay.ToString("h:mm:ss tt") & "',N'" & ValueVazeyat & "',N'" & Listfood.Address.ToString() & "',N'" & Listfood.Tell.ToString() & "',0,N'" & tahvilgirande & "',0,0,0")
            End If

            If result = "1" Then
                Dim sumFactorMaliat As Double = 0
                InsertChildAndKardeks(SaleInvoiceID, UpdateFact, JsonString, sumFactorMaliat)
                CreateDocument(SaleInvoiceID, DateTime.Now.ToString("yyyy-MM-dd ", New CultureInfo("en-US")), TimeOfDay.ToString("h:mm:ss tt", New CultureInfo("en-US")), TafziliMoshtari, ExpFood,
                               SumMoney, 0, 0, 0, SumMoney, UpdateFact)
                Dim idfactor = NumberFact
                If idfactor = "0" Then
                    idfactor = SaleInvoiceID
                End If
                Dim jameMaliat = funcSql.ConvertToDouble(funcSql.CellReader("TblChild_ForooshKala", "sum(ChildForooshKala_MaliyatMablagh)", "ChildForooshKala_ParentID=" & idfactor))
                Dim jamekol = funcSql.ConvertToDouble(funcSql.CellReader("TblChild_ForooshKala", "sum(ChildForooshKala_JameKol)", "ChildForooshKala_ParentID =" & idfactor))
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Update, " TblParent_FrooshKala", "ForooshKalaParent_JameMaliyat =" & jameMaliat & ",ForooshKalaParent_JameKol=" & sumFactorMaliat & "", "[ForooshKalaParent_ID]=" & idfactor & "")
            Else
                WriteText("not save SaleInvoice : " & result)

            End If

            PrintFish(SaleInvoiceID, SumMoney, UpdateFact)
            If result = "1" Then
                Return NumberFish
            Else
                WriteText("Error Return Result End Function =  " & result)
                Return result
            End If

        Catch ex As Exception
            If ex.InnerException IsNot Nothing Then
                WriteText("SaveFactor InnerException : " & ex.InnerException.Message)
            Else
                WriteText("SaveFactor : " & ex.Message)
            End If
            Return NumberFish
        End Try
    End Function
#End Region


#Region "چاپ فاکتور "

    ''' <summary>
    ''' طراحی فاکتور موردنظر بایک ساختار یکپارچه
    ''' </summary>
    ''' <param name="data">شی داده های سفارش</param>
    ''' <param name="report">فاکتور مورد نظر برای طراحی</param>
    ''' <param name="printername">نام پرینتر مورد نظر جهت چاپ</param>
    ''' <returns></returns>
    Public Function DesignReport(ByVal datasource As Model.SaleInvoicePrint, ByRef report As XtraReport, ByVal printername As String,
                          ByVal sumPrice As Long, ByVal updated As Boolean, Optional ByVal stateorderprint As String = "") As XtraReport

        Try
            Dim price As Long
            If sumPrice > 0 Then
                If _SettingFactor.Setting_CurrencySymbol.Contains("ریال") Then
                    price = sumPrice.ToString.Substring(0, sumPrice.ToString().Length - 1)
                Else
                    price = sumPrice
                End If
            End If
            Dim stateOrder = ""
            If String.IsNullOrEmpty(stateorderprint) Then
                If updated Then
                    stateOrder = "فیش اصلاحی"
                Else
                    stateOrder = "فیش جدید"
                End If
            Else
                stateOrder = stateorderprint

            End If
            Dim textprice = (Num2Text.ToFarsi(price) + " تومان ").ToString()
            Dim _setting As New SaleInvoicePrint.Setting
            _setting.DateTimeToday = DateTime.Now.JulianToPersianDate()
            _setting.PriceText = textprice
            _setting.StateSale = stateOrder
            datasource.SettingPrint = _setting
            'report = reportDesign.CreatReport(Of Model.SaleInvoicePrint)(datasource, report)
            report.PrinterName = printername

            Dim dts As New List(Of Model.SaleInvoicePrint)
            dts.Add(datasource)
            report.DataSource = dts

            Return report

        Catch ex As Exception
            WriteText("Design Report : " & ex.Message)
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' چاپ لیست فاکتور ها
    ''' </summary>
    Public Sub PrintFish(SaleID As String, sumPrice As String, updated As Boolean)
        Try
            Dim data = GetSaleInvoice(SaleID)
            If _SettingUser.BironbarMoshtari Or _SettingUser.DakhelSalonMoshtari Or _SettingUser.PeykMoshtari Then
                RptCustomer(data, sumPrice, updated)
            End If

            If _SettingUser.BironbarAshpazkhane Or _SettingUser.DakhelSalonAshpazkhane Or _SettingUser.PeykAshpazkhane Then
                RptKitchen(data, sumPrice, updated)
            End If

            If _SettingUser.BironbarSandogh Or _SettingUser.DakhelSalonSandogh Or _SettingUser.PeykSandogh Then
                RptCashier(data, sumPrice, updated)
            End If

        Catch ex As Exception
            WriteText("Print Report : " & ex.Message)
        End Try
    End Sub
    Sub RptCustomer(ByVal data As Model.SaleInvoicePrint, ByVal sumPrice As Long, updated As Boolean)
        Try
            Dim report
            If _SettingUser.Costumer5Cm Then
                report = New RptCustomerSmall
            Else
                report = New RptCustomer
            End If

            report = DesignReport(data, report, _SettingUser.PrinterCustomer, sumPrice, updated)

            report.RequestParameters = False
            report.ShowPrintStatusDialog = False
            report.PrintingSystem.ShowMarginsWarning = False
            report.CreateDocument(False)
            Dim printTool As New DevExpress.XtraPrinting.PrintToolBase(report.PrintingSystem)
            printTool.PrinterSettings.Copies = 1
            printTool.Print(_SettingUser.PrinterCustomer)
        Catch ex As Exception
            WriteText("Print RptCustomer : " & ex.Message)
        End Try
    End Sub
    Sub RptCashier(ByVal data As Model.SaleInvoicePrint, ByVal sumPrice As Long, updated As Boolean)
        Try
            Dim report
            If _SettingUser.Sandogh5Cm Then
                report = New RptCashierSmall
            Else
                report = New RptCashier
            End If
            report = DesignReport(data, report, _SettingUser.PrinterSandogh, sumPrice, updated)

            report.RequestParameters = False
            report.ShowPrintStatusDialog = False
            report.PrintingSystem.ShowMarginsWarning = False
            report.CreateDocument(False)
            Dim printTool As New DevExpress.XtraPrinting.PrintToolBase(report.PrintingSystem)
            printTool.PrinterSettings.Copies = 1
            printTool.Print(_SettingUser.PrinterSandogh)
        Catch ex As Exception
            WriteText("Print RptCashier : " & ex.Message)
        End Try
    End Sub
    Sub RptKitchen(ByVal data As Model.SaleInvoicePrint, ByVal sumPrice As Long, updated As Boolean)
        Try
            If data.SaleInvoice Is Nothing Then
                Return
            End If

            Dim report
            If _SettingUser.Kitchen5Cm Then
                report = New RptKitchenSmall
            Else
                report = New RptKitchen
            End If

            report = DesignReport(data, report, _SettingUser.PrinterAshpazkhane, sumPrice, updated)

            report.RequestParameters = False
            report.ShowPrintStatusDialog = False
            report.PrintingSystem.ShowMarginsWarning = False
            report.CreateDocument(False)
            Dim printTool As New DevExpress.XtraPrinting.PrintToolBase(report.PrintingSystem)
            printTool.PrinterSettings.Copies = 1
            printTool.Print(_SettingUser.PrinterAshpazkhane)
        Catch ex As Exception
            WriteText("Print RptKitchen : " & ex.Message)
        End Try
    End Sub
    Function GetSaleInvoice(ByVal saleinvoiceID As Long) As Model.SaleInvoicePrint
        Return localizationDBContext.SaleInvoiceRepo.PrintSaleInvoice(saleinvoiceID)
    End Function

#End Region

    Public Function GetSerialSanad() As String
        Try
            Using myConnection As New System.Data.SqlClient.SqlConnection(constr)

                Using myCommand As New System.Data.SqlClient.SqlCommand("SELECT isnull(MAX([Serial_Sanad]),0) + 1  FROM [tblParentSanad] ", myConnection)
                    myCommand.CommandType = System.Data.CommandType.Text
                    myCommand.CommandTimeout = 0
                    If myConnection.State = ConnectionState.Closed Then myConnection.Open()
                    Dim MaxID = CLng(myCommand.ExecuteScalar())
                    myConnection.Close()
                    Return MaxID
                End Using

            End Using
        Catch ex As Exception
            WriteText("GetSerialSanad : " & ex.Message)
        End Try
    End Function
    Function InsertChildAndKardeks(_IDFact As String, IsUpdate As Boolean, ByVal DTkala As List(Of ListFood), ByRef sumfactor As Integer) As Boolean

        Try
            If IsUpdate Then
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Delete, "TblChild_ForooshKala", , "ChildForooshKala_ParentID=" & CLng(_IDFact))
            End If

            Dim sharhekala = ""
            Dim darsadMalyat As Double = funcSql.ConvertToDouble(funcSql.CellReader("tblSettingIDFactor", "Setting_DarsadMaliyat", ""))
            Dim sumkalamaliat As Double = 0
            Dim jameMablagh As Double = 0

            For Each food As ListFood In DTkala

                Dim FoodCode = food.ID_Kala
                Dim tedad = food.ChildForooshKala_TedadAsli
                Dim Gheymat = funcSql.CellReader("TblKala", "GheymatForoshAsli", "ID_Kala=" & FoodCode & "")
                Dim productName = funcSql.CellReader("TblKala", "Name_Kala", "ID_Kala=" & FoodCode & "")

                Dim moafazMaliat As Boolean = funcSql.CellReader("TblKala", "MoafMaliyat", "ID_Kala=" & FoodCode & "")
                Dim sum As Double = 0

                Dim MablaghMaliat = 0
                sum = Gheymat * tedad
                If Not moafazMaliat Then

                    MablaghMaliat = (funcSql.ConvertToDouble(sum) / 100) * darsadMalyat
                    sumkalamaliat += Gheymat * tedad
                Else
                    jameMablagh += Gheymat * tedad
                End If
                Dim jamekol = sum + MablaghMaliat
                sharhekala = food.ChildForooshKala_SharhKala
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, "TblChild_ForooshKala", "" & FoodCode & "," & CLng(_IDFact) & ",N'" & sharhekala & "'," & tedad & "," & Gheymat & "," & sum & ",0,0," & sum & "," & MablaghMaliat & "," & darsadMalyat & "," & jamekol & ",N'" & productName & "'")

            Next

            Dim maliatm As Double = ((Convert.ToInt64(sumkalamaliat) / 100) * darsadMalyat)
            sumfactor = (sumkalamaliat + maliatm) + jameMablagh

            Return True
        Catch ex As Exception
            WriteText("InsertChildAndKardeks" & ex.Message)
        End Try
    End Function
    Sub CreateDocument(NumberFact As Long, DateSanad As Date, Time As String, TafziliMoshtari As Integer, Exp As String, MablaghKol As Long, MablagheTakhfif As Long, Maliyat As Long, MablagheKhadamat As Long, MablaghKhales As Long, UpdateSanad As Boolean)

        Try
            Dim indx As Integer = 0
            Dim SerialSanad, NumberSanad
            pdate.Culture_EN()


            If UpdateSanad Then
                SerialSanad = funcSql.CellReader("[dbo].[TblParent_FrooshKala]", "[ForooshKalaParent_SerialSanad]", "ForooshKalaParent_ID=" & NumberFact & "").ToString
                ''''''''''''''UpdateParent'''''''''''''''''''
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Update, "tblParentSanad", "Exption_Sanad= N'" & Exp & "',Edited_Sanad=1 ,Date_Modify='" & DateSanad & "',User_ID=" & IDUser & "", "[Serial_Sanad]=" & SerialSanad & "")
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Delete, "tblChildeSanad", , "[Serial_Sanad]=" & SerialSanad & "")
            Else
                ''''''''''''''SaveParent'''''''''''''''''''
                SerialSanad = funcSql.CellReader("[dbo].[tblParentSanad]", " isnull(MAX([Serial_Sanad]),0)+1").ToString
                NumberSanad = funcSql.CellReader("[dbo].[tblParentSanad]", "isnull(MAX(Number_Sanad),0)+1").ToString

            End If

            Dim AccIDBes, MoeinIDBes, TafziliIDBes, AccIDBedhkar, MoeinIDBedehkar, TafziliIDBedehkar, AccIDKhadamatBes, MoeinIDKhadamatBes,
                TafziliIDKhadamatBes, AccIDKhadamatBedekhar, MoeinIDKhadamatBedehkar, TafziliIDKhadamatBedehkar, AccIDArzeshAfzodeBes, MoeinIDArzeshAfzodeBes,
                AccIDTakhfifForshBed, MoeinIDTakhfifForoshBed As String
            Dim DtSanad, DtKhadamat, DtArzeshAfzode, DtTakhfifForosh As New DataTable

            DtSanad = funcSql.ReadTable("tblSettingAcc", "NameAcc=N'فروش'")
            DtKhadamat = funcSql.ReadTable("tblSettingAcc", "NameAcc=N'خدمات حین فروش'")
            DtArzeshAfzode = funcSql.ReadTable("tblSettingAcc", "NameAcc=N'ارزش افزوده فروش'")
            DtTakhfifForosh = funcSql.ReadTable("tblSettingAcc", "NameAcc=N'تخفیف فروش'")

            With DtTakhfifForosh.Rows(0)
                AccIDTakhfifForshBed = .Item(3)
                MoeinIDTakhfifForoshBed = .Item(4)
            End With

            With DtArzeshAfzode.Rows(0)
                AccIDArzeshAfzodeBes = .Item(6)
                MoeinIDArzeshAfzodeBes = .Item(7)
            End With

            With DtSanad.Rows(0)
                AccIDBedhkar = .Item(3)
                MoeinIDBedehkar = .Item(4)
                TafziliIDBedehkar = IIf(IsDBNull(.Item(5)), "NULL", .Item(5))
                AccIDBes = .Item(6)
                MoeinIDBes = .Item(7)
                TafziliIDBes = IIf(IsDBNull(.Item(8)), "NULL", .Item(8))
            End With

            With DtKhadamat.Rows(0)
                AccIDKhadamatBedekhar = .Item(3)
                MoeinIDKhadamatBedehkar = .Item(4)
                TafziliIDKhadamatBedehkar = IIf(IsDBNull(.Item(5)), "NULL", .Item(5))
                AccIDKhadamatBes = .Item(6)
                MoeinIDKhadamatBes = .Item(7)
                TafziliIDKhadamatBes = IIf(IsDBNull(.Item(8)), "NULL", .Item(8))
            End With


            result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, "tblParentSanad", "" & SerialSanad & "," & NumberSanad & ",3,4,'" & DateSanad & "','" & Time & "',N'" & Exp & "',1,0,0,0,NULL," & IDUser & "")
            Dim Tozihat = String.Format("فاکتور فروش به شماره {0}  ", NumberFact)

            '''''''''''ArtikelHesabDaryaftaniBedehkar''''''''''''''''''''''
            Dim MablaghHesabDaryaftani = ((MablaghKol - MablagheTakhfif) + (Maliyat))
            If MablaghHesabDaryaftani > 0 Then
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, "tblChildeSanad", "" & SerialSanad & "," & AccIDBedhkar & "," & TafziliMoshtari & "," & MoeinIDBedehkar & ",N'" & Tozihat & "'," & NumberFact & ",5," & funcSql.ConvertToDouble(MablaghHesabDaryaftani) & ",0")
            End If

            If MablagheTakhfif > 0 Then
                ''''''''''''ArtikelTakhfifForoshBedehkar'''''''''''''''''
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, "tblChildeSanad", "" & SerialSanad & "," & AccIDTakhfifForshBed & ",NULL," & MoeinIDTakhfifForoshBed & ",N'" & Tozihat & "'," & NumberFact & ",5," & funcSql.ConvertToDouble(MablagheTakhfif) & ",0")
            End If

            If funcSql.ConvertToDouble((MablaghKol - MablagheKhadamat)) > 0 Then
                ''''''''''' ArtikelForoshBestankar''''''''''''''''''''
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, "tblChildeSanad", "" & SerialSanad & "," & AccIDBes & "," & TafziliIDBes & "," & MoeinIDBes & ",N'" & Tozihat & "'," & NumberFact & ",5,0," & funcSql.ConvertToDouble((MablaghKol - MablagheKhadamat)) & "")
            End If

            If MablagheKhadamat > 0 Then
                ''''''''''''ArtikelKhadamatBestankar'''''''''''''''''''''
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, "tblChildeSanad", "" & SerialSanad & "," & AccIDKhadamatBes & "," & TafziliIDKhadamatBes & "," & MoeinIDKhadamatBes & ",N'" & Tozihat & "'," & NumberFact & ",5,0," & funcSql.ConvertToDouble(MablagheKhadamat) & "")
            End If

            If Maliyat > 0 Then
                ''''''''''''ArtikelArzeshAfzodeBestankar'''''''''''''''''''''
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, "tblChildeSanad", "" & SerialSanad & "," & AccIDArzeshAfzodeBes & ",NULL," & MoeinIDArzeshAfzodeBes & ",N'" & Tozihat & "'," & NumberFact & ",5,0," & funcSql.ConvertToDouble(Maliyat) & "")
            End If

        Catch ex As Exception

            WriteText("CreatDocument =  " & ex.Message)
        End Try
    End Sub


    Public Class ListFood
        <JsonProperty("ID_Kala")>
        Public Property ID_Kala() As String
        <JsonProperty("ChildForooshKala_TedadAsli")>
        Public Property ChildForooshKala_TedadAsli() As String
        <JsonProperty("SumPriceRow")>
        Public Property SumPriceRow() As String
        <JsonProperty("Table_Number")>
        Public Property Table_Number() As String
        <JsonProperty("Costumer_Code")>
        Public Property Costumer_Code() As String

        <JsonProperty("Costumer_Name")>
        Public Property Costumer_Name() As String
        <JsonProperty("Print_Confirm")>
        Public Property Print_Confirm() As Boolean
        <JsonProperty("ChildForooshKala_SharhKala")>
        Public Property ChildForooshKala_SharhKala() As String
        <JsonProperty("User_Id")>
        Public Property User_Id() As String
        <JsonProperty("Price_Sum")>
        Public Property Price_Sum() As String
        <JsonProperty("ForooshKalaParent_TypeFact")>
        Public Property ForooshKalaParent_TypeFact() As String

        <JsonProperty("JameMablaghMaliat")>
        Public Property JameMablaghMaliat() As String

        <JsonProperty("JameMablaghKhales")>
        Public Property JameMablaghKhales() As String

        <JsonProperty("JameMablaghTakhfif")>
        Public Property JameMablaghTakhfif() As String

        <JsonProperty("JameMablaghServic")>
        Public Property JameMablaghServic() As String

        <JsonProperty("Address")>
        Public Property Address() As String
        <JsonProperty("Tell")>
        Public Property Tell() As String
    End Class
    Class printData
        Public Property SaleInvoiceID() As Long
        Public Property SumMoney() As Long
        Public Property UpdateFact() As Boolean
        Public Property SaleNumber() As String

    End Class
    Public Class ForushReport
        <JsonProperty("SumKolFact")>
        Public Property SumKolFact() As String

        <JsonProperty("JamBirunbar")>
        Public Property JamBirunbar() As String
        <JsonProperty("Jampeik")>
        Public Property Jampeik() As String
        <JsonProperty("JaminSalon")>
        Public Property JaminSalon() As String
        <JsonProperty("JamSumCancleFact")>
        Public Property JamSumCancleFact() As String
        <JsonProperty("mablagkhales")>
        Public Property mablagkhales() As String
    End Class
    Private Sub WriteText(text As String)
        Dim FileStream As FileStream
        Dim StrPath As String = System.Web.HttpContext.Current.Server.MapPath("~/ErrorLog.txt")

        If File.Exists(StrPath) Then
            FileStream = New FileStream(StrPath, FileMode.Append, FileAccess.Write)
        Else
            FileStream = New FileStream(StrPath, FileMode.Create, FileAccess.Write)
        End If


        Using StreamWriter As New StreamWriter(FileStream)
            StreamWriter.WriteLine(String.Format("Error:{0} --  DateTime:{1}", text, DateTime.Now))
            StreamWriter.Close()
            FileStream.Close()
        End Using

    End Sub


End Class

