Imports FontAwesome

Public Class InstallForm

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FaInstaller.Install()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FaInstaller.UnInstall()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TestForm.Show()
    End Sub
End Class