﻿Public Class splash_screen


    Private Sub splash_screen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()

        While Me.Opacity > 0
            Me.Opacity -= 0.00001

        End While

        Me.Visible = False
        Login.Show()
        'Me.Hide()

    End Sub


End Class