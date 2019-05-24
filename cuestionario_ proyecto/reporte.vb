Public Class reporte
    Private Sub reporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'CUESTIONARIO_FINALDataSet3.NIVEL' Puede moverla o quitarla según sea necesario.
        Me.NIVELTableAdapter.Fill(Me.CUESTIONARIO_FINALDataSet3.NIVEL)

        Me.ReportViewer1.RefreshReport()

        Me.ReportViewer1.RefreshReport
    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
End Class