'' Author: Francisco Bumanglag
'' Project: Website Traffic Metric 
'' Assignment: Module 6 Exercise 
'' Course: Adv Visual Basic, Santa Ana College
'' Class: CMPR205 Dr. Kimberly Davis 
'' Date: March 19, 2024


Public Class frmMetric

    Private Sub frmMetric_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnAnalyze_Click(sender As Object, e As EventArgs) Handles btnAnalyze.Click

        ''declare variables for visitor time, average time, and total time.
        Dim strVisitorTime As String
        Dim intVisitorTime As Integer
        Dim decAverageTime As Decimal
        Dim intTotalTime As Integer = 0

        ''declare variables.  messages include prompts for input, headings for input dialogs,
        ''error messages for non-numeric or negative input, and a marker for a canceled input action
        Dim strInputMessage As String = "Enter the number of seconds spent by visitor"
        Dim strInputHeading As String = "Visitor Time"
        Dim strNormalMessage As String = "Enter the number of seconds spent by visitor"
        Dim strNonNumericError As String = "Error - Enter a numeric value for the time spent by visitor"
        Dim strNegError As String = "Error - Enter a positive number for the time spent by visitor"
        Dim strCancelClicked As String = ""

        Dim intMaxNumberOfEntries As Integer = 12 ''maximum number of entries
        Dim intNumberOfEntries As Integer = 1 ''counter for loop

        'displays input box for visitor time with message count
        strVisitorTime = InputBox(strInputMessage & intNumberOfEntries, strInputHeading, " ")

        ''loops until max entries or cancel, validates numeric positive input, updates total time, and prompts again
        Do Until intNumberOfEntries > intMaxNumberOfEntries Or strVisitorTime = strCancelClicked
            If IsNumeric(strVisitorTime) Then
                intVisitorTime = Convert.ToInt32(strVisitorTime)
                If intVisitorTime > 0 Then
                    lstVisitorTimes.Items.Add(intVisitorTime)
                    intTotalTime += intVisitorTime ''accumulate total time
                    intNumberOfEntries += 1
                    strInputMessage = strNormalMessage
                Else
                    strInputMessage = strNegError
                End If
            Else
                strInputMessage = strNonNumericError
            End If
            If intNumberOfEntries <= intMaxNumberOfEntries Then
                strVisitorTime = InputBox(strInputMessage & intNumberOfEntries, strInputHeading, " ")
            End If
        Loop

        ''calculates, displays average time if entries exist, else alerts
        If intNumberOfEntries > 1 Then
            lblAverageTime.Visible = True
            decAverageTime = intTotalTime / (intNumberOfEntries - 1)
            lblAverageTime.Text = "Average time spent: " & decAverageTime.ToString("F2") & " seconds"
        Else
            MsgBox("No time value was entered.", MsgBoxStyle.Information, "Input Needed")
        End If
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click

        ''clears list, hides average label, enables Analyze button
        lstVisitorTimes.Items.Clear()
        lblAverageTime.Visible = False
        btnAnalyze.Enabled = True

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click

        ''exit application
        Close()

    End Sub

End Class
