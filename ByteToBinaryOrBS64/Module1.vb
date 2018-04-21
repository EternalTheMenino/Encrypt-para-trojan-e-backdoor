Module Module1

    Sub Main()
        Dim code As Byte() = IO.File.ReadAllBytes("1.exe")
        Dim codeBs As String = Convert.ToBase64String(code)
        Dim Temp As String = ""
        Dim txtBuilder As New System.Text.StringBuilder
        For Each Character As Byte In System.Text.ASCIIEncoding.ASCII.GetBytes(codeBs)
            txtBuilder.Append(Convert.ToString(Character, 2).PadLeft(8, "0"))
            txtBuilder.Append(" ")
        Next
        Temp = txtBuilder.ToString.Substring(0, txtBuilder.ToString.Length - 0)
        IO.File.WriteAllText("1.txt", Temp)
        IO.File.WriteAllText("2.txt", codeBs)
        IO.File.WriteAllText("3.txt", BinaryToString(Temp))
    End Sub
    Public Function BinaryToString(ByVal Binary As String) As String
        Dim Characters As String = System.Text.RegularExpressions.Regex.Replace(Binary, "[^01]", "")
        Dim ByteArray((Characters.Length / 8) - 1) As Byte
        For Index As Integer = 0 To ByteArray.Length - 1
            ByteArray(Index) = Convert.ToByte(Characters.Substring(Index * 8, 8), 2)
        Next
        Return System.Text.ASCIIEncoding.ASCII.GetString(ByteArray)
    End Function
End Module
