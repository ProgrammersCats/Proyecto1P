Public Class Producto
    Private _nombreProducto As String
    Public Property NombreProducto As String
        Get
            Return _nombreProducto
        End Get
        Set(ByVal value As String)
            _nombreProducto = value
        End Set
    End Property

    Private _pvp As Double
    Public Property Pvp() As Double
        Get
            Return _pvp
        End Get
        Set(ByVal value As Double)
            _pvp = value
        End Set
    End Property

    Private _precioFabrica As Double
    Public Property PrecioFabrica() As Double
        Get
            Return _precioFabrica
        End Get
        Set(ByVal value As Double)
            _precioFabrica = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(nombreProducto As String, pvp As Double, precioFabrica As Double)
        Me.NombreProducto = nombreProducto
        Me.Pvp = pvp
        Me.PrecioFabrica = precioFabrica
    End Sub
End Class
