Public Class Factura
    Private _numeroFactura As String
    Public Property NumeroFactura As String
        Get
            Return _numeroFactura
        End Get
        Set(ByVal value As String)
            _numeroFactura = value
        End Set
    End Property
    Private _fecha As String
    Public Property Fecha() As String
        Get
            Return _fecha
        End Get
        Set(ByVal value As String)
            _fecha = value
        End Set
    End Property
    Private _cliente As Cliente
    Public Property Cliente() As Cliente
        Get
            Return _cliente
        End Get
        Set(ByVal value As Cliente)
            _cliente = value
        End Set
    End Property

    Private _lugarEmi As Provincia
    Public Property LugarEmision() As Provincia
        Get
            Return _lugarEmi
        End Get
        Set(ByVal value As Provincia)
            _lugarEmi = value
        End Set
    End Property

    Private _detalles As ArrayList
    Public Property Detalle() As ArrayList
        Get
            Return _detalles
        End Get
        Set(ByVal value As ArrayList)
            _detalles = value
        End Set
    End Property

    Private _subtotal As Double
    Public Property Subtotal() As Double
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Double)
            _subtotal = value
        End Set
    End Property

    Private _total As Double
    Public Property Total() As Double
        Get
            Return _total
        End Get
        Set(ByVal value As Double)
            _total = value
        End Set
    End Property

    Public Sub New(numero As String)
        Me.NumeroFactura = numero
    End Sub

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function
End Class
