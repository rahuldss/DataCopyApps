Public Class frmDataCopy
    Dim fileSource As System.IO.FileInfo
    Dim fileSource4Thread As System.IO.FileInfo
    Dim fileDest As System.IO.FileInfo
    Dim lngfileSizeTotal As Double
    Dim lngfileSizecopied As Double
    Dim strFileDestNew As String = ""
    Dim strFileNew As String = ""
    Dim isMoving As Boolean = False

    Private Sub frmDataCopy_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'txtSource.Text = "d:\_builds"
        'txtDestination.Text = "E:\_Builds"
        txtSource.Text = "K:\Narender\Projects"
        txtDestination.Text = "D:\Narender\Projects"
        'txtSource.Text = "H:\_Backups\_Office\DDrive_Narender\Narender"
        'txtDestination.Text = "H:\_Backups\_Office\Narender"

        lblCPath.Text = "."
        lblDirName.Text = "."
        lblFileName.Text = "."
        lblSizeCopied.Text = "0"

        lngfileSizeTotal = 1
        lngfileSizecopied = 1

        '***GET SETTINGS***
        Try
            Dim strDBDetailsSplit() As String = SettingGetSet.GetSettings()
            txtSource.Text = strDBDetailsSplit(0)
            txtDestination.Text = strDBDetailsSplit(1)
        Catch ex As Exception
        End Try        
    End Sub

    Private Sub CmdSelectSource_Click(sender As System.Object, e As System.EventArgs) Handles CmdSelectSource.Click
        If Len(txtSource.Text) > 0 Then
            If System.IO.Directory.Exists(txtSource.Text) = True Then
                FBDialog1.SelectedPath = txtSource.Text
            Else
                FBDialog1.RootFolder = Environment.SpecialFolder.Desktop
            End If
        Else
            FBDialog1.RootFolder = Environment.SpecialFolder.Desktop
        End If

        FBDialog1.ShowDialog(Me)
        txtSource.Text = FBDialog1.SelectedPath.ToString
    End Sub

    Private Sub cmdSelectDest_Click(sender As System.Object, e As System.EventArgs) Handles cmdSelectDest.Click
        If Len(txtDestination.Text) > 0 Then
            If System.IO.Directory.Exists(txtDestination.Text) = True Then
                FBDialog1.SelectedPath = txtDestination.Text
            Else
                FBDialog1.RootFolder = Environment.SpecialFolder.Desktop
            End If
        Else
            FBDialog1.RootFolder = Environment.SpecialFolder.Desktop
        End If

        FBDialog1.ShowDialog(Me)
        txtDestination.Text = FBDialog1.SelectedPath.ToString
    End Sub

    Private Sub cmdCopy_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopy.Click
        Try
            SettingGetSet.SaveSettings(txtSource.Text, txtDestination.Text)
        Catch ex As Exception
        End Try

        If fnValidate() Then
            isMoving = False

            lblTime.Text = "Start at : " & DateTime.Now

            txtLogs.Text = ""
            txtLogsEx.Text = ""
            lngfileSizeTotal = 0
            lblSizeCopied.Text = 0

            cmdCopy.Enabled = False
            cmdMove.Enabled = False
            chkKeepFiles.Enabled = False
            chkShowLog.Enabled = False

            'CALCULATE SIZE
            lblCalculate.Text = "Calculating Size...(0)"
            '---
            Dim CalSizeThread As System.Threading.Thread
            CalSizeThread = New System.Threading.Thread(AddressOf prcCalcSizeByThread)
            CalSizeThread.Start()
            '---
            'Call prcCalculateDataSize(txtSource.Text, True)

            'COPY ALL FILES
            Call RecursiveCopyFiles(txtSource.Text, txtDestination.Text, True)

            cmdCopy.Enabled = True
            cmdMove.Enabled = True
            chkKeepFiles.Enabled = True
            chkShowLog.Enabled = True

            lblTime.Text = lblTime.Text & " - End at : " & DateTime.Now

            Call prcWriteLogs("DCLog", False)

            MsgBox("Done!")
        End If
    End Sub

    Private Sub cmdMove_Click(sender As System.Object, e As System.EventArgs) Handles cmdMove.Click
        Try
            SettingGetSet.SaveSettings(txtSource.Text, txtDestination.Text)
        Catch ex As Exception
        End Try

        If fnValidate() Then
            isMoving = True

            lblTime.Text = "Start at : " & DateTime.Now

            txtLogs.Text = ""
            txtLogsEx.Text = ""
            lngfileSizeTotal = 0
            lblSizeCopied.Text = 0

            cmdCopy.Enabled = False
            cmdMove.Enabled = False
            chkKeepFiles.Enabled = False
            chkShowLog.Enabled = False

            'CALCULATE SIZE
            lblCalculate.Text = "Calculating Size...(0)"
            '---
            Dim CalSizeThread As System.Threading.Thread
            CalSizeThread = New System.Threading.Thread(AddressOf prcCalcSizeByThread)
            CalSizeThread.Start()
            '---
            'Call prcCalculateDataSize(txtSource.Text, True)

            'MOVE ALL FILES
            Call RecursiveMoveFiles(txtSource.Text, txtDestination.Text, True)

            cmdCopy.Enabled = True
            cmdMove.Enabled = True
            chkKeepFiles.Enabled = True
            chkShowLog.Enabled = True

            lblTime.Text = lblTime.Text & " - End at : " & DateTime.Now

            ''strOutputFilePath = txtOutput.Text & "\" & CboFormat.SelectedItem.ToString & "_" & Format(Date.Now, "ddMMMyyyy_hhmmsstt") & ".txt"
            'Dim fileWrite As New FileWrite(Application.StartupPath & "\DCLogMove.txt")
            'fileWrite.WriteFile(lblTime.Text & vbCrLf)
            'fileWrite.WriteFile(txtLogs.Text)
            'fileWrite.CloseFile(chkShowLog.Checked)

            'fileWrite = New FileWrite(Application.StartupPath & "\DCLogExMove.txt")
            'fileWrite.WriteFile(lblTime.Text & vbCrLf)
            'fileWrite.WriteFile(txtLogsEx.Text)
            'fileWrite.CloseFile(chkShowLog.Checked)

            Call prcWriteLogs("DCLogMove", True)

            MsgBox("Done!")
        End If
    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        lblTime.Text = lblTime.Text & " - Aborted at : " & DateTime.Now
        If isMoving Then
            Call prcWriteLogs("DCLogMove", False)
        Else
            Call prcWriteLogs("DCLog", False)
        End If
        End
    End Sub

    Sub prcWriteLogs(strLogFileName As String, isMove As Boolean)
        Try
            'strOutputFilePath = txtOutput.Text & "\" & CboFormat.SelectedItem.ToString & "_" & Format(Date.Now, "ddMMMyyyy_hhmmsstt") & ".txt"
            Dim fileWrite As New FileWrite(Application.StartupPath & "\" & strLogFileName & Format(Date.Now, "ddMMMyyyy_hhmmsstt") & ".txt")
            fileWrite.WriteFile(lblTime.Text & vbCrLf)
            fileWrite.WriteFile(txtLogs.Text)
            fileWrite.CloseFile(chkShowLog.Checked)

            fileWrite = New FileWrite(Application.StartupPath & "\" & strLogFileName & Format(Date.Now, "ddMMMyyyy_hhmmsstt") & "Ex.txt")
            fileWrite.WriteFile(lblTime.Text & vbCrLf)
            fileWrite.WriteFile(txtLogsEx.Text)
            fileWrite.CloseFile(chkShowLog.Checked)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function fnValidate() As Boolean
        'CHECK SOURCE
        If System.IO.Directory.Exists(txtSource.Text) = False Then
            MsgBox("Please Check Source Path!", MsgBoxStyle.Critical)
            CmdSelectSource.Focus()
            Return False
        Else 'CHECK DESTINATION
            If System.IO.Directory.Exists(txtDestination.Text) = False Then
                MsgBox("Please Check Destination Path!", MsgBoxStyle.Critical)
                cmdSelectDest.Focus()
                Return False                
            End If
        End If
        Return True
    End Function

    Private Sub RecursiveCopyFiles(ByVal sourceDir As String, ByVal destDir As String, ByVal fRecursive As Boolean)
        Dim i As Integer
        Dim posSep As Integer
        Dim sDir As String
        Dim aDirs() As String
        Dim sFile As String
        Dim aFiles() As String
        Try
            ' Add trailing separators to the supplied paths if they don't exist.
            If Not sourceDir.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) Then
                sourceDir &= System.IO.Path.DirectorySeparatorChar
            End If

            If Not destDir.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) Then
                destDir &= System.IO.Path.DirectorySeparatorChar
            End If

            ' Recursive switch to continue drilling down into dir structure.
            If fRecursive Then
                ' Get a list of directories from the current parent.
                aDirs = System.IO.Directory.GetDirectories(sourceDir)

                '//PBExtract.Maximum = IIf(aDirs.GetUpperBound(0) > 0, aDirs.GetUpperBound(0), 100)

                For i = 0 To aDirs.GetUpperBound(0)
                    ' Get the position of the last separator in the current path.
                    posSep = aDirs(i).LastIndexOf("\")
                    ' Get the path of the source directory.
                    sDir = aDirs(i).Substring((posSep + 1), aDirs(i).Length - (posSep + 1))

                    lblCPath.Text = aDirs(i)
                    lblDirName.Text = sDir

                    ' Create the new directory in the destination directory.
                    System.IO.Directory.CreateDirectory(destDir + sDir)

                    ' //PBExtract.Value = i

                    ' Since we are in recursive mode, copy the children also
                    RecursiveCopyFiles(aDirs(i), (destDir + sDir), fRecursive)
                    'MsgBox("")
                Next
            End If
            ' Get the files from the current parent.
            aFiles = System.IO.Directory.GetFiles(sourceDir)

            ' Copy all files.
            For i = 0 To aFiles.GetUpperBound(0)
                ' Get the position of the trailing separator.
                posSep = aFiles(i).LastIndexOf("\")
                ' Get the full path of the source file.
                sFile = aFiles(i).Substring((posSep + 1), aFiles(i).Length - (posSep + 1))

                'lblCPath.Text = aFiles(i)
                lblFileName.Text = sFile

                'MsgBox("S File : " & aFiles(i) & vbCrLf & "D File : " & destDir + sFile)
                Try
                    fileSource = New System.IO.FileInfo(aFiles(i))
                    fileDest = New System.IO.FileInfo(destDir + sFile)
                Catch ex As Exception
                    txtLogsEx.AppendText("IO $ " & ex.Message & vbCrLf)
                End Try

                If fileDest.Exists Then
                    If fileSource.Name = fileDest.Name And fileSource.LastWriteTime = fileDest.LastWriteTime And fileSource.Length = fileDest.Length Then
                        'LEAVE THE FILE IF NAME,SIZE AND LAST WRITTEN TIME IS SAME...
                        txtLogs.AppendText("MATCHED $ " & fileSource.FullName & " $ " & fileDest.FullName & vbCrLf)

                        'TOTAL FILE SIZE COPIED/MOVED
                        lngfileSizecopied = lngfileSizecopied + fileSource.Length
                    Else
                        If chkKeepFiles.Checked Then
                            'COPY THE FILE AND KEEP EXISTING...
                            strFileNew = fnKeepFiles(destDir, fileDest.FullName, 1)
                            System.IO.File.Copy(aFiles(i), strFileNew, True)
                            txtLogs.AppendText("KEPT $ " & fileSource.FullName & " $ " & fileDest.FullName & vbCrLf)

                            'TOTAL FILE SIZE COPIED/MOVED
                            lngfileSizecopied = lngfileSizecopied + fileSource.Length
                        Else
                            If fileSource.Name = fileDest.Name And fileSource.LastWriteTime < fileDest.LastWriteTime Then
                                'LEAVE THE FILE IF NAME,SIZE IS SAME AND LAST WRITTEN TIME OF DESTINATION IS NEWER...
                                txtLogs.AppendText("LEFT_DESTINATION_NEWER $ " & fileSource.FullName & " $ " & fileDest.FullName & vbCrLf)

                                'TOTAL FILE SIZE COPIED/MOVED
                                lngfileSizecopied = lngfileSizecopied + fileSource.Length
                            Else
                                'COPY THE FILE AND REPLACE EXISTING...
                                System.IO.File.Copy(aFiles(i), destDir + sFile, True)
                                txtLogs.AppendText("REPLACED $ " & fileSource.FullName & " $ " & fileDest.FullName & vbCrLf)

                                'TOTAL FILE SIZE COPIED/MOVED
                                lngfileSizecopied = lngfileSizecopied + fileSource.Length
                            End If
                        End If
                    End If
                Else                    
                    'COPY THE FILE...
                    System.IO.File.Copy(aFiles(i), destDir + sFile, True)
                    txtLogs.AppendText("COPIED $ " & fileSource.FullName & vbCrLf)

                    'TOTAL FILE SIZE COPIED/MOVED
                    lngfileSizecopied = lngfileSizecopied + fileSource.Length
                End If

                'TOTAL FILE SIZE COPIED/MOVED
                lblSizeCopied.Text = lngfileSizecopied
                'TOTAL FILE SIZE REMAINING
                If lngfileSizeTotal > 0 Then
                    lblSizeRemaining.Text = "Remaining Size : " & (lngfileSizeTotal - lngfileSizecopied) & " - %age : " & (lngfileSizecopied * 100 / lngfileSizeTotal)
                End If

                fileSource = Nothing
                fileDest = Nothing

                System.Windows.Forms.Application.DoEvents()
                'MsgBox("")

                'CALCULATE TOTAL FILE SIZE...
                lblCalculate.Text = "Calculating Size...(" & lngfileSizeTotal & ")"

            Next i
        Catch ex As Exception
            txtLogsEx.AppendText(ex.Message & vbCrLf)
        End Try
    End Sub

    Private Sub RecursiveMoveFiles(ByVal sourceDir As String, ByVal destDir As String, ByVal fRecursive As Boolean)
        Dim i As Integer
        Dim posSep As Integer
        Dim sDir As String
        Dim aDirs() As String
        Dim sFile As String
        Dim aFiles() As String
        Try
            ' Add trailing separators to the supplied paths if they don't exist.
            If Not sourceDir.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) Then
                sourceDir &= System.IO.Path.DirectorySeparatorChar
            End If

            If Not destDir.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) Then
                destDir &= System.IO.Path.DirectorySeparatorChar
            End If

            ' Recursive switch to continue drilling down into dir structure.
            If fRecursive Then
                ' Get a list of directories from the current parent.
                aDirs = System.IO.Directory.GetDirectories(sourceDir)

                '//PBExtract.Maximum = IIf(aDirs.GetUpperBound(0) > 0, aDirs.GetUpperBound(0), 100)

                For i = 0 To aDirs.GetUpperBound(0)
                    ' Get the position of the last separator in the current path.
                    posSep = aDirs(i).LastIndexOf("\")
                    ' Get the path of the source directory.
                    sDir = aDirs(i).Substring((posSep + 1), aDirs(i).Length - (posSep + 1))

                    lblCPath.Text = aDirs(i)
                    lblDirName.Text = sDir

                    ' Create the new directory in the destination directory.
                    System.IO.Directory.CreateDirectory(destDir + sDir)

                    ' //PBExtract.Value = i

                    ' Since we are in recursive mode, Move the children also
                    RecursiveMoveFiles(aDirs(i), (destDir + sDir), fRecursive)
                    'MsgBox("")
                Next
            End If
            ' Get the files from the current parent.
            aFiles = System.IO.Directory.GetFiles(sourceDir)

            ' Move all files.
            For i = 0 To aFiles.GetUpperBound(0)
                ' Get the position of the trailing separator.
                posSep = aFiles(i).LastIndexOf("\")
                ' Get the full path of the source file.
                sFile = aFiles(i).Substring((posSep + 1), aFiles(i).Length - (posSep + 1))

                'lblCPath.Text = aFiles(i)
                lblFileName.Text = sFile

                'MsgBox("S File : " & aFiles(i) & vbCrLf & "D File : " & destDir + sFile)
                Try
                    fileSource = New System.IO.FileInfo(aFiles(i))
                    fileDest = New System.IO.FileInfo(destDir + sFile)
                    'access denied
                    'fileSource.
                Catch ex As Exception
                    'txtLogsEx.AppendText(ex.Message & vbCrLf)
                End Try
                Try
                    If fileDest.Exists Then
                        If fileSource.Name = fileDest.Name And fileSource.LastWriteTime = fileDest.LastWriteTime And fileSource.Length = fileDest.Length Then
                            
                            If chkKeepFiles.Checked Then
                                'TOTAL FILE SIZE COPIED/MOVED
                                lngfileSizecopied = lngfileSizecopied + fileSource.Length

                                'MOVE THE FILE AND KEEP EXISTING...
                                strFileNew = fnKeepFiles(destDir, fileDest.FullName, 1)
                                System.IO.File.Move(aFiles(i), strFileNew)
                                txtLogs.AppendText("KEPT $ " & fileSource.FullName & " $ " & fileDest.FullName & vbCrLf)
                            ElseIf chkDeleteMatched.Checked = True Then
                                System.IO.File.Delete(aFiles(i))
                                txtLogs.AppendText("DELETED $ " & fileSource.FullName & vbCrLf)
                            Else
                                'LEAVE THE FILE IF NAME,SIZE AND LAST WRITTEN TIME IS SAME...
                                txtLogs.AppendText("MATCHED $ " & fileSource.FullName & " $ " & fileDest.FullName & vbCrLf)
                            End If

                        Else
                            If chkKeepFiles.Checked Then
                                'TOTAL FILE SIZE COPIED/MOVED
                                lngfileSizecopied = lngfileSizecopied + fileSource.Length

                                'MOVE THE FILE AND KEEP EXISTING...
                                strFileNew = fnKeepFiles(destDir, fileDest.FullName, 1)
                                System.IO.File.Move(aFiles(i), strFileNew)
                                txtLogs.AppendText("KEPT $ " & fileSource.FullName & " $ " & fileDest.FullName & vbCrLf)
                            Else
                                'TOTAL FILE SIZE COPIED/MOVED
                                lngfileSizecopied = lngfileSizecopied + fileSource.Length
                                'MOVE THE FILE AND REPLACE(By Deleting) EXISTING...
                                'System.IO.File.Delete(destDir + sFile)
                                System.IO.File.Copy(aFiles(i), destDir + sFile, True)
                                txtLogs.AppendText("REPLACED $ " & fileSource.FullName & " $ " & fileDest.FullName & vbCrLf)
                            End If
                            End If
                        Else
                            'TOTAL FILE SIZE COPIED/MOVED
                            lngfileSizecopied = lngfileSizecopied + fileSource.Length

                            'Move THE FILE...
                            System.IO.File.Move(aFiles(i), destDir + sFile)
                            txtLogs.AppendText("COPIED $ " & fileSource.FullName & vbCrLf)
                        End If
                Catch exFile As Exception
                    txtLogsEx.AppendText(exFile.Message & vbCrLf)
                End Try
                'TOTAL FILE SIZE COPIED/MOVED
                lblSizeCopied.Text = lngfileSizecopied
                'TOTAL FILE SIZE REMAINING
                If lngfileSizeTotal > 0 Then
                    lblSizeRemaining.Text = "Remaining Size : " & (lngfileSizeTotal - lngfileSizecopied) & " - %age : " & (lngfileSizecopied * 100 / lngfileSizeTotal)
                End If

                fileSource = Nothing
                fileDest = Nothing

                System.Windows.Forms.Application.DoEvents()
                'MsgBox("")
            Next i
        Catch ex As Exception
            txtLogsEx.AppendText(ex.Message & vbCrLf)
        End Try
    End Sub

    Function fnKeepFiles(strDest As String, strFileDest As String, intFileCopyNo As Int16) As String
        Try
            If IO.File.Exists(strFileDest) Then
                strFileDestNew = strDest & System.IO.Path.GetFileNameWithoutExtension(strFileDest) & "_Copy(" & intFileCopyNo & ")" & System.IO.Path.GetExtension(strFileDest)
                fnKeepFiles(strDest, strFileDestNew, intFileCopyNo + 1)
            End If
        Catch ex As Exception
            txtLogsEx.AppendText(ex.Message & vbCrLf)
        End Try
        Return strFileDestNew
    End Function

    Private Sub prcCalculateDataSize(ByVal sourceDir As String, ByVal fRecursive As Boolean)
        'MsgBox("prcCalculateDataSize")
        Dim i As Integer
        Dim posSep As Integer
        Dim sDir As String
        Dim aDirs() As String
        Dim sFile As String
        Dim aFiles() As String
        Try
            ' Add trailing separators to the supplied paths if they don't exist.
            If Not sourceDir.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) Then
                sourceDir &= System.IO.Path.DirectorySeparatorChar
            End If

            ' Recursive switch to continue drilling down into dir structure.
            If fRecursive Then
                ' Get a list of directories from the current parent.
                aDirs = System.IO.Directory.GetDirectories(sourceDir)

                '//PBExtract.Maximum = IIf(aDirs.GetUpperBound(0) > 0, aDirs.GetUpperBound(0), 100)

                For i = 0 To aDirs.GetUpperBound(0)
                    ' Get the position of the last separator in the current path.
                    posSep = aDirs(i).LastIndexOf("\")
                    ' Get the path of the source directory.
                    sDir = aDirs(i).Substring((posSep + 1), aDirs(i).Length - (posSep + 1))

                    lblCPath.Text = aDirs(i)
                    lblDirName.Text = sDir

                    ' //PBExtract.Value = i

                    ' Since we are in recursive mode, copy the children also
                    prcCalculateDataSize(aDirs(i), fRecursive)
                    'MsgBox("")
                Next
            End If
            ' Get the files from the current parent.
            aFiles = System.IO.Directory.GetFiles(sourceDir)

            ' Copy all files.
            For i = 0 To aFiles.GetUpperBound(0)
                ' Get the position of the trailing separator.
                posSep = aFiles(i).LastIndexOf("\")
                ' Get the full path of the source file.
                sFile = aFiles(i).Substring((posSep + 1), aFiles(i).Length - (posSep + 1))

                'lblCPath.Text = aFiles(i)
                lblFileName.Text = sFile

                'MsgBox("S File : " & aFiles(i) & vbCrLf & "D File : " & destDir + sFile)
                Try
                    fileSource = New System.IO.FileInfo(aFiles(i))
                    lngfileSizeTotal = lngfileSizeTotal + fileSource.Length
                Catch ex As Exception
                    txtLogsEx.AppendText(ex.Message & vbCrLf)
                End Try

                'CALCULATE TOTAL FILE SIZE...
                lblCalculate.Text = "Calculating Size...(" & lngfileSizeTotal & ")"

                fileSource = Nothing

                System.Windows.Forms.Application.DoEvents()
                'MsgBox("")
            Next i
        Catch ex As Exception
            txtLogsEx.AppendText(ex.Message & vbCrLf)
        End Try
    End Sub

    Sub prcCalcSizeByThread()
        'MsgBox("in thread")
        Call prcCalculateDataSizeByThread(txtSource.Text, True)
    End Sub

    Private Sub prcCalculateDataSizeByThread(ByVal sourceDir As String, ByVal fRecursive As Boolean)
        On Error Resume Next
        Dim i As Integer
        Dim posSep As Integer
        Dim sDir As String
        Dim aDirs() As String
        Dim sFile As String
        Dim aFiles() As String
        'MsgBox("in thread Calculating...")

        ' Add trailing separators to the supplied paths if they don't exist.
        If Not sourceDir.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()) Then
            sourceDir &= System.IO.Path.DirectorySeparatorChar
        End If

        ' Recursive switch to continue drilling down into dir structure.
        If fRecursive Then
            ' Get a list of directories from the current parent.
            aDirs = System.IO.Directory.GetDirectories(sourceDir)

            '//PBExtract.Maximum = IIf(aDirs.GetUpperBound(0) > 0, aDirs.GetUpperBound(0), 100)

            For i = 0 To aDirs.GetUpperBound(0)
                ' Get the position of the last separator in the current path.
                posSep = aDirs(i).LastIndexOf("\")
                ' Get the path of the source directory.
                sDir = aDirs(i).Substring((posSep + 1), aDirs(i).Length - (posSep + 1))

                'lblCPath.Text = aDirs(i)
                'lblDirName.Text = sDir

                ' //PBExtract.Value = i

                ' Since we are in recursive mode, copy the children also
                prcCalculateDataSizeByThread(aDirs(i), fRecursive)
                'MsgBox("")
            Next
        End If
        ' Get the files from the current parent.
        aFiles = System.IO.Directory.GetFiles(sourceDir)

        ' Copy all files.
        For i = 0 To aFiles.GetUpperBound(0)
            ' Get the position of the trailing separator.
            posSep = aFiles(i).LastIndexOf("\")
            ' Get the full path of the source file.
            sFile = aFiles(i).Substring((posSep + 1), aFiles(i).Length - (posSep + 1))

            'lblCPath.Text = aFiles(i)
            'lblFileName.Text = sFile

            'MsgBox("S File : " & aFiles(i) & vbCrLf & "D File : " & destDir + sFile)
            'Try
            fileSource4Thread = New System.IO.FileInfo(aFiles(i))
            lngfileSizeTotal = lngfileSizeTotal + fileSource4Thread.Length
            'Catch ex As Exception
            '    'txtLogsEx.AppendText(ex.Message & vbCrLf)
            'End Try

            ''CALCULATE TOTAL FILE SIZE...
            'lblCalculate.Text = "Calculating Size...(" & lngfileSizeTotal & ")"

            fileSource4Thread = Nothing

            System.Windows.Forms.Application.DoEvents()
            'MsgBox(lngfileSizeTotal)
        Next i
        If Err.Description.Length > 0 Then
            MsgBox(Err.Description)
            txtLogsEx.AppendText(Err.Description & vbCrLf)
        End If
    End Sub
End Class