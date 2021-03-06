Public Class Form1
    Private MainRect As Rectangle
    Private Hero As Player
    Private allZomb As Integer = 100
    Private Zombies(allZomb) As Enemy
    Private ZomHit(allZomb) As Attack
    Private Knife As Attack
    Private ShopBuilding As Building
    Private logicalZombie As Integer = 3
    Private keysPressed As New HashSet(Of Keys)
    Private counter As Integer = 0
    Private runMod As Integer = 10
    Private Gen As New Random
    Private shopping As Boolean = False
    Private GameStart As Boolean = False
    Private ShopItems(2) As shop

    Private Declare Function mciSendString Lib "winmm.dll" Alias "mciSendStringA" _
    (ByVal lpstrCommand As String, ByVal lpstrReturnString As String,
    ByVal uReturnLength As Integer, ByVal hwndCallback As Integer) As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DoubleBuffered = True
        Start()
        CopyResourceToDisk()
    End Sub
    Private Sub Start()
        MainRect = DisplayRectangle
        Hero = New Player(MainRect)
        For i As Integer = 0 To Zombies.Count - 1
            Dim loc As Integer = i Mod 4
            If loc = 0 Then
                Zombies(i) = New Enemy(MainRect, MainRect.Width / 2, -60)
            ElseIf loc = 1 Then
                Zombies(i) = New Enemy(MainRect, MainRect.Width / 2, MainRect.Height + 30)
            ElseIf loc = 2 Then
                Zombies(i) = New Enemy(MainRect, MainRect.Width + 20, MainRect.Height / 2)
            Else
                Zombies(i) = New Enemy(MainRect, -20, MainRect.Height / 2)
            End If
            ZomHit(i) = New Attack(MainRect)
        Next
        Knife = New Attack(MainRect)
        ShopBuilding = New Building(MainRect, 800, 230, 0)
        ShopItems(0) = New shop("strPlus")
        lblStrQty.Text = ShopItems(0).Quantity
        lblStrPrice.Text = ShopItems(0).Price
        ShopItems(1) = New shop("fullHeal")
        lblHealQty.Text = ShopItems(1).Quantity
        lblHealPrice.Text = ShopItems(1).Price
        ShopItems(2) = New shop("EnergyRen")
        lblEnergyQty.Text = ShopItems(2).Quantity
        lblEnergyPrice.Text = ShopItems(2).Price

    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim G As Graphics = e.Graphics
        G.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        If GameStart Then
            If Hero.Health > 0 Then
                ShopBuilding.ShowMain(G)
                For i As Integer = 0 To logicalZombie
                    Zombies(i).Show(G)
                    ZomHit(i).Show(G)
                Next
                PlayerBuildCol(ShopBuilding.xBase, ShopBuilding.yBase, 64 * 2, 64 * 2)
                If Not shopping Then
                    Hero.Show(G)
                    Knife.Show(G)
                    ShopBuilding.ShowTop(G)
                End If
            End If
        End If
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If GameStart Then
            If Hero.Health > 0 Then

                If Not shopping Then
                    If keysPressed.Contains(Keys.Space) And Hero.Energy > 10 Then
                        Hero.knifing = True
                        PlaySound("knife.wav")
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
                        Hero.Energy += Hero.EnergyReg
                    End If
                    For i As Integer = 0 To logicalZombie
                        If CirSqrCollision(Zombies(i).cx, Zombies(i).cy, Zombies(i).cRadius, Hero.x, Hero.y, 61, 64) And Zombies(i).visible = True Then
                            If Zombies(i).playZomSound Then
                                PlaySound("zombie.wav")
                                Zombies(i).playZomSound = False
                            End If

                            If zomTB(i) And zomLR(i) Then
                                If Not Zombies(i).moving Then
                                    Zombies(i).isAtk = True
                                    zomAtk(i)
                                End If
                            Else
                                Zombies(i).isAtk = False
                            End If
                            Zombies(i).timer -= 1
                        Else
                            ZombieAI(i)
                            Zombies(i).playZomSound = True
                        End If
                        If counter Mod 10 = 0 And Zombies(i).moving Then
                            Zombies(i).Direction += 1
                        End If
                        zomBuildingCol(i, ShopBuilding.xBase + 10, ShopBuilding.yBase, 64 * 2, 64 * 2)
                        Zombies(i).Update()
                    Next

                    If counter Mod 200 = 0 And logicalZombie < Zombies.Count - 1 Then
                        logicalZombie += 1
                    End If
                    counter += 1
                    Hero.Update()
                    If CirSqrCollision(Hero.x + 15 + 14, Hero.y + 45 + 14, 14, ShopBuilding.xBase + 70, ShopBuilding.yBase + 128, 25, 10) Then
                        lblTest.Visible = True
                        If keysPressed.Contains(Keys.F) Then
                            shopping = True
                            shopPanel.Visible = True
                        End If
                    Else
                        lblTest.Visible = False
                    End If
                End If
                lblCoins.Text = Hero.Coin
            Else
                lblGameOver.Visible = True
                btnStart.Visible = True
                btnStart.Text = "EXIT"
            End If
        End If

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
    Private Sub PlayerBuildCol(xb As Double, yb As Double, w As Double, h As Double)
        If CirSqrCollision(Hero.x + 15 + 14, Hero.y + 45 + 14, 14, xb, yb, w, h) Then
            If CirSqrCollision(Hero.x + 15 + 14, Hero.y + 45 + 14, 14, xb + w - 1, yb, 1, h) Then
                Hero.x = xb + w - 15
            End If
            If CirSqrCollision(Hero.x + 15 + 14, Hero.y + 45 + 14, 14, xb, yb, 1, h) Then
                Hero.x = xb - 15 - 28
            End If
            If CirSqrCollision(Hero.x + 15 + 14, Hero.y + 45 + 14, 14, xb, yb + h - 1, w, 1) Then
                Hero.y = yb + h - 45
            End If
            If CirSqrCollision(Hero.x + 15 + 14, Hero.y + 45 + 14, 14, xb, yb, w, 1) Then
                Hero.y = yb - 45 - 28
            End If

        End If

    End Sub
    Private Sub zomBuildingCol(i As Integer, xb As Double, yb As Double, w As Double, h As Double)
        If CirSqrCollision(Zombies(i).x + 15 + 14, Zombies(i).y + 45 + 14, 14, xb + w - 1, yb, 1, h) Then
            Zombies(i).x = xb + w - 15
        End If
        If CirSqrCollision(Zombies(i).x + 15 + 14, Zombies(i).y + 45 + 14, 14, xb, yb, 1, h) Then
            Zombies(i).x = xb - 15 - 28
        End If
        If CirSqrCollision(Zombies(i).x + 15 + 14, Zombies(i).y + 45 + 14, 14, xb, yb + h - 1, w, 1) Then
            Zombies(i).y = yb + h - 45
        End If
        If CirSqrCollision(Zombies(i).x + 15 + 14, Zombies(i).y + 45 + 14, 14, xb, yb, w, 1) Then
            Zombies(i).y = yb - 45 - 28
        End If
    End Sub
    Private Function zomLR(i As Integer) As Boolean
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
    Private Function zomTB(i As Integer) As Boolean
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
    Private Sub zomAtk(i)
        ZomHit(i).x = Zombies(i).x
        ZomHit(i).y = Zombies(i).y
        Zombies(i).atkCounter = ZomHit(i).atkseq
        If counter Mod 5 = 0 Then
            ZomHit(i).atkseq += 1
        End If
        If RectsCollision(ZomHit(i).xStart, ZomHit(i).yStart, ZomHit(i).Width, ZomHit(i).Height, Hero.x + 15, Hero.y, 30, 60) Then
            Hero.Health -= 0.1
        End If
        If ZomHit(i).atkseq > 5 Then
            ZomHit(i).atkseq = 0
            Zombies(i).isAtk = False
        End If
    End Sub
    Private Sub AttKnife()
        Knife.x = Hero.x
        Knife.y = Hero.y
        Hero.knifeCounter = Knife.atkseq
        If counter Mod 3 = 0 Then
            Knife.atkseq += 1
        End If
        If Knife.atkseq > 5 Then
            For i As Integer = 0 To logicalZombie
                If RectsCollision(Knife.xStart, Knife.yStart, Knife.Width, Knife.Height, Zombies(i).x, Zombies(i).y, Zombies(i).Width, Zombies(i).Height) And Zombies(i).visible Then
                    Zombies(i).Health -= Knife.dmg * Hero.sMultiplier
                    Select Case Knife.direction
                        Case 0
                            Zombies(i).speedY -= 12
                        Case 1
                            Zombies(i).speedY += 12
                        Case 2
                            Zombies(i).speedX -= 12
                        Case 3
                            Zombies(i).speedX += 12
                    End Select
                    If Zombies(i).Health <= 0 Then
                        Hero.Coin += Gen.Next(5, 30)
                        Zombies(i).visible = False
                    End If
                End If
            Next
            Knife.atkseq = 0
            Hero.Energy -= 10
            Hero.knifing = False
        End If
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

    Private Function CirSqrCollision(cx As Double, cy As Double, cRadius As Double, rx As Double, ry As Double, rWidth As Double, rHeight As Double) As Boolean
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

    Private Sub btnLeave_Click(sender As Object, e As EventArgs) Handles btnLeave.Click
        PlaySound("button.wav")
        shopping = False
        shopPanel.Visible = False
        lblTest.Visible = False
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        PlaySound("button.wav")
        If lblGameOver.Visible = False Then
            GameStart = True

            lblGameOver.Visible = False
            btnStart.Visible = False
        Else
            Me.Close()
        End If

    End Sub

    Private Sub btnStr_Click(sender As Object, e As EventArgs) Handles btnStr.Click
        If ShopItems(0).Quantity > 0 And Hero.Coin >= ShopItems(0).Price Then
            PlaySound("button.wav")
            ShopItems(0).Buy()
            lblStrQty.Text = ShopItems(0).Quantity
            Hero.Coin -= ShopItems(0).Price
            Hero.sMultiplier += 0.25
        End If
        If ShopItems(0).Quantity = 0 Then
            lblStrQty.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnHeal_Click(sender As Object, e As EventArgs) Handles btnHeal.Click
        If ShopItems(1).Quantity > 0 And Hero.Coin >= ShopItems(1).Price Then
            PlaySound("button.wav")
            ShopItems(1).Buy()
            lblHealQty.Text = ShopItems(1).Quantity
            Hero.Coin -= ShopItems(1).Price
            Hero.Health = 100
        End If
        If ShopItems(1).Quantity = 0 Then
            lblHealQty.ForeColor = Color.Red
        End If
    End Sub

    Private Sub btnEnergy_Click(sender As Object, e As EventArgs) Handles btnEnergy.Click
        If ShopItems(2).Quantity > 0 And Hero.Coin >= ShopItems(2).Price Then
            PlaySound("button.wav")
            ShopItems(2).Buy()
            lblEnergyQty.Text = ShopItems(2).Quantity
            Hero.Coin -= ShopItems(2).Price
            Hero.EnergyReg += 0.02
        End If
        If ShopItems(2).Quantity = 0 Then
            lblEnergyQty.ForeColor = Color.Red
        End If
    End Sub
    Private Sub PlaySound(s As String)
        Try
            mciSendString("close myWAV" & s, Nothing, 0, 0)

            Dim fileName1 As String = s
            mciSendString("open " & ChrW(34) & fileName1 & ChrW(34) & " type mpegvideo alias myWAV" & s, Nothing, 0, 0)
            mciSendString("play myWAV" & s, Nothing, 0, 0)

            Dim Volume As Integer = 400
            mciSendString("setaudio myWAV" & s & " volume to " & Volume.ToString, Nothing, 0, 0)

        Catch ex As Exception
            Me.Text = ex.Message
        End Try
    End Sub
    Private Sub CopyResourceToDisk()
        If Not IO.File.Exists("button.wav") Then
            Dim bts(CInt(My.Resources.button.Length - 1)) As Byte
            My.Resources.button.Read(bts, 0, bts.Length)
            IO.File.WriteAllBytes("button.wav", bts)
        End If
        If Not IO.File.Exists("knife.wav") Then
            Dim bts(CInt(My.Resources.knife.Length - 1)) As Byte
            My.Resources.knife.Read(bts, 0, bts.Length)
            IO.File.WriteAllBytes("knife.wav", bts)
        End If
        If Not IO.File.Exists("zombie.wav") Then
            Dim bts(CInt(My.Resources.zombie1.Length - 1)) As Byte
            My.Resources.zombie1.Read(bts, 0, bts.Length)
            IO.File.WriteAllBytes("zombie.wav", bts)
        End If
    End Sub
End Class
