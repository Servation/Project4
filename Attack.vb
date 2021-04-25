Public Class Attack
    Public Property x As Double
    Public Property y As Double
    Public Property speedY As Decimal
    Public Property size As Integer
    Public Property visible As Boolean = True
    Public Property direction As Integer

    Private MainRect As Rectangle



    Sub New(MainRect As Rectangle)
        Me.MainRect = MainRect
        _direction = 1
    End Sub

    Public Sub Show(G As Graphics)
        If _visible Then
            Select Case _direction
                Case 0
                    G.FillPolygon(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), {New Point(x, y - 20), New Point(x, y + 10), New Point(x + 60, y + 10), New Point(x + 60, y - 20)})
                Case 1
                    G.FillPolygon(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), {New Point(x, y + 60), New Point(x, y + 90), New Point(x + 60, y + 90), New Point(x + 60, y + 60)})
                Case 2
                    G.FillPolygon(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), {New Point(x - 20, y + 5), New Point(x + 10, y + 5), New Point(x + 10, y + 65), New Point(x - 20, y + 65)})
                Case 3
                    G.FillPolygon(New SolidBrush(Color.FromArgb(100, 0, 0, 0)), {New Point(x + 50, y + 5), New Point(x + 80, y + 5), New Point(x + 80, y + 65), New Point(x + 50, y + 65)})
            End Select

        End If

    End Sub

    Public Sub Update()
        _y += _speedY
        If _y < -20 Then
            _visible = False
        End If
    End Sub
End Class
