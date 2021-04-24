Public Class Form1
    Private MainRect As Rectangle
    Private Hero As Player
    ' zombie test
    Private Zombies(20) As Enemy
    Private keysPressed As New HashSet(Of Keys)
    Private counter As Integer = 0
    Private runMod As Integer = 10
    Private Gen As New Random
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        StartPlayer()
    End Sub

    Private Sub StartPlayer()
        MainRect = DisplayRectangle
        Hero = New Player(MainRect)
        For i As Integer = 0 To Zombies.Count - 1
            Zombies(i) = New Enemy(MainRect)
        Next

    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim G As Graphics = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        For i As Integer = 0 To Zombies.Count - 1
            Zombies(i).Show(G)
            Zombies(i).Update()
        Next

        Hero.Show(G)
        Hero.Update()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        counter += 1
        If keysPressed.Contains(Keys.A) And Hero.speedX > -Hero.maxSpeed And Not keysPressed.Contains(Keys.D) Then
            Hero.speedX -= 1
            Hero.moving = True
        End If
        If keysPressed.Contains(Keys.D) And Hero.speedX < Hero.maxSpeed And Not keysPressed.Contains(Keys.A) Then
            Hero.speedX += 1
            Hero.moving = True
        End If
        If keysPressed.Contains(Keys.W) And Hero.speedY > -Hero.maxSpeed And Not keysPressed.Contains(Keys.S) Then
            Hero.speedY -= 1
            Hero.moving = True
        End If
        If keysPressed.Contains(Keys.S) And Hero.speedY < Hero.maxSpeed And Not keysPressed.Contains(Keys.W) Then
            Hero.speedY += 1
            Hero.moving = True
        End If
        If keysPressed.Contains(Keys.ShiftKey) Then
            Hero.running = True
            runMod = 5
        Else
            Hero.running = False
            runMod = 10
        End If

        If counter Mod runMod = 0 And Hero.moving Then
            Hero.Direction += 1
        End If

        For i As Integer = 0 To Zombies.Count - 1
            If Zombies(i).Timer <= 0 Then
                Zombies(i).Timer = Gen.Next(5, 40)
                Zombies(i).DirectionTime = Gen.Next(0, 8)
            Else
                If Zombies(i).DirectionTime = 0 And Zombies(i).speedX > -Zombies(i).maxSpeed Then
                    Zombies(i).speedX -= 1
                    Zombies(i).moving = True
                    Zombies(i).DirectionTime = If(Zombies(i).x < 20, 1, 0)
                ElseIf Zombies(i).DirectionTime = 1 And Zombies(i).speedX < Zombies(i).maxSpeed Then
                    Zombies(i).speedX += 1
                    Zombies(i).moving = True
                    Zombies(i).DirectionTime = If(Zombies(i).x > MainRect.Width - 65, 0, 1)
                ElseIf Zombies(i).DirectionTime = 2 And Zombies(i).speedY > -Zombies(i).maxSpeed Then
                    Zombies(i).speedY -= 1
                    Zombies(i).moving = True
                    Zombies(i).DirectionTime = If(Zombies(i).y < 20, 3, 2)
                ElseIf Zombies(i).DirectionTime = 3 And Zombies(i).speedY < Zombies(i).maxSpeed Then
                    Zombies(i).speedY += 1
                    Zombies(i).moving = True
                    Zombies(i).DirectionTime = If(Zombies(i).y > MainRect.Height - 65, 2, 3)
                End If
                Zombies(i).Timer -= 1
            End If
            If counter Mod 10 = 0 And Zombies(i).moving Then
                Zombies(i).Direction += 1
            End If
        Next


        Invalidate()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        keysPressed.Add(e.KeyCode)
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        keysPressed.Remove(e.KeyCode)
    End Sub
End Class
