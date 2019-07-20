Imports System.Globalization
Imports System.Threading

Public Class clsPersianDate

    Private PerDt As New System.Globalization.PersianCalendar
    Private Dt As Date = Now

    Public Function PersianYear() As Integer
        Return PerDt.GetYear(Dt)
    End Function
    Sub Culture_EN()
        Dim culture = CultureInfo.CreateSpecificCulture("EN-us")
        Thread.CurrentThread.CurrentCulture = culture
    End Sub

    Sub Culture_IR()
        Dim culture = CultureInfo.CreateSpecificCulture("fa-IR")
        Thread.CurrentThread.CurrentCulture = culture
    End Sub
    Public Function PersianDateDiff(Date1 As String, Date2 As String, Optional Interval As DateInterval = DateInterval.Day) As Long

        Dim d1 = CDate(GregorianDate(Date1))
        Dim d2 = CDate(GregorianDate(Date2))
        Return DateDiff(Interval, d1, d2)
    End Function
    Public Function PersianDate(Optional InDate As Date = Nothing) As String
        Try
            If InDate.Year <= 1 Then InDate = Now
            Dim PClndr As New Globalization.PersianCalendar
            Dim DateInIran As String = PClndr.GetYear(InDate).ToString()
            DateInIran &= "/" & Strings.Right(("0" & PClndr.GetMonth(InDate)), 2)
            DateInIran &= "/" & Strings.Right(("0" & PClndr.GetDayOfMonth(InDate)), 2)
            Return DateInIran
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function GregorianDate(InDate As String) As String
        If InDate.Length <> 10 Then Return ""
        Dim Year As Integer = Mid(InDate, 1, 4)
        If Year < 1300 OrElse Mid(InDate, 1, 4) > 1500 Then Return ""
        Dim Month As Integer = Mid(InDate, 6, 2)
        If Not IsNumeric(Month) OrElse Month > 12 OrElse Month < 1 Then Return ""
        Dim Day As Integer = Mid(InDate, 9, 2)
        If Day < 1 OrElse Day > 31 Then Return ""
        Try
            Dim PClndr As New Globalization.PersianCalendar
            Return PClndr.ToDateTime(Year, Month, Day, 0, 0, 0, 0).ToString
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Function tarikh() As String
        Dim pc As New PersianCalendar()
        Dim thistime As DateTime = DateTime.Now
        Dim persiantimenow As String

        persiantimenow = pc.GetYear(thistime) & "/" & pc.GetMonth(thistime) & "/" & pc.GetDayOfMonth(thistime)


        Return persiantimenow


    End Function
    Public Function persianweek() As String
        Select Case PerDt.GetDayOfWeek(Dt)

            Case 1
                Return "دوشنبه"

            Case 2
                Return "سه شنبه"

            Case 3
                Return "چهارشنبه"

            Case 4
                Return "پنجشنبه"

            Case 5
                Return "جمعه"

            Case 6
                Return "شنبه"

            Case 7
                Return "یکشنبه"
        End Select

    End Function
    Public Function PersianMonth() As Integer
        Return PerDt.GetMonth(Dt)
    End Function

    Public Function PersianDay() As Integer
        Return PerDt.GetDayOfMonth(Dt)
    End Function

    Public Function PersianMonthName() As String

        Select Case PerDt.GetMonth(Dt)

            Case 1
                Return "فروردین"

            Case 2
                Return "اردیبهشت"

            Case 3
                Return "خرداد"

            Case 4
                Return "تیر"

            Case 5
                Return "مرداد"

            Case 6
                Return "شهریور"

            Case 7
                Return "مهر"

            Case 8
                Return "آبان"

            Case 9
                Return "آذر"

            Case 10
                Return "دی"

            Case 11
                Return "بهمن"

            Case 12
                Return "اسفند"

        End Select

    End Function

    Function PersianMonthName(p1 As Date) As String
        Throw New NotImplementedException
    End Function

End Class