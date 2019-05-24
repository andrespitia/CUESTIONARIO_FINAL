Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class USUARIO
    Dim datos As DataSet
    Dim ayuda As String = System.IO.Path.Combine(Application.StartupPath, "CUESTIONARIO.chm")
    Sub INSERTAR_USUARIO()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "INSERT INTO USUARIO (CODIGO_USUARIO,NOMBRE_USUARIO, APELLIDO_USUARIO, CORREO, PASSWORD_USUARIO, EDAD, ID_ROL) VALUES (@CODIGO_USUARIO,@NOMBRE_USUARIO, @APELLIDO_USUARIO,@CORREO,@PASSWORD_USUARIO, @EDAD, @ID_ROL)"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()
            comando.Parameters.AddWithValue("@CODIGO_USUARIO", TextBox1.Text) 'ENVIO DE PARAMETROS'
            comando.Parameters.AddWithValue("@NOMBRE_USUARIO", TextBox2.Text)
            comando.Parameters.AddWithValue("@APELLIDO_USUARIO", TextBox3.Text)
            comando.Parameters.AddWithValue("@CORREO", TextBox4.Text)
            comando.Parameters.AddWithValue("@PASSWORD_USUARIO", TextBox5.Text)
            comando.Parameters.AddWithValue("@EDAD", TextBox7.Text)
            comando.Parameters.AddWithValue("@ID_ROL", ComboBox1.SelectedValue)

            ' comando.Parameters.AddWithValue("@ID_ROL", ComboBox1.SelectedIndex)
            comando.ExecuteNonQuery()
            'MsgBox("EL USUARIO SE HA REGISTRADO")
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
        If (TextBox1.Text <> "") And (TextBox2.Text <> "") And (TextBox3.Text <> "") And (TextBox4.Text <> "") And (TextBox5.Text <> "") And (TextBox7.Text <> "") And TextBox5.Text = TextBox6.Text Then

            Call INSERTAR_USUARIO()
            MsgBox("EL USUARIO SE HA REGISTRADO")
            Login.Show()
            Me.Hide()

            lbl_contra.Visible = True
        Else
            MsgBox("TODOS LOS CAMPOS SON OBLIGATORIAS")
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Login.Show()
        Me.Close()
    End Sub

    Private Sub ComboBox1_load(sender As Object, e As EventArgs) Handles MyBase.Load
        HelpProvider1.HelpNamespace = ayuda
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
    Sub MODIFICAR_USUARIO()
        Try

            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "UPDATE USUARIO SET NOMBRE_USUARIO = '" & TextBox2.Text & "',
                                                    APELLIDO_USUARIO = '" & TextBox3.Text & "',
                                                    CORREO = '" & TextBox4.Text & "',
                                                    PASSWORD_USUARIO = '" & TextBox5.Text & "',                                                    
                                                    EDAD = '" & TextBox7.Text & "',
                                                    ID_ROL = '" & ComboBox1.SelectedValue & "' 
                                                    WHERE CODIGO_USUARIO = '" & TextBox1.Text & "'"
            Dim comando As New SqlCommand(query, conex)
            conex.Open()
            comando.ExecuteNonQuery()
            MsgBox("MODIFICACION CORRECTA")
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
        Call MODIFICAR_USUARIO()

    End Sub
    Sub CONSULTAR_USUARIO()
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        Dim query As String = "SELECT*FROM USUARIO INNER JOIN ROL ON ROL.ID_ROL=USUARIO.ID_ROL WHERE CODIGO_USUARIO = " & TextBox1.Text & " "
        Dim comando As New SqlCommand(query, conex)
        'Dim lista As Byte

        Dim pueb As New SqlDataAdapter(comando)
        datos = New DataSet
        pueb.Fill(datos, "USUARIO")


        TextBox2.Text = datos.Tables("USUARIO").Rows(0).Item("NOMBRE_USUARIO")
        TextBox3.Text = datos.Tables("USUARIO").Rows(0).Item("APELLIDO_USUARIO")
        TextBox4.Text = datos.Tables("USUARIO").Rows(0).Item("CORREO")
        TextBox5.Text = datos.Tables("USUARIO").Rows(0).Item("PASSWORD_USUARIO")
        TextBox7.Text = datos.Tables("USUARIO").Rows(0).Item("EDAD")
        ComboBox1.Text = datos.Tables("USUARIO").Rows(0).Item("NOMBRE_ROL")
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        Call CONSULTAR_USUARIO()

        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
        TextBox7.Enabled = False
        ComboBox1.Enabled = False


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ToolStripProgressBar1.Value = 0
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Visible = True
        Timer1.Start()
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        TextBox5.Enabled = True
        TextBox7.Enabled = True
        ComboBox1.Enabled = True
    End Sub



    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox7_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox7.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
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

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpNavigator.TableOfContents)
    End Sub
End Class