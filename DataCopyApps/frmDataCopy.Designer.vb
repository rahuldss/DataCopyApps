<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDataCopy
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblSizeCopied = New System.Windows.Forms.Label()
        Me.label7 = New System.Windows.Forms.Label()
        Me.cmdMove = New System.Windows.Forms.Button()
        Me.cmdCopy = New System.Windows.Forms.Button()
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.cmdSelectDest = New System.Windows.Forms.Button()
        Me.lblCPath = New System.Windows.Forms.Label()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.label1 = New System.Windows.Forms.Label()
        Me.CmdSelectSource = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblFileName = New System.Windows.Forms.Label()
        Me.lblDirName = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.GBPaths = New System.Windows.Forms.GroupBox()
        Me.chkKeepFiles = New System.Windows.Forms.CheckBox()
        Me.FBDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtLogsEx = New System.Windows.Forms.TextBox()
        Me.lblCalculate = New System.Windows.Forms.Label()
        Me.lblSizeRemaining = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.chkShowLog = New System.Windows.Forms.CheckBox()
        Me.txtLogs = New System.Windows.Forms.TextBox()
        Me.chkDeleteMatched = New System.Windows.Forms.CheckBox()
        Me.groupBox1.SuspendLayout()
        Me.GBPaths.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSizeCopied
        '
        Me.lblSizeCopied.AutoSize = True
        Me.lblSizeCopied.Location = New System.Drawing.Point(132, 247)
        Me.lblSizeCopied.Name = "lblSizeCopied"
        Me.lblSizeCopied.Size = New System.Drawing.Size(0, 13)
        Me.lblSizeCopied.TabIndex = 40
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(17, 247)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(110, 13)
        Me.label7.TabIndex = 39
        Me.label7.Text = "Size Copied/Moved : "
        '
        'cmdMove
        '
        Me.cmdMove.Location = New System.Drawing.Point(268, 347)
        Me.cmdMove.Name = "cmdMove"
        Me.cmdMove.Size = New System.Drawing.Size(93, 28)
        Me.cmdMove.TabIndex = 38
        Me.cmdMove.Text = "&Move"
        Me.cmdMove.UseVisualStyleBackColor = True
        '
        'cmdCopy
        '
        Me.cmdCopy.Location = New System.Drawing.Point(171, 347)
        Me.cmdCopy.Name = "cmdCopy"
        Me.cmdCopy.Size = New System.Drawing.Size(93, 28)
        Me.cmdCopy.TabIndex = 37
        Me.cmdCopy.Text = "&Copy"
        Me.cmdCopy.UseVisualStyleBackColor = True
        '
        'txtDestination
        '
        Me.txtDestination.Location = New System.Drawing.Point(88, 19)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(419, 20)
        Me.txtDestination.TabIndex = 4
        '
        'cmdSelectDest
        '
        Me.cmdSelectDest.Location = New System.Drawing.Point(513, 19)
        Me.cmdSelectDest.Name = "cmdSelectDest"
        Me.cmdSelectDest.Size = New System.Drawing.Size(28, 19)
        Me.cmdSelectDest.TabIndex = 5
        Me.cmdSelectDest.Text = "..."
        Me.cmdSelectDest.UseVisualStyleBackColor = True
        '
        'lblCPath
        '
        Me.lblCPath.Location = New System.Drawing.Point(97, 122)
        Me.lblCPath.Name = "lblCPath"
        Me.lblCPath.Size = New System.Drawing.Size(462, 50)
        Me.lblCPath.TabIndex = 36
        Me.lblCPath.Text = "..."
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.txtDestination)
        Me.groupBox1.Controls.Add(Me.cmdSelectDest)
        Me.groupBox1.Location = New System.Drawing.Point(12, 62)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(547, 44)
        Me.groupBox1.TabIndex = 30
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Select Destination Paths..."
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(5, 19)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(67, 13)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Dest Folder :"
        '
        'CmdSelectSource
        '
        Me.CmdSelectSource.Location = New System.Drawing.Point(513, 19)
        Me.CmdSelectSource.Name = "CmdSelectSource"
        Me.CmdSelectSource.Size = New System.Drawing.Size(28, 19)
        Me.CmdSelectSource.TabIndex = 5
        Me.CmdSelectSource.Text = "..."
        Me.CmdSelectSource.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 122)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Current Path : "
        '
        'lblFileName
        '
        Me.lblFileName.AutoSize = True
        Me.lblFileName.Location = New System.Drawing.Point(113, 203)
        Me.lblFileName.Name = "lblFileName"
        Me.lblFileName.Size = New System.Drawing.Size(0, 13)
        Me.lblFileName.TabIndex = 34
        '
        'lblDirName
        '
        Me.lblDirName.AutoSize = True
        Me.lblDirName.Location = New System.Drawing.Point(116, 177)
        Me.lblDirName.Name = "lblDirName"
        Me.lblDirName.Size = New System.Drawing.Size(0, 13)
        Me.lblDirName.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Current File : "
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(17, 177)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(95, 13)
        Me.label5.TabIndex = 31
        Me.label5.Text = "Current Directory : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Source Folder :"
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(88, 19)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(419, 20)
        Me.txtSource.TabIndex = 4
        '
        'GBPaths
        '
        Me.GBPaths.Controls.Add(Me.Label2)
        Me.GBPaths.Controls.Add(Me.txtSource)
        Me.GBPaths.Controls.Add(Me.CmdSelectSource)
        Me.GBPaths.Location = New System.Drawing.Point(12, 12)
        Me.GBPaths.Name = "GBPaths"
        Me.GBPaths.Size = New System.Drawing.Size(547, 44)
        Me.GBPaths.TabIndex = 29
        Me.GBPaths.TabStop = False
        Me.GBPaths.Text = "Select Source Paths..."
        '
        'chkKeepFiles
        '
        Me.chkKeepFiles.AutoSize = True
        Me.chkKeepFiles.Checked = True
        Me.chkKeepFiles.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkKeepFiles.Location = New System.Drawing.Point(35, 354)
        Me.chkKeepFiles.Name = "chkKeepFiles"
        Me.chkKeepFiles.Size = New System.Drawing.Size(130, 17)
        Me.chkKeepFiles.TabIndex = 41
        Me.chkKeepFiles.Text = "Keep Matched Items?"
        Me.chkKeepFiles.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(365, 347)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(93, 28)
        Me.cmdExit.TabIndex = 42
        Me.cmdExit.Text = "E&xit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtLogsEx)
        Me.GroupBox2.Location = New System.Drawing.Point(565, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(348, 363)
        Me.GroupBox2.TabIndex = 43
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Logs"
        '
        'txtLogsEx
        '
        Me.txtLogsEx.BackColor = System.Drawing.Color.White
        Me.txtLogsEx.Location = New System.Drawing.Point(11, 16)
        Me.txtLogsEx.Multiline = True
        Me.txtLogsEx.Name = "txtLogsEx"
        Me.txtLogsEx.ReadOnly = True
        Me.txtLogsEx.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLogsEx.Size = New System.Drawing.Size(327, 341)
        Me.txtLogsEx.TabIndex = 0
        Me.txtLogsEx.WordWrap = False
        '
        'lblCalculate
        '
        Me.lblCalculate.AutoSize = True
        Me.lblCalculate.Location = New System.Drawing.Point(18, 267)
        Me.lblCalculate.Name = "lblCalculate"
        Me.lblCalculate.Size = New System.Drawing.Size(10, 13)
        Me.lblCalculate.TabIndex = 44
        Me.lblCalculate.Text = "."
        '
        'lblSizeRemaining
        '
        Me.lblSizeRemaining.AutoSize = True
        Me.lblSizeRemaining.Location = New System.Drawing.Point(18, 288)
        Me.lblSizeRemaining.Name = "lblSizeRemaining"
        Me.lblSizeRemaining.Size = New System.Drawing.Size(10, 13)
        Me.lblSizeRemaining.TabIndex = 45
        Me.lblSizeRemaining.Text = "."
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(17, 311)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(10, 13)
        Me.lblTime.TabIndex = 46
        Me.lblTime.Text = "."
        '
        'chkShowLog
        '
        Me.chkShowLog.AutoSize = True
        Me.chkShowLog.Checked = True
        Me.chkShowLog.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowLog.Location = New System.Drawing.Point(464, 354)
        Me.chkShowLog.Name = "chkShowLog"
        Me.chkShowLog.Size = New System.Drawing.Size(80, 17)
        Me.chkShowLog.TabIndex = 47
        Me.chkShowLog.Text = "Show Log?"
        Me.chkShowLog.UseVisualStyleBackColor = True
        '
        'txtLogs
        '
        Me.txtLogs.BackColor = System.Drawing.Color.White
        Me.txtLogs.Location = New System.Drawing.Point(12, 378)
        Me.txtLogs.Multiline = True
        Me.txtLogs.Name = "txtLogs"
        Me.txtLogs.ReadOnly = True
        Me.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtLogs.Size = New System.Drawing.Size(901, 176)
        Me.txtLogs.TabIndex = 48
        Me.txtLogs.WordWrap = False
        '
        'chkDeleteMatched
        '
        Me.chkDeleteMatched.AutoSize = True
        Me.chkDeleteMatched.Location = New System.Drawing.Point(35, 331)
        Me.chkDeleteMatched.Name = "chkDeleteMatched"
        Me.chkDeleteMatched.Size = New System.Drawing.Size(223, 17)
        Me.chkDeleteMatched.TabIndex = 49
        Me.chkDeleteMatched.Text = "Delete Fully Matched Items From Source?"
        Me.chkDeleteMatched.UseVisualStyleBackColor = True
        '
        'frmDataCopy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(921, 563)
        Me.Controls.Add(Me.chkDeleteMatched)
        Me.Controls.Add(Me.txtLogs)
        Me.Controls.Add(Me.chkShowLog)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblSizeRemaining)
        Me.Controls.Add(Me.lblCalculate)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.chkKeepFiles)
        Me.Controls.Add(Me.lblSizeCopied)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.cmdMove)
        Me.Controls.Add(Me.cmdCopy)
        Me.Controls.Add(Me.lblCPath)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblFileName)
        Me.Controls.Add(Me.lblDirName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.GBPaths)
        Me.Name = "frmDataCopy"
        Me.Text = "Data Copy Apps - Created By NDS"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.GBPaths.ResumeLayout(False)
        Me.GBPaths.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSizeCopied As System.Windows.Forms.Label
    Friend WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents cmdMove As System.Windows.Forms.Button
    Private WithEvents cmdCopy As System.Windows.Forms.Button
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents cmdSelectDest As System.Windows.Forms.Button
    Friend WithEvents lblCPath As System.Windows.Forms.Label
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents CmdSelectSource As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblFileName As System.Windows.Forms.Label
    Friend WithEvents lblDirName As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents GBPaths As System.Windows.Forms.GroupBox
    Friend WithEvents chkKeepFiles As System.Windows.Forms.CheckBox
    Friend WithEvents FBDialog1 As System.Windows.Forms.FolderBrowserDialog
    Private WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtLogsEx As System.Windows.Forms.TextBox
    Friend WithEvents lblCalculate As System.Windows.Forms.Label
    Friend WithEvents lblSizeRemaining As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents chkShowLog As System.Windows.Forms.CheckBox
    Friend WithEvents txtLogs As System.Windows.Forms.TextBox
    Friend WithEvents chkDeleteMatched As System.Windows.Forms.CheckBox

End Class
