Imports FontAwesome

Public Class TestForm

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TestBox.Font = FaFont(100)
        TestBox.Text = TestBox.Text + Convert.ToChar(Fa.File)
    End Sub

End Class