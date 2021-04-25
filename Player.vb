Public Class Player
    Public Property x As Double
    Public Property y As Double
    Public Property speedX As Decimal
    Public Property speedY As Decimal
    Public Property visible As Boolean
    Public Property moving As Boolean
    Public Property running As Boolean
    Public Property maxSpeed As Decimal
    Public Property knifing As Boolean
    Public Property knifeCounter As Integer
    Public Property sMultiplier As Double
    Public Property Health As Decimal
    Public Property Energy As Decimal
    Private direct As Integer
    Private normalFrames(35) As Bitmap
    Private knifeFrames(23) As Bitmap
    Private MainRect As Rectangle
    Public Property Direction As Integer
        Get
            Return direct
        End Get
        Set(value As Integer)
            direct = value
        End Set
    End Property
    Sub New(MainRect As Rectangle)
        Me.MainRect = MainRect
        _x = MainRect.Width / 2 - 45
        _y = MainRect.Height / 2 - 45
        _maxSpeed = 1.5
        Direction = 18
        _Health = 100
        _Energy = 100
        _sMultiplier = 1
        _moving = False
        _running = False
        _knifing = False
        Dim img As New Bitmap(My.Resources.playerwalking)
        _visible = True
        For i As Integer = 0 To 35
            normalFrames(i) = New Bitmap(61, 64)
            Dim gr As Graphics = Graphics.FromImage(normalFrames(i))
            Dim xPosition As Integer = (i Mod 9) * 63
            gr.DrawImage(img, 0, 0, New RectangleF(xPosition, Int(i / 9) * 64, 61, 64), GraphicsUnit.Pixel)
        Next
        Dim imgknife As New Bitmap(My.Resources.player)

        For i As Integer = 0 To knifeFrames.Count - 1
            knifeFrames(i) = New Bitmap(61, 64)
            Dim gs As Graphics = Graphics.FromImage(knifeFrames(i))
            Dim xPosition As Integer = (i Mod 6) * 64
            gs.DrawImage(imgknife, 0, 0, New RectangleF(xPosition, 757 + (Int(i / 6) * 64), 61, 64), GraphicsUnit.Pixel)
        Next
    End Sub

    Public Sub Show(G As Graphics)

        If visible Then
            G.FillEllipse(New SolidBrush(Color.FromArgb(150, 0, 0, 0)), New RectangleF(CSng(_x + 15), CSng(_y + 45), 28, 14))
            If knifing Then
                If Direction >= 0 And Direction <= 8 Then
                    G.DrawImage(CType(knifeFrames(0 + knifeCounter), Image), CSng(_x), CSng(_y - 4), 61, 64)
                ElseIf Direction >= 9 And Direction <= 17 Then
                    G.DrawImage(CType(knifeFrames(6 + knifeCounter), Image), CSng(_x), CSng(_y - 4), 61, 64)
                ElseIf Direction >= 18 And Direction <= 26 Then
                    G.DrawImage(CType(knifeFrames(12 + knifeCounter), Image), CSng(_x), CSng(_y - 4), 61, 64)
                ElseIf Direction >= 27 Then
                    G.DrawImage(CType(knifeFrames(18 + knifeCounter), Image), CSng(_x), CSng(_y - 4), 61, 64)
                End If
            Else
                G.DrawImage(CType(normalFrames(direct), Image), CSng(_x), CSng(_y), 61, 64)
            End If
        End If

        ' test attackframes
        'For i As Integer = 0 To knifeFrames.Count - 1
        '    G.DrawImage(CType(knifeFrames(i), Image), i * 40, 0, 61, 64)
        'Next


    End Sub

    Public Sub Update()
        If running Then
            maxSpeed = 3
        Else
            maxSpeed = 1.5
        End If
        _x += _speedX
        _y += _speedY

        If _x < -10 Then
            _x = -10
        ElseIf _x > MainRect.Width - 45 Then
            _x = MainRect.Width - 45
        End If
        If _y < -5 Then
            _y = -5
        ElseIf _y > MainRect.Height - 55 Then
            _y = MainRect.Height - 55
        End If
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
            If Direction < 8 Then
                Direction = 0
            ElseIf Direction < 17 Then
                Direction = 9
            ElseIf Direction < 26 Then
                Direction = 18
            Else
                Direction = 27
            End If
            moving = False
        End If
        If knifing Then
        End If


    End Sub
End Class
