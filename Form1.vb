Imports Commons.Json

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btnViewCard_Click(sender As Object, e As EventArgs) Handles btnViewCard.Click
        If txtUsername.Text <> "" AndAlso txtRepository.Text <> "" Then
            Try
                Dim fr As System.Net.HttpWebRequest
                Dim targetURI As New Uri("https://api.github.com/repos/" & txtUsername.Text & "/" & txtRepository.Text & "/stats/punch_card")
                Dim output As String = ""
                fr = DirectCast(System.Net.HttpWebRequest.Create(targetURI), System.Net.HttpWebRequest)
                fr.UserAgent = "ocdtr_vb_test"
                If (fr.GetResponse().ContentLength > 0) Then
                    Dim str As New System.IO.StreamReader(fr.GetResponse().GetResponseStream())
                    output = str.ReadToEnd()
                    str.Close()
                    My.Application.Log.WriteEntry(output)
                    Dim numArray As Integer()() = JsonMapper.To(Of Integer()())(output)
                    Dim commitsArray(6, 23) As Integer

                    Dim i As Integer
                    For i = 0 To 167
                        commitsArray(numArray(i)(0), numArray(i)(1)) = numArray(i)(2)
                    Next

                    Dim labelArray(6, 23) As Windows.Forms.Label
                    Dim j, l, m As Integer
                    For j = 0 To 6
                        For l = 0 To 23
                            labelArray(j, l) = New Windows.Forms.Label
                            labelArray(j, l).Name = "LabelCommits(" & j & "," & l & ")"
                            labelArray(j, l).Top = 25 * j + 75
                            labelArray(j, l).Left = 25 * l + 80
                            labelArray(j, l).Height = 20
                            labelArray(j, l).Width = 20
                            labelArray(j, l).TextAlign = ContentAlignment.TopRight
                            labelArray(j, l).Text = commitsArray(j, l)
                            labelArray(j, l).Visible = True
                            labelArray(j, l).Parent = Me
                        Next
                    Next

                    Dim daysArray(6) As Windows.Forms.Label
                    For m = 0 To 6
                        daysArray(m) = New Windows.Forms.Label
                        daysArray(m).Left = 20
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
