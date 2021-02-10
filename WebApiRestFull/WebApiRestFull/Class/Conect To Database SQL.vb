Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System
Imports System.Net.Mail
Imports System.Net
Imports System.Collections.Specialized
Imports System.Security.Cryptography
Imports System.Text
Imports System.Management
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports System.Threading
Imports System.Web.Configuration
Imports BL

Public Class ConectToDatabaseSQL

    Public Sub New()
        ReadConnection()
        sqlCon.ConnectionString = constr
    End Sub



    Public Enum CommandType
        Insert = 1
        Update = 2
        Delete = 3
    End Enum

    Private haveConErr As Boolean
    Private sqlCon As New SqlConnection()
    Private sqlCmd As New SqlCommand

    Public Sub ReadConnection()
        Dim serverName As String = ".\sqlexpress"
        Using fs As New FileStream(System.Web.HttpContext.Current.Server.MapPath("~/ConnectionSQL.dat"), FileMode.Open, FileAccess.Read)
            Using r As New StreamReader(fs)
                serverName = r.ReadToEnd
            End Using
        End Using
        constr = String.Format($"Data Source={serverName.Trim(";")};Initial Catalog=Gishniz;User ID=gish;Password=gishniz$2020@!;MultipleActiveResultSets=true;")
        DBAccess.SetConnection(constr)

    End Sub
    Private Sub ConToDB()

        Try
            ReadConnection()
            haveConErr = False
            sqlCon.ConnectionString = constr
            sqlCon.Open()
        Catch ex As Exception
            haveConErr = True
        End Try

    End Sub
    Private Sub DisConToDB()

        Try
            sqlCon.Close()
        Catch ex As Exception
        End Try

    End Sub

    Public Function DBConnectionStatus() As Boolean
        Try
            Using sqlConn As New SqlConnection(constr)
                sqlConn.Open()
                Return (sqlConn.State = ConnectionState.Open)
            End Using
        Catch e1 As SqlException

            Return False
        Catch e2 As Exception
            Return False
        End Try
    End Function

    Public Function ConvertToDouble(ByVal DoubleInteger As Object) As Double
        Try

            If IsDBNull(DoubleInteger) Or DoubleInteger Is Nothing Then
                Return 0
            ElseIf DoubleInteger.ToString.Equals("") Then
                Return 0
            ElseIf DoubleInteger = 0 Then
                Return 0

            Else
                Return Convert.ToDouble(DoubleInteger)
            End If


        Catch ex As Exception
            Return 0
        End Try
    End Function
    Public Function DoCommand(ByVal cmdType As CommandType, ByVal Table As String, Optional ByVal values As String = Nothing, Optional ByVal exp As String = Nothing) As String

        If Not DBConnectionStatus() Then Return "0" : Exit Function

        Try

            Dim query As New Text.StringBuilder
            sqlCmd.Parameters.Clear()


            sqlCmd.CommandType = Data.CommandType.StoredProcedure

            Select Case cmdType

                Case CommandType.Insert


                    query.Append("[dbo].[SP_Insert]")
                    sqlCmd.Parameters.AddWithValue("@table", Table)
                    sqlCmd.Parameters.AddWithValue("@values", values)

                Case CommandType.Delete

                    query.Append("[dbo].[SP_Delete]")
                    sqlCmd.Parameters.AddWithValue("@table", Table)
                    sqlCmd.Parameters.AddWithValue("@exp", exp.ToString())


                Case CommandType.Update

                    query.Append("[dbo].[SP_Update]")
                    sqlCmd.Parameters.AddWithValue("@table", Table)
                    sqlCmd.Parameters.AddWithValue("@values", values)
                    sqlCmd.Parameters.AddWithValue("@exp", exp)

            End Select


            With sqlCmd

                Call ConToDB()
                .Connection = sqlCon
                .CommandText = query.ToString
                .ExecuteNonQuery()

            End With

            Return "1"

        Catch ex As Exception

            Return ex.Message

        Finally
            sqlCmd.Parameters.Clear()

            Call DisConToDB()

        End Try


    End Function
    Public Function ReadTable(ByVal Table As String, Optional ByVal exp As String = Nothing) As Data.DataTable
        If Not DBConnectionStatus() Then Return Nothing : Exit Function
        Try
            Dim da As New SqlDataAdapter
            Dim dt As New Data.DataTable
            Dim query As New System.Text.StringBuilder

            sqlCmd.Parameters.Clear()

            sqlCmd.CommandType = Data.CommandType.StoredProcedure

            query.Append("[dbo].[SP_Readtable]")

            With sqlCmd.Parameters

                .AddWithValue("@table", Table)

                If Not String.IsNullOrEmpty(exp) Then

                    .AddWithValue("@exp", exp)

                Else

                    Dim statment As String = "1=1"

                    .AddWithValue("@exp", statment)

                End If

            End With

            sqlCmd.Connection = sqlCon

            Call ConToDB()

            sqlCmd.CommandText = query.ToString

            da.SelectCommand = sqlCmd

            da.Fill(dt)

            Return dt

        Catch ex As Exception
            Return Nothing
        Finally

            Call DisConToDB()
        End Try

    End Function
    Sub Culture_EN()
        Dim culture = CultureInfo.CreateSpecificCulture("EN-us")
        'Thread.CurrentThread.CurrentUICulture = culture
        Thread.CurrentThread.CurrentCulture = culture
        culture.NumberFormat.CurrencyPositivePattern = 3
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = "ریال"
    End Sub

    Sub Culture_IR()
        Dim culture = CultureInfo.CreateSpecificCulture("fa-IR")
        'Thread.CurrentThread.CurrentUICulture = culture
        Thread.CurrentThread.CurrentCulture = culture
        culture.NumberFormat.CurrencyPositivePattern = 3
        Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencySymbol = "ریال"
    End Sub
    Public Function ReadNumberDevice() As Integer
        result = DoCommand(CommandType.Update, "TblCostumerInfo", "[NumDevice]=decryptbypassphrase('HeyzhaEncrypPa',[TblCostumerInfo].[NumDevice])", "[IDInfo] =1")
        Dim Number As Integer
        If result = "1" Then
            Number = CellReader("TblCostumerInfo", "[NumDevice]", "")
            result = DoCommand(CommandType.Update, "TblCostumerInfo", "[NumDevice]=encryptbypassphrase('HeyzhaEncrypPa',[TblCostumerInfo].[NumDevice])", "[IDInfo] =1")
        End If

        Return Number
    End Function
    Public Function ReadActive() As Boolean
        result = DoCommand(CommandType.Update, "TblCostumerInfo", "[Active]=decryptbypassphrase('HeyzhaEncrypPa',[TblCostumerInfo].[Active])", "[IDInfo] =1")
        Dim Active = CellReader("TblCostumerInfo", "[Active]", "[IDInfo] ='1'")
        If Active = "Yes" Then
            result = DoCommand(CommandType.Update, "TblCostumerInfo", "[Active]=encryptbypassphrase('HeyzhaEncrypPa',[TblCostumerInfo].[Active])", "[IDInfo] =1")
        Else
            result = DoCommand(CommandType.Update, "TblCostumerInfo", "[Active]=decryptbypassphrase('HeyzhaEncrypPa',[TblCostumerInfo].[Active])", "[IDInfo] =1")
        End If

        If Active = "Yes" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function GetReport(ByVal DateStart As Date, ByVal DateEnd As Date, ByVal TypeFact As String, ByRef OutPut As String) As String
        Dim valuer As String = String.Empty
        Using con As New SqlConnection(constr)
            Dim cmd As SqlCommand = con.CreateCommand
            cmd.CommandType = Data.CommandType.StoredProcedure
            cmd.CommandText = "Sp_SumshiftTypeFact"
            cmd.Parameters.Add("@DateStart ", SqlDbType.Date).Value = DateStart
            cmd.Parameters.Add("@DateEnd ", SqlDbType.Date).Value = DateEnd
            cmd.Parameters.Add("@TypeFact ", SqlDbType.NVarChar).Value = TypeFact
            cmd.Parameters.Add("@JameKolMablagh", SqlDbType.BigInt).Direction = ParameterDirection.Output
            If con.State = ConnectionState.Closed Then con.Open()
            cmd.ExecuteNonQuery()
            valuer = CLng(cmd.Parameters("@JameKolMablagh").Value.ToString())
            con.Close()
        End Using
        Return valuer
    End Function
    Dim sqldr As SqlDataReader
    Dim value As String = String.Empty
    Public Function cellreader2(ByVal Table As String, ByVal cmd As String, Optional ByVal exp As String = Nothing) As String
        If haveConErr Then Return Nothing : Exit Function
        Try

            Dim SqlQ As New System.Text.StringBuilder


            SqlQ.Append("SELECT " & cmd & " FROM ")
            SqlQ.Append(Table.ToString & " ")
            If Not String.IsNullOrEmpty(exp) Then SqlQ.Append("WHERE " & exp.ToString)
            sqlCmd.Connection = sqlCon
            'Call ConToDB()
            If sqlCon.State <> ConnectionState.Open Then sqlCon.Open()


            sqlCmd.CommandType = System.Data.CommandType.Text
            sqlCmd.CommandText = SqlQ.ToString
            sqldr = sqlCmd.ExecuteReader
            If sqldr.HasRows Then
                sqldr.Read()
                value = sqldr.Item(0).ToString()
            End If
            If Not String.IsNullOrEmpty(value) Then
                Return value
            Else
                Return 0
            End If



        Catch ex As Exception
            Return Nothing
        Finally
            sqldr.Close()
            Call DisConToDB()
        End Try

    End Function
    Public Function CellReader(ByVal Table As String, ByVal cmd As String, Optional ByVal exp As String = Nothing) As String

        If Not DBConnectionStatus() Then Return Nothing : Exit Function

        Dim sqldr As SqlDataReader
        Try
            sqlCmd.Parameters.Clear()


            Dim value As String = "0"

            Dim da As New SqlDataAdapter
            Dim dt As New Data.DataTable
            Dim query As New System.Text.StringBuilder

            sqlCmd.CommandType = Data.CommandType.StoredProcedure

            query.Append("[dbo].[SP_CellReader]")

            With sqlCmd.Parameters

                .AddWithValue("@table", Table)
                .AddWithValue("@cmd", cmd)
                If Not String.IsNullOrEmpty(exp) Then

                    .AddWithValue("@exp", exp)

                Else

                    Dim statment As String = "1=1"

                    .AddWithValue("@exp", statment)

                End If

            End With

            sqlCmd.Connection = sqlCon

            Call ConToDB()

            sqlCmd.CommandText = query.ToString

            sqldr = sqlCmd.ExecuteReader


            If sqldr.HasRows Then

                sqldr.Read()

                value = sqldr.Item(0).ToString()

                sqldr.Close()

            End If

            Return value



        Catch ex As Exception

            Return ex.Message
        Finally

            Call DisConToDB()
        End Try

    End Function
    Public Function GetFishNumber_Froosh(_DateFact As String) As String
        Using myConnection As New System.Data.SqlClient.SqlConnection(constr)


            Dim EndShiftNight As DateTime = CellReader("tblSettingIDFactor", "NmEnd", "")      '   اتمام شیفت شب
            EndShiftNight = EndShiftNight.ToString("HH:mm")


            Dim StartShift As DateTime = CellReader("tblSettingIDFactor", "AMStart", "")      '   اتمام شیفت شب
            StartShift = StartShift.ToString("HH:mm")


            Dim today As DateTime = DateTime.Today
            Dim qw As DateTime = today.AddDays(1).AddSeconds(-1).ToString("HH:mm")


            Dim EndShi As New TimeSpan(EndShiftNight.Hour, EndShiftNight.Minute, EndShiftNight.Second)         '12 o'clock
            Dim Startshi As New TimeSpan(StartShift.Hour, StartShift.Minute, StartShift.Second)
            Dim Nimeshab As New TimeSpan(qw.Hour, qw.Minute, 59)            '10 o'clock
            Dim Nowtime As TimeSpan = DateTime.Now.TimeOfDay            'match found


            If (Nowtime >= Nimeshab) Then     ' اگر از نیمه شب گذشته بود 

                If (Nowtime < EndShi) Then    ' اگر شیفت شب نرسیده بود ادامه فیش های روز قل را برو

                    Dim DateDay As DateTime = Convert.ToDateTime(_DateFact)
                    DateDay = DateDay.AddDays(-1)
                    Dim BeforeDay As String = DateDay.ToString("yyyy-MM-dd ", New CultureInfo("en-US"))

                    'SELECT ISNULL(MAX(ForooshKalaParent_ShomareFish),(SELECT ISNULL(MAX(ForooshKalaParent_ShomareFish),(SELECT  Setting_NumberFishStart-1 FROM tblSettingIDFactor  )) +1 from TblParent_FrooshKala where [ForooshKalaParent_Date]='" & BeforeDay &"' )) +1 from TblParent_FrooshKala where [ForooshKalaParent_Date]='"& _DateFact &"'
                    Using myCommand As New System.Data.SqlClient.SqlCommand("SELECT ISNULL(MAX(ForooshKalaParent_ShomareFish),(SELECT ISNULL(MAX(ForooshKalaParent_ShomareFish),(SELECT  Setting_NumberFishStart-1 FROM tblSettingIDFactor  )) +1 from TblParent_FrooshKala where [ForooshKalaParent_Date]='" & BeforeDay & "' )) +1 from TblParent_FrooshKala where [ForooshKalaParent_Date]='" & _DateFact & "'", myConnection)

                        myCommand.CommandType = System.Data.CommandType.Text
                        myCommand.CommandTimeout = 0
                        If myConnection.State = ConnectionState.Closed Then myConnection.Open()
                        Dim MaxID = CLng(myCommand.ExecuteScalar())
                        myConnection.Close()
                        Return MaxID
                    End Using

                Else
                    'از ساعت پایانی شیفت شب گذشته است و فیش ها از 100 شروع می شود

                    Using myCommand As New System.Data.SqlClient.SqlCommand("declare @NewId bigint SELECT @NewId= Setting_NumberFishStart FROM tblSettingIDFactor while (SELECT count(ForooshKalaParent_ShomareFish)  from TblParent_FrooshKala where [ForooshKalaParent_Date]='" & _DateFact & "' and ForooshKalaParent_ShomareFish=@NewId )>0 begin set @NewId +=1 end set @NewID =@NewId select  @NewId ", myConnection)
                        myCommand.CommandType = System.Data.CommandType.Text
                        myCommand.CommandTimeout = 0
                        If myConnection.State = ConnectionState.Closed Then myConnection.Open()
                        Dim MaxID = CLng(myCommand.ExecuteScalar())
                        myConnection.Close()
                        Return MaxID
                    End Using


                End If

            Else

                Dim nim As New TimeSpan(0, 0, 59)

                If Nowtime.Hours = nim.Hours Then

                    Dim DateDay As DateTime = Convert.ToDateTime(_DateFact)
                    DateDay = DateDay.AddDays(-1)
                    Dim BeforeDay As String = DateDay.ToString("yyyy-MM-dd ", New CultureInfo("en-US"))
                    Using myCommand As New System.Data.SqlClient.SqlCommand("SELECT ISNULL(MAX(ForooshKalaParent_ShomareFish),(SELECT ISNULL(MAX(ForooshKalaParent_ShomareFish),(SELECT  Setting_NumberFishStart-1 FROM tblSettingIDFactor  )) +1 from TblParent_FrooshKala where [ForooshKalaParent_Date]='" & BeforeDay & "' ))+1  from TblParent_FrooshKala where [ForooshKalaParent_Date]='" & _DateFact & "'", myConnection)

                        myCommand.CommandType = System.Data.CommandType.Text
                        myCommand.CommandTimeout = 0
                        If myConnection.State = ConnectionState.Closed Then myConnection.Open()
                        Dim MaxID = CLng(myCommand.ExecuteScalar())
                        myConnection.Close()
                        Return MaxID
                    End Using

                ElseIf Nowtime > Startshi Then
                    '  
                    'Using myCommand As New System.Data.SqlClient.SqlCommand("declare @IdParent bigint  SELECT @IdParent= max( [TblParent_FrooshKala].[ForooshKalaParent_ID] )  FROM TblParent_FrooshKala where [ForooshKalaParent_Date]='" & _DateFact & "' SELECT ForooshKalaParent_ShomareFish+1 FROM [dbo].[TblParent_FrooshKala] where [ForooshKalaParent_ID] =@IdParent ", myConnection)

                    Using myCommand As New System.Data.SqlClient.SqlCommand(" declare @starttime time (7) select @starttime =[AMStart]  from [dbo].[tblSettingIDFactor]   SELECT ISNULL(MAX(ForooshKalaParent_ShomareFish),(SELECT  Setting_NumberFishStart-1 FROM tblSettingIDFactor  ))+1  as 'FishNumber'   FROM TblParent_FrooshKala   where [TblParent_FrooshKala].[ForooshKalaParent_Time]>=@starttime  and  [ForooshKalaParent_Date]='" & _DateFact & "'", myConnection)


                        myCommand.CommandType = System.Data.CommandType.Text
                        myCommand.CommandTimeout = 0
                        If myConnection.State = ConnectionState.Closed Then myConnection.Open()
                        Dim MaxID = CLng(myCommand.ExecuteScalar())
                        myConnection.Close()
                        Return MaxID
                    End Using

                Else
                    ' از نیمه شب نگذشته است 
                    Using myCommand As New System.Data.SqlClient.SqlCommand("SELECT ISNULL(MAX(ForooshKalaParent_ShomareFish),(SELECT  Setting_NumberFishStart-1 FROM tblSettingIDFactor  ))+1 AS MaxFishNumber FROM TblParent_FrooshKala where [ForooshKalaParent_Date]='" & _DateFact & "'", myConnection)
                        myCommand.CommandType = System.Data.CommandType.Text
                        myCommand.CommandTimeout = 0
                        If myConnection.State = ConnectionState.Closed Then myConnection.Open()
                        Dim MaxID = CLng(myCommand.ExecuteScalar())
                        myConnection.Close()
                        Return MaxID
                    End Using
                End If


            End If




        End Using
    End Function
    'Public Function GetFishNumber_Froosh(_DateFact As String) As String
    '    Using myConnection As New System.Data.SqlClient.SqlConnection(constr)
    '        Using myCommand As New System.Data.SqlClient.SqlCommand("SELECT ISNULL(MAX(ForooshKalaParent_ShomareFish),(SELECT  Setting_NumberFishStart-1 FROM tblSettingIDFactor  ))+1 AS MaxFishNumber FROM TblParent_FrooshKala where [ForooshKalaParent_Date]='" & _DateFact & "'", myConnection)
    '            myCommand.CommandType = System.Data.CommandType.Text
    '            myCommand.CommandTimeout = 0
    '            If myConnection.State = ConnectionState.Closed Then myConnection.Open()
    '            Dim MaxID = CLng(myCommand.ExecuteScalar())
    '            myConnection.Close()
    '            Return MaxID
    '        End Using

    '    End Using
    'End Function
    Public Function GetFactID_Froosh() As String
        Using myConnection As New System.Data.SqlClient.SqlConnection(constr)
            Using myCommand As New System.Data.SqlClient.SqlCommand("SELECT [dbo].[Get_ID_FactFroosh] () AS Max_ID_Fact", myConnection)
                myCommand.CommandType = System.Data.CommandType.Text
                myCommand.CommandTimeout = 0
                'Try
                If myConnection.State = ConnectionState.Closed Then myConnection.Open()
                Dim MaxID = CLng(myCommand.ExecuteScalar())
                '''زمانی که فاکتوری ثبت نشده شماره فاکتور شروع رو میخونه و مقدار گام رو بهش اضافه میکنه
                If MaxID = 0 Then
                    Return CellReaderSetting("StartID")
                Else

                    Dim Increment = CLng(CellReaderSetting("Increment"))
                    Return (MaxID + Increment)

                End If

                myConnection.Close()


            End Using

        End Using
    End Function
    Public Function CellReaderSetting(_Colums As String) As Integer
        Dim newProdID As Int32 = 0
        Dim sql As String = "select " & _Colums & "  from tblSettingIDFactor  where 1=1"
        Using conn As New SqlConnection(constr)
            Dim cmd As New SqlCommand(sql, conn)
            Try
                conn.Open()
                newProdID = CType(cmd.ExecuteScalar(), Int32)

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        End Using
        Return CType(newProdID, Integer)
    End Function
    Public Sub ReadID(ByVal txtCode As TextBox, ByVal Table As String)
        Try
            Dim dr As SqlDataReader
            If sqlCon.State = ConnectionState.Open Then sqlCon.Close()
            sqlCon.Open()
            sqlCmd.Connection = sqlCon
            sqlCmd.CommandText = "select IDENT_CURRENT('" & Table & "') + IDENT_INCR('" & Table & "')"
            dr = sqlCmd.ExecuteReader
            If dr.HasRows Then
                dr.Read()
                txtCode.Text = dr.Item(0).ToString()
                dr.Close()
            End If
            sqlCon.Close()
        Catch ex As Exception
            MsgBox(ex.ToString())
            'func.WriteLog(ex.Message, Me.Name, pdate.PersianDate(Date.Now))
        End Try
    End Sub



    Dim dtsms As New DataTable



    Shared Function ExtractNumbers(ByVal expr As String) As String
        Return String.Join(Nothing, System.Text.RegularExpressions.Regex.Split(expr, "[^\d]"))
    End Function

    Public Function CheckForInternetConnection() As Boolean

        Try
            Return My.Computer.Network.Ping("www.google.com")
        Catch
            Return False
        End Try

    End Function


End Class
