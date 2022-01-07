'CODE BY TALENT1
Public Class Form1
    Dim cdd() As String
    Private Sub ComboBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyData = Keys.Enter Then

            Dim process As Process = New Process
            With process
                .StartInfo.ErrorDialog = False
                .StartInfo.RedirectStandardInput = True
                .StartInfo.RedirectStandardOutput = True
                .StartInfo.UseShellExecute = False
                .StartInfo.FileName = "cmd.exe"
                .StartInfo.CreateNoWindow = True
                .StartInfo.WindowStyle = ProcessWindowStyle.Hidden

            End With
            process.Start()
            Try
                process.StandardInput.WriteLine("cd/d " & cdd(3))
            Catch
            End Try
            process.StandardInput.WriteLine(ComboBox1.Text)
            process.StandardInput.WriteLine("echo [~cd~]%cd%[~cd~]")
            process.StandardInput.WriteLine("exit")
            Dim outpp As New TextBox
            outpp.Text = process.StandardOutput.ReadToEnd
            cdd = Split(outpp.Text, "[~cd~]")

            For i = 4 To outpp.Lines.Length - 6
                RichTextBox1.Text = RichTextBox1.Text & outpp.Lines(i).Substring(0) & vbCrLf
            Next
            ComboBox1.Items.Add(ComboBox1.Text)
            ComboBox1.Text = ""
            RichTextBox1.SelectionStart = RichTextBox1.Text.Length
            RichTextBox1.ScrollToCaret()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RichTextBox1.Text = "Microsoft Windows [Version " & My.Computer.Info.OSVersion & "]"
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class
