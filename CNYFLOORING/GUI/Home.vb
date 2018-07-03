Public Class Home

    Private Sub btnCustomers_Click(sender As Object, e As EventArgs) Handles btnCustomers.Click
        Dim aForm As New Customers
        aForm.Show()
        Me.Hide()
    End Sub
End Class