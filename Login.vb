Public Class frmLogin

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If AuthAPI.CheckCombo(UsernameTextBox.Text, PasswordTextBox.Text) Then
            Form1.Show()
            Me.Close()
        Else
            MsgBox("The username or password was invalid.", MsgBoxStyle.Exclamation, "Combat Corps")
            PasswordTextBox.Text = ""
            PasswordTextBox.Focus()
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Application.Exit()
    End Sub

End Class
