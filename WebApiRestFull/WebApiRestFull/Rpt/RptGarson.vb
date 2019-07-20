Imports JntNum2Text
Imports System.Drawing

Public Class RptGarson


    Sub New()

        ' This call is required by the designer.
        InitializeComponent()


        TblCompany_InfoTableAdapter1.Fill(SanDataBaseDataSet1.tblCompany_Info)
    End Sub

    Private Sub ReportFrooshKala_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint
        pdate.Culture_IR()
    End Sub
End Class