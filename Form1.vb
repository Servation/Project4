Public Class Form1
    Private MainRect As Rectangle
    Private Hero As Player
    Private Zombies(50) As Enemy
    Private Knife As Attack
    Private logicalZombie As Integer = 0
    Private keysPressed As New HashSet(Of Keys)
    Private counter As Integer = 0
    Private runMod As Integer = 10
    Private attackseq As Integer = 0
    Private Gen As New Random
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        StartPlayer()
    End Sub

    Private Sub StartPlayer()
        MainRect = DisplayRectangle
        Hero = New Player(MainRect)
        For i As Integer = 0 To Zombies.Count - 1
            Dim loc As Integer = i Mod 4
            If loc = 0 Then
                Zombies(i) = New Enemy(MainRect, MainRect.Width / 2, -40)
            ElseIf loc = 1 Then
                Zombies(i) = New Enemy(MainRect, MainRect.Width / 2, MainRect.Height + 30)
            ElseIf loc = 2 Then
                Zombies(i) = New Enemy(MainRect, MainRect.Width + 20, MainRect.Height / 2)
            Else
                Zombies(i) = New Enemy(MainRect, -20, MainRect.Height / 2)
            End If
        Next
        Knife = New Attack(MainRect)
    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim G As Graphics = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        For i As Integer = 0 To logicalZombie
            Zombies(i).Show(G)
        Next
        Hero.Show(G)
        Knife.Show(G)
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If keysPressed.Contains(Keys.Space) And Hero.Energy > 0 Then
            Hero.knifing = True
        End If
        If Hero.knifing = False Then
            Movement()
        Else
            AttKnife()
        End If
        Running()

        If counter Mod runMod = 0 And Hero.moving Then
            Hero.Direction += 1
            If Hero.Energy >= 0 And Hero.running Then
                Hero.Energy -= 0.5
            End If
        End If

        If Hero.Energy < 100 And Not Hero.running Then
            Hero.Energy += 0.1
        End If

        For i As Integer = 0 To logicalZombie
            If RecSqrCollision(Zombies(i).cx, Zombies(i).cy, Zombies(i).cRadius, Hero.x, Hero.y, 61, 64) Then
                If zomTB(i) And zomLR(i) Then
                    ' TODO add zombie attack
                End If
                Zombies(i).timer -= 1
            Else
                ZombieAI(i)
            End If
            If counter Mod 10 = 0 And Zombies(i).moving Then
                Zombies(i).Direction += 1
            End If
            Zombies(i).Update()
        Next

        If counter Mod 500 = 0 And logicalZombie < Zombies.Count - 1 Then
            logicalZombie += 1
        End If
        counter += 1
        Hero.Update()
        Invalidate()
    End Sub

    Private Sub Running()
        If keysPressed.Contains(Keys.ShiftKey) And Hero.Energy > 1 Then
            Hero.running = True
            runMod = 3
        Else
            Hero.running = False
            runMod = 6
        End If
    End Sub

    Private Sub ZombieAI(i As Integer)
        If Zombies(i).timer <= 0 Then
            Zombies(i).timer = Gen.Next(5, 40)
            Zombies(i).directionTime = Gen.Next(0, 8)
        Else
            Zombies(i).enemyAI()
        End If
    End Sub
    Private Function zomTB(i As Integer) As Boolean
        If Zombies(i).cx > Hero.x + 61 And Zombies(i).speedX > -Zombies(i).maxSpeed Then
            Zombies(i).speedX -= 1
            Zombies(i).moving = True
            Return False
        ElseIf Zombies(i).cx < Hero.x And Zombies(i).speedX < Zombies(i).maxSpeed Then
            Zombies(i).speedX += 1
            Zombies(i).moving = True
            Return False
        End If
        Return True
    End Function

    Private Function zomLR(i As Integer) As Boolean
        If Zombies(i).cy > Hero.y + 64 And Zombies(i).speedY > -Zombies(i).maxSpeed Then
            Zombies(i).speedY -= 1
            Zombies(i).moving = True
            Return False
        ElseIf Zombies(i).cy < Hero.y And Zombies(i).speedY < Zombies(i).maxSpeed Then
            Zombies(i).speedY += 1
            Zombies(i).moving = True
            Return False
        End If
        Return True
    End Function

    Private Sub AttKnife()
        Hero.knifeCounter = attackseq
        If counter Mod 3 = 0 Then
            attackseq += 1
        End If
        If attackseq > 5 Then
            For i As Integer = 0 To logicalZombie
                If RectsCollision(Knife.xStart, Knife.yStart, Knife.Width, Knife.Height, Zombies(i).x, Zombies(i).y, Zombies(i).Width, Zombies(i).Height) Then
                    Zombies(i).Health -= Knife.dmg * Hero.sMultiplier
                    Select Case Knife.direction
                        Case 0
                            Zombies(i).speedY -= 8
                        Case 1
                            Zombies(i).speedY += 8
                        Case 2
                            Zombies(i).speedX -= 8
                        Case 3
                            Zombies(i).speedX += 8
                    End Select
                    If Zombies(i).Health <= 0 Then
                        Zombies(i).visible = False
                    End If
                End If
            Next
            attackseq = 0
            Hero.Energy -= 10
            Hero.knifing = False
        End If
        Knife.x = Hero.x
        Knife.y = Hero.y
    End Sub

    Private Sub Movement()
        If keysPressed.Contains(Keys.A) And Hero.speedX > -Hero.maxSpeed And Not keysPressed.Contains(Keys.D) Then
            Hero.speedX -= 1
            Hero.moving = True
            Knife.direction = 2
        End If
        If keysPressed.Contains(Keys.D) And Hero.speedX < Hero.maxSpeed And Not keysPressed.Contains(Keys.A) Then
            Hero.speedX += 1
            Hero.moving = True
            Knife.direction = 3
        End If
        If keysPressed.Contains(Keys.W) And Hero.speedY > -Hero.maxSpeed And Not keysPressed.Contains(Keys.S) Then
            Hero.speedY -= 1
            Hero.moving = True
            If Not (keysPressed.Contains(Keys.A) Or keysPressed.Contains(Keys.D)) Then
                Knife.direction = 0
            End If
        End If
        If keysPressed.Contains(Keys.S) And Hero.speedY < Hero.maxSpeed And Not keysPressed.Contains(Keys.W) Then
            Hero.speedY += 1
            Hero.moving = True
            If Not (keysPressed.Contains(Keys.A) Or keysPressed.Contains(Keys.D)) Then
                Knife.direction = 1
            End If
        End If
    End Sub

    Private Function RectsCollision(r1x As Double, r1y As Double, r1w As Double, r1h As Double, r2x As Double, r2y As Double, r2w As Double, r2h As Double) As Boolean
        Return (r1x + r1w >= r2x And r1x <= r2x + r2w And r1y + r1h >= r2y And r1y <= r2y + r2h)
    End Function

    Private Function RecSqrCollision(cx As Double, cy As Double, cRadius As Double, rx As Double, ry As Double, rWidth As Double, rHeight As Double) As Boolean
        Dim tempX As Double = cx
        Dim tempY As Double = cy

        If cx < rx Then
            tempX = rx
        ElseIf cx > rx + rWidth Then
            tempX = rx + rWidth
        End If
        If cy < ry Then
            tempY = ry
        ElseIf cy > ry + rHeight Then
            tempY = ry + rHeight
        End If

        Dim disX As Double = cx - tempX
        Dim disY As Double = cy - tempY
        Dim distance As Double = Math.Sqrt((disX * disX) + (disY * disY))

        Return distance <= cRadius
    End Function
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        keysPressed.Add(e.KeyCode)
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        keysPressed.Remove(e.KeyCode)
    End Sub
End Class
