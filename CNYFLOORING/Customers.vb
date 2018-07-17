
Option Strict On
Public Class Customers

    'declare dataset
    Private Customer As New DataSet

    Private Sub CustomerBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles CustomerBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CustomerBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CNYFLOORING2DataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CNYFLOORING2DataSet.Customer' table. You can move, or remove it, as needed.
        Me.CustomerTableAdapter.Fill(Me.CNYFLOORING2DataSet.Customer)
        Customer = clsCustomers.GetRecords()
        DisplayRecord(0)

    End Sub

    Public Sub DisplayRecord(ByVal aIndex As Integer)

        Try
            If Customer.Tables("Customer").Rows.Count = 0 Then
                Exit Sub
            End If

            lblCurrent.Text = (aIndex + 1).ToString
            lblTotal.Text = (Customer.Tables("Customer").Rows.Count).ToString

            IDTextBox.Text = Customer.Tables("Customer").Rows(aIndex).Item(0).ToString
            FirstNameTextBox.Text = Customer.Tables("Customer").Rows(aIndex).Item(1).ToString
            LastNameTextBox.Text = Customer.Tables("Customer").Rows(aIndex).Item(2).ToString
            AddressTextBox.Text = Customer.Tables("Customer").Rows(aIndex).Item(3).ToString
            CityTextBox.Text = Customer.Tables("Customer").Rows(aIndex).Item(4).ToString
            StateTextBox.Text = Customer.Tables("Customer").Rows(aIndex).Item(5).ToString
            PhoneNumberTextBox.Text = Customer.Tables("Customer").Rows(aIndex).Item(6).ToString
            DateDateTimePicker.Value = CDate(Customer.Tables("Customer").Rows(aIndex).Item(2))
            JobDescriptionTextBox.Text = Customer.Tables("Cusotmer").Rows(aIndex).Item(7).ToString


        Catch ex As Exception
            MessageBox.Show("Error occurred in Form: Customers. Method: DisplayRecord(index). Error: " _
                           & ex.Message)
        End Try

    End Sub

    Private Sub btnMainMenu_Click(sender As Object, e As EventArgs) Handles btnMainMenu.Click
        Dim aForm As New Home
        aForm.Show()
        Me.Hide()
    End Sub



    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            If (CInt(lblCurrent.Text) = Customer.Tables("Customer").Rows.Count) Then
                ' do nothing, because we don't care
                Exit Sub
            End If
            ' go to the next record
            DisplayRecord(CInt(lblCurrent.Text))
        Catch ex As Exception
            MessageBox.Show("error occurred in form: Customer. method: btnnext_click(). error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click

        Try
            If lblCurrent.Text = "1" Then
                Exit Sub
            End If
            DisplayRecord(CInt(lblCurrent.Text) - 2)

        Catch ex As Exception
            MessageBox.Show("error occurred in form: Customer. method: btnPrev_Click(). error:" & ex.Message)
        End Try
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Try
            ' go to the last record
            DisplayRecord(Customer.Tables("Customer").Rows.Count - 1)
        Catch ex As Exception
            MessageBox.Show("error occurred in form: Customer. method: btnlast_click(). error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Try
            ' go to the first record
            DisplayRecord(0)
        Catch ex As Exception
            MessageBox.Show("error occurred in form: Customer. method: btnfirst_click(). error: " & ex.Message)
        End Try
    End Sub



    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim myCustomers As clsCustomers

        Try
            If IsValidNumber(IDTextBox, "ID") = True Then
                If IsValidText(FirstNameTextBox, "FirstName") = True Then
                    If IsValidText(LastNameTextBox, "LastName") = True Then
                        If IsValidText(AddressTextBox, "Address") = True Then
                            If IsValidText(CityTextBox, "City") = True Then
                                If IsValidText(StateTextBox, "State") = True Then
                                    If IsValidText(PhoneNumberTextBox, "Phone Number") = True Then
                                        If IsDate(DateDateTimePicker.Value) = True Then
                                            If IsValidText(JobDescriptionTextBox, "Job Description") = True Then

                                                myCustomers = New clsCustomers(CInt(IDTextBox.Text.Trim), FirstNameTextBox.Text, LastNameTextBox.Text, AddressTextBox.Text,
                                                                               CityTextBox.Text, StateTextBox.Text, PhoneNumberTextBox.Text, CDate(DateDateTimePicker.Value),
                                                                               JobDescriptionTextBox.Text)

                                                ' declare a variable to holds the result
                                                Dim intResult As Integer
                                                ' call the function to add a record
                                                intResult = clsCustomers.AddRecord(myCustomers)
                                                ' evaluate the result
                                                If intResult = 1 Then
                                                    MessageBox.Show("A record has been successfully added!")
                                                ElseIf intResult = 0 Then
                                                    MessageBox.Show("Add failed!")
                                                Else
                                                    MessageBox.Show("Massive fail please contact the Author")

                                                End If

                                                ' get the updated dataset
                                                Customer = clsCustomers.GetRecords()
                                                'Me.EventDataGridView.DataSource = dsEvents.Tables("Event")
                                                ' display the first record
                                                DisplayRecord(0)


                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    End If

                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error occurred in Form: Customer. Method: btnAdd_Click(). Error: " & ex.Message)
        End Try
    End Sub



    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim myCustomers As clsCustomers

        Try
            If IsValidNumber(IDTextBox, "ID") = True Then
                If IsValidText(FirstNameTextBox, "FirstName") = True Then
                    If IsValidText(LastNameTextBox, "LastName") = True Then
                        If IsValidText(AddressTextBox, "Address") = True Then
                            If IsValidText(CityTextBox, "City") = True Then
                                If IsValidText(StateTextBox, "State") = True Then
                                    If IsValidText(PhoneNumberTextBox, "Phone Number") = True Then
                                        If IsDate(DateDateTimePicker.Value) = True Then
                                            If IsValidText(JobDescriptionTextBox, "Job Description") = True Then

                                                myCustomers = New clsCustomers(CInt(IDTextBox.Text.Trim), FirstNameTextBox.Text, LastNameTextBox.Text, AddressTextBox.Text,
                                                                               CityTextBox.Text, StateTextBox.Text, PhoneNumberTextBox.Text, CDate(DateDateTimePicker.Value),
                                                                               JobDescriptionTextBox.Text)

                                                ' declare a variable to holds the result
                                                Dim intResult As Integer
                                                ' call the function to add a record
                                                intResult = clsCustomers.AddRecord(myCustomers)
                                                ' evaluate the result
                                                If intResult = 1 Then
                                                    MessageBox.Show("A record has been successfully updated!")
                                                ElseIf intResult = 0 Then
                                                    MessageBox.Show("Add failed!")
                                                Else
                                                    MessageBox.Show("Massive fail please contact the Author")

                                                End If

                                                ' get the updated dataset
                                                Customer = clsCustomers.GetRecords()
                                                'Me.EventDataGridView.DataSource = dsEvents.Tables("Event")
                                                ' display the first record
                                                DisplayRecord(0)


                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If

                    End If

                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error occurred in Form: Customer. Method: btnUpdate_Click(). Error: " & ex.Message)
        End Try
    End Sub



    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        ' a variable to hold user's response
        Dim intresponse As Integer

        Try
            intresponse = MessageBox.Show("Are you certain you want to delete the record?",
                                          "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                                          MessageBoxDefaultButton.Button2)
            ' check the user response
            If intresponse = vbNo Then
                Exit Sub
            ElseIf IDTextBox.Text.Length = 0 Or Not IsNumeric(IDTextBox.Text.Trim) Then
                MessageBox.Show("You must enter a valid ID number for record deletion.")
                Exit Sub
            Else
                ' user answered Yes! and ID field has a valid value
                Dim intResult As Integer
                intResult = clsCustomers.DeleteRecord(IDTextBox.Text.Trim)

                ' evaluate the return result
                If intResult = 1 Then
                    MessageBox.Show("The record has been deleted!")
                ElseIf intResult = 0 Then
                    MessageBox.Show("Massive failure")
                Else
                    MessageBox.Show("Something is very wrong, please contact the Author")
                End If

            End If

            ' get the updated dataset
            Customer = clsCustomers.GetRecords()


        Catch ex As Exception
            MessageBox.Show("Error occurred in Form: Customers. Method: btnDelete_Click(). Error: " & ex.Message)
        End Try

    End Sub
End Class
