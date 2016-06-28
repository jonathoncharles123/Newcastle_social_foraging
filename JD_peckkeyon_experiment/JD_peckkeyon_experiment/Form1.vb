Option Explicit On
Option Strict On
Imports AxWHISKERSDKLib
Imports System.IO

Public Class Form1
    'Written as an experiment by Jonathon Dunn June 2016

#Region "Declarations"


    'Devices: these must match Whisker server device names in the inverted commas
    'Purpose = to ensure that any spelling mistakes are spotted
    Const peckingkeylatch As String = "PECKINGKEYLATCH"
    Const houselight As String = "HOUSELIGHT"
    Const peckingkeyima0 As String = "PECKINGKEYIMA0"
    Const peckingkeyima1 As String = "PECKINGKEYIMA1"
    Const peckingkeyima2 As String = "PECKINGKEYIMA2"
    Const feeder As String = "FEEDER"
    Const peckingkeyon As String = "PECKINGKEYON"

    'Declare variables - private should be the default
    Private box1 As String = "box1" 'this is the grouping name - we can add to this when we have more feeding stations 
    Private CurrentEvent As String 'whether the event is a peck or not a peck
    Private iTotalTrials As Integer 'number of trials in running session
    Private iSumTrials As Integer 'sum of all trials across sessions
    Private iTrial As Integer 'the current trial
    Private GoodTrials As Integer 'the number of good trials (where the lit key was pecked)
    Private TimeToFeed As Integer 'the amount of time the bird has to feed from the hopper
    Private ITI As Integer 'the intertrial interval
    'Private Declare Function timeGetTime Lib "winmm.dll" () As Integer 'a function to allow us to get the current time
    Public lngStartTime As Integer 'the start time for our delay sub
    Private nStimulusTime As Integer 'the time we want the pecking key to be lit 
    Private bConditionalFood As Boolean 'says if the conditional button is checked
    Private StartLatency As DateTime 'the time when the trial starts
    Private CurrentLatency As TimeSpan 'the length of time from start of trial to end of trial
    Private TotalLatency As TimeSpan 'the sum of all the CurrentLatencies
    Private MeanLatency As Double 'TotalLatency/GoodTrials
    Private z As Integer 'counter
    Private strFile As String 'name of output path
    Private FeedStation As String 'feeding station
    Private Function today() As Date
        Return DateTime.Now.Date 'for today's date right now '
    End Function

    Private Function tomorrow() As Date
        Return DateTime.Today.AddDays(1).Date 'for tomorrow's date '
    End Function



    'Define whisker events
    Const Key_Peck = "Key_Peck"
    Const End_Stimulus = "End_Stimulus"
    Const End_of_ITI = "End_of_ITI"
    Const starfeederRFID_EVENT = "starfeederRFID_EVENT" 'doesn't work yet as can't listen to messages 
#End Region

    'Introduce a delay somewhere.  Just put Call delay(500) to get a delay of 
    '500ms
    Public Sub delay(msdelay As Integer, Optional processEvents As Boolean = False) ' this is rather unsafe...
        Dim StartTime As DateTime = Now(), elapsed As TimeSpan
        Do
            elapsed = Now - StartTime
            'for longer delays, we might want to r
            If processEvents Then Application.DoEvents()
        Loop Until elapsed.TotalMilliseconds > msdelay
    End Sub

    'When called, the pecking key light will turn on 
    Private Sub LatchOn()
        Call Whisker.LineSetState(peckingkeylatch, WHISKERSDKLib.wsLineState.wsOn)
    End Sub

    'When called, the pecking key light will turn off 
    Private Sub LatchOff()
        Call Whisker.LineSetState(peckingkeylatch, WHISKERSDKLib.wsLineState.wsOff)
    End Sub

    'When called, the following image will be created on the pecking
    'key - see JD's guide on what image shapes/colours you want to have
    Private Sub DefineImageOn()
        Call Whisker.LineSetState(peckingkeyima0, WHISKERSDKLib.wsLineState.wsOn)
        Call Whisker.LineSetState(peckingkeyima1, WHISKERSDKLib.wsLineState.wsOn)
        Call Whisker.LineSetState(peckingkeyima2, WHISKERSDKLib.wsLineState.wsOn)
    End Sub

    'When called, the following image will be turned off
    Private Sub DefineImageOff()
        Call Whisker.LineSetState(peckingkeyima0, WHISKERSDKLib.wsLineState.wsOff)
        Call Whisker.LineSetState(peckingkeyima1, WHISKERSDKLib.wsLineState.wsOff)
        Call Whisker.LineSetState(peckingkeyima2, WHISKERSDKLib.wsLineState.wsOff)
    End Sub

    'When called, the feeder will turn on
    Private Sub FeederOn()
        Call Whisker.LineSetState(feeder, WHISKERSDKLib.wsLineState.wsOn)
    End Sub

    'When called, the feeder will turn off
    Private Sub FeederOff()
        Call Whisker.LineSetState(feeder, WHISKERSDKLib.wsLineState.wsOff)
    End Sub

    '1. Connect to the whisker server when the form is loaded and claim the lines we need
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Insert the date and time into the form as a default (but able to change this manually if nec.)
        Me.DatePicker.Value = tomorrow()
        Me.txtTime.Text = "07:00:00"
    End Sub

    '2. If we want to start the trial immediately, by checking this box, we get date and time info
    'Public Sub chkImmediate_Click(sender As Object, e As EventArgs) Handles chkImmediate.Click
    '    Me.txtDate.Text = today.ToShortDateString
    '    Me.txtTime.Text = today.ToLongTimeString
    'End Sub

    '^^^^This^^^^ is rather peculiar. It would happen whenever the item is *clicked* (e.g. if *deselected*).
    'as what we want is to 'ignore the date/time' if starting immediately, better to show this
    Private Sub chkImmediate_CheckedChanged(sender As Object, e As EventArgs) Handles chkImmediate.CheckedChanged
        Me.DatePicker.Enabled = Not chkImmediate.Checked
        Me.txtTime.Enabled = Not chkImmediate.Checked
    End Sub
    '3. Click the Connect button, to connect to the server, claim the line we need and make sure the Go
    'button is enabled
    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        'Connect to the whisker server
        Whisker.ConnectToServer()
        'Claim the following lines
        Call Whisker.LineClaim(box1, peckingkeylatch, peckingkeylatch, WHISKERSDKLib.wsLineType.wsOutput, WHISKERSDKLib.wsResetType.wsResetOff)
        Call Whisker.LineClaim(box1, houselight, houselight, WHISKERSDKLib.wsLineType.wsOutput, WHISKERSDKLib.wsResetType.wsResetOff)
        Call Whisker.LineClaim(box1, peckingkeyima0, peckingkeyima0, WHISKERSDKLib.wsLineType.wsOutput, WHISKERSDKLib.wsResetType.wsResetOff)
        Call Whisker.LineClaim(box1, peckingkeyima1, peckingkeyima1, WHISKERSDKLib.wsLineType.wsOutput, WHISKERSDKLib.wsResetType.wsResetOff)
        Call Whisker.LineClaim(box1, peckingkeyima2, peckingkeyima2, WHISKERSDKLib.wsLineType.wsOutput, WHISKERSDKLib.wsResetType.wsResetOff)
        Call Whisker.LineClaim(box1, feeder, feeder, WHISKERSDKLib.wsLineType.wsOutput, WHISKERSDKLib.wsResetType.wsResetOff)
        Call Whisker.LineClaim(box1, peckingkeyon, peckingkeyon, WHISKERSDKLib.wsLineType.wsInput, WHISKERSDKLib.wsResetType.wsResetOff)
        'Make sure that we are able to click the Go button
        cmdGo.Enabled = True
        'Get session variables from the form
        iTotalTrials = CInt(Val(txtTotalTrials.Text))
        TimeToFeed = CInt(Val(txtFeed.Text) * 1000)
        nStimulusTime = CInt(Val(txtStimulusTime.Text) * 1000)
        ITI = CInt(Val(txtITI.Text) * 1000)
        bConditionalFood = chkConditionalFood.Checked
        FeedStation = txtFeedingStation.Text
        'name the output file:
        strFile = String.Format(txtDirectory.Text + "test_experiment_" + DateTime.Today.ToString("dd_MMM_yyy") + ".csv") 'can change this if need a daily file/master file
    End Sub

    '4. When we click the Go button, we read in the number of trials we want
    'the time we want to give the bird to feed (which could be variable) and we start the number of trials,
    'sum trials and good trials as 0.  We also call the start trial sub.
    Private Sub cmdGo_Click(sender As Object, e As EventArgs) Handles cmdGo.Click
        'Make sure the following are not enabled on the form
        Me.txtFeedingStation.Enabled = False
        Me.txtTotalTrials.Enabled = False
        Me.txtStimulusTime.Enabled = False
        Me.txtITI.Enabled = False
        Me.txtFeed.Enabled = False
        Me.chkConditionalFood.Enabled = False
        Me.chkImmediate.Enabled = False
        Me.DatePicker.Enabled = False
        Me.txtTime.Enabled = False
        Me.txtDirectory.Enabled = False
        Randomize()
        iTrial = 0
        iSumTrials = 0
        GoodTrials = 0
        If chkImmediate.Checked Then Call StartSession()
        'z = 1  <-redundant; deleted
        Call CheckTime()
    End Sub

    '5. Compare date and times from the form vs. the current date/time.  If after the date/time on the form
    'Then we can initiate the rest of the code:
    Private Sub CheckTime()
        'Get the date and time variables from the form
        Dim formDt As String
        Dim formTi As String
        formDt = DatePicker.Value.ToShortDateString
        formTi = txtTime.Text
        Dim formDtTi As String
        'Combine the date and time variables from the form
        formDtTi = String.Format(formDt & " " & formTi)
        Dim formDateTime As DateTime = DateTime.Parse(formDtTi)

        'NOW
        Do Until Now > formDateTime
            Threading.Thread.Sleep(1000)
        Loop
        StartSession()

        'WAS
        'Set up a counter
        'Dim a As Integer = 0
        ''Start a loop. 1) check current date/time and z value. 2) If z>1 and current date/time is equal to/greater than the form date
        ''Then Call Start_Trial(). 3) If not, check the current date/time after 1ms. 4) Once conditions are satisfied, we need to 
        ''use the counter to break the loop, otherwise, we just keep calling start trial...
        'Do
        '    If DateTime.Now.Year >= formDateTime.Year And DateTime.Now.Month >= formDateTime.Month And DateTime.Now.Day >= formDateTime.Day And DateTime.Now.Hour >= formDateTime.Hour And DateTime.Now.Minute >= formDateTime.Minute And z = 1 Then
        '        Call Start_Trial()
        '        Call Start_starfeeder()
        '        a = a + 1
        '    End If
        '    Threading.Thread.Sleep(1000)
        'Loop While (a < 1)
        '
        '^^^this is horribly complex & thus difficult to read debug. e.g. z is redundant (it was set before the only possible call to the function). 

    End Sub

    'make sure we can start the starfeeder client when the first trial starts - need to work out how to programmatically
    'click the 'start' button on starfeeder client, or else just run the client from when we click 'go'
    Private Sub StartSession()
        Process.Start("C:\Users\User\Documents\StarFeeder\starfeeder_0.2.4_windows\starfeeder.exe")
        Start_Trial()
    End Sub

    '6. when a trial is started, the key light is switched on and we set the whisker event Key_Peck
    'to be created when the peckingkey is pecked / turned on
    Private Sub Start_Trial()
        Call DefineImageOn()
        Call LatchOn()
        Call Whisker.LineSetEvent(peckingkeyon, Key_Peck, WHISKERSDKLib.wsLineEventType.wsLineToOn)
        Call Whisker.TimerSetEvent(End_Stimulus, nStimulusTime, 0)
        Me.TextBox1.Text = "STIMULUS ON"
        StartLatency = DateTime.Now
    End Sub

    '7. When a whisker event occurs, do the following
    Private Sub Whisker_Event(ByVal sender As Object, ByVal e As AxWHISKERSDKLib._DWhiskerSDKEvents_EventEvent) Handles Whisker.Event
        Dim Message As String = e.eventMessage, Timestamp As Integer = e.time
        Me.txtTry2.Text = Message ' this bit is just for JD to see what is going on
        Select Case Message
            Case Key_Peck : Call Peck()
            Case End_Stimulus : Call EndTrial()
            Case End_of_ITI : Call NewTrial()
        End Select
    End Sub

    'THIS IS MY ATTEMPT TO RECEIVE THE RFID EVENTS... AT THE MOMENT I DON'T THINK THAT THIS CLIENT IS LISTENING
    Private Sub Whisker_ClientMessage(ByVal sender As Object, ByVal e As AxWHISKERSDKLib._DWhiskerSDKEvents_ClientMessageEvent) Handles Whisker.ClientMessage
        Dim Message As String = e.message, Timestamp As Integer = e.timeStamp
        Select Case Message
            Case starfeederRFID_EVENT : MessageBox.Show("RFID event!") 'this will be changed to be more useful in the future
        End Select
    End Sub


    '8. The peck sub says turn off key light (leaving the key image shape/colour as before), clear the
    'whisker event i.e. being pecked ON, and then call the give food sub.
    Private Sub Peck()
        Call LatchOff()
        Call Whisker.LineClearEventsByLine(peckingkeyon, WHISKERSDKLib.wsLineEventType.wsLineToOn) 'maybe KillEvents might be more useful?
        Call Whisker.TimerClearEvent(End_Stimulus) 'maybe KillEvents might be more useful?
        CurrentEvent = "peck"
        GoodTrials = GoodTrials + 1
        CurrentLatency = DateTime.Now - StartLatency
        TotalLatency = TotalLatency + CurrentLatency
        Dim Secs As Double = TotalLatency.TotalSeconds ' can't do division on datetimes, so conver to decimal first
        MeanLatency = Secs / GoodTrials
        Me.TextBox1.Text = "FOOD DELIVERY"
        Call GiveFood()
    End Sub

    '9. The EndTrial sub - define the event as 'no peck', turn off the light and 
    Private Sub EndTrial()
        CurrentEvent = "no peck"
        Call LatchOff()
        Call Whisker.LineClearEventsByLine(peckingkeyon, WHISKERSDKLib.wsLineEventType.wsLineToOn) 'kill?
        Call Whisker.TimerClearEvent(End_Stimulus) 'kill?
        If Not bConditionalFood Then 'if no peck and conditional, get no food, but if not conditional, get food
            Me.TextBox1.Text = "FOOD DELIVERY"
            Call GiveFood()
        Else Me.TextBox1.Text = "INTERTRIAL INTERVAL" 'This doesn't seem to get updated quite fast enough
            Call InterTrialInterval()
        End If
    End Sub

    '10. Turn on the hopper to give food, keep it on for the delay time we specified in the form,
    'then turn the hopper off and call the intertrial interval sub
    Private Sub GiveFood()
        Call FeederOn()
        Me.TextBox1.Text = "INTERTRIAL INTERVAL"
        delay(TimeToFeed)
        Call FeederOff()
        Call InterTrialInterval()
    End Sub

    '11. Count the number of trials, total trials and then call the new trial sub after the specified
    'ITI interval from the form.  IDEALLY I'd like to add the MASS and RFID information from the starfeeder for each trial.
    Private Sub InterTrialInterval()
        Dim CLatency As Double = CurrentLatency.TotalSeconds
        iTrial = iTrial + 1
        iSumTrials = iSumTrials + 1
        Me.txtTrials.Text = Str(iTrial)
        Me.txtGoodTrials.Text = Str(GoodTrials)
        Me.txtLatency.Text = Str(MeanLatency) 'This doesn't always seem to work (not sure why yet)
        Call Whisker.TimerSetEvent(End_of_ITI, ITI, 0)
        'Write to a daily file - first for pecks: check if file exists as need to create one otherwise.
        If CurrentEvent = "peck" And System.IO.File.Exists(strFile) = True Then
            Dim objWriter As New System.IO.StreamWriter(strFile, True)
            objWriter.WriteLine(DateTime.Now & " " & FeedStation & " " & iTrial & " " & GoodTrials & " " & "success" & " " & CLatency)
            objWriter.Close()
        ElseIf CurrentEvent = "peck" And System.IO.File.Exists(strFile) = False Then
            Dim objWriter As New System.IO.StreamWriter(strFile, False)
            objWriter.WriteLine(DateTime.Now & " " & FeedStation & " " & iTrial & " " & GoodTrials & " " & "success" & " " & CLatency)
            objWriter.Close()
            'Now for no pecks: check if file exists as need to create one otherwise. 
        ElseIf CurrentEvent = "no peck" And System.IO.File.Exists(strFile) = True Then
            Dim objWriter As New System.IO.StreamWriter(strFile, True)
            objWriter.WriteLine(DateTime.Now & " " & FeedStation & " " & iTrial & " " & GoodTrials & " " & "failure" & " " & "NA")
            objWriter.Close()
        ElseIf CurrentEvent = "no peck" And System.IO.File.Exists(strFile) = False Then
            Dim objWriter As New System.IO.StreamWriter(strFile, False)
            objWriter.WriteLine(DateTime.Now & " " & FeedStation & " " & iTrial & " " & GoodTrials & " " & "failure" & " " & "NA")
            objWriter.Close()
        End If
        delay(ITI)
        Call NewTrial()
    End Sub

    '12. If the number of trials is bigger than the total we want, end the session, otherwise start again
    Private Sub NewTrial()
        If iTrial >= iTotalTrials Then
            Call End_Session()
        Else : Call Start_Trial()
        End If
    End Sub

    '13. At the end of the session state the session is finished
    Private Sub End_Session()
        Me.TextBox1.Text = "SESSION FINISHED"
    End Sub

    '14. If you cancel the form, this message comes up
    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Are you sure you want to quit?", "Cancel program", MessageBoxButtons.YesNoCancel) <> DialogResult.Yes Then
            e.Cancel = True
        End If
    End Sub

    'Would like to get an error message/disconnect from whisker if get a whisker error
    Private Sub Whisker_Error(ByVal sender As Object, ByVal e As AxWHISKERSDKLib._DWhiskerSDKEvents_ErrorEvent) Handles Whisker.Error
        Dim ErrorMessage As String = e.errorMessage, Timestamp As Integer = e.time
        Call Whisker.Disconnect()
        Call Whisker.AlertOperator(ErrorMessage, True, False)
    End Sub

    'Would like to get this alert operator if whisker is disconnected
    Private Sub Whisker_Disconnected(ByVal sender As Object, ByVal e As EventArgs) Handles Whisker.Disconnected
        Call Whisker.AlertOperator("Session over - Disconnected", True, False)
    End Sub

    'This was in the old VB6 program, not sure if needed?
    Private Sub break(ByVal message As String)
        Call Whisker.AlertOperator(message, True, False)
    End Sub


End Class
