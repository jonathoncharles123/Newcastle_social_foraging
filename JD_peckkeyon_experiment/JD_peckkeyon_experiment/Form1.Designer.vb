<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Whisker = New AxWHISKERSDKLib.AxWhiskerSDK()
        Me.cmdGo = New System.Windows.Forms.Button()
        Me.chkConditionalFood = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtStimulusTime = New System.Windows.Forms.TextBox()
        Me.lblITI = New System.Windows.Forms.Label()
        Me.txtITI = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFeed = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTotalTrials = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFeedingStation = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkImmediate = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDirectory = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.DatePicker = New System.Windows.Forms.DateTimePicker()
        Me.txtTime = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmdConnect = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtStartTime = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGoodTrials = New System.Windows.Forms.TextBox()
        Me.txtTrials = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtLatency = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.txtTry2 = New System.Windows.Forms.TextBox()
        CType(Me.Whisker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Whisker
        '
        Me.Whisker.Enabled = True
        Me.Whisker.Location = New System.Drawing.Point(597, 499)
        Me.Whisker.Name = "Whisker"
        Me.Whisker.OcxState = CType(resources.GetObject("Whisker.OcxState"), System.Windows.Forms.AxHost.State)
        Me.Whisker.Size = New System.Drawing.Size(32, 32)
        Me.Whisker.TabIndex = 0
        '
        'cmdGo
        '
        Me.cmdGo.Location = New System.Drawing.Point(366, 364)
        Me.cmdGo.Name = "cmdGo"
        Me.cmdGo.Size = New System.Drawing.Size(56, 44)
        Me.cmdGo.TabIndex = 10
        Me.cmdGo.Text = "Go"
        Me.cmdGo.UseVisualStyleBackColor = True
        '
        'chkConditionalFood
        '
        Me.chkConditionalFood.AutoSize = True
        Me.chkConditionalFood.Checked = True
        Me.chkConditionalFood.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkConditionalFood.Location = New System.Drawing.Point(9, 138)
        Me.chkConditionalFood.MaximumSize = New System.Drawing.Size(250, 0)
        Me.chkConditionalFood.Name = "chkConditionalFood"
        Me.chkConditionalFood.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkConditionalFood.Size = New System.Drawing.Size(205, 17)
        Me.chkConditionalFood.TabIndex = 37
        Me.chkConditionalFood.Text = "Food delivery conditional on key peck"
        Me.chkConditionalFood.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Stimulus time (s):"
        '
        'txtStimulusTime
        '
        Me.txtStimulusTime.Location = New System.Drawing.Point(92, 46)
        Me.txtStimulusTime.Name = "txtStimulusTime"
        Me.txtStimulusTime.Size = New System.Drawing.Size(36, 20)
        Me.txtStimulusTime.TabIndex = 35
        Me.txtStimulusTime.Text = "15"
        '
        'lblITI
        '
        Me.lblITI.AutoSize = True
        Me.lblITI.Location = New System.Drawing.Point(6, 75)
        Me.lblITI.Name = "lblITI"
        Me.lblITI.Size = New System.Drawing.Size(37, 13)
        Me.lblITI.TabIndex = 34
        Me.lblITI.Text = "ITI (s):"
        '
        'txtITI
        '
        Me.txtITI.Location = New System.Drawing.Point(92, 72)
        Me.txtITI.Name = "txtITI"
        Me.txtITI.Size = New System.Drawing.Size(36, 20)
        Me.txtITI.TabIndex = 33
        Me.txtITI.Text = "150"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 32
        Me.Label6.Text = "Time to feed (s):"
        '
        'txtFeed
        '
        Me.txtFeed.Location = New System.Drawing.Point(92, 102)
        Me.txtFeed.Name = "txtFeed"
        Me.txtFeed.Size = New System.Drawing.Size(35, 20)
        Me.txtFeed.TabIndex = 31
        Me.txtFeed.Text = "5"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Number of trials:"
        '
        'txtTotalTrials
        '
        Me.txtTotalTrials.Location = New System.Drawing.Point(92, 17)
        Me.txtTotalTrials.Name = "txtTotalTrials"
        Me.txtTotalTrials.Size = New System.Drawing.Size(35, 20)
        Me.txtTotalTrials.TabIndex = 29
        Me.txtTotalTrials.Text = "80"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Feeding station:"
        '
        'txtFeedingStation
        '
        Me.txtFeedingStation.Location = New System.Drawing.Point(109, 9)
        Me.txtFeedingStation.Name = "txtFeedingStation"
        Me.txtFeedingStation.Size = New System.Drawing.Size(35, 20)
        Me.txtFeedingStation.TabIndex = 39
        Me.txtFeedingStation.Text = "box1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkConditionalFood)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtStimulusTime)
        Me.GroupBox1.Controls.Add(Me.lblITI)
        Me.GroupBox1.Controls.Add(Me.txtITI)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtFeed)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtTotalTrials)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(231, 173)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Trial parameters"
        '
        'chkImmediate
        '
        Me.chkImmediate.AutoSize = True
        Me.chkImmediate.Location = New System.Drawing.Point(18, 26)
        Me.chkImmediate.Name = "chkImmediate"
        Me.chkImmediate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkImmediate.Size = New System.Drawing.Size(80, 17)
        Me.chkImmediate.TabIndex = 41
        Me.chkImmediate.Text = "?Immediate"
        Me.chkImmediate.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 42
        Me.Label9.Text = "Date:"
        '
        'txtDirectory
        '
        Me.txtDirectory.Location = New System.Drawing.Point(17, 253)
        Me.txtDirectory.Name = "txtDirectory"
        Me.txtDirectory.Size = New System.Drawing.Size(264, 20)
        Me.txtDirectory.TabIndex = 22
        Me.txtDirectory.Text = "C:\Users\User\Documents\2016 experiments\Data\"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 237)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(161, 13)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Choose directory for datafile csv:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DatePicker)
        Me.GroupBox2.Controls.Add(Me.txtTime)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.chkImmediate)
        Me.GroupBox2.Location = New System.Drawing.Point(294, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(156, 172)
        Me.GroupBox2.TabIndex = 46
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Start"
        '
        'DatePicker
        '
        Me.DatePicker.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DatePicker.Location = New System.Drawing.Point(56, 52)
        Me.DatePicker.Name = "DatePicker"
        Me.DatePicker.Size = New System.Drawing.Size(74, 20)
        Me.DatePicker.TabIndex = 66
        Me.DatePicker.Value = New Date(2016, 6, 30, 0, 0, 0, 0)
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(55, 86)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.Size = New System.Drawing.Size(73, 20)
        Me.txtTime.TabIndex = 45
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 93)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Time:"
        '
        'cmdConnect
        '
        Me.cmdConnect.Location = New System.Drawing.Point(366, 301)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(56, 44)
        Me.cmdConnect.TabIndex = 47
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 139)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(127, 13)
        Me.Label13.TabIndex = 53
        Me.Label13.Text = "Mean latency to peck (s):"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(75, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 13)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "Start time:"
        '
        'txtStartTime
        '
        Me.txtStartTime.BackColor = System.Drawing.SystemColors.Menu
        Me.txtStartTime.Location = New System.Drawing.Point(133, 107)
        Me.txtStartTime.Multiline = True
        Me.txtStartTime.Name = "txtStartTime"
        Me.txtStartTime.Size = New System.Drawing.Size(185, 23)
        Me.txtStartTime.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(51, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 59
        Me.Label3.Text = "Total good trials:"
        '
        'txtGoodTrials
        '
        Me.txtGoodTrials.BackColor = System.Drawing.SystemColors.Menu
        Me.txtGoodTrials.Location = New System.Drawing.Point(133, 78)
        Me.txtGoodTrials.Multiline = True
        Me.txtGoodTrials.Name = "txtGoodTrials"
        Me.txtGoodTrials.Size = New System.Drawing.Size(185, 23)
        Me.txtGoodTrials.TabIndex = 58
        '
        'txtTrials
        '
        Me.txtTrials.BackColor = System.Drawing.SystemColors.Menu
        Me.txtTrials.Location = New System.Drawing.Point(133, 49)
        Me.txtTrials.Multiline = True
        Me.txtTrials.Name = "txtTrials"
        Me.txtTrials.Size = New System.Drawing.Size(185, 23)
        Me.txtTrials.TabIndex = 57
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(51, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 13)
        Me.Label7.TabIndex = 56
        Me.Label7.Text = "Completed trials:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(57, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 55
        Me.Label1.Text = "Session status:"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Menu
        Me.TextBox1.Location = New System.Drawing.Point(133, 15)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(185, 22)
        Me.TextBox1.TabIndex = 54
        '
        'txtLatency
        '
        Me.txtLatency.BackColor = System.Drawing.SystemColors.Menu
        Me.txtLatency.Location = New System.Drawing.Point(133, 136)
        Me.txtLatency.Multiline = True
        Me.txtLatency.Name = "txtLatency"
        Me.txtLatency.Size = New System.Drawing.Size(185, 23)
        Me.txtLatency.TabIndex = 62
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtLatency)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtStartTime)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtGoodTrials)
        Me.GroupBox3.Controls.Add(Me.txtTrials)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Location = New System.Drawing.Point(10, 286)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(339, 177)
        Me.GroupBox3.TabIndex = 63
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Session status"
        '
        'txtTry2
        '
        Me.txtTry2.Location = New System.Drawing.Point(317, 226)
        Me.txtTry2.Name = "txtTry2"
        Me.txtTry2.Size = New System.Drawing.Size(130, 20)
        Me.txtTry2.TabIndex = 65
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(462, 465)
        Me.Controls.Add(Me.txtTry2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.cmdConnect)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtFeedingStation)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtDirectory)
        Me.Controls.Add(Me.cmdGo)
        Me.Controls.Add(Me.Whisker)
        Me.Name = "Form1"
        Me.Text = "Training program"
        CType(Me.Whisker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Whisker As AxWHISKERSDKLib.AxWhiskerSDK
    Friend WithEvents cmdGo As Button
    Friend WithEvents chkConditionalFood As CheckBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtStimulusTime As TextBox
    Friend WithEvents lblITI As Label
    Friend WithEvents txtITI As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtFeed As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTotalTrials As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFeedingStation As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkImmediate As CheckBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtDirectory As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents txtTime As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents cmdConnect As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtStartTime As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtGoodTrials As TextBox
    Friend WithEvents txtTrials As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents txtLatency As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txtTry2 As TextBox
    Friend WithEvents DatePicker As DateTimePicker
End Class
