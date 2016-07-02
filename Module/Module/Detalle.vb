Public Class Detalle
    Private _item As Producto
    Private _codigo As String
    Public Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property
    Public Property Item() As Producto
        Get
            Return _item
        End Get
        Set(ByVal value As Producto)
            _item = value
        End Set
    End Property

    Private _cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Private _totalDetalle As Double
    Public ReadOnly Property TotalDetalle() As Double
        Get
            Return Me.Cantidad * Me.Item.Pvp
        End Get

    End Property

    Sub New(codigo As String)
        Dim pro As New Producto("Gato", 10.0, 12.0)
        Me.Item = pro
        Me.Codigo = codigo
        Me.Cantidad = 5

    End Sub
    Public Overrides Function ToString() As String
        Return Me.Codigo + vbTab + vbTab + Me.Item.NombreProducto & vbTab + vbTab & Me.Cantidad & vbTab + vbTab & Me.Item.Pvp & vbTab + vbTab & Me.TotalDetalle
    End Function
End Class
