
Option Strict On
Public Class Customers

    'declare dataset
    Private dsEvents As New DataSet

    Private Sub CustomerBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles CustomerBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomerBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CNYFLOORING2DataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CNYFLOORING2DataSet.Customer' table. You can move, or remove it, as needed.
        Me.CustomerTableAdapter.Fill(Me.CNYFLOORING2DataSet.Customer)

    End Sub

    Public Sub DisplayRecord(ByVal aIndex As Integer)
      

    End Sub

End Class
