Imports System.IO
Module FR
    ' --------------------------------------------------------------
    ' Provides CSV File reader and management
    '    This class reads a text file row by row
    '    If rows contain comma delimited field values then 
    '    the row can returned as an array of field values 
    ' --------------------------------------------------------------
    Public Row As String        ' current row value 

    Dim SR As StreamReader  ' underlying .net stream reader 

    ' --------------------------------------------------------------
    ' File Open 
    '   Throws error if file does not exist
    ' --------------------------------------------------------------
    Public Function Open(FileSpec As String, ByRef ErrMsg As String) As Boolean

        Dim fi As FileInfo = New FileInfo(FileSpec)

        If fi.Exists Then
            SR = System.IO.File.OpenText(FileSpec)
            NextRow()
            ErrMsg = ""
        Else
            ErrMsg = "File does not exist "
            Return False
        End If
        Return True
    End Function

    ' --------------------------------------------------------------
    ' Delete File - physical deletion of the disk file
    ' --------------------------------------------------------------
    Public Sub DeleteFile(FileSpec As String)

        Dim fi As FileInfo = New FileInfo(FileSpec)

        If fi.Exists Then
            Close()
            fi.Delete()
        End If
    End Sub

    ' --------------------------------------------------------------
    ' File Close
    ' --------------------------------------------------------------
    Public Sub Close()

        Try
            SR.Close()
            SR.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    ' --------------------------------------------------------------
    ' NextRow - reads one row of the file stream if not at eof
    ' --------------------------------------------------------------
    Public Function NextRow() As Boolean

        If Not SR.EndOfStream Then
            Row = SR.ReadLine()
            Return True
        End If
        Return False
    End Function

    ' --------------------------------------------------------------
    ' Returns the End of File condition
    ' --------------------------------------------------------------
    Public Function EOF() As Boolean
        Return SR.EndOfStream
    End Function

End Module
