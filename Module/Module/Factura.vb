Imports System.Xml
Imports [Module]

Public Class Factura
    Dim path As String = "C:\Users\Marcitech\Source\Repos\Proyecto1P\Module\Module\facturas.xml"
    Dim xmlDom As New XmlDocument()
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
    Private _vendedor As Vendedor
    Public Property Vendedor() As Vendedor
        Get
            Return _vendedor
        End Get
        Set(ByVal value As Vendedor)
            _vendedor = value
        End Set
    End Property

    Public Function GenerarXml(xmlDom As XmlDocument) As XmlElement
        Dim item As XmlElement = xmlDom.CreateElement("factura")
        Dim nroFactura As XmlElement = xmlDom.CreateElement("nroFactura")
        Dim fecha As XmlElement = xmlDom.CreateElement("fecha")
        Dim subtotal As XmlElement = xmlDom.CreateElement("subtotal")
        Dim iva As XmlElement = xmlDom.CreateElement("iva")
        Dim total As XmlElement = xmlDom.CreateElement("total")
        Dim cliente As XmlElement = xmlDom.CreateElement("cliente")

        nroFactura.InnerText = Me.NumeroFactura
        fecha.InnerText = Me.Fecha
        subtotal.InnerText = Me.Subtotal
        iva.InnerText = Me.IVA
        total.InnerText = Me.Total



        item.AppendChild(nroFactura)
        item.AppendChild(fecha)
        item.AppendChild(Me.Cliente.GenerarXml(xmlDom))
        item.AppendChild(subtotal)
        item.AppendChild(iva)
        item.AppendChild(total)
        Return item
    End Function

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
    Public ReadOnly Property Subtotal() As Double
        Get
            Dim subT As Double
            For Each det As Detalle In Me.Detalles
                subT += det.TotalDetalle
            Next
            Return subT
        End Get

    End Property

    Private _total As Double
    Public ReadOnly Property Total() As Double
        Get
            Return Me.IVA + Me.Subtotal
        End Get

    End Property
    Private _iva As Double
    Public ReadOnly Property IVA() As Double
        Get
            Return (Me.LugarEmision.Iva * Me.Subtotal) / 100
        End Get

    End Property
    Private _devolucion As Double
    Public Property Devolucion() As Double
        Get
            Return (_devolucion * Me.Total) / 100
        End Get
        Set(ByVal value As Double)
            _devolucion = value
        End Set
    End Property
    Private _totalPagar As Double
    Public ReadOnly Property TotalPagar() As Double
        Get
            Return Me.Total - Me.Devolucion
        End Get

    End Property

    Public Sub New(numero As String)
        Me.NumeroFactura = numero
    End Sub
    Public Sub New()
        Me.Fecha = Date.Now
        Me.NumeroFactura = 1
    End Sub
    Public Sub MostrarFactura()

        Console.WriteLine("--------------------------------------------------------------------------------" + vbNewLine +
                            "Id Factura: " + vbTab + Me.NumeroFactura + vbTab + vbTab + vbTab + "Fecha: " + vbTab + Me.Fecha + vbNewLine +
                            "Nombre: " + vbTab + Cliente.Nombre + vbTab + vbTab + vbTab + "RUC: " + vbTab + Cliente.Ruc + vbNewLine +
                            "Dirección: " + vbTab + Cliente.Direccion + vbTab + vbTab + vbTab + "Teléfono: " + vbTab + Cliente.Telefono + vbNewLine +
                          "--------------------------------------------------------------------------------" + vbNewLine +
                          "                                    DETALLE                                     " + vbNewLine +
                          "--------------------------------------------------------------------------------" + vbNewLine +
                            "Id" + vbTab + vbTab + "Descripción" + vbTab + "Cantidad" + vbTab + "Precio" + vbTab + vbTab + "Total" + vbNewLine +
                          "================================================================================")
        Me.MostrarDetalles()

    End Sub

    Public Sub AgregarProducto(prod As Producto)

        Dim cantidad As String
        Console.Write("Cantidad: ")
        cantidad = Console.ReadLine()

        Dim detalle As New Detalle(prod, CInt(cantidad))
        Me.Detalles.Add(detalle)

        'Console.Write("Numero incorrecto")

    End Sub
    Public Sub MostrarDetalles()
        For Each deta As Detalle In Me.Detalles
            Console.WriteLine(deta.ToString)
        Next
        Console.WriteLine("--------------------------------------------------------------------------------" + vbNewLine +
                            "Subtotal: " & vbTab & Me.Subtotal & vbNewLine + "IVA: " + vbTab + vbTab & Me.IVA & vbNewLine + "Total: " + vbTab + vbTab & Me.Total & vbNewLine +
                            "Devolución: " + vbTab & Me.Devolucion & vbNewLine + "Total a pagar: " + vbTab & Me.TotalPagar & vbNewLine +
                          "--------------------------------------------------------------------------------")
    End Sub
End Class
