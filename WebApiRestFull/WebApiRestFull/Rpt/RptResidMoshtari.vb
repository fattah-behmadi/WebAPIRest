Imports JntNum2Text
Imports System.Drawing

Public Class RptResidMoshtari



    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        'Control.CheckForIllegalCrossThreadCalls = False
        ' Add any initialization after the InitializeComponent() call.

        'Vw_PrintFrooshTableAdapter1.Fill(SanDataBaseDataSet1.Vw_PrintFroosh)


        TblCompany_InfoTableAdapter1.Fill(SanDataBaseDataSet1.tblCompany_Info)

    End Sub

    Private Sub ReportFrooshKala_BeforePrint(sender As Object, e As Printing.PrintEventArgs) Handles MyBase.BeforePrint

        pdate.Culture_IR()
    End Sub
End Class