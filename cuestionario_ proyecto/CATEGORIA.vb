Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class CATEGORIA
    Dim datos As DataSet
    Sub INSERTAR_CATEGORIA()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "INSERT INTO CATEGORIA (NOMBRE_CATEGORIA) VALUES (@NOMBRE_CATEGORIA)"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()
            'comando.Parameters.AddWithValue("@ID_CATEGORIA", txt_id.Text) 'ENVIO DE PARAMETROS'
            comando.Parameters.AddWithValue("@NOMBRE_CATEGORIA", txt_nombre.Text)



            ' comando.Parameters.AddWithValue("@ID_ROL", ComboBox1.SelectedIndex)
            comando.ExecuteNonQuery()
            MsgBox("EL USUARIO SE HA REGISTRADO")
            conex.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CONSULTAR_CATEGORIA()

        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        Dim query As String = "SELECT * FROM CATEGORIA WHERE ID_CATEGORIA = " & txt_id.Text & " "
        Dim comando As New SqlCommand(query, conex)
        '  Dim lista As Byte

        Dim pueb As New SqlDataAdapter(comando)
        datos = New DataSet
        pueb.Fill(datos, "CATEGORIA")

        txt_id.Text = datos.Tables("CATEGORIA").Rows(0).Item("ID_CATEGORIA")
        txt_nombre.Text = datos.Tables("CATEGORIA").Rows(0).Item("NOMBRE_CATEGORIA")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Call INSERTAR_CATEGORIA()
        PREGUNTA.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Call CONSULTAR_CATEGORIA()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        CUESTIONARIO.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripProgressBar1.Value = ToolStripProgressBar1.Value + 1

        Try
            If ToolStripProgressBar1.Value = 100 Then
                ToolStripProgressBar1.Visible = 0
                ToolStripProgressBar1.Visible = False
                Timer1.Stop()


                MsgBox("CONEXION ESTABLECIDA")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
End Class