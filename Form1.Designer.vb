<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.shopPanel = New System.Windows.Forms.Panel()
        Me.lblEnergyPrice = New System.Windows.Forms.Label()
        Me.lblHealPrice = New System.Windows.Forms.Label()
        Me.lblStrPrice = New System.Windows.Forms.Label()
        Me.lblEnergyQty = New System.Windows.Forms.Label()
        Me.lblHealQty = New System.Windows.Forms.Label()
        Me.lblStrQty = New System.Windows.Forms.Label()
        Me.lblCoins = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.btnLeave = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnEnergy = New System.Windows.Forms.Label()
        Me.btnHeal = New System.Windows.Forms.Label()
        Me.btnStr = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblTest = New System.Windows.Forms.Label()
        Me.shopPanel.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1
        '
        'shopPanel
        '
        Me.shopPanel.BackColor = System.Drawing.Color.Black
        Me.shopPanel.BackgroundImage = Global.Project4.My.Resources.Resources.insideShop
        Me.shopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.shopPanel.Controls.Add(Me.lblEnergyPrice)
        Me.shopPanel.Controls.Add(Me.lblHealPrice)
        Me.shopPanel.Controls.Add(Me.lblStrPrice)
        Me.shopPanel.Controls.Add(Me.lblEnergyQty)
        Me.shopPanel.Controls.Add(Me.lblHealQty)
        Me.shopPanel.Controls.Add(Me.lblStrQty)
        Me.shopPanel.Controls.Add(Me.lblCoins)
        Me.shopPanel.Controls.Add(Me.PictureBox4)
        Me.shopPanel.Controls.Add(Me.btnLeave)
        Me.shopPanel.Controls.Add(Me.Label8)
        Me.shopPanel.Controls.Add(Me.btnEnergy)
        Me.shopPanel.Controls.Add(Me.btnHeal)
        Me.shopPanel.Controls.Add(Me.btnStr)
        Me.shopPanel.Controls.Add(Me.Label4)
        Me.shopPanel.Controls.Add(Me.lblQty)
        Me.shopPanel.Controls.Add(Me.Label3)
        Me.shopPanel.Controls.Add(Me.Label2)
        Me.shopPanel.Controls.Add(Me.Label1)
        Me.shopPanel.Controls.Add(Me.PictureBox3)
        Me.shopPanel.Controls.Add(Me.PictureBox2)
        Me.shopPanel.Controls.Add(Me.PictureBox1)
        Me.shopPanel.Location = New System.Drawing.Point(466, 150)
        Me.shopPanel.Name = "shopPanel"
        Me.shopPanel.Size = New System.Drawing.Size(600, 600)
        Me.shopPanel.TabIndex = 0
        Me.shopPanel.Visible = False
        '
        'lblEnergyPrice
        '
        Me.lblEnergyPrice.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblEnergyPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblEnergyPrice.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnergyPrice.ForeColor = System.Drawing.Color.White
        Me.lblEnergyPrice.Location = New System.Drawing.Point(390, 238)
        Me.lblEnergyPrice.Name = "lblEnergyPrice"
        Me.lblEnergyPrice.Size = New System.Drawing.Size(80, 24)
        Me.lblEnergyPrice.TabIndex = 22
        Me.lblEnergyPrice.Text = "100"
        Me.lblEnergyPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHealPrice
        '
        Me.lblHealPrice.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblHealPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblHealPrice.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHealPrice.ForeColor = System.Drawing.Color.White
        Me.lblHealPrice.Location = New System.Drawing.Point(255, 238)
        Me.lblHealPrice.Name = "lblHealPrice"
        Me.lblHealPrice.Size = New System.Drawing.Size(80, 24)
        Me.lblHealPrice.TabIndex = 21
        Me.lblHealPrice.Text = "100"
        Me.lblHealPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStrPrice
        '
        Me.lblStrPrice.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblStrPrice.BackColor = System.Drawing.Color.Transparent
        Me.lblStrPrice.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStrPrice.ForeColor = System.Drawing.Color.White
        Me.lblStrPrice.Location = New System.Drawing.Point(125, 238)
        Me.lblStrPrice.Name = "lblStrPrice"
        Me.lblStrPrice.Size = New System.Drawing.Size(80, 24)
        Me.lblStrPrice.TabIndex = 20
        Me.lblStrPrice.Text = "100"
        Me.lblStrPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEnergyQty
        '
        Me.lblEnergyQty.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblEnergyQty.BackColor = System.Drawing.Color.Transparent
        Me.lblEnergyQty.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnergyQty.ForeColor = System.Drawing.Color.White
        Me.lblEnergyQty.Location = New System.Drawing.Point(390, 203)
        Me.lblEnergyQty.Name = "lblEnergyQty"
        Me.lblEnergyQty.Size = New System.Drawing.Size(80, 24)
        Me.lblEnergyQty.TabIndex = 19
        Me.lblEnergyQty.Text = "0"
        Me.lblEnergyQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblHealQty
        '
        Me.lblHealQty.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblHealQty.BackColor = System.Drawing.Color.Transparent
        Me.lblHealQty.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHealQty.ForeColor = System.Drawing.Color.White
        Me.lblHealQty.Location = New System.Drawing.Point(255, 203)
        Me.lblHealQty.Name = "lblHealQty"
        Me.lblHealQty.Size = New System.Drawing.Size(80, 24)
        Me.lblHealQty.TabIndex = 18
        Me.lblHealQty.Text = "0"
        Me.lblHealQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStrQty
        '
        Me.lblStrQty.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblStrQty.BackColor = System.Drawing.Color.Transparent
        Me.lblStrQty.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStrQty.ForeColor = System.Drawing.Color.White
        Me.lblStrQty.Location = New System.Drawing.Point(125, 203)
        Me.lblStrQty.Name = "lblStrQty"
        Me.lblStrQty.Size = New System.Drawing.Size(80, 24)
        Me.lblStrQty.TabIndex = 17
        Me.lblStrQty.Text = "0"
        Me.lblStrQty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCoins
        '
        Me.lblCoins.AutoSize = True
        Me.lblCoins.BackColor = System.Drawing.Color.Transparent
        Me.lblCoins.Font = New System.Drawing.Font("Microsoft YaHei UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoins.ForeColor = System.Drawing.Color.Black
        Me.lblCoins.Location = New System.Drawing.Point(50, 560)
        Me.lblCoins.Name = "lblCoins"
        Me.lblCoins.Size = New System.Drawing.Size(36, 26)
        Me.lblCoins.TabIndex = 16
        Me.lblCoins.Text = "50"
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.Project4.My.Resources.Resources.coin
        Me.PictureBox4.Location = New System.Drawing.Point(12, 556)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 15
        Me.PictureBox4.TabStop = False
        '
        'btnLeave
        '
        Me.btnLeave.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnLeave.BackColor = System.Drawing.Color.Maroon
        Me.btnLeave.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.btnLeave.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLeave.ForeColor = System.Drawing.Color.Black
        Me.btnLeave.Location = New System.Drawing.Point(434, 538)
        Me.btnLeave.Name = "btnLeave"
        Me.btnLeave.Size = New System.Drawing.Size(150, 50)
        Me.btnLeave.TabIndex = 14
        Me.btnLeave.Text = "LEAVE"
        Me.btnLeave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(56, 237)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 19)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Price:"
        '
        'btnEnergy
        '
        Me.btnEnergy.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnEnergy.BackColor = System.Drawing.Color.Maroon
        Me.btnEnergy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.btnEnergy.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEnergy.ForeColor = System.Drawing.Color.Wheat
        Me.btnEnergy.Location = New System.Drawing.Point(400, 281)
        Me.btnEnergy.Name = "btnEnergy"
        Me.btnEnergy.Size = New System.Drawing.Size(60, 30)
        Me.btnEnergy.TabIndex = 12
        Me.btnEnergy.Text = "BUY"
        Me.btnEnergy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnHeal
        '
        Me.btnHeal.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnHeal.BackColor = System.Drawing.Color.Maroon
        Me.btnHeal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.btnHeal.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHeal.ForeColor = System.Drawing.Color.Wheat
        Me.btnHeal.Location = New System.Drawing.Point(265, 281)
        Me.btnHeal.Name = "btnHeal"
        Me.btnHeal.Size = New System.Drawing.Size(60, 30)
        Me.btnHeal.TabIndex = 11
        Me.btnHeal.Text = "BUY"
        Me.btnHeal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStr
        '
        Me.btnStr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnStr.BackColor = System.Drawing.Color.Maroon
        Me.btnStr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.btnStr.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStr.ForeColor = System.Drawing.Color.Wheat
        Me.btnStr.Location = New System.Drawing.Point(135, 281)
        Me.btnStr.Name = "btnStr"
        Me.btnStr.Size = New System.Drawing.Size(60, 30)
        Me.btnStr.TabIndex = 10
        Me.btnStr.Text = "BUY"
        Me.btnStr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("MS PGothic", 48.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(202, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(197, 64)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "SHOP"
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.BackColor = System.Drawing.Color.Transparent
        Me.lblQty.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty.ForeColor = System.Drawing.Color.White
        Me.lblQty.Location = New System.Drawing.Point(67, 202)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(36, 19)
        Me.lblQty.TabIndex = 6
        Me.lblQty.Text = "Qty:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(380, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 19)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Energy Regen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(262, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Full Heal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(125, 107)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Strength +"
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Image = Global.Project4.My.Resources.Resources.icons8_lightning_bolt_80
        Me.PictureBox3.Location = New System.Drawing.Point(400, 129)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 2
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Image = Global.Project4.My.Resources.Resources.icons8_strength_100
        Me.PictureBox2.Location = New System.Drawing.Point(135, 129)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Image = Global.Project4.My.Resources.Resources.icons8_heart_64
        Me.PictureBox1.Location = New System.Drawing.Point(265, 129)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(60, 60)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblTest
        '
        Me.lblTest.AutoSize = True
        Me.lblTest.BackColor = System.Drawing.Color.Transparent
        Me.lblTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTest.ForeColor = System.Drawing.Color.White
        Me.lblTest.Location = New System.Drawing.Point(705, 52)
        Me.lblTest.Name = "lblTest"
        Me.lblTest.Size = New System.Drawing.Size(175, 25)
        Me.lblTest.TabIndex = 1
        Me.lblTest.Text = "Press 'F' to Enter"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Project4.My.Resources.Resources.grass
        Me.ClientSize = New System.Drawing.Size(1584, 961)
        Me.Controls.Add(Me.lblTest)
        Me.Controls.Add(Me.shopPanel)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1600, 1000)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1600, 1000)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.shopPanel.ResumeLayout(False)
        Me.shopPanel.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents shopPanel As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents lblQty As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblCoins As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents btnLeave As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents btnEnergy As Label
    Friend WithEvents btnHeal As Label
    Friend WithEvents btnStr As Label
    Friend WithEvents lblTest As Label
    Friend WithEvents lblEnergyPrice As Label
    Friend WithEvents lblHealPrice As Label
    Friend WithEvents lblStrPrice As Label
    Friend WithEvents lblEnergyQty As Label
    Friend WithEvents lblHealQty As Label
    Friend WithEvents lblStrQty As Label
End Class
