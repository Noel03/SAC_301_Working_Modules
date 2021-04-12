Public Class Form1
    Dim RowList As List(Of String)
    Dim Index As Integer
    Dim Score As Integer
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
End Class
