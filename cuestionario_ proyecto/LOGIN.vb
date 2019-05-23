Imports System.Data.SqlClient
Public Class Form1
    Public dataReader As SqlDataReader
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "sp_VerificarUsuario"
            Dim comando As New SqlCommand(query, conex)

            comando.CommandType = CommandType.StoredProcedure
            comando.Parameters.AddWithValue("@CORREO", txt_correo.Text)
            comando.Parameters.AddWithValue("@PASSWORD_USUARIO", txt_contra.Text)
            comando.Parameters.AddWithValue("@ID_ROL", ComboBox1.SelectedValue)

            conex.Open()
            dataReader = comando.ExecuteReader


            If dataReader.HasRows And ComboBox1.SelectedValue = 1 Then
                CATEGORIA.Show()
                Me.Close()
            ElseIf dataReader.HasRows And ComboBox1.SelectedValue = 2 Then
                PREGUNTA.Show()
                Me.Close()
            Else
                lbl_msj.Visible = True
            End If
            ToolStripProgressBar1.Value = 0
            ToolStripStatusLabel1.Text = "Cargando"
            ToolStripProgressBar1.Visible = True
            Timer1.Start()
        Catch ex As Exception
            MessageBox.Show("ErrorBlinkStyle DE USUARIO O CONTRASEÑA")
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ComboBox1_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        conex.Open()
        Dim query As String = "SELECT * FROM ROL"
        Dim comando As New SqlCommand(query, conex)
        comando.CommandType = CommandType.Text

        Dim DA As New SqlDataAdapter(comando)
        Dim DT As New DataTable

        DA.Fill(DT)
        ComboBox1.DataSource = DT
        ComboBox1.DisplayMember = "NOMBRE_ROL"
        ComboBox1.ValueMember = "ID_ROL"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        USUARIO.Show()
        Me.Close()

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
