Imports System.Data.SqlClient
Imports System.IO


Module varibale

    Dim fs As New FileStream(System.Web.HttpContext.Current.Server.MapPath("~/ConnectionSQL.dat"), FileMode.Open, FileAccess.Read)
    Dim r As New StreamReader(fs)
    Public constr As String = r.ReadToEnd
    'Public constr As String = "Data Source=192.168.1.6;Initial Catalog=SanResturant;User ID=sa;Password=heyzha@2228932;"

    Public funcSql As New ConectToDatabaseSQL
    'Public funcOledb As New ConectToDatabaseOleDb
    Public result As String = ""
    Public pdate As New clsPersianDate
    Public AdvUserIDTelegram As String = "@SanResturant"
    Public HashCode As String = "b4a3c7c9542d9aff13d17da2bbabd0b3"
    Public AppId As Integer = 81701
End Module
