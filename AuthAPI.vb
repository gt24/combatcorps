Imports System.Xml
Module AuthAPI
    Public Function CheckCombo(ByVal Username As String, ByVal Password As String)
        Dim Doc As XmlReader = SendPost("login", "username=" & Username & "&password=" & Password)

        Doc.ReadToFollowing("api")
        Doc.ReadStartElement()

        If Doc.LocalName = "login" Then
            'Doc.ReadStartElement()
            'MsgBox(Doc.ReadElementString)
            'Doc.ReadEndElement()
            Doc.Close()
            Return True
        Else
            Doc.Close()
            Return False
        End If
    End Function

    Private Function SendPost(ByVal Mode As String, ByVal Data As String) As XmlReader
        Dim Request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://www.combatcorps.com/forums/api.php?mode=" & Mode)
        Request.ContentType = "application/x-www-form-urlencoded"
        Request.Method = "POST"

        Dim RequestStream As New IO.StreamWriter(Request.GetRequestStream)
        RequestStream.Write(Data)
        RequestStream.Close()

        Dim Response As System.Net.HttpWebResponse = Request.GetResponse
        'MsgBox(New IO.StreamReader(Response.GetResponseStream).ReadToEnd)

        Dim Settings = New Xml.XmlReaderSettings
        Settings.IgnoreWhitespace = True
        SendPost = XmlTextReader.Create(Response.GetResponseStream, Settings)
        'Response.Close()
    End Function
End Module
