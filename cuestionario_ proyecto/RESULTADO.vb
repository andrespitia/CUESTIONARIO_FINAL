Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class RESULTADO
    Dim datos As New DataSet
    Dim query As String
    Private Sub ComboBox2_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        conex.Open()
        Dim query As String = "SELECT * FROM USUARIO"
        Dim comando As New SqlCommand(query, conex)
        comando.CommandType = CommandType.Text
        Dim DA As New SqlDataAdapter(comando)
        Dim DT As New DataTable

        DA.Fill(DT)
        ComboBox2.DataSource = DT
        ComboBox2.DisplayMember = "NOMBRE_USUARIO"
        ComboBox2.ValueMember = "CODIGO_USUARIO"
    End Sub
    Private Sub ComboBox1_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        conex.Open()
        Dim query As String = "SELECT * FROM CUESTIONARIO"
        Dim comando As New SqlCommand(query, conex)
        comando.CommandType = CommandType.Text
        Dim DA As New SqlDataAdapter(comando)
        Dim DT As New DataTable

        DA.Fill(DT)
        ComboBox1.DataSource = DT
        ComboBox1.DisplayMember = "NOMBRE_CUESTIONARIO"
        ComboBox1.ValueMember = "ID_CUESTIONARIO"
    End Sub
    Sub INSERTAR_RESULTADO()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "INSERT INTO RESULTADO (RES_CORRECTA,RES_INCORRECTA,TOTAL_PREGUNTAS,PRUNTAJE,FECHA_CUESTIONARIO,HORA_CUESTIONARIO,ID_CUESTIONARIO,CODIGO_USUARIO) VALUES (@RES_CORRECTA,@RES_INCORRECTA,@TOTAL_PREGUNTAS,@PRUNTAJE,@FECHA_CUESTIONARIO,@HORA_CUESTIONARIO,@ID_CUESTIONARIO,@CODIGO_USUARIO)"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()

            comando.Parameters.AddWithValue("@RES_CORRECTA", txt_res_correctas.Text)
            comando.Parameters.AddWithValue("@RES_INCORRECTA", TextBox1.Text)
            comando.Parameters.AddWithValue("@TOTAL_PREGUNTAS", TextBox9.Text)
            comando.Parameters.AddWithValue("@PRUNTAJE", TextBox2.Text)
            comando.Parameters.AddWithValue("@FECHA_CUESTIONARIO", TextBox4.Text)
            comando.Parameters.AddWithValue("@HORA_CUESTIONARIO", TextBox3.Text)
            comando.Parameters.AddWithValue("@ID_CUESTIONARIO", ComboBox1.SelectedValue)
            comando.Parameters.AddWithValue("@CODIGO_USUARIO", ComboBox2.SelectedValue)

            comando.ExecuteNonQuery()
            MsgBox("CONEXION ESTABLECIDA")
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
        Call INSERTAR_RESULTADO()
    End Sub
    Sub CONSULTAR_RESULTADO()
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        Dim query As String = "SELECT*FROM RESULTADO INNER JOIN CUESTIONARIO ON RESULTADO.ID_CUESTIONARIO=CUESTIONARIO.ID_CUESTIONARIO INNER JOIN USUARIO ON USUARIO.CODIGO_USUARIO=RESULTADO.CODIGO_USUARIO WHERE RESULTADO.ID_RESULTADO = " & txt_id.Text & " "
        Dim comando As New SqlCommand(query, conex)
        'Dim lista As Byte

        Dim pueb As New SqlDataAdapter(comando)
        datos = New DataSet
        pueb.Fill(datos, "RESULTADO")

        txt_id.Text = datos.Tables("RESULTADO").Rows(0).Item("ID_RESULTADO")
        txt_res_correctas.Text = datos.Tables("RESULTADO").Rows(0).Item("RES_CORRECTA")
        TextBox1.Text = datos.Tables("RESULTADO").Rows(0).Item("RES_INCORRECTA")
        TextBox9.Text = datos.Tables("RESULTADO").Rows(0).Item("TOTAL_PREGUNTAS")
        TextBox2.Text = datos.Tables("RESULTADO").Rows(0).Item("PRUNTAJE")
        TextBox4.Text = datos.Tables("RESULTADO").Rows(0).Item("FECHA_CUESTIONARIO").ToString
        TextBox3.Text = datos.Tables("RESULTADO").Rows(0).Item("HORA_CUESTIONARIO").ToString
        ComboBox2.Text = datos.Tables("RESULTADO").Rows(0).Item("NOMBRE_USUARIO")
        ComboBox1.Text = datos.Tables("RESULTADO").Rows(0).Item("NOMBRE_CUESTIONARIO")

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Call CONSULTAR_RESULTADO()
        txt_res_correctas.Enabled = False
        TextBox1.Enabled = False
        TextBox9.Enabled = False
        TextBox2.Enabled = False
        TextBox4.Enabled = False
        TextBox3.Enabled = False
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
    End Sub
    Sub MODIFICAR_RESULTADO()


    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Call MODIFICAR_RESULTADO()
    End Sub
    Sub ELIMINAR_RESULTADO()
        Try
            'ToolStripStatusLabel1.Text = "Cargando"
            'ToolStripProgressBar1.Visible = True
            'Timer1.Start()
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim QUERY As String = "DELETE FROM RESULTADO WHERE ID_RESULTADO = '" & txt_id.Text & "'"
            Dim comando As New SqlCommand(QUERY, conex)
            conex.Open()
            comando.ExecuteNonQuery()

            conex.Close()


        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Call ELIMINAR_RESULTADO()
        txt_res_correctas.Clear()
        TextBox1.Clear()
        TextBox9.Clear()
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox3.Clear()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        txt_res_correctas.Enabled = True
        TextBox1.Enabled = True
        TextBox9.Enabled = True
        TextBox2.Enabled = True
        TextBox4.Enabled = True
        TextBox3.Enabled = True
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
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