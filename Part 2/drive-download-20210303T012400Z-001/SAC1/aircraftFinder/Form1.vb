Public Class Form1
    Dim RowList As List(Of String)
    Dim Index As Integer
    Dim Score As Integer
    Dim searchName As String
    '----------------------------------------------------------------------
    'FR_Load
    '   Loads the text file into the File Reader And uses it To make a list 
    '   named RowList containing the different lists
    '----------------------------------------------------------------------
    Private Sub FR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim err As String = ""
        RowList = New List(Of String)() 'Initialises RowList as a New List
        If FR.Open("C:\Users\2359523\Downloads\examList.txt", err) Then
            FR.NextRow() 'Skips the first row containing the "Student,Subject,Score"
            RowList.Add(FR.Row) 'It then adds the row after the "Student,Subject,Score" row 
            While Not FR.EOF 'A loop that runs when it's not the end of file
                FR.NextRow() 'Goes to the next row
                RowList.Add(FR.Row) 'Row gets added to the RowList list
            End While
            FR.Close() 'Closes the FR file
            Index = 0 'Initialises the index to 0 indicating the first Row
            ShowField() 'Runs the ShowField routine
            OutcomeField() 'Runs the OutcomeField routine
        End If
    End Sub
    '----------------------------------------------------------------------
    'ShowField
    '   This sub routine splits the RowList to different rows and displays
    '   the Row to it's text box
    '----------------------------------------------------------------------
    Private Sub ShowField()
        Dim Column As String()
        Dim sepChar As Char = ","
        Column = RowList(Index).Split(sepChar) 'splits the RowList by , and sets it to different Columns. The Row is
        'on is dependent on the Index
        txtStudent.Text = Column(0) 'Sets the txtStudent box to the first column
        txtSubject.Text = Column(1) 'Sets the txtSubject box to the first column
        txtScore.Text = Column(2) 'Sets the txtScore box to the first column
        Score = txtScore.Text 'Makes the score equal the value of txtScore text box
    End Sub
    '----------------------------------------------------------------------
    'OutcomeField
    '   This sub routine gets the Score and outputs Pass or Fail in the
    '   txtOutcome message box
    '----------------------------------------------------------------------
    Private Sub OutcomeField()
        If Score >= 50 Then
            txtOutcome.Text = "Pass" 'If the score is more or equal to 50 txtOutcome will display Pass in the txtOutcome
        Else
            txtOutcome.Text = "Fail" 'If the score is less than 50 txtOutcome will display Fail in the txtOutcome
        End If
    End Sub
    '-------------------------------------------------------------
    'NextButton
    '   Adds 1 to index if Index is less than how much RowList is
    '-------------------------------------------------------------
    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles nextButton.Click
        If Index < RowList.Count - 1 Then 'If the Index is less than the RowList, this will run
            Index += 1 'Adds 1 to the index
            ShowField()
            OutcomeField()
        End If
    End Sub
    '-------------------------------------------------------------
    'Back Button
    '   Subtracts 1 to index if Index more than 0
    '-------------------------------------------------------------
    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles backButton.Click
        If Index > 0 Then 'If the Index is more than the 0, this will run
            Index -= 1 'Subtracts 1 to the index
            ShowField()
            OutcomeField()
        End If
    End Sub
    '----------------------------------------------------------------------
    'BtnValidate_Click
    '   When btnValidate is clicked it shows a MessageBox whether or not
    '   the score is Valid or Not Valid depending on it's value
    '----------------------------------------------------------------------

    Private Sub BtnValidate_Click(sender As Object, e As EventArgs) Handles btnValidate.Click
        If Score >= 0 And Score <= 100 Then 'Score is within the 0 to 100 range
            MessageBox.Show("Valid") 'If the Score is within 0 to 100 it will display a message box showing Valid
        Else
            MessageBox.Show("Invalid Score") 'If it's not within the range between 0 to 100 it will display a message box showing Invalid Score
        End If
    End Sub
    ' ------------------------------------------------------------------------------------------------------------------
    ' When a string is typed into the search bar it stores it as a searchPlane variable, to be used in the search button
    ' ------------------------------------------------------------------------------------------------------------------
    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        searchName = LCase(txtSearch.Text) 'Puts whatever the value the user types in the txtSearch 
        'into searchName And makes it lowercase to make it Not case sensitive
    End Sub
    ' ------------------------------------------------------------------------------------------------------------
    ' This gets the searchName then puts it into the funcSearch, function when search is clicked
    ' ------------------------------------------------------------------------------------------------------------
    Private Sub FindButton_Click(sender As Object, e As EventArgs) Handles findButton.Click
        Dim a As Integer = RowList.Count
        If searchName <> "" Then
            Index = funcSearch(searchName, a) 'if the search has this value, it will make the index to whatever row funcSearch found the name                   
            If Index = -1 Then                      'if the search doesn't have this value, it will display a box saying "This isn't found"                     
                MessageBox.Show("This isn't found")
                Index = 0
            End If
            ShowField()
        End If
        If searchName = "" Then                    'if nothing is shown typed up onto the search, it will display a box saying "Please enter a name" 

            MessageBox.Show("Please enter a name")
        End If
    End Sub
    ' ------------------------------------------------------------------------------------------------------------
    ' This recieves the value of the searchName and turns it into a targ
    '   It then makes a for loop starting for 0 to the amount of rows there are
    '   If a targ is found within the row in the data it then makes the boolTest to true
    '   If true it returns I which is then put into the index
    '   If it isn't true it makes the index equal -1
    ' ------------------------------------------------------------------------------------------------------------
    Function funcSearch(targ As String, a As Integer) As Integer
        Dim i As Integer
        Dim Row As String()
        Dim sepChar As Char = ","c
        Dim studentName As String
        Dim boolTest As Boolean
        For i = 0 To RowList.Count - 1              'the loops starts from 0 to however amount of rows there are
            Row = RowList(i).Split(sepChar)         'It then makes the row whatever the loop number is
            studentName = LCase(Row(0))              'it then assigns studentName to whatever the name within the row is and makes it lowercase
            boolTest = studentName.Contains(targ)     'it then tests whether or not the searchName has the targ
            If boolTest = True Then                 'If it's true it returns i which is the Index
                Return i
            End If
        Next
        Return -1                                   'if it's not it returns -1
    End Function
End Class
