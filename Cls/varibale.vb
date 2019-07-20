Imports System.Data.SqlClient


Module varibale

    Public constr As String = My.Settings.SanResturantConnectionString

    Public funcSql As New ConectToDatabaseSQL
    'Public funcOledb As New ConectToDatabaseOleDb
    Public result As String = ""
    Public pdate As New clsPersianDate
    Public AdvUserIDTelegram As String = "@SanResturant"
    Public HashCode As String = "b4a3c7c9542d9aff13d17da2bbabd0b3"
    Public AppId As Integer = 81701
End Module
