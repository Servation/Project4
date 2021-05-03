Public Class Enemy
    Public Property x As Double
    Public Property y As Double
    Public Property speedX As Decimal
    Public Property speedY As Decimal
    Public Property visible As Boolean
    Public Property moving As Boolean
    Public Property maxSpeed As Decimal
    Public Property timer As Integer
    Public Property directionTime As Integer
    Public Property isAtk As Boolean
    Public Property atkCounter As Integer
    Public Property Health As Double
    Public Property cx As Double
    Public Property cy As Double
    Public Property cRadius As Double
    Public Property playZomSound As Boolean
    Private direct As Integer
    Public ReadOnly Property Width As Double = 34
    Public ReadOnly Property Height As Double = 64
    Public Property Direction As Integer
        Get
            Return direct
        End Get
        Set(value As Integer)
            direct = value
        End Set
    End Property
    Private normalFrame(35) As Bitmap
    Private atkFrame(23) As Bitmap
    Private MainRect As Rectangle

    Sub New(MainRect As Rectangle, randX As Integer, randY As Integer)
        Me.MainRect = MainRect
        _x = randX
        _y = randY
        _playZomSound = True
        _maxSpeed = 2
        Direction = 18
        _moving = False
        _Health = 100
        _isAtk = False
        Dim img As New Bitmap(My.Resources.zombie)
        _visible = True
        For i As Integer = 0 To 35
            normalFrame(i) = New Bitmap(62, 63)
            Dim gr As Graphics = Graphics.FromImage(normalFrame(i))
            Dim xPosition As Integer = (i Mod 9) * 64
            gr.DrawImage(img, 0, 0, New RectangleF(xPosition, 505 + (Int(i / 9) * 63), 62, 63), GraphicsUnit.Pixel)
        Next
        For i As Integer = 0 To atkFrame.Count - 1
            atkFrame(i) = New Bitmap(62, 63)
            Dim gr As Graphics = Graphics.FromImage(atkFrame(i))
            Dim xPos As Integer = (i Mod 6) * 63
            gr.DrawImage(img, 0, 0, New RectangleF(xPos, 759 + (Int(i / 6) * 63), 60, 63), GraphicsUnit.Pixel)
        Next
    End Sub
    Public Sub Show(G As Graphics)
        If visible Then
            G.FillEllipse(New SolidBrush(Color.FromArgb(150, 0, 0, 0)), New Rectangle(CSng(_x + 3), CSng(_y + 45), 28, 14))
            cRadius = 150
            cx = _x - 130 + cRadius
            cy = _y - 100 + cRadius
            If _Health < 100 Then
                G.DrawRectangle(New Pen(Color.Black), New Rectangle(CSng(_x - 8), CSng(_y - 10), 50, 10))
                G.FillRectangle(New SolidBrush(Color.DarkRed), New Rectangle(CSng(_x - 8), CSng(_y - 10), _Health / 2, 10))
            End If
            If isAtk Then
                If Direction >= 0 And Direction <= 8 Then
                    G.DrawImage(CType(atkFrame(0 + atkCounter), Image), CSng(_x), CSng(_y - 4), 61, 64)
                ElseIf Direction >= 9 And Direction <= 17 Then
                    G.DrawImage(CType(atkFrame(6 + atkCounter), Image), CSng(_x), CSng(_y - 4), 61, 64)
                ElseIf Direction >= 18 And Direction <= 26 Then
                    G.DrawImage(CType(atkFrame(12 + atkCounter), Image), CSng(_x), CSng(_y - 4), 61, 64)
                ElseIf Direction >= 27 Then
                    G.DrawImage(CType(atkFrame(18 + atkCounter), Image), CSng(_x), CSng(_y - 4), 61, 64)
                End If
            Else
                G.DrawImage(normalFrame(direct), CSng(_x), CSng(_y), 61, 64)
            End If
            ' test atk frames
            'For i As Integer = 0 To atkFrame.Count - 1
            '    G.DrawImage(atkFrame(i), 60 * i, 100, 61, 64)
            'Next
            ' Area where it starts following player
            'G.DrawEllipse(New Pen(Color.Red), New Rectangle(CSng(_x - 130), CSng(_y - 100), 300, 300))
            ' hitbox area 
            'G.DrawRectangle(New Pen(Color.Red), New Rectangle(CSng(_x), CSng(_y), Width, Height))
            ' health bar/pool
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
            If Direction < 8 Then
                Direction = 0
            ElseIf Direction < 17 Then
                Direction = 9
            ElseIf Direction < 26 Then
                Direction = 18
            Else
                Direction = 27
            End If
            _moving = False
        End If
    End Sub
    Public Sub enemyAI()
        If _directionTime = 0 And _speedX > -_maxSpeed Then
            _speedX -= 1
            _moving = True
            _directionTime = If(_x < 20, 1, 0)
        ElseIf _directionTime = 1 And _speedX < _maxSpeed Then
            _speedX += 1
            _moving = True
            _directionTime = If(_x > MainRect.Width - 65, 0, 1)
        ElseIf _directionTime = 2 And _speedY > -_maxSpeed Then
            _speedY -= 1
            moving = True
            _directionTime = If(_y < 20, 3, 2)
        ElseIf _directionTime = 3 And _speedY < _maxSpeed Then
            speedY += 1
            _moving = True
            _directionTime = If(_y > MainRect.Height - 65, 2, 3)
        End If
        _timer -= 1
    End Sub
End Class
