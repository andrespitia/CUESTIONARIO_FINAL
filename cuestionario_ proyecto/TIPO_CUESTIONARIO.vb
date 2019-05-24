Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class TIPO_CUESTIONARIO
    Dim datos As DataSet
    Dim ayuda As String = System.IO.Path.Combine(Application.StartupPath, "CUESTIONARIO.chm")
    Sub INSERTAR_TIPO_CUESTIONARIO()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "INSERT INTO TIPO_CUESTIONARIO (NOMBRE_CUESTIONARIO) VALUES (@NOMBRE_CUESTIONARIO)"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()
            'comando.Parameters.AddWithValue("@ID_CATEGORIA", txt_id.Text) 'ENVIO DE PARAMETROS'
            comando.Parameters.AddWithValue("@NOMBRE_CUESTIONARIO", txt_nombre.Text)

            ' comando.Parameters.AddWithValue("@ID_ROL", ComboBox1.SelectedIndex)
            comando.ExecuteNonQuery()
            MsgBox("TIPO DE CUESTIONARIO REGISTRADO")
            conex.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Call INSERTAR_TIPO_CUESTIONARIO()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        NIVEL.Show()
        Me.Hide()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripProgressBar1.Value = ToolStripProgressBar1.Value + 1

        Try
            If ToolStripProgressBar1.Value = 100 Then
                ToolStripProgressBar1.Visible = 0
                ToolStripProgressBar1.Visible = False
                Timer1.Stop()


                'MsgBox("CONEXION ESTABLECIDA")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        CATEGORIA.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpNavigator.TableOfContents)
    End Sub

    Private Sub TIPO_CUESTIONARIO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HelpProvider1.HelpNamespace = ayuda
    End Sub
End Class