Imports Commons.Json

Public Class Form1
    Dim labelArray(6, 23) As Windows.Forms.Label
    Dim daysArray(6) As Windows.Forms.Label
    Dim hoursArray(23) As Windows.Forms.Label

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btnViewCard_Click(sender As Object, e As EventArgs) Handles btnViewCard.Click
        If txtUsername.Text <> "" AndAlso txtRepository.Text <> "" Then
            Try
                Dim fr As System.Net.HttpWebRequest
                Dim targetURI As New Uri("https://api.github.com/repos/" & txtUsername.Text & "/" & txtRepository.Text & "/stats/punch_card")
                Dim output As String = ""
                fr = DirectCast(System.Net.HttpWebRequest.Create(targetURI), System.Net.HttpWebRequest)
                fr.UserAgent = "PunchCardViewer_VB/1.0"
                If (fr.GetResponse().ContentLength > 0) Then
                    Dim str As New System.IO.StreamReader(fr.GetResponse().GetResponseStream())
                    output = str.ReadToEnd()
                    str.Close()
                    My.Application.Log.WriteEntry(output)
                    Dim numArray As Integer()() = JsonMapper.To(Of Integer()())(output)
                    Dim commitsArray(6, 23) As Integer

                    Dim mostCommits As Integer = 0

                    Dim i As Integer
                    For i = 0 To 167
                        If numArray(i)(2) > mostCommits Then
                            mostCommits = numArray(i)(2)
                        End If
                        commitsArray(numArray(i)(0), numArray(i)(1)) = numArray(i)(2)
                    Next

                    Dim j, k, l, m, n As Integer
                    For j = 0 To 6
                        For l = 0 To 23
                            labelArray(j, l) = New Windows.Forms.Label
                            labelArray(j, l).Top = 25 * j + 75
                            labelArray(j, l).Left = 25 * l + 80
                            labelArray(j, l).Height = 20
                            labelArray(j, l).Width = 25
                            labelArray(j, l).TextAlign = ContentAlignment.TopRight
                            labelArray(j, l).Text = commitsArray(j, l)
                            k = Int(Math.Abs(commitsArray(j, l) / mostCommits * 255 - 255))
                            labelArray(j, l).BackColor = Color.FromArgb(255, k, k, k)
                            If k < 100 Then
                                labelArray(j, l).ForeColor = Color.White
                            End If
                            labelArray(j, l).Visible = True
                            labelArray(j, l).Parent = Me
                        Next
                    Next

                    For m = 0 To 6
                        daysArray(m) = New Windows.Forms.Label
                        daysArray(m).Left = 10
                        daysArray(m).Top = 25 * m + 75
                        daysArray(m).Height = 20
                        daysArray(m).Visible = True
                        daysArray(m).Parent = Me
                    Next
                    daysArray(0).Text = "Sunday"
                    daysArray(1).Text = "Monday"
                    daysArray(2).Text = "Tuesday"
                    daysArray(3).Text = "Wednesday"
                    daysArray(4).Text = "Thursday"
                    daysArray(5).Text = "Friday"
                    daysArray(6).Text = "Saturday"

                    For n = 0 To 23
                        hoursArray(n) = New Windows.Forms.Label
                        hoursArray(n).Left = 25 * n + 80
                        hoursArray(n).Top = 50
                        hoursArray(n).Height = 20
                        hoursArray(n).Width = 25
                        hoursArray(n).Text = CStr(n + 1)
                        hoursArray(n).TextAlign = ContentAlignment.TopRight
                        hoursArray(n).Visible = True
                        hoursArray(n).Parent = Me
                    Next

                    My.Application.Log.WriteEntry("Most commits on any given hour: " & CStr(mostCommits))
                End If
            Catch ex As System.Net.WebException
                'Error in accessing the resource, handle it
                My.Application.Log.WriteException(ex)
                MsgBox("Unable to load GitHub Punch Card API", MsgBoxStyle.Exclamation)
            End Try
        End If
    End Sub

    Private Sub txtUsername_KeyUp(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnViewCard.PerformClick()
        End If
    End Sub

    Private Sub txtRepostiry_KeyUp(sender As Object, e As KeyEventArgs) Handles txtRepository.KeyUp
        If e.KeyCode = Keys.Enter Then
            btnViewCard.PerformClick()
        End If
    End Sub
End Class
