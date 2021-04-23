Public Class Player
    Public Property x As Double
    Public Property y As Double
    Public Property speedX As Decimal
    Public Property speedY As Decimal
    Public Property visible As Boolean
    Public Property moving As Boolean

    Public Property maxSpeed As Decimal
    Private direct As Integer

    Public Property Direction As Integer
        Get
            Return direct
        End Get
        Set(value As Integer)
            direct = value
        End Set
    End Property

    Private frame(35) As Bitmap

    Private MainRect As Rectangle

    Sub New(MainRect As Rectangle)
        Me.MainRect = MainRect
        _x = MainRect.Width / 2 - 45
        _y = MainRect.Height / 2 - 45
        _maxSpeed = 1.5
        Direction = 18
        moving = False
        Dim img As New Bitmap(My.Resources.playerwalking)
        _visible = True
        Dim bitY = 0

        For i As Integer = 0 To 35
            frame(i) = New Bitmap(61, 64)
            Dim gr As Graphics = Graphics.FromImage(frame(i))
            Dim xPosition As Integer = (i Mod 9) * 63
            gr.DrawImage(img, 0, 0, New RectangleF(xPosition, Int(i / 9) * 64, 61, 64), GraphicsUnit.Pixel)
        Next
    End Sub

    Public Sub Show(G As Graphics)

        If visible Then
            G.FillEllipse(New SolidBrush(Color.FromArgb(150, 0, 0, 0)), New RectangleF(CSng(_x + 15), CSng(_y + 45), 28, 14))
            G.DrawImage(CType(frame(direct), Image), CSng(_x), CSng(_y), 61, 64)
        End If
    End Sub

    Public Sub Update()
        _x += _speedX
        _y += _speedY
        declerate()
    End Sub

    Public Sub declerate()
        If _speedY > 0 Then
            _speedY -= 0.2
            If _speedX = 0 Then
                If Direction < 18 Or Direction > 26 Then
                    Direction = 18
                End If
            End If
        ElseIf _speedY < 0 Then
            _speedY += 0.2
            If _speedX = 0 Then
                If Direction < 0 Or Direction > 7 Then
                    Direction = 0
                End If
            End If
        End If
        If _speedX > 0 Then
            _speedX -= 0.2
            If Direction < 27 Or Direction > 34 Then
                Direction = 27
            End If
        ElseIf _speedX < 0 Then
            _speedX += 0.2
            If Direction < 9 Or Direction > 17 Then
                Direction = 9
            End If
        End If
        If _speedY = 0 And _speedX = 0 Then
            moving = False
        End If

    End Sub
End Class
