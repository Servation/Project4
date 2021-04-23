Public Class Form1
    Private MainRect As Rectangle
    Private Hero As Player
    Private keysPressed As New HashSet(Of Keys)
    Private counter As Integer = 0
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        StartPlayer()
    End Sub

    Private Sub StartPlayer()
        MainRect = DisplayRectangle
        Hero = New Player(MainRect)
    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim G As Graphics = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Hero.Show(G)
        Hero.Update()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If keysPressed.Contains(Keys.A) And Hero.speedX > -Hero.maxSpeed Then
            Hero.speedX -= 1
            Hero.moving = True
        End If
        If keysPressed.Contains(Keys.D) And Hero.speedX < Hero.maxSpeed Then
            Hero.speedX += 1
            Hero.moving = True
        End If
        If keysPressed.Contains(Keys.W) And Hero.speedY > -Hero.maxSpeed Then
            Hero.speedY -= 1
            Hero.moving = True
        End If
        If keysPressed.Contains(Keys.S) And Hero.speedY < Hero.maxSpeed Then
            Hero.speedY += 1
            Hero.moving = True
        End If
        If counter Mod 1 = 0 And Hero.moving And Hero.Direction < 35 Then
            Hero.Direction += 1
            Debug.WriteLine(Hero.Direction)
        End If
        Invalidate()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        keysPressed.Add(e.KeyCode)
    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        keysPressed.Remove(e.KeyCode)
    End Sub
End Class
