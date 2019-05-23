
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class PREGUNTA
    Dim datos As New DataSet
    Dim query As String

    Sub INSERTAR_PREGUNTA()
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "INSERT INTO PREGUNTAS (PREGUNTA,ID_CATEGORIA,ID_CUESTIONARIO,ID_NIVEL) VALUES (@PREGUNTA,@ID_CATEGORIA,@ID_CUESTIONARIO,@ID_NIVEL)"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()

            comando.Parameters.AddWithValue("@PREGUNTA", TextBox1.Text)
            comando.Parameters.AddWithValue("@ID_CATEGORIA", ComboBox1.SelectedValue)
            comando.Parameters.AddWithValue("@ID_CUESTIONARIO", ComboBox3.SelectedValue)
            comando.Parameters.AddWithValue("@ID_NIVEL", ComboBox2.SelectedValue)


            TextBox1.Clear()

            comando.ExecuteNonQuery()
            'MsgBox("CONEXION ESTABLECIDA")
            conex.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub CONSULTAR_PREGUNTA()
        'ToolStripStatusLabel1.Text = "Cargando"
        'ToolStripProgressBar1.Visible = True
        'Timer1.Start()
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        Dim query As String = "SELECT * FROM PREGUNTAS INNER JOIN CATEGORIA ON CATEGORIA.ID_CATEGORIA=PREGUNTAS.ID_CATEGORIA INNER JOIN NIVEL ON PREGUNTAS.ID_NIVEL=NIVEL.ID_NIVEL INNER JOIN CUESTIONARIO ON CUESTIONARIO.ID_CUESTIONARIO=PREGUNTAS.ID_CUESTIONARIO WHERE ID_PREGUNTA = " & ComboBox4.SelectedValue & " "
        Dim comando As New SqlCommand(query, conex)
        'Dim lista As Byte

        Dim pueb As New SqlDataAdapter(comando)
        datos = New DataSet
        pueb.Fill(datos, "PREGUNTAS")


        TextBox1.Text = datos.Tables("PREGUNTAS").Rows(0).Item("PREGUNTA")
        ComboBox1.Text = datos.Tables("PREGUNTAS").Rows(0).Item("NOMBRE_CATEGORIA")
        ComboBox3.Text = datos.Tables("PREGUNTAS").Rows(0).Item("NOMBRE_CUESTIONARIO")
        ComboBox2.Text = datos.Tables("PREGUNTAS").Rows(0).Item("NOMBRE_NIVEL")
    End Sub
    Sub MODIFICAR_PREGUNTA()
        'ToolStripStatusLabel1.Text = "Cargando"
        'ToolStripProgressBar1.Visible = True
        'Timer1.Start()
        Try

            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "UPDATE PREGUNTAS SET PREGUNTA = '" & TextBox1.Text & "',
                                                    ID_CATEGORIA = '" & ComboBox1.SelectedValue & "',
                                                    ID_CUESTIONARIO = '" & ComboBox3.SelectedValue & "',
                                                    ID_NIVEL = '" & ComboBox2.SelectedValue & "' 
                                                    WHERE ID_PREGUNTA = '" & ComboBox4.SelectedValue & "'"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()
            comando.ExecuteNonQuery()
            TextBox1.Clear()
            MsgBox("MODIFICACION CORRECTA")
            conex.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ELIMINAR_PREGUNTA()

        Try

            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim QUERY As String = "DELETE FROM PREGUNTAS WHERE ID_PREGUNTA = '" & ComboBox4.SelectedValue & "'"
            Dim comando As New SqlCommand(QUERY, conex)
            conex.Open()
            comando.ExecuteNonQuery()
            TextBox1.Clear()
            MsgBox("ILIMINACION EXITOSA")
            conex.Close()


        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
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
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Call INSERTAR_PREGUNTA()
    End Sub
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()

        Call CONSULTAR_PREGUNTA()
        ComboBox1.Enabled = False
        ComboBox2.Enabled = False
        ComboBox3.Enabled = False
        TextBox1.Enabled = False
        'respuesta
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        CheckBox1.Enabled = False
        CheckBox2.Enabled = False
        CheckBox3.Enabled = False
        CheckBox4.Enabled = False
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Call MODIFICAR_PREGUNTA()
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        ComboBox1.Enabled = True
        ComboBox2.Enabled = True
        ComboBox3.Enabled = True
        TextBox1.Enabled = True
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Call ELIMINAR_PREGUNTA()
    End Sub

    Sub INSERTAR_RESPUESATAS1()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "INSERT INTO RESPUESTA (RESPUESTAS,CORRECTA,ID_PREGUNTA) VALUES (@RESPUESTAS,@CORRECTA,@ID_PREGUNTA)"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()

            'comando.Parameters.AddWithValue("@ID_RESPUESTA", TextBox2.Text)

            comando.Parameters.AddWithValue("@RESPUESTAS", TextBox2.Text)
            comando.Parameters.AddWithValue("@CORRECTA", CheckBox1.Checked)
            comando.Parameters.AddWithValue("@ID_PREGUNTA", ComboBox4.SelectedValue)

            comando.ExecuteNonQuery()
            'MsgBox("CONEXION ESTABLECIDA")
            TextBox2.Clear()
            conex.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Sub INSERTAR_RESPUESATAS2()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "INSERT INTO RESPUESTA (RESPUESTAS,CORRECTA,ID_PREGUNTA) VALUES (@RESPUESTAS,@CORRECTA,@ID_PREGUNTA)"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()

            'comando.Parameters.AddWithValue("@ID_RESPUESTA", TextBox2.Text)

            comando.Parameters.AddWithValue("@RESPUESTAS", TextBox3.Text)
            comando.Parameters.AddWithValue("@CORRECTA", CheckBox2.Checked)
            comando.Parameters.AddWithValue("@ID_PREGUNTA", ComboBox4.SelectedValue)

            comando.ExecuteNonQuery()
            'MsgBox("CONEXION ESTABLECIDA")
            TextBox3.Clear()
            conex.Close()
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub INSERTAR_RESPUESATAS3()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "INSERT INTO RESPUESTA (RESPUESTAS,CORRECTA,ID_PREGUNTA) VALUES (@RESPUESTAS,@CORRECTA,@ID_PREGUNTA)"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()

            'comando.Parameters.AddWithValue("@ID_RESPUESTA", TextBox2.Text)

            comando.Parameters.AddWithValue("@RESPUESTAS", TextBox4.Text)
            comando.Parameters.AddWithValue("@CORRECTA", CheckBox3.Checked)
            comando.Parameters.AddWithValue("@ID_PREGUNTA", ComboBox4.SelectedValue)

            comando.ExecuteNonQuery()
            'MsgBox("CONEXION ESTABLECIDA")
            TextBox4.Clear()
            conex.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub INSERTAR_RESPUESATAS4()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "INSERT INTO RESPUESTA (RESPUESTAS,CORRECTA,ID_PREGUNTA) VALUES (@RESPUESTAS,@CORRECTA,@ID_PREGUNTA)"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()


            comando.Parameters.AddWithValue("@RESPUESTAS", TextBox5.Text)
            comando.Parameters.AddWithValue("@CORRECTA", CheckBox4.Checked)
            comando.Parameters.AddWithValue("@ID_PREGUNTA", ComboBox4.SelectedValue)

            comando.ExecuteNonQuery()
            'MsgBox("CONEXION ESTABLECIDA")
            conex.Close()
            TextBox5.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Sub CONSULTAR_RESPUESTAS1()
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        Dim query As String = "SELECT * FROM RESPUESTA INNER JOIN PREGUNTAS ON RESPUESTA.ID_PREGUNTA=PREGUNTAS.ID_PREGUNTA WHERE  PREGUNTAS.ID_PREGUNTA =" & ComboBox4.SelectedValue & ""
        Dim comando As New SqlCommand(query, conex)
        'Dim lista As Byte

        Dim pueb As New SqlDataAdapter(comando)
        datos = New DataSet
        pueb.Fill(datos, "RESPUESTA")



        TextBox2.Text = datos.Tables("RESPUESTA").Rows(0).Item("RESPUESTAS")
        CheckBox1.Checked = datos.Tables("RESPUESTA").Rows(0).Item("CORRECTA")

        TextBox3.Text = datos.Tables("RESPUESTA").Rows(1).Item("RESPUESTAS")
        CheckBox2.Checked = datos.Tables("RESPUESTA").Rows(1).Item("CORRECTA")

        TextBox4.Text = datos.Tables("RESPUESTA").Rows(2).Item("RESPUESTAS")
        CheckBox3.Checked = datos.Tables("RESPUESTA").Rows(2).Item("CORRECTA")

        TextBox5.Text = datos.Tables("RESPUESTA").Rows(3).Item("RESPUESTAS")
        CheckBox4.Checked = datos.Tables("RESPUESTA").Rows(3).Item("CORRECTA")

    End Sub

    Sub MODIFICAR_RESPUESTAS1()
        Try

            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "UPDATE RESPUESTA SET RESPUESTAS = '" & TextBox2.Text & "',
                                    CORRECTA = '" & CheckBox1.Checked & "'                                                    
                                    WHERE ID_PREGUNTA  = '" & ComboBox4.SelectedValue & "'AND RESPUESTAS = '" & TextBox2.Text & "'"


            Dim comando As New SqlCommand(query, conex)
            conex.Open()
            comando.ExecuteNonQuery()
            ' MsgBox("MODIFICACION CORRECTA")
            conex.Close()


        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub MODIFICAR_RESPUESTAS2()
        Try

            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "UPDATE RESPUESTA SET RESPUESTAS = '" & TextBox3.Text & "',
                                    CORRECTA = '" & CheckBox2.Checked & "'                                                    
                                    WHERE ID_PREGUNTA  = '" & ComboBox4.SelectedValue & "'AND RESPUESTAS = '" & TextBox3.Text & "'"


            Dim comando As New SqlCommand(query, conex)
            conex.Open()
            comando.ExecuteNonQuery()
            'MsgBox("MODIFICACION CORRECTA")
            conex.Close()


        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub MODIFICAR_RESPUESTAS3()
        Try

            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "UPDATE RESPUESTA SET RESPUESTAS = '" & TextBox4.Text & "',
                                    CORRECTA = '" & CheckBox3.Checked & "'                                                    
                                    WHERE ID_PREGUNTA  = '" & ComboBox4.SelectedValue & "'AND RESPUESTAS = '" & TextBox4.Text & "'"


            Dim comando As New SqlCommand(query, conex)
            conex.Open()
            comando.ExecuteNonQuery()
            'MsgBox("MODIFICACION CORRECTA")
            conex.Close()


        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub MODIFICAR_RESPUESTAS4()
        Try

            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "UPDATE RESPUESTA SET RESPUESTAS = '" & TextBox5.Text & "',
                                    CORRECTA = '" & CheckBox4.Checked & "'                                                    
                                    WHERE ID_PREGUNTA  = '" & ComboBox4.SelectedValue & "'AND RESPUESTAS = '" & TextBox5.Text & "'"


            Dim comando As New SqlCommand(query, conex)
            conex.Open()
            comando.ExecuteNonQuery()
            ' MsgBox("MODIFICACION CORRECTA")
            conex.Close()


        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub ELIMINAR_RESPUESTAS()
        Try
            'ToolStripStatusLabel1.Text = "Cargando"
            'ToolStripProgressBar1.Visible = True
            'Timer1.Start()
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim QUERY As String = "DELETE FROM RESPUESTA WHERE ID_PREGUNTA = '" & ComboBox4.SelectedValue & "'"
            Dim comando As New SqlCommand(QUERY, conex)
            conex.Open()
            comando.ExecuteNonQuery()
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
        Try

            Call INSERTAR_RESPUESATAS1()
            Call INSERTAR_RESPUESATAS2()
            Call INSERTAR_RESPUESATAS3()
            Call INSERTAR_RESPUESATAS4()



            MsgBox("CONEXION ESTABLECIDA")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()



        Call CONSULTAR_RESPUESTAS1()
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        CheckBox1.Enabled = False
        CheckBox2.Enabled = False
        CheckBox3.Enabled = False
        CheckBox4.Enabled = False
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()

        Call MODIFICAR_RESPUESTAS1()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()


        MsgBox("MODIFICACION CORRECTA")

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()

        Call ELIMINAR_RESPUESTAS()
    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()

        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        CheckBox1.Enabled = True
        CheckBox2.Enabled = True
        CheckBox3.Enabled = True
        CheckBox4.Enabled = True
    End Sub


    Private Sub ComboBox1_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        conex.Open()
        Dim query As String = "SELECT * FROM CATEGORIA"
        Dim comando As New SqlCommand(query, conex)
        comando.CommandType = CommandType.Text

        Dim DA As New SqlDataAdapter(comando)
        Dim DT As New DataTable

        DA.Fill(DT)
        ComboBox1.DataSource = DT
        ComboBox1.DisplayMember = "NOMBRE_CATEGORIA"
        ComboBox1.ValueMember = "ID_CATEGORIA"
        'ToolStripStatusLabel1.Text = "cargando"

    End Sub

    Private Sub ComboBox2_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        conex.Open()
        Dim query As String = "SELECT * FROM NIVEL"
        Dim comando As New SqlCommand(query, conex)
        comando.CommandType = CommandType.Text
        Dim DA As New SqlDataAdapter(comando)
        Dim DT As New DataTable

        DA.Fill(DT)
        ComboBox2.DataSource = DT
        ComboBox2.DisplayMember = "NOMBRE_NIVEL"
        ComboBox2.ValueMember = "ID_NIVEL"
    End Sub

    Private Sub ComboBox3_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        conex.Open()
        Dim query As String = "SELECT * FROM CUESTIONARIO"
        Dim comando As New SqlCommand(query, conex)
        comando.CommandType = CommandType.Text
        Dim DA As New SqlDataAdapter(comando)
        Dim DT As New DataTable

        DA.Fill(DT)
        ComboBox3.DataSource = DT
        ComboBox3.DisplayMember = "NOMBRE_CUESTIONARIO"
        ComboBox3.ValueMember = "ID_CUESTIONARIO"
    End Sub


    Private Sub ComboBox4_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        conex.Open()
        Dim query As String = "SELECT * FROM PREGUNTAS"
        Dim comando As New SqlCommand(query, conex)
        comando.CommandType = CommandType.Text
        Dim DA As New SqlDataAdapter(comando)
        Dim DT As New DataTable

        DA.Fill(DT)
        ComboBox4.DataSource = DT
        ComboBox4.DisplayMember = "PREGUNTA"
        ComboBox4.ValueMember = "ID_PREGUNTA"
    End Sub

    Private Sub Button8_MouseEnter(sender As Object, e As EventArgs) Handles Button8.MouseEnter
        Label5.Visible = True
    End Sub

    Private Sub Button8_MouseLeave(sender As Object, e As EventArgs) Handles Button8.MouseLeave
        Label5.Visible = False
    End Sub

    Private Sub Button9_MouseEnter(sender As Object, e As EventArgs) Handles Button9.MouseEnter
        Label8.Visible = True
    End Sub

    Private Sub Button9_MouseLeave(sender As Object, e As EventArgs) Handles Button9.MouseLeave
        Label8.Visible = False
    End Sub

    Private Sub Button7_MouseEnter(sender As Object, e As EventArgs) Handles Button7.MouseEnter
        Label9.Visible = True
    End Sub

    Private Sub Button7_MouseLeave(sender As Object, e As EventArgs) Handles Button7.MouseLeave
        Label9.Visible = False
    End Sub

    Private Sub Button3_MouseEnter(sender As Object, e As EventArgs) Handles Button3.MouseEnter
        Label10.Visible = True
    End Sub

    Private Sub Button3_MouseLeave(sender As Object, e As EventArgs) Handles Button3.MouseLeave
        Label10.Visible = False
    End Sub

    Private Sub Button4_MouseEnter(sender As Object, e As EventArgs) Handles Button4.MouseEnter
        Label11.Visible = True
    End Sub

    Private Sub Button4_MouseLeave(sender As Object, e As EventArgs) Handles Button4.MouseLeave
        Label11.Visible = False
    End Sub

    Private Sub Button1_MouseEnter(sender As Object, e As EventArgs) Handles Button1.MouseEnter
        Label12.Visible = True
    End Sub

    Private Sub Button1_MouseLeave(sender As Object, e As EventArgs) Handles Button1.MouseLeave
        Label12.Visible = False
    End Sub

    Private Sub Button2_MouseEnter(sender As Object, e As EventArgs) Handles Button2.MouseEnter
        Label13.Visible = True
    End Sub

    Private Sub Button2_MouseLeave(sender As Object, e As EventArgs) Handles Button2.MouseLeave
        Label13.Visible = False
    End Sub

    Private Sub Button11_MouseEnter(sender As Object, e As EventArgs) Handles Button11.MouseEnter
        Label14.Visible = True
    End Sub

    Private Sub Button11_MouseLeave(sender As Object, e As EventArgs) Handles Button11.MouseLeave
        Label14.Visible = False
    End Sub

    Private Sub Button5_MouseEnter(sender As Object, e As EventArgs) Handles Button5.MouseEnter
        Label15.Visible = True
    End Sub

    Private Sub Button5_MouseLeave(sender As Object, e As EventArgs) Handles Button5.MouseLeave
        Label15.Visible = False
    End Sub

    Private Sub Button6_MouseEnter(sender As Object, e As EventArgs) Handles Button6.MouseEnter
        Label16.Visible = True
    End Sub

    Private Sub Button6_MouseLeave(sender As Object, e As EventArgs) Handles Button6.MouseLeave
        Label16.Visible = False
    End Sub
End Class