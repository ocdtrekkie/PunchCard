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
                    '[[0,0,1],[0,1,3],[0,2,0],[0,3,1],[0,4,0],[0,5,0],[0,6,0],[0,7,0],[0,8,1],[0,9,0],[0,10,0],[0,11,0],[0,12,0],[0,13,0],[0,14,2],[0,15,0],[0,16,3],[0,17,0],[0,18,2],[0,19,2],[0,20,5],[0,21,1],[0,22,1],[0,23,13],[1,0,9],[1,1,7],[1,2,1],[1,3,0],[1,4,0],[1,5,0],[1,6,0],[1,7,0],[1,8,0],[1,9,0],[1,10,0],[1,11,1],[1,12,0],[1,13,1],[1,14,2],[1,15,1],[1,16,0],[1,17,3],[1,18,15],[1,19,18],[1,20,10],[1,21,11],[1,22,4],[1,23,13],[2,0,13],[2,1,13],[2,2,2],[2,3,1],[2,4,0],[2,5,0],[2,6,0],[2,7,0],[2,8,0],[2,9,1],[2,10,2],[2,11,3],[2,12,3],[2,13,5],[2,14,2],[2,15,0],[2,16,1],[2,17,5],[2,18,10],[2,19,12],[2,20,12],[2,21,2],[2,22,7],[2,23,9],[3,0,4],[3,1,9],[3,2,1],[3,3,0],[3,4,0],[3,5,0],[3,6,0],[3,7,0],[3,8,0],[3,9,1],[3,10,4],[3,11,3],[3,12,1],[3,13,3],[3,14,0],[3,15,0],[3,16,0],[3,17,3],[3,18,2],[3,19,9],[3,20,6],[3,21,5],[3,22,4],[3,23,12],[4,0,9],[4,1,4],[4,2,1],[4,3,0],[4,4,0],[4,5,0],[4,6,0],[4,7,0],[4,8,1],[4,9,1],[4,10,3],[4,11,7],[4,12,2],[4,13,0],[4,14,0],[4,15,0],[4,16,2],[4,17,0],[4,18,7],[4,19,7],[4,20,11],[4,21,8],[4,22,10],[4,23,4],[5,0,7],[5,1,8],[5,2,2],[5,3,0],[5,4,0],[5,5,0],[5,6,0],[5,7,0],[5,8,0],[5,9,2],[5,10,1],[5,11,5],[5,12,5],[5,13,0],[5,14,0],[5,15,0],[5,16,1],[5,17,5],[5,18,10],[5,19,6],[5,20,10],[5,21,10],[5,22,18],[5,23,13],[6,0,9],[6,1,5],[6,2,2],[6,3,5],[6,4,1],[6,5,0],[6,6,0],[6,7,0],[6,8,0],[6,9,0],[6,10,0],[6,11,0],[6,12,0],[6,13,0],[6,14,0],[6,15,0],[6,16,0],[6,17,1],[6,18,0],[6,19,0],[6,20,0],[6,21,1],[6,22,5],[6,23,2]]
                    Dim numArray As Integer()() = JsonMapper.To(Of Integer()())(output)
                    Dim commitsArray(6, 23) As Integer
                    Console.WriteLine(numArray(1)(2)) ' = 3

                    Dim i As Integer
                    For i = 0 To 167
                        commitsArray(numArray(i)(0), numArray(i)(1)) = numArray(i)(2)
                    Next

                    Console.WriteLine(commitsArray(0, 1))

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
