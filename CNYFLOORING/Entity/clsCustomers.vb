' Class Name: clsCustomers
' Purpose: A container to hold all attributes and methods in a class
' Change log: B.Grant 6/25/2018

Public Class clsCustomers

    ' Private attributes

    Private intAccountID As Integer
    Private strFirstName As String
    Private strLastName As String
    Private strAddress As String
    Private strCity As String
    Private strState As String
    Private strPhoneNumber As String
    Private sDate As Date
    Private strJobDescription As String

    ' Property methods - getters and setters

    Public Property AccountID() As Integer
        Get
            Return intAccountID
        End Get
        ' The automatic number will begin at 0 value
        Set(value As Integer)
            If value > 0 Then
                intAccountID = value
            Else
                intAccountID = -1
            End If
        End Set

    End Property

    Public Property FirstName() As String
        Get
            Return strFirstName

        End Get

        Set(value As String)
            If value <> String.Empty Then
                strFirstName = value
            Else
                strFirstName = "Null String"
            End If
        End Set

    End Property

    Public Property LastName() As String
        Get
            Return strLastName

        End Get

        Set(value As String)
            If value <> String.Empty Then
                strLastName = value
            Else
                strLastName = "Null String"
            End If
        End Set

    End Property

    Public Property Address() As String
        Get
            Return strAddress

        End Get

        Set(value As String)
            If value <> String.Empty Then
                strAddress = value
            Else
                strAddress = "Null String"
            End If
        End Set

    End Property


    Public Property City() As String
        Get
            Return strCity

        End Get

        Set(value As String)
            If value <> String.Empty Then
                strCity = value
            Else
                strCity = "Null String"
            End If
        End Set

    End Property

    Public Property State() As String
        Get
            Return strState

        End Get

        Set(value As String)
            If value <> String.Empty Then
                strState = value
            Else
                strState = "Null String"
            End If
        End Set

    End Property


    Public Property PhoneNumber() As String
        Get
            Return strPhoneNumber

        End Get

        Set(value As String)
            If value <> String.Empty Then
                strPhoneNumber = value
            Else
                strPhoneNumber = "Null String"
            End If
        End Set

    End Property

    Public Property DDate() As Date
        Get
            Return sDate
        End Get
        Set(value As Date)
            If IsDate(value) = True Then
                sDate = value
            Else
                sDate = #1/1/2017#
            End If
        End Set
    End Property

    Public Property JobDescription() As String
        Get
            Return strJobDescription

        End Get

        Set(value As String)
            If value <> String.Empty Then
                strJobDescription = value
            Else
                strJobDescription = "Null String"
            End If
        End Set

    End Property

    'CONSTRUCTORS

    'Default Constructor

    Public Sub New()
        intAccountID = 0
        strFirstName = ""
        strLastName = ""
        strAddress = ""
        strCity = ""
        strState = ""
        strPhoneNumber = ""
        sDate = #1/1/9999#
        strJobDescription = ""
    End Sub

    ' parameter based constructor
    Public Sub New(ByVal aAccountID As Integer, ByVal aFirstName As String, ByVal aLastName As String,
                   ByVal aAddress As String, ByVal aCity As String, ByVal aState As String, ByVal aPhoneNumber As String,
                   ByVal aDate As Date, ByVal aJobDescription As String)
        intAccountID = aAccountID
        strFirstName = aFirstName
        strLastName = aLastName
        strAddress = aAddress
        strCity = aCity
        strState = aState
        strPhoneNumber = aPhoneNumber
        sDate = aDate
        strJobDescription = aJobDescription

    End Sub

    ' Class Methods

    ' Method Name:  classInfo
    ' Purpose:      To obtain a record from the database for this entity
    ' Parameter:    None
    ' Return:       A record of this entity - String

    Public Function classInfo() As String
        Return "AccountID = " & AccountID() & vbCr & "FirstName = " & FirstName() & vbCr & "LastName = " & LastName() & vbCr _
            & "Address = " & Address() & vbCr & "City = " & City() & vbCr & "State = " & State() & vbCr & "PhoneNumber = " & PhoneNumber() & vbCr _
            & "Date= " & DDate() & vbCr & "JobDescription= " & JobDescription() & vbCr
    End Function

    ' Method Name:  GetRecords
    ' Purpose:      To obtain all the records from the database for this entity
    ' Parameter:    None
    ' Return:       All the records for this entity - Dataset
    ' Change Log:   10/17/16 J. Loverme

    Public Shared Function GetRecords() As DataSet
        Try
            Return clsCustomersDA.GetRecords()
        Catch ex As Exception
            MessageBox.Show("Error occurred in Class: clsCustomers. Method: GetRecords(). Error: " _
                            & ex.Message)
            Return Nothing
        End Try
    End Function

    ' Method Name:  DeleteRecord
    ' Purpose:      To delete a record from the database for this entity
    ' Parameter:    Primary Key - String
    ' Return:       Result (number of rows affected) - Integer
    ' Change Log:   10/17/16 J. Loverme
    Public Shared Function DeleteRecord(ByVal aPrimaryKey As String) As Integer
        Try
            Return clsCustomersDA.DeleteRecord(aPrimaryKey)
        Catch ex As Exception
            MessageBox.Show("Error occurred in Class: clsCustomers. Method: DeleteRecord(String). Error: " _
                            & ex.Message)
            Return -9
        End Try
    End Function

    ' Method Name:  AddRecord
    ' Purpose:      To add a record from the database for this entity
    ' Parameter:    Object (aEvent) - clsEvents
    ' Return:       Result (number of rows affected) - Integer
    ' Change Log:   10/17/16 J. Loverme
    Public Shared Function AddRecord(ByVal aEvent As clsCustomers) As Integer
        Try
            Return clsCustomersDA.AddRecord(aEvent)
        Catch ex As Exception
            MessageBox.Show("Error occurred in Class: clsCustomers. Method: AddRecord(Object). Error: " _
                            & ex.Message)
            Return -9
        End Try
    End Function

    ' Method Name:  UpdateRecord
    ' Purpose:      To update a record from the database for this entity
    ' Parameter:    Object (aEvent) - clsEvent
    ' Return:       Result (number of rows affected) - Integer
    ' Change Log:   10/17/16 J. Loverme
    Public Shared Function UpdateRecord(ByVal aEvent As clsCustomers) As Integer
        Try
            Return clsCustomersDA.UpdateRecord(aEvent)
        Catch ex As Exception
            MessageBox.Show("Error occurred in Class: clsCustomers. Method: UpdateRecord(Object). Error: " _
                            & ex.Message)
            Return -9
        End Try
    End Function

End Class
