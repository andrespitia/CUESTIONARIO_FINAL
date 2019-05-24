Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class mantenimiento
    Dim datos As DataSet
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim copia As String = "BACKUP_" & Now.Day & "_" & Now.Month & "_" & Now.Year & ".bak"
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        conex.Open()
        Dim ruta As String = "C:\respaldos\"
        Dim consulta As String = "BACKUP DATABASE CUESTIONARIO_FINAL TO DISK = '" & ruta & copia & "'"
        Dim cmd As New SqlCommand(consulta, conex)
        cmd.ExecuteNonQuery()
        MsgBox("Copia realizada con exito, verigique en " & ruta)
        conex.Close()
    End Sub
    Sub paso1()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")

            Dim query As String = "ALTER DATABASE CUESTIONARIO_FINAL SET RECOVERY SIMPLE"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()

            Dim pueb As New SqlDataAdapter(comando)
            datos = New DataSet
            pueb.Fill(datos, "CUESTIONARIO_FINAL")

            MsgBox("Cambio de estado a simple")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub paso2()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "DBCC SHRINKFILE (CUESTIONARIO_FINAL_log,1);"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()
            MsgBox("Reducción del log realizada con exito")
            Dim pueb As New SqlDataAdapter(comando)
            datos = New DataSet
            pueb.Fill(datos, "CUESTIONARIO_FINAL")
            'conex.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub paso3()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "ALTER DATABASE CUESTIONARIO_FINAL SET RECOVERY FULL;"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()
            Dim pueb As New SqlDataAdapter(comando)
            datos = New DataSet
            pueb.Fill(datos, "CUESTIONARIO_FINAL")
            MsgBox("La base de datos ha vuelto a su estado inicial (full)")
            'conex.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Call paso1()
        Call paso2()
        Call paso3()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        PREGUNTA.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripProgressBar1.Value = ToolStripProgressBar1.Value + 1

        Try
            If ToolStripProgressBar1.Value = 100 Then
                ToolStripProgressBar1.Visible = 0
                ToolStripProgressBar1.Visible = False
                Timer1.Stop()



            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        PREGUNTA.Show()
        Me.Hide()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs)
        NIVEL.Show()
        Me.Hide()
    End Sub
End Class