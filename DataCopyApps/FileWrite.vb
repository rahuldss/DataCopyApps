Public Class FileWrite
    Private strOutputFilePath As String
    Private xWrite As IO.StreamWriter
    Private xFile As IO.File

    'strOutputFilePath = txtOutput.Text & "\" & CboFormat.SelectedItem.ToString & "_" & Format(Date.Now, "ddMMMyyyy_hhmmsstt") & ".txt"
    Public Sub New(strFullFileName As String)
        strOutputFilePath = strFullFileName
        xWrite = xFile.CreateText(strOutputFilePath)
    End Sub

    Public Sub WriteFile(ByVal Str As String)
        xWrite.Write(Str)
    End Sub

    Public Sub CloseFile(open As Boolean)
        xWrite.Close()
        xFile = Nothing
        System.Windows.Forms.Application.DoEvents()
        If open Then
            Shell("Notepad.exe " & strOutputFilePath, AppWinStyle.MaximizedFocus)
        End If
    End Sub

    ''' <summary>
    ''' TO READ A FILE
    ''' </summary>
    ''' <param name="Str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ReadFile(ByVal Str As String) As String
        Try
            Return xFile.ReadAllText(Str)
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class


'*******START - CLASS FOR WRITING TEXT FILES**************************
''' <summary>
''' CLASS TO HANDEL TEXT FILE OPERATIONS LIKE - OPEN,CLOSE AND WRITE
''' </summary>
''' <remarks></remarks>
Public Class clsFileHandling
    Shared xWrite As System.IO.StreamWriter
    Shared xFile As System.IO.File
    Shared strOutputFilePath As String

    ''' <summary>
    ''' TO OPEN A FILE TO WRITE USING WRITEFILE FUNCTION
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub OpenFile(ByVal strFile As String)
        strOutputFilePath = strFile
        xWrite = xFile.CreateText(strOutputFilePath)
    End Sub

    ''' <summary>
    ''' TO WRITE A FILE. AFTER WRITING THE FILE USE CLOSEFILE!
    ''' </summary>
    ''' <param name="Str"></param>
    ''' <remarks></remarks>
    Public Shared Sub WriteFile(ByVal Str As String)
        xWrite.WriteLine(Str)
    End Sub

    ''' <summary>
    ''' TO CLOSE THE FILE OPENED BY OPENFILE FUNCTION
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared Sub CloseFile(Optional ByVal RunFile As Boolean = False)
        xWrite.Close()
        xFile = Nothing
        System.Windows.Forms.Application.DoEvents()
        If RunFile Then
            Shell("Notepad.exe " & strOutputFilePath, AppWinStyle.MaximizedFocus)
        End If
    End Sub

    ''' <summary>
    ''' TO READ A FILE
    ''' </summary>
    ''' <param name="Str"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ReadFile(ByVal Str As String) As String
        Try
            Return xFile.ReadAllText(Str)
        Catch ex As Exception
            Return ""
        End Try
    End Function
End Class
'*******START - CLASS FOR WRITING TEXT FILES**************************


Public Class SettingGetSet
    Public Shared Sub SaveSettings(ByVal Source As String, ByVal Dest As String)
        Try
            clsFileHandling.OpenFile("DBSettings.txt")
            clsFileHandling.WriteFile(Source & "~" & Dest)
            clsFileHandling.CloseFile(False)
        Catch ex As Exception
            'MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod.ToString())
        End Try
    End Sub
    Public Shared Function GetSettings(Optional ByVal isSource As Boolean = False) As String()
        Dim strDBDetails As String = ""
        Dim strDBDetailsSplit() As String = {""}
        Try            
            strDBDetails = clsFileHandling.ReadFile("DBSettings.txt")

            strDBDetails = strDBDetails.Replace(Chr(10), "").Replace(Chr(13), "")
            strDBDetailsSplit = strDBDetails.Split("~")
        Catch ex As Exception
            'MyCLS.clsHandleException.HandleEx(ex, System.Reflection.MethodBase.GetCurrentMethod.ToString())
        End Try
        Return strDBDetailsSplit
    End Function
End Class