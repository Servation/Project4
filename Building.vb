Public Class Building
    Public Property xBase As Integer
    Public Property yBase As Integer
    Public Property xTop As Integer
    Public Property yTop As Integer
    Public Property type As Integer

    Private size As Integer = 64
    Private MainRect As Rectangle
    Private roofback As Bitmap
    Private roofBL As Bitmap
    Private roofBR As Bitmap
    Private frontR As Bitmap
    Private frontL As Bitmap
    Private door As Bitmap
    Private window As Bitmap
    Private roofTL As Bitmap
    Private roofTR As Bitmap

    Sub New(MainRect As Rectangle, x As Double, y As Double, z As Integer)
        Me.MainRect = MainRect
        _xBase = x
        _yBase = y
        _type = z
        Select Case _type
            Case 0
                roofback = New Bitmap(My.Resources.RoofBrick1)
                roofBL = New Bitmap(My.Resources.RoofBL1)
                roofBR = New Bitmap(My.Resources.RoofBR1)
                frontL = New Bitmap(My.Resources.BrickL1)
                frontR = New Bitmap(My.Resources.BrickR1)
                door = New Bitmap(My.Resources.Door1)
                window = New Bitmap(My.Resources.Window1)
                roofTL = New Bitmap(My.Resources.RoofTL1)
                roofTR = New Bitmap(My.Resources.RoofTR1)
        End Select
    End Sub

    Public Sub ShowMain(G As Graphics)
        Select Case _type
            Case 0
                G.DrawImage(roofback, xBase, yBase, 64, 64)
                G.DrawImage(roofback, xBase + 64, yBase, 64, 64)
                G.DrawImage(roofBL, xBase, yBase, 64, 64)
                G.DrawImage(roofBR, xBase + 64, yBase, 64, 64)
                G.DrawImage(frontL, xBase, yBase + 64, 64, 64)
                G.DrawImage(frontR, xBase + 64, yBase + 64, 64, 64)
                G.DrawImage(door, xBase + 56, yBase + 64, 64, 64)
                G.DrawImage(window, xBase - 5, yBase + 55, 64, 64)
        End Select

    End Sub

    Public Sub ShowTop(G As Graphics)
        Select Case _type
            Case 0
                G.DrawImage(roofTL, xBase, yBase - 64, 64, 64)
                G.DrawImage(roofTR, xBase + 64, yBase - 64, 64, 64)
        End Select
    End Sub
End Class
