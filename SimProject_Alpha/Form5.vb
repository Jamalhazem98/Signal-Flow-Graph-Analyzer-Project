Public Class Form5
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MsgBox("This project was made for System Dynamics course in JU Mechatronics Department. By :Jamal Sa'd. Supervised by: Dr. Adham Alsharkawi")
    End Sub
End Class