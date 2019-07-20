﻿Imports System.Net
Imports System.Web.Http
Imports System.Data.SqlClient
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Security.Cryptography
Imports System.IO
Imports System.Threading
Imports JntNum2Text
Imports System.Globalization

Public Class HomeController
    Inherits ApiController
#Region " تابع گرفتن گروه های غذایی"
    <HttpGet> _
    Public Function GetGroupFood() As JArray
        Try
            funcSql.ReadConnection()
            Dim sqlcom As New SqlDataAdapter("SELECT * FROM [TblGroupKala]  WHERE [TypeGroup] <> N'فقط خریدنی'", constr)
            Dim DtGroupFood As New DataTable
            sqlcom.Fill(DtGroupFood)
            Dim JSONString As String = String.Empty
            JSONString = JsonConvert.SerializeObject(DtGroupFood)
            Dim arrayFood = JArray.Parse(JSONString)
            Return arrayFood
        Catch ex As Exception
            WriteText("GetGroupFood : " & ex.Message)

        End Try
    End Function
#End Region

#Region " تابع گرفتن غذاهای مورد علاقه"
    <HttpGet> _
    Public Function GetFoodFavorite() As JArray
        Try
            funcSql.ReadConnection()
            Dim sqlcom As New SqlDataAdapter("SELECT top 30  WITH TIES [IDKala] FROM [VwChart_FrooshKala] ORDER BY [Count]  DESC", constr)
            Dim DtGroupFood As New DataTable
            sqlcom.Fill(DtGroupFood)
            Dim JSONString As String = String.Empty
            JSONString = JsonConvert.SerializeObject(DtGroupFood)
            Dim arrayFood = JArray.Parse(JSONString)
            Return arrayFood

        Catch ex As Exception
            WriteText("GetFoodFavorite : " & ex.Message)
        End Try


    End Function
#End Region

#Region " تابع لیست تلفن مخاطبین"
    <HttpGet> _
    <Route("api/home/GetTellContact/{IDContact}")>
    Public Function GetTellContact(IDContact As String) As JArray

        Try
            funcSql.ReadConnection()
            Dim dtContact As New DataTable
            Dim Sqlda As New SqlDataAdapter("SELECT [tblTell].[Tell_Contact]  FROM [dbo].[tblTell] where [tblTell].[Contacts_ID] =" & IDContact, constr)
            Sqlda.Fill(dtContact)
            Dim JSONString As String = String.Empty
            JSONString = JsonConvert.SerializeObject(dtContact)
            Dim arrayFood = JArray.Parse(JSONString)
            Return arrayFood

        Catch ex As Exception
            WriteText("GetTellContact : " & ex.Message)
        End Try

    End Function
#End Region

#Region " تابع لیست آدرس مخاطبین"
    <HttpGet> _
    <Route("api/home/GetAddressContact/{IDContact}")>
    Public Function GetAddressContact(IDContact As String) As JArray
        Try
            funcSql.ReadConnection()
            Dim dtContact As New DataTable
            Dim Sqlda As New SqlDataAdapter("select [tblAdress].[Adress] from [dbo].[tblAdress] where [tblAdress].[Contact_ID]=" & IDContact, constr)
            Sqlda.Fill(dtContact)
            Dim JSONString As String = String.Empty
            JSONString = JsonConvert.SerializeObject(dtContact)
            Dim arrayFood = JArray.Parse(JSONString)
            Return arrayFood

        Catch ex As Exception
            WriteText("GetAddressContact : " & ex.Message)
        End Try
    End Function
#End Region

#Region " تابع لیست مخاطبین"
    <HttpGet> _
    Public Function GetListContact() As JArray
        Try
            funcSql.ReadConnection()
            Dim dtContact As New DataTable
            Dim Sqlda As New SqlDataAdapter("select [FullName],[Tafzili_ID],[Contacts_ID]  FROM [SanResturant].[dbo].[tblContacts]", constr)
            Sqlda.Fill(dtContact)
            Dim JSONString As String = String.Empty
            JSONString = JsonConvert.SerializeObject(dtContact)
            Dim arrayFood = JArray.Parse(JSONString)
            Return arrayFood

        Catch ex As Exception
            WriteText("GetListContact : " & ex.Message)
        End Try

    End Function

#End Region

#Region " تابع گرفتن مبالغ مالیاتی و تخفیف"
    <HttpGet> _
    Public Function GetSettingDarsad() As JArray

        Try
            funcSql.ReadConnection()
            Dim dtContact As New DataTable
            Dim Sqlda As New SqlDataAdapter("SELECT [Setting_DarsadMaliyat],[Setting_DardadTakhfif],[Setting_MablaghTakhfif],[Setting_DarsadService] ,[Setting_MablaghService]  FROM [SanResturant].[dbo].[tblSettingIDFactor]", constr)
            Sqlda.Fill(dtContact)
            Dim JSONString As String = String.Empty
            JSONString = JsonConvert.SerializeObject(dtContact)
            Dim arrayFood = JArray.Parse(JSONString)
            Return arrayFood
        Catch ex As Exception
            WriteText("GetSettingDarsad : " & ex.Message)
        End Try
    End Function
#End Region

#Region "تابع برگرداندن آخرین فاکتور ها"
    <HttpGet> _
    Public Function GetLastFactors() As JArray
        Try
            funcSql.ReadConnection()
            Dim dtfact As New DataTable
            Dim Sqlda As New SqlDataAdapter("SELECT TOP 30 [ForooshKalaParent_ID],[ForooshKalaParent_ShomareMiz],[ForooshKalaParent_ShomareFish],[ForooshKalaParent_Time],[ForooshKalaParent_Tahvilgirande],[ForooshKalaParent_SerialSanad],ForooshKalaParent_TypeFact FROM [SanResturant].[dbo].[TblParent_FrooshKala] WHERE [ForooshKalaParent_Date]='" & DateTime.Now.ToShortDateString() & "' AND ForooshKalaParent_StatusFact <>N'لغو' ", constr)
            Sqlda.Fill(dtfact)
            Dim JSONStringa As String = String.Empty
            JSONStringa = JsonConvert.SerializeObject(dtfact)
            Dim arrayFood = JArray.Parse(JSONStringa)
            Return arrayFood

        Catch ex As Exception
            WriteText("GetLastFactors : " & ex.Message)
        End Try
    End Function
#End Region

#Region "تابع لغو فاکتور"
    <HttpGet> _
    <Route("api/home/CancleFactor/{IDFactor}/{SerialSanad}/{UserCode}")>
    Public Function CancleFactor(IDFactor As String, SerialSanad As String, UserCode As String) As Boolean
        Try
            result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Delete, "[tblChildeSanad]", , " [Serial_Sanad]=" & SerialSanad & "")
            If result = "1" Then


                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Delete, "[tblParentSanad]", , " [Serial_Sanad]=" & SerialSanad & "")
                If result = "1" Then
                    Dim nameuser = funcSql.CellReader("[tblLogin]", "[Login_Name]", "[Login_ID]=" & UserCode & "")
                    Dim Exp = String.Format("لغو فاکتور توسط کاربر {0}", nameuser)
                    result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Update, "[TblParent_FrooshKala]", "ForooshKalaParent_StatusFact=N'لغو' ,ForooshKalaParent_Tozih=N'" & Exp & "'", "[ForooshKalaParent_ID]=" & IDFactor & "")
                    Dim Numberfish = funcSql.CellReader("TblParent_FrooshKala", "ForooshKalaParent_ShomareFish", "ForooshKalaParent_ID=" & IDFactor & "")
                    If result = "1" Then
                        Me.IDUser = UserCode
                        '  ThreadPool.QueueUserWorkItem(Sub(state) Printfactcancle(Numberfish))
                        Printfactcancle(Numberfish)
                        Return True
                    End If
                Else
                    Return False
                End If

            End If
        Catch ex As Exception
            WriteText("CancleFactor : " & ex.Message)
        End Try

    End Function
#End Region

#Region "چاپ فاکتور لغو شده در آشپزخانه"
    Public Function Printfactcancle(numberfact As String)
        Try
            _kitchen4C = Convert.ToInt32(CBool(If(funcSql.CellReader("tblPrinterUserSetting", "Kitchen5Cm", "UserID=" & IDUser & ""), 0)))
            Dim dtSettingPrinte As New DataTable
            dtSettingPrinte = GetSettingPUser(IDUser)
            Dim RwSetting = dtSettingPrinte.Rows(0)
            Dim Printerashpazkhane = RwSetting("PrinterAshpazkhane")
            If _kitchen4C = 1 Then


                Using Report As New RptUpdateFactSmall
                    Report.TextUpdateFactor.Value = String.Format("شماره فیش {0} لغو گردید لطفا از تهیه ی سفارش صرف نظر فرمایید. با تشکر", numberfact)
                    Report.RequestParameters = False
                    Report.ShowPrintStatusDialog = False
                    Report.PrintingSystem.ShowMarginsWarning = False
                    Report.CreateDocument(False)
                    Dim printTool As New DevExpress.XtraPrinting.PrintToolBase(Report.PrintingSystem)
                    Dim NamePrinter = Printerashpazkhane
                    printTool.Print(NamePrinter)
                End Using

            Else


                Using Report As New RptUpdateFactHigh
                    Report.TextUpdateFactor.Value = String.Format("شماره فیش {0} لغو گردید لطفا از تهیه ی سفارش صرف نظر فرمایید. با تشکر", numberfact)
                    Report.RequestParameters = False
                    Report.ShowPrintStatusDialog = False
                    Report.PrintingSystem.ShowMarginsWarning = False
                    Report.CreateDocument(False)
                    Dim printTool As New DevExpress.XtraPrinting.PrintToolBase(Report.PrintingSystem)
                    Dim NamePrinter = Printerashpazkhane
                    printTool.Print(NamePrinter)
                End Using

            End If
            Return True
        Catch ex As Exception
            WriteText("Printfactcancle : " & ex.Message)
        End Try

    End Function
#End Region

#Region "تابع غذاهای یک فاکتور"
    <HttpGet> _
<Route("api/home/GetSefaresh/{Numberfact}")>
    Public Function GetSefaresh(Numberfact As String) As JArray
        Try
            funcSql.ReadConnection()
            Dim dtfact As New DataTable
            Dim Sqlda As New SqlDataAdapter("  SELECT [ID_Kala],[Name_Kala],[ChildForooshKala_TedadAsli],[ChildForooshKala_SharhKala],[ChildForooshKala_GheymatPaye],ForooshKalaParent_TypeFact FROM dbo.[Vw_PrintFroosh]  WHERE ForooshKalaParent_ID =" & Numberfact & "", constr)
            Sqlda.Fill(dtfact)
            Dim JSONString As String = String.Empty
            JSONString = JsonConvert.SerializeObject(dtfact)
            Dim arrayFood = JArray.Parse(JSONString)
            Return arrayFood

        Catch ex As Exception
            WriteText("GetSefaresh : " & ex.Message)
        End Try


    End Function
#End Region

#Region "توضیحات آشپزخانه"
    <HttpGet> _
    Public Function GetExpAshpazkhane() As JArray
        Try
            funcSql.ReadConnection()
            Dim dtExp As New DataTable
            Dim Sqlda As New SqlDataAdapter("SELECT  *  FROM [SanResturant].[dbo].[TblExpAshpazkhane]", constr)
            Sqlda.Fill(dtExp)
            Dim JSONString As String = String.Empty
            JSONString = JsonConvert.SerializeObject(dtExp)
            Dim arrayFood = JArray.Parse(JSONString)
            Return arrayFood
        Catch ex As Exception
            WriteText("GetExpAshpazkhane : " & ex.Message)
        End Try
    End Function
#End Region
    
#Region "دستگاه های مجاز"
    <HttpGet> _
    <Route("api/home/DeviceRegister/{DeviceID}/{DeviceName}")>
    Public Function DeviceRegister(DeviceID As String, DeviceName As String) As Boolean

        'TODO: این بخش فعال شود جهت قفل سخت افزاری 


        'Dim NumDevice As Integer = funcSql.ReadNumberDevice
        'If NumDevice <> 0 Then
        '    Dim countDevice As Integer = funcSql.CellReader("TblRegisterDevice", "count(DeviceID)", "")
        '    If (countDevice > NumDevice) Then Return False
        '    If (NumDevice > countDevice) Then

        '        Dim id = funcSql.CellReader("TblRegisterDevice", "count(DeviceID)", "DeviceID=N'" & DeviceID & "'")
        '        If id = 0 Then
        '            result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, "TblRegisterDevice", "N'" & DeviceID & "',N'" & DeviceName & "'")
        '            If result = "1" Then
        '                Return True
        '            Else
        '                Return False
        '            End If
        '        Else
        '            Return True
        '        End If

        '    End If
        '    If (NumDevice = countDevice) Then
        '        '       کد را در جدول چک می کنه که ایا وجود دارد یا خیر 
        '        Dim ExistsDevice = funcSql.CellReader("TblRegisterDevice", "count(DeviceID)", "DeviceID=N'" & DeviceID & "'")
        '        Select Case ExistsDevice
        '            Case "0"
        '                Return False
        '            Case "1"
        '                Return True
        '            Case Nothing
        '                Return False
        '        End Select
        '    End If


        'Else
        '    Return False
        'End If
        Return True


    End Function
#End Region



#Region "لیست غذاها"
    <HttpGet> _
    Public Function GetFood() As JArray
        Try
            funcSql.ReadConnection()
            Dim dtFood As New DataTable
            Dim Sqlda As New SqlDataAdapter("SELECT TOP 1000 [ID_Kala],[Name_Kala],[Fk_GroupKala],[GheymatForoshAsli],[Picture]  FROM [SanResturant].[dbo].[TblKala]", constr)
            Sqlda.Fill(dtFood)
            Dim JSONString As String = String.Empty
            JSONString = JsonConvert.SerializeObject(dtFood)
            Dim arrayFood = JArray.Parse(JSONString)
            Return arrayFood
        Catch ex As Exception
            WriteText("GetFood : " & ex.Message)
        End Try
    End Function
#End Region
    Dim IDUser As String

#Region "ورود گارسون"
    <HttpGet> _
    <Route("api/home/LoginGarson/{_UserName}/{_Password}")>
    Public Function LoginGarson(_UserName As String, _Password As String) As JArray





        Try
            funcSql.ReadConnection()
            _UserName = Convert.ToString(_UserName)
            _Password = Convert.ToString(_Password)
            Dim sqlstr As String = String.Format("SELECT Login_ID,Login_Name,''  as CurrencySymbol   FROM [SanResturant].[dbo].[tblLogin] where Login_UserName=N'{0}' AND Login_PassWord=N'{1}'", _UserName, PasswordEncrypt(_Password))
            Dim sqlcom As New SqlDataAdapter(sqlstr, constr)
            Dim DtUser As New DataTable
            sqlcom.Fill(DtUser)
            Dim JSONString As String = String.Empty
            If DtUser.Rows.Count = 0 Then
                Dim dr As DataRow = DtUser.NewRow()
                DtUser.Rows.Add(dr)
                DtUser.Rows(0)("Login_ID") = "0"
                DtUser.Rows(0)("Login_Name") = "0"
                DtUser.Rows(0)("CurrencySymbol") = "ريال"
            Else
                IDUser = DtUser.Rows(0)("Login_ID")
            End If
            Dim Currency As String = funcSql.CellReader("tblSettingIDFactor", "Setting_CurrencySymbol", "")
            If Currency = Nothing Then
                Currency = "ريال"
            End If
            DtUser.Rows(0)("CurrencySymbol") = Currency
            JSONString = JsonConvert.SerializeObject(DtUser)
            Dim arrayFood = JArray.Parse(JSONString)
            GetDefaultContact()

        Return arrayFood
        Catch ex As Exception
            WriteText("LoginGarson : " & ex.Message)
        End Try
    End Function
#End Region

    Dim DefaultContact As String
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
    <HttpPost> <Route("api/home/SaveFactor/{NumberFact}/{NumFishUpdate}")> _
    Public Function SaveFactor(NumberFact As String, NumFishUpdate As String, <FromBody> JsonString As List(Of ListFood)) As String
        Try
            'Dim ActiveLock As Boolean = funcSql.ReadActive
            Dim ActiveLock As Boolean = True '   این خط غیر فعال شود و خط بالایی فعال جهت قفل سخت افزاری

            If ActiveLock Then

                Dim TxtIDFact, NumberFish As String
                Dim Listfood = JsonString(0)
                funcSql.Culture_EN()
                Dim UpdateFact As Boolean = False
                If NumberFact <> "0" Then
                    UpdateFact = True
                End If
                If Not UpdateFact Then
                    TxtIDFact = funcSql.GetFactID_Froosh()

                    Dim TimeEnChange = DateTime.Now

                    NumberFish = funcSql.GetFishNumber_Froosh(TimeEnChange.ToString("yyyy-MM-dd ", New CultureInfo("en-US")))
                Else
                    TxtIDFact = NumberFact
                    NumberFish = NumFishUpdate
                End If
                Dim tahvilgirande As String = "تحویل گیرنده"
                Dim TozihatFactor = "ثبت فاکتور با تبلت"
                Dim TafziliMoshtari, ExpFood, IDUserGarson, SumMoney, NumberMiz As String
                Dim CountOFFood As Integer = Listfood.ChildForooshKala_TedadAsli

                NumberMiz = Listfood.Table_Number
                TafziliMoshtari = Listfood.Costumer_Code
                tahvilgirande = Listfood.Costumer_Name
                IDUserGarson = Listfood.User_Id
                IDUser = IDUserGarson
                SumMoney = Listfood.Price_Sum
                ExpFood = Listfood.ChildForooshKala_SharhKala
                IdSandogh = funcSql.CellReader("tblSandogh", "Tafzili_ID", "[User_ID]=" & IDUserGarson & "")
                Dim ValueVazeyat = Listfood.ForooshKalaParent_TypeFact

                If String.IsNullOrEmpty(TafziliMoshtari) Then
                    If String.IsNullOrEmpty(DefaultContact) Then
                        GetDefaultContact()
                    End If
                    TafziliMoshtari = DefaultContact
                End If


                If UpdateFact Then
                    result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Update, " TblParent_FrooshKala", "[ForooshKalaParent_Tafzili]=" & TafziliMoshtari & ",[ForooshKalaParent_Date]='" & DateTime.Now & "',[ForooshKalaParent_Tozih]=N'" & TozihatFactor & "',[ForooshKalaParent_JameMablaghPaye]=" & SumMoney & ",[ForooshKalaParent_JameMaliyat]=" & Listfood.JameMablaghMaliat & ",[ForooshKalaParent_JameTakhfif]=" & Listfood.JameMablaghTakhfif & ",[ForooshKalaParent_JameMablaghPasTakhfif]=" & Listfood.JameMablaghKhales & ",[ForooshKalaParent_JameKol]=" & Listfood.JameMablaghKhales & ",[ForooshKalaParent_JameService]=" & Listfood.JameMablaghServic & ",[ForooshKalaParent_UserId]=" & IDUser & ",[ForooshKalaParent_ShomareMiz]=" & NumberMiz & ",[ForooshKalaParent_ModateEntezar]=0,[ForooshKalaParent_ShomareFish]=" & NumberFish & ",[ForooshKalaParent_StatusFact]=N'ویرایش شده',[ForooshKalaParent_Time]='" & TimeOfDay.ToString("h:mm:ss tt") & "',[ForooshKalaParent_TypeFact]=N'" & ValueVazeyat & "',[ForooshKalaParent_SelectedAdress]=N'" & Listfood.Address & "',[ForooshKalaParent_SelectedTell]=N'" & Listfood.Tell & "',[ForooshKalaParent_NumberPager]=0,[ForooshKalaParent_Tahvilgirande]=N'" & tahvilgirande & "',[ForooshKalaParent_TasvieFact]=0", "[ForooshKalaParent_ID]=" & NumberFact & "")
                Else
                    result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, " TblParent_FrooshKala", "" & CLng(TxtIDFact) & "," & TafziliMoshtari & ",'" & DateTime.Now & "',N'" & TozihatFactor & "'," & SumMoney & "," & Listfood.JameMablaghMaliat & "," & Listfood.JameMablaghTakhfif & "," & Listfood.JameMablaghKhales & "," & Listfood.JameMablaghKhales & "," & Listfood.JameMablaghServic & "," & IDUser & "," & GetSerialSanad() & ",'" & NumberMiz & "',0," & NumberFish & ",N'عادی','" & TimeOfDay.ToString("h:mm:ss tt") & "',N'" & ValueVazeyat & "',N'" & Listfood.Address.ToString() & "',N'" & Listfood.Tell.ToString() & "',0,N'" & tahvilgirande & "',0,0,0")
                End If



                If result = "1" Then

                    Dim sumFactorMaliat As Double = 0
                    InsertChildAndKardeks(TxtIDFact, UpdateFact, JsonString, sumFactorMaliat)
                    CreateDocument(TxtIDFact, DateTime.Now.ToString("yyyy-MM-dd ", New CultureInfo("en-US")), TimeOfDay.ToString("h:mm:ss tt", New CultureInfo("en-US")), TafziliMoshtari, ExpFood, SumMoney, 0, 0, 0, SumMoney, UpdateFact)

                    Dim idfactor = NumberFact
                    If idfactor = "0" Then
                        idfactor = TxtIDFact
                    End If
                    Dim jameMaliat = funcSql.ConvertToDouble(funcSql.CellReader("TblChild_ForooshKala", "sum(ChildForooshKala_MaliyatMablagh)", "ChildForooshKala_ParentID=" & idfactor))
                    Dim jamekol = funcSql.ConvertToDouble(funcSql.CellReader("TblChild_ForooshKala", "sum(ChildForooshKala_JameKol)", "ChildForooshKala_ParentID =" & idfactor))

                    result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Update, " TblParent_FrooshKala", "ForooshKalaParent_JameMaliyat =" & jameMaliat & ",ForooshKalaParent_JameKol=" & sumFactorMaliat & "", "[ForooshKalaParent_ID]=" & idfactor & "")

                End If


                Dim dtSettingPrinte As DataTable = GetSettingPUser(IDUserGarson)
                Dim RwSetting = dtSettingPrinte.Rows(0)
                Dim Printercostumer = RwSetting("PrinterCustomer")
                Dim Printersandogh = RwSetting("PrinterSandogh")
                Dim Printerashpazkhane = RwSetting("PrinterAshpazkhane")
                Dim costumerActive As Boolean = RwSetting("DakhelSalonMoshtari")
                Dim sandoghActive As Boolean = RwSetting("DakhelSalonSandogh")
                Dim ashpazkhaneActive As Boolean = RwSetting("DakhelSalonAshpazkhane")
                Dim sanlondar As Boolean = RwSetting("Salondar")

                Dim Print_Confirm = Listfood.Print_Confirm
                
                If Not Print_Confirm Then
                    
                    'ThreadPool.QueueUserWorkItem(Function(state) PrintFish(TxtIDFact, SumMoney, Printercostumer, Printerashpazkhane, Printersandogh, costumerActive, ashpazkhaneActive, sandoghActive))
                    PrintFish(TxtIDFact, SumMoney, Printercostumer, Printerashpazkhane, Printersandogh, costumerActive, ashpazkhaneActive, sandoghActive, sanlondar)
                
            End If
            'End If
                


            If result = "1" Then
                'WriteText("SuccessFull ...")
                Return NumberFish
            Else
                WriteText("Error Return Result End Function =  " & result)
                Return result
            End If
            Else
            Return "NotActive"
            End If
        Catch ex As Exception
            WriteText("SaveFactor : " & ex.Message)
        End Try
    End Function

#End Region

#Region "توابع کاربردی"
    Public Function PasswordEncrypt(ByVal inText As String) As String

        Try
            Dim key = "Heyzha@2228932_SanSystem"
            Dim bytesBuff As Byte() = Encoding.Unicode.GetBytes(inText)
            Using aes__1 As Aes = Aes.Create()
                Dim crypto As New Rfc2898DeriveBytes(key, New Byte() {&H49, &H76, &H61, &H6E, &H20, &H4D,
                 &H65, &H64, &H76, &H65, &H64, &H65,
                 &H76})
                aes__1.Key = crypto.GetBytes(32)
                aes__1.IV = crypto.GetBytes(16)
                Using mStream As New MemoryStream()
                    Using cStream As New CryptoStream(mStream, aes__1.CreateEncryptor(), CryptoStreamMode.Write)
                        cStream.Write(bytesBuff, 0, bytesBuff.Length)
                        cStream.Close()
                    End Using
                    inText = Convert.ToBase64String(mStream.ToArray())
                End Using
            End Using
            Return inText
        Catch ex As Exception
            WriteText("Encrypt : " & ex.Message)
        End Try
    End Function
    Dim IdSandogh As String
    Public Function GetSerialSanad() As String
        Try
            Using myConnection As New System.Data.SqlClient.SqlConnection(constr)

                Using myCommand As New System.Data.SqlClient.SqlCommand("SELECT isnull(MAX([Serial_Sanad]),0)+1  FROM [tblParentSanad] ", myConnection)
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
    Public Class ListFood
        <JsonProperty("ID_Kala")> _
        Public Property ID_Kala() As String
        <JsonProperty("ChildForooshKala_TedadAsli")> _
        Public Property ChildForooshKala_TedadAsli() As String
        <JsonProperty("SumPriceRow")> _
        Public Property SumPriceRow() As String
        <JsonProperty("Table_Number")> _
        Public Property Table_Number() As String
        <JsonProperty("Costumer_Code")> _
        Public Property Costumer_Code() As String

        <JsonProperty("Costumer_Name")> _
        Public Property Costumer_Name() As String
        <JsonProperty("Print_Confirm")> _
        Public Property Print_Confirm() As Boolean
        <JsonProperty("ChildForooshKala_SharhKala")> _
        Public Property ChildForooshKala_SharhKala() As String
        <JsonProperty("User_Id")> _
        Public Property User_Id() As String
        <JsonProperty("Price_Sum")> _
        Public Property Price_Sum() As String
        <JsonProperty("ForooshKalaParent_TypeFact")> _
        Public Property ForooshKalaParent_TypeFact() As String

        <JsonProperty("JameMablaghMaliat")> _
        Public Property JameMablaghMaliat() As String

        <JsonProperty("JameMablaghKhales")> _
        Public Property JameMablaghKhales() As String

        <JsonProperty("JameMablaghTakhfif")> _
        Public Property JameMablaghTakhfif() As String

        <JsonProperty("JameMablaghServic")> _
        Public Property JameMablaghServic() As String

        <JsonProperty("Address")> _
        Public Property Address() As String
        <JsonProperty("Tell")> _
        Public Property Tell() As String
    End Class

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
                result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, "TblChild_ForooshKala", "" & FoodCode & "," & CLng(_IDFact) & ",N'" & sharhekala & "'," & tedad & "," & Gheymat & "," & sum & ",0,0," & sum & "," & MablaghMaliat & "," & darsadMalyat & "," & jamekol & "")

            Next


            Dim maliatm As Double = ((Convert.ToInt64(sumkalamaliat) / 100) * darsadMalyat)
            sumfactor = (sumkalamaliat + maliatm) + jameMablagh


            Return True
        Catch ex As Exception
            WriteText("InsertChildAndKardeks" & ex.Message)
        End Try
    End Function
    Public Function GetPrinterUser(ByVal IDuser As String) As String

        Try

            funcSql.ReadConnection()
            Dim Sqlcon As New SqlConnection(constr)
            Dim sqlcom As New SqlCommand("", Sqlcon)
            If Sqlcon.State <> ConnectionState.Open Then Sqlcon.Open()
            sqlcom.CommandText = "SELECT PrinterAshpazkhane  FROM [SanResturant].[dbo].[tblPrinterUserSetting] where UserID='" & IDuser & "'"
            Dim val = sqlcom.ExecuteScalar
            If val IsNot Nothing Then
                Return val
            Else
                Return Nothing
            End If


        Catch ex As Exception
            WriteText("GetPrinterUser : " & ex.Message)
        End Try

    End Function
    Public Function GetSettingPUser(ByVal IDUser As String) As DataTable
        Try
            Dim dtsetting As New DataTable
            Dim Sqlda As New SqlDataAdapter("SELECT * FROM [SanResturant].[dbo].[tblPrinterUserSetting] where UserID='" & IDUser & "'", constr)
            Sqlda.Fill(dtsetting)
            Return dtsetting
        Catch ex As Exception
            WriteText("GetSettingPUser :  " & ex.Message)
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




        Dim AccIDBes, MoeinIDBes, TafziliIDBes, AccIDBedhkar, MoeinIDBedehkar, TafziliIDBedehkar, AccIDKhadamatBes, MoeinIDKhadamatBes, TafziliIDKhadamatBes, AccIDKhadamatBedekhar, MoeinIDKhadamatBedehkar, TafziliIDKhadamatBedehkar, AccIDArzeshAfzodeBes, MoeinIDArzeshAfzodeBes, AccIDTakhfifForshBed, MoeinIDTakhfifForoshBed As String

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



        '       #Constفاکتور فروش به شماره 115 خریدار اسماعیل آبادی به شماره سند حسابداری 20 در تاریخ 12/2/2017 11:27:01 AM
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



        'If DaryaftNagdi Then
        '    '        پرداخت نقدی 
        '    ''''''''''' Bedehkar''''''''''''''''''''
        '    result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, "tblChildeSanad", "" & SerialSanad & ",110," & IdSandogh & ",11001,N'" & Tozihat & "'," & idFactor & ",1," & MablaghKhales & ",0")

        '    ''''''''''' Bestankar''''''''''''''''''''
        '    result = funcSql.DoCommand(ConectToDatabaseSQL.CommandType.Insert, "tblChildeSanad", "" & SerialSanad & ",130," & TafziliMoshtari & ",13001,N'" & Tozihat & "'," & idFactor & ",1,0," & MablaghKhales & "")
        'End If

        Catch ex As Exception

            WriteText("CreatDocument =  " & ex.Message)
        End Try
    End Sub
    Dim _sandogh4C, _customer4C, _kitchen4C As Boolean
    Public Function PrintFish(_txtNumber As String, _txtSumMoney As String, _PMoshtari As String, _PAshpazkhane As String, _PSandogh As String, _ChMoshtari As Boolean, _ChAshpazkhane As Boolean, _ChSandogh As Boolean, _ChSalon As Boolean)

        Try


            _sandogh4C = CBool(funcSql.cellreader2("tblPrinterUserSetting", "Sandogh5Cm", "UserID=" & IDUser & ""))
            _customer4C = CBool(funcSql.cellreader2("tblPrinterUserSetting", "Costumer5Cm", "UserID=" & IDUser & ""))
            _kitchen4C = CBool(funcSql.cellreader2("tblPrinterUserSetting", "Kitchen5Cm", "UserID=" & IDUser & ""))


            Dim horof = _txtSumMoney.ToString.ToString.Substring(0, _txtSumMoney.ToString.Length - 1)
            Dim Horof1 = Num2Text.ToFarsi(Convert.ToInt64(Val(horof)))
            Dim NumcopyAshpaz, NumcopySandogh, NumcopyMoshtari As Integer
            Dim defultPrinter As Boolean
            GetSetting(NumcopyAshpaz, NumcopySandogh, NumcopyMoshtari, defultPrinter)

            If _ChMoshtari Then

                Dim Report
                If _customer4C Then
                    Report = New RptResidMoshtariSmall
                Else
                    Report = New RptResidMoshtari
                End If

                Report.FilterString = "ForooshKalaParent_ID=" & _txtNumber & ""
                Report.RequestParameters = False
                Report.ShowPrintStatusDialog = False
                Report.PrintingSystem.ShowMarginsWarning = False
                Report.CreateDocument(False)
                Dim printTool As New DevExpress.XtraPrinting.PrintToolBase(Report.PrintingSystem)
                Dim NamePrinter = _PMoshtari
                printTool.PrinterSettings.Copies = NumcopyMoshtari

                printTool.Print(NamePrinter)

            End If


            If _ChSalon Then

                Dim RptGarson As New RptGarson

                With RptGarson

                    .Horof.Value = Horof1 + " تومان "
                    .PersianDate.Value = pdate.PersianDate(DateTime.Now)

                    .FilterString = "ForooshKalaParent_ID=" & _txtNumber & ""
                    .RequestParameters = False
                    .ShowPrintStatusDialog = False
                    .PrintingSystem.ShowMarginsWarning = False
                    .CreateDocument(False)
                    Dim printTool As New DevExpress.XtraPrinting.PrintToolBase(.PrintingSystem)
                    Dim NamePrinter = _PMoshtari
                    printTool.PrinterSettings.Copies = NumcopyMoshtari
                    printTool.Print(NamePrinter)

                End With
            End If




            If _ChAshpazkhane Then
                'If defultPrinter Then
                
                Dim Report
                If _kitchen4C Then
                    Report = New RptAshpazkhaneDefaultSmall
                Else
                    Report = New RptAshpazkhaneDefault
                End If

                Report.FilterString = "[ForooshKalaParent_ID]=" & _txtNumber & ""
                Report.RequestParameters = False
                Report.ShowPrintStatusDialog = False
                Report.PrintingSystem.ShowMarginsWarning = False
                Report.CreateDocument(False)
                Dim printTool As New DevExpress.XtraPrinting.PrintToolBase(Report.PrintingSystem)
                Dim NamePrinter = _PAshpazkhane
                printTool.PrinterSettings.Copies = NumcopyAshpaz
                printTool.Print(NamePrinter)

                'print = True

                'Else
                'Using Report As New RptAshpazkhane
                '    Report.FilterString = "[ForooshKalaParent_ID]=" & _txtNumber & ""
                '    Report.RequestParameters = False
                '    Report.ShowPrintStatusDialog = False
                '    Report.PrintingSystem.ShowMarginsWarning = False
                '    Report.CreateDocument(False)
                '    Dim printTool As New DevExpress.XtraPrinting.PrintToolBase(Report.PrintingSystem)
                '    Dim NamePrinter = _PAshpazkhane
                '    printTool.PrinterSettings.Copies = NumcopyAshpaz
                '    printTool.Print(NamePrinter)
                'End Using

                'End If

            End If
            If _ChSandogh Then


                Dim Report
                If _sandogh4C Then
                    Report = New RptResidSandoghSmall
                Else
                    Report = New RptResidSandogh
                End If

                Report.FilterString = "[ForooshKalaParent_ID]=" & _txtNumber & ""
                Report.RequestParameters = False
                Report.ShowPrintStatusDialog = False
                Report.PrintingSystem.ShowMarginsWarning = False
                Report.CreateDocument(False)
                Dim printTool As New DevExpress.XtraPrinting.PrintToolBase(Report.PrintingSystem)
                Dim NamePrinter = _PSandogh
                printTool.PrinterSettings.Copies = NumcopySandogh
                printTool.Print(NamePrinter)



            End If
            'Return print
        Catch ex As Exception
            WriteText(ex.Message.ToString)

            'Return False
        End Try
    End Function
    Public Sub GetSetting(ByRef NumbercopyAshpazkhane As Integer, ByRef NumbercopyMoshtari As Integer, ByRef NumbercopySandogh As Integer, ByRef DefultPrinter As Boolean)

        NumbercopyAshpazkhane = My.Settings.NuCopyAshpazh
        NumbercopyMoshtari = My.Settings.NuCopyMoshtari
        NumbercopySandogh = My.Settings.NuCopySandogh
        DefultPrinter = My.Settings.DefultPrinter

    End Sub

    <HttpGet> _
<Route("api/home/ReportForush/{DateStart}/{DateEnd}")>
    Public Function ReportForush(DateStart As String, DateEnd As String) As JArray
        Try

      
        pdate.Culture_EN()




        Dim _DateStart As Date = DateTime.ParseExact(DateStart, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)
        Dim _DateEnd As Date = DateTime.ParseExact(DateEnd, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)


        Dim SumKolFact = funcSql.CellReader("TblParent_FrooshKala", "sum(ForooshKalaParent_JameKol)", "ForooshKalaParent_Date BETWEEN '" & _DateStart & "' AND '" & _DateEnd & "'")
        Dim JamBirunbar, Jampeik, JaminSalon, JamSumCancleFact As String


        funcSql.GetReport(_DateStart, _DateEnd, "بیرون بر", JamBirunbar)
        funcSql.GetReport(_DateStart, _DateEnd, "پیک", Jampeik)
        funcSql.GetReport(_DateStart, _DateEnd, "لغو", JamSumCancleFact)
        funcSql.GetReport(_DateStart, _DateEnd, "داخل سالن", JaminSalon)



        'Dim SumKolFact = funcSql.CellReader("TblParent_FrooshKala", "sum(ForooshKalaParent_JameKol)", "ForooshKalaParent_Date BETWEEN '" & _DateStart & "' AND '" & _DateEnd & "'")
        'Dim JamBirunbar = funcSql.CellReader("TblParent_FrooshKala", "sum(ForooshKalaParent_JameKol)", "(ForooshKalaParent_Date BETWEEN '" & _DateStart & "' AND '" & _DateEnd & "') AND(ForooshKalaParent_TypeFact=N'بیرون بر')")
        'Dim Jampeik = funcSql.CellReader("TblParent_FrooshKala", "sum(ForooshKalaParent_JameKol)", "(ForooshKalaParent_Date BETWEEN '" & _DateStart & "' AND '" & _DateEnd & "') AND(ForooshKalaParent_TypeFact=N'پیک')")
        'Dim JaminSalon = funcSql.CellReader("TblParent_FrooshKala", "sum(ForooshKalaParent_JameKol)", "(ForooshKalaParent_Date BETWEEN '" & _DateStart & "' AND '" & _DateEnd & "') AND(ForooshKalaParent_TypeFact LIKE N'%داخل سالن%' )")
        'Dim JamSumCancleFact = funcSql.CellReader("TblParent_FrooshKala", "sum(ForooshKalaParent_JameKol)", "(ForooshKalaParent_Date BETWEEN '" & _DateStart & "' AND '" & _DateEnd & "')AND(ForooshKalaParent_StatusFact like N'%لغو%')")


        Dim mablagkhales As String = String.Empty
        If JamSumCancleFact <> "" Then
            mablagkhales = Convert.ToDouble(SumKolFact) - Convert.ToDouble(JamSumCancleFact)
        End If

        Dim ListReport As New List(Of ForushReport)


        ListReport.Add(New ForushReport() With {.JamBirunbar = JamBirunbar, _
        .SumKolFact = SumKolFact, _
        .Jampeik = Jampeik, _
        .JaminSalon = JaminSalon, _
        .JamSumCancleFact = JamSumCancleFact, _
        .mablagkhales = mablagkhales
})

        Dim JSONString As String = String.Empty
        JSONString = JsonConvert.SerializeObject(ListReport)
        Dim arrayFood = JArray.Parse(JSONString)
            Return arrayFood

        Catch ex As Exception
            WriteText("Error in ReportForush : " & ex.Message)
        End Try
    End Function
    Public Class ForushReport
        <JsonProperty("SumKolFact")> _
        Public Property SumKolFact() As String

        <JsonProperty("JamBirunbar")> _
        Public Property JamBirunbar() As String
        <JsonProperty("Jampeik")> _
        Public Property Jampeik() As String
        <JsonProperty("JaminSalon")> _
        Public Property JaminSalon() As String
        <JsonProperty("JamSumCancleFact")> _
        Public Property JamSumCancleFact() As String
        <JsonProperty("mablagkhales")> _
        Public Property mablagkhales() As String
    End Class

#End Region

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

    ' GET api/<controller>
    Public Function GetValues() As IEnumerable(Of String)
        Return New String() {"value1", "value2"}
    End Function

    ' GET api/<controller>/5
    Public Function GetValue(ByVal id As Integer) As String
        Return "value"
    End Function

    ' POST api/<controller>
    Public Sub PostValue(<FromBody()> ByVal value As String)

    End Sub

    ' PUT api/<controller>/5
    Public Sub PutValue(ByVal id As Integer, <FromBody()> ByVal value As String)

    End Sub

    ' DELETE api/<controller>/5
    Public Sub DeleteValue(ByVal id As Integer)

    End Sub
End Class


'  [{"JameMablaghKhales":"261600.0","JameMablaghMaliat":"21600","JameMablaghServic":"0","JameMablaghTakhfif":"0","SumPriceRow":"240000","Address":"انقلاب 8بن بست معروف ساختمان گل رز طبقه 5","Costumer_Code":"10010019","Costumer_Name":"مصطفی بلالی","ID_Kala":"9","ChildForooshKala_TedadAsli":1,"ChildForooshKala_SharhKala":"","Price_Sum":"240000","Print_Confirm":"false","Table_Number":"0","Tell":"0","User_Id":"2059","ForooshKalaParent_TypeFact":"بیرون بر"}]