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

    Private _detalles As New ArrayList()
    Public Property Detalles() As ArrayList
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
    Public Sub MostrarFactura()
        Dim cli As New Cliente("Paul", "Valle", "Norte", "001", "0985455")
        Dim det As New Detalle("001554")
        Dim lugar As New Provincia()
        Me.LugarEmision = lugar
        Me.Detalles.Add(det)
        Cliente = cli
        Console.WriteLine("--------------------------------------------------------------------------------" +
                            "Id Factura: " + vbTab + Me.NumeroFactura + vbTab + vbTab + vbTab + "Fecha: " + vbTab + Me.Fecha + vbNewLine +
                            "Nombre: " + vbTab + Cliente.Nombre + vbTab + vbTab + vbTab + "RUC: " + vbTab + Cliente.Ruc + vbNewLine +
                            "Direccion: " + vbTab + Cliente.Direccion + vbTab + vbTab + vbTab + "Telefono: " + vbTab + Cliente.Telefono + vbNewLine +
                          "--------------------------------------------------------------------------------" + vbNewLine +
                          "                                    DETALLE                                     " + vbNewLine +
                          "--------------------------------------------------------------------------------" + vbNewLine +
                            "Codigo" + vbTab + vbTab + "Descripcion" + vbTab + "Cantidad" + vbTab + "Precio" + vbTab + vbTab + "Total" + vbNewLine +
                          "================================================================================")
        For Each deta As Detalle In Me.Detalles
            Console.WriteLine(deta.ToString)
        Next
        Console.WriteLine("--------------------------------------------------------------------------------" + vbNewLine +
                            "Subtotal: " & Me.Subtotal & vbTab + vbTab + vbTab + "IVA: " + vbTab & Me.LugarEmision.Iva & vbTab + vbTab + vbTab + "Total: " & Me.Total & vbNewLine +
                          "--------------------------------------------------------------------------------")

    End Sub


End Class
