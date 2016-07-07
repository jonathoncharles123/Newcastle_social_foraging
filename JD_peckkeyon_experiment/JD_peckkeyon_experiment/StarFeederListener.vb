Module StarFeeder
    'Parses the messages from the starfeeder client

    'Code from starfeeder client (python)

    'messages also get a 'starfeeder' pre-pended (based on RNC screenshot)

    'If self.whisker.is_connected() : 
    '        self.broadcast(
    '            "RFID_EVENT: reader {reader}, RFID {rfid}, "
    '            "timestamp {timestamp}".format(
    '                rfid=rfid_event.rfid,
    '                reader=rfid_event.reader_name,
    '                timestamp=rfid_event.timestamp,
    'If self.whisker.is_connected() : 
    '        self.broadcast(
    '            "MASS_EVENT: reader {reader}, RFID {rfid}, balance {balance}, "
    '            "mass {mass_kg} kg, timestamp {timestamp}".format(
    '                reader=mass_event.reader_name,
    '                rfid=mass_event.rfid,
    '                balance=mass_event.balance_name,
    '                mass_kg=mass_event.mass_kg,
    '                timestamp=mass_event.timestamp,
    '            )
    '        )

    Private Const RFIDEVENT As String = "starfeeder: RFID_EVENT: reader"
    Private Const MASSEVENT As String = "starfeeder: MASS_EVENT: reader"
    Private Const RFID As String = "RFID"
    Private Const BALANCE As String = "balance"
    Private Const MASS As String = "mass"
    Private Const TIMESTAMP As String = "timestamp"
    Private Const None As String = "none"
    Private Const noMass As Double = -1


    Public Class StarFeederEvent
        ' implements a 'read only' data object containing the data from a client message from the starfeeder client
        ' note the use of private members, exposed as functions
        ' this ensures the contents of an object cannot be altered after created
        ' prevents accidents such as writing data to the object when testing it, etc.
        Private m_balance As String = None
        Private m_reader As String = None
        Private m_rfid As Long
        Private m_masskg As Double
        Private m_timestamp As DateTime
        Private m_clientTime As Long

        'Attempt to make a new item by parsing the string.
        'If string does not match expected format, throw an exception
        Public Sub New(message As String, clienttime As Long)
            m_clientTime = clienttime
            Try
                Dim s() As String = message.Split(",")  'slice up the strings into an array
                'Using [String].Split() function - which returns a string array separated by commas.
                'Note - I'm not using space/colon as a splitter here, as timestamp will contain these!

                'First element should contain either a "starfeeder: RFIDEVENT: reader xx" or "starfeeder: MASSEVENT: reader xx"
                'Other slices depend on which it is...
                If checkcontents_and_trim(s(0), StarFeeder.RFIDEVENT, True) Then
                    m_reader = s(0) ' already trimmed
                    If checkcontents_and_trim(s(1), StarFeeder.RFID) Then m_rfid = CLng(s(1))
                    If checkcontents_and_trim(s(2), StarFeeder.TIMESTAMP) Then m_timestamp = CDate(s(2))
                    m_balance = None
                    m_masskg = noMass

                ElseIf checkcontents_and_trim(s(0), StarFeeder.MASSEVENT) Then
                    m_reader = s(0) ' already trimmed
                    If checkcontents_and_trim(s(1), StarFeeder.RFID) Then m_rfid = CLng(s(1))
                    If checkcontents_and_trim(s(2), StarFeeder.BALANCE) Then m_balance = s(2)
                    If checkcontents_and_trim(s(3), StarFeeder.MASS) Then m_masskg = CDbl(s(3).TrimEnd(" ", "k", "g")) 'note that the s(3) contains characters at the end that will prevent coversion to double...
                    If checkcontents_and_trim(s(4), StarFeeder.TIMESTAMP) Then m_timestamp = CDate(s(4))

                Else
                    Throw New Exception("String does not start with RFID_EVENT or MASS_EVENT [" & s(0) & "]")
                End If
            Catch ex As Exception
                Debug.Print(ex.Message)
                Debug.Fail("Could Not parse StarFeederEvent" & ex.Message)
                Throw ex
            End Try
        End Sub

        Private Function checkcontents_and_trim(ByRef s As String, ByVal expectedStart As String, Optional silent As Boolean = False) As Boolean
            If (s.Trim()).StartsWith(expectedStart) Then
                s = Mid(s.Trim(), expectedStart.Length + 1)
                Return True
            Else
                If Not silent Then Throw New Exception("String does not start with :'" & expectedStart & "' [" & s & "]")
                Return False
            End If
        End Function


        Public Function Balance() As String
            Return m_balance
        End Function
        Public Function Reader() As String
            Return m_reader
        End Function
        Public Function RFID() As Long
            Return m_rfid
        End Function
        Public Function MassKg() As Double
            Return m_masskg
        End Function
        Public Function timestamp() As DateTime
            Return m_timestamp
        End Function
        Public Function clienttime() As Long
            Return m_clientTime
        End Function
    End Class

#Region "debug"

    Public Const test1 As String = "starfeeder: RFID_EVENT: reader rfid0, RFID 9000460000717672, timestamp 2015-12-23 15:54:48.406561"
    Public Const test2 As String = "starfeeder: MASS_EVENT: reader rfidxyz, RFID 1234567891234678, balance balance0, mass 0.010050306871918704 kg, timestamp 2016-01-31 15:54:48.406561"

    ' While code is paused in debugger, can test using 
    ' Call StarFeeder.TestStrings()
    ' in immediate window
    Public Function TestStrings() As Boolean
        Try
            Debug.Print("attempting to make object from test string 1")
            Dim j As New StarFeederEvent(test1, 0)

            Debug.Print("Reader, ID, time/date" & j.Reader & "," & j.RFID.ToString & "," & j.timestamp.ToLongTimeString() & " on " & j.timestamp.ToLongDateString())


            Debug.Print("attempting to make object from test string 2")
            Dim kj As New StarFeederEvent(test2, 0)
            Debug.Print("Reader, ID, time/date" & kj.Reader & "," & kj.RFID.ToString & "," & kj.timestamp.ToLongTimeString() & " on " & j.timestamp.ToLongDateString())
            Debug.Print("Balance, mass" & kj.Balance & "," & kj.MassKg.ToString())

            Debug.Print("Success? - check the locals window :o)")


        Catch ex As Exception
            Debug.Fail(ex.Message)
            Return False
        End Try
        Return True
    End Function
#End Region

End Module
