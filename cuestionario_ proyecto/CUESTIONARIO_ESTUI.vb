Imports System.Data.SqlClient
Public Class CUESTIONARIO_ESTUI
    Dim ayuda As String = System.IO.Path.Combine(Application.StartupPath, "CUESTIONARIO.chm")
    Dim datos As New DataSet

    Private Sub ComboBox1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HelpProvider1.HelpNamespace = ayuda
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


    Private Sub PREGUNTASBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles PREGUNTASBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.PREGUNTASBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CUESTIONARIO_FINALDataSet3)

    End Sub

    Private Sub CUESTIONARIO_ESTUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'CUESTIONARIO_FINALDataSet3.PREGUNTAS' Puede moverla o quitarla según sea necesario.
        Me.PREGUNTASTableAdapter.Fill(Me.CUESTIONARIO_FINALDataSet3.PREGUNTAS)
        Me.ver_res()
        Me.ver_pre()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
        Dim query As String = "SELECT * FROM CUESTIONARIO INNER JOIN PREGUNTAS ON PREGUNTAS.ID_CUESTIONARIO= CUESTIONARIO.ID_CUESTIONARIO WHERE PREGUNTAS.ID_CUESTIONARIO= " & ComboBox1.SelectedValue & ""
        Dim comando As New SqlCommand(query, conex)
        Dim pueb As New SqlDataAdapter(comando)
        'MsgBox(query)
        datos = New DataSet
        pueb.Fill(datos, "RESPUESTA")
        If ComboBox1.SelectedValue = 1 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 2 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 3 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 4 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 5 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 6 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 7 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 8 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 9 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 10 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 11 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 12 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 13 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 14 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 15 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 16 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 17 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 18 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 19 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 20 Then
            Call ver_pre()
            Call ver_res()
        End If
        If ComboBox1.SelectedValue = 21 Then
            Call ver_pre()
            Call ver_res()
        End If
    End Sub


    Private Sub ver_pre()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "SELECT * FROM PREGUNTAS INNER JOIN CUESTIONARIO ON PREGUNTAS.ID_CUESTIONARIO = CUESTIONARIO.ID_CUESTIONARIO WHERE PREGUNTAS.ID_CUESTIONARIO = " & ComboBox1.SelectedValue & ""
            Dim comando As New SqlCommand(query, conex)
            Dim pueb As New SqlDataAdapter(comando)
            datos = New DataSet
            pueb.Fill(datos, "PREGUNTAS")
            PREGUNTALabel2.Text = datos.Tables("PREGUNTAS").Rows(0).Item("PREGUNTA").ToString
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ver_res()
        Try
            Dim conex As New SqlConnection("Data Source=DESKTOP-N3PL2OJ;Initial Catalog=CUESTIONARIO_FINAL;Integrated Security=True")
            Dim query As String = "SELECT * FROM RESPUESTA INNER JOIN PREGUNTAS ON RESPUESTA.ID_PREGUNTA=PREGUNTAS.ID_PREGUNTA WHERE  PREGUNTAS.PREGUNTA = '" & PREGUNTALabel2.Text & "' "

            Dim comando As New SqlCommand(query, conex)
            Dim pueb As New SqlDataAdapter(comando)
            datos = New DataSet

            pueb.Fill(datos, "RESPUESTA")
            Label2.Text = datos.Tables("RESPUESTA").Rows(0).Item("RESPUESTAS").ToString
            Label3.Text = datos.Tables("RESPUESTA").Rows(1).Item("RESPUESTAS").ToString
            Label4.Text = datos.Tables("RESPUESTA").Rows(2).Item("RESPUESTAS").ToString
            Label5.Text = datos.Tables("RESPUESTA").Rows(3).Item("RESPUESTAS").ToString

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub Respuestas_corr_incorr()
        Dim a As String
        Dim b As String
        Dim c As String
        Dim d As String

        a = datos.Tables("RESPUESTA").Rows(0).Item("CORRECTA").ToString
        b = datos.Tables("RESPUESTA").Rows(1).Item("CORRECTA").ToString
        c = datos.Tables("RESPUESTA").Rows(2).Item("CORRECTA").ToString
        d = datos.Tables("RESPUESTA").Rows(3).Item("CORRECTA").ToString

        If Not RadioButton1.Checked = a And RadioButton1.Checked = True Then
            Label9.Text = Label9.Text + 1
        ElseIf RadioButton1.Checked = a And RadioButton1.Checked = True Then
            Label7.Text = Label7.Text + 1
        End If

        If Not RadioButton2.Checked = b And RadioButton2.Checked = True Then
            Label9.Text = Label9.Text + 1
        ElseIf RadioButton2.Checked = b And RadioButton2.Checked = True Then
            Label7.Text = Label7.Text + 1
        End If

        If Not RadioButton3.Checked = c And RadioButton3.Checked = True Then
            Label9.Text = Label9.Text + 1
        ElseIf RadioButton3.Checked = c And RadioButton3.Checked = True Then
            Label7.Text = Label7.Text + 1
        End If

        If Not RadioButton4.Checked = d And RadioButton4.Checked = True Then
            Label9.Text = Label9.Text + 1
        ElseIf RadioButton4.Checked = d And RadioButton4.Checked = True Then
            Label7.Text = Label7.Text + 1
        End If
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        RadioButton4.Checked = False
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.PREGUNTASBindingSource.MoveNext()
        Call ver_res()
        Call Respuestas_corr_incorr()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Help.ShowHelp(Me, HelpProvider1.HelpNamespace, HelpNavigator.TableOfContents)
    End Sub
End Class