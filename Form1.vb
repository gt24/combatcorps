Public Class Form1

    Private Sub IRCManager_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles IRCManager.DoWork
        Dim socket As New Net.Sockets.Socket(Net.Sockets.AddressFamily.InterNetwork, Net.Sockets.SocketType.Stream, Net.Sockets.ProtocolType.Tcp)
        socket.Connect("irc.eighthbit.net", 6667)
        socket.Send(System.Text.Encoding.UTF8.GetBytes("NICK hai" & vbNewLine))
        socket.Send(System.Text.Encoding.UTF8.GetBytes("USER vbnet * * :hai thar" & vbNewLine))
        socket.Send(System.Text.Encoding.UTF8.GetBytes("JOIN #bots" & vbNewLine))
        socket.Send(System.Text.Encoding.UTF8.GetBytes("PRIVMSG #bots :hello thar!" & vbNewLine))

        While socket.Connected
            Dim Bytes(512) As Byte
            Dim Len As Integer = socket.Receive(Bytes, 512, Net.Sockets.SocketFlags.None)
            If Len = 0 Then
                IRCManager.ReportProgress(100)
                Exit Sub
            End If
            Dim Data = System.Text.Encoding.UTF8.GetString(Bytes, 0, Len)

            IRCManager.ReportProgress(50, Data)
        End While
    End Sub

    Private Sub IRCManager_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles IRCManager.ProgressChanged
        If e.UserState.ToString.Contains("PRIVMSG") Then
            MsgBox(e.UserState)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        IRCManager.RunWorkerAsync()
    End Sub
End Class
