Imports System.Data.OleDb

Public Class shop
    Public ReadOnly Property Name As String
    Public ReadOnly Property Price As Integer
    Private intQuantity As Integer

    Public ReadOnly Property Quantity As Integer
        Get
            Dim ConnectionString As String = "Provider = Microsoft.Jet.OLEDB.4.0;" & "Data Source = ShopItems.mdb"
            Dim SQLStatement = "SELECT Items.Quantity
                            FROM Items
                            WHERE (((Items.Name)='" & _Name & "'));"
            Dim ds = New DataSet()
            Dim oledbAdapter = New OleDbDataAdapter(SQLStatement, ConnectionString)
            oledbAdapter.Fill(ds)
            oledbAdapter.Dispose()
            intQuantity = ds.Tables(0).Rows(0).ItemArray(0)
            Return intQuantity
        End Get
    End Property

    Public Sub New(name As String)
        _Name = name
        Dim ConnectionString As String = "Provider = Microsoft.Jet.OLEDB.4.0;" & "Data Source = ShopItems.mdb"
        Dim SQLStatement = "SELECT Items.Price, Items.Quantity
                            FROM Items
                            WHERE (((Items.Name)='" & _Name & "'));"
        Dim ds = New DataSet()
        Dim oledbAdapter = New OleDbDataAdapter(SQLStatement, ConnectionString)
        oledbAdapter.Fill(ds)
        oledbAdapter.Dispose()
        _Price = ds.Tables(0).Rows(0).ItemArray(0)
        intQuantity = ds.Tables(0).Rows(0).ItemArray(1)
    End Sub

    Public Sub Buy()
        'Dim Connection As OleDbConnection = New OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;" & "Data Source = ShopItems.mdb")
        'Dim SQLStatement = "UPDATE Items SET Items.Quantity = [Quantity]-1
        '                    WHERE (((Items.Name)='" & _Name & "'));"
        'Dim command = New OleDbCommand(SQLStatement, Connection)
        'Dim dataAdapter = New OleDbDataAdapter()
        'dataAdapter.UpdateCommand = command

        Dim ConnectionString As String = "Provider = Microsoft.Jet.OLEDB.4.0;" & "Data Source = ShopItems.mdb"
        Dim SQLStatement = "UPDATE Items SET Items.Quantity = [Quantity]-1
                            WHERE (((Items.Name)='" & _Name & "'));"
        Dim ds = New DataSet()
        Dim oledbAdapter = New OleDbDataAdapter(SQLStatement, ConnectionString)
        oledbAdapter.Fill(ds)
        oledbAdapter.Dispose()
    End Sub

End Class
