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

Public Class ConectToDatabaseSQL
    Public Enum CommandType
        Insert = 1
        Update = 2
        Delete = 3
    End Enum

    Private haveConErr As Boolean
    Private sqlCon As New SqlConnection(constr)
    Private sqlCmd As New SqlCommand

    Public Sub ReadConnection()

        Using fs As New FileStream(System.Web.HttpContext.Current.Server.MapPath("ConnectionSQL.dat"), FileMode.Open, FileAccess.Read)
            Using r As New StreamReader(fs)
                constr = r.ReadToEnd

            End Using
        End Using

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
            Using myCommand As New System.Data.SqlClient.SqlCommand("SELECT ISNULL(MAX(ForooshKalaParent_ShomareFish),(SELECT  Setting_NumberFishStart-1 FROM tblSettingIDFactor  ))+1 AS MaxFishNumber FROM TblParent_FrooshKala where [ForooshKalaParent_Date]='" & _DateFact & "'", myConnection)
                myCommand.CommandType = System.Data.CommandType.Text
                myCommand.CommandTimeout = 0
                If myConnection.State = ConnectionState.Closed Then myConnection.Open()
                Dim MaxID = CLng(myCommand.ExecuteScalar())
                myConnection.Close()
                Return MaxID
            End Using

        End Using
    End Function
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
