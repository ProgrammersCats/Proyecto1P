Public Class Detalle
    Private _item As Producto
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
            Return Cantidad * _item.Pvp
        End Get

    End Property
End Class
