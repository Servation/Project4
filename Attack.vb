Public Class Attack
    Public Property x As Double
    Public Property y As Double
    Public Property speedY As Decimal
    Public Property size As Integer
    Public Property visible As Boolean = True
    Public Property direction As Integer
    Public Property dmg As Double
    Private xS As Decimal
    Private yS As Decimal
    Private W As Decimal
    Private H As Decimal

    Private MainRect As Rectangle

    Public ReadOnly Property xStart As Decimal
        Get
            Return xS
        End Get
    End Property
    Public ReadOnly Property yStart As Decimal
        Get
            Return yS
        End Get
    End Property
    Public ReadOnly Property Width As Decimal
        Get
            Return W
        End Get
    End Property
    Public ReadOnly Property Height As Decimal
        Get
            Return H
        End Get
    End Property




    Sub New(MainRect As Rectangle)
        Me.MainRect = MainRect
        _direction = 1
        _dmg = 35
    End Sub

    Public Sub Show(G As Graphics)
        If _visible Then
            ' hitbox test
            Select Case _direction
                Case 0
                    xS = _x
                    yS = _y - 20
                    W = 60
                    H = 30
                Case 1
                    xS = _x
                    yS = _y + 60
                    W = 60
                    H = 30
                Case 2
                    xS = _x - 20
                    yS = _y + 5
                    W = 30
                    H = 60
                Case 3
                    xS = _x + 50
                    yS = _y + 5
                    W = 30
                    H = 60
            End Select
            'G.DrawRectangle(New Pen(Color.Red), New Rectangle(xS, yS, W, H))
        End If

    End Sub

End Class
