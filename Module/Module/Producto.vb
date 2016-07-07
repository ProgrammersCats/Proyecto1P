Imports System.Xml

Public Class Producto
    Private _nombreProducto As String
    Private _codigoProd As String
    Public Property CodigoProducto() As String
        Get
            Return _codigoProd
        End Get
        Set(ByVal value As String)
            _codigoProd = value
        End Set
    End Property
    Public Property NombreProducto As String
        Get
            Return _nombreProducto
        End Get
        Set(ByVal value As String)
            _nombreProducto = value
        End Set
    End Property

    Private _precio As Double
    Public Property Precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property

    Private _costo As Double
    Public Property Costo() As Double
        Get
            Return _costo
        End Get
        Set(ByVal value As Double)
            _costo = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(codigo As String, nombreProducto As String, precio As Double, costo As Double)
        Me.CodigoProducto = codigo
        Me.NombreProducto = nombreProducto
        Me.Precio = precio
        Me.Costo = costo
    End Sub

    Public Overrides Function ToString() As String
        Return "|    " + Me.CodigoProducto + vbTab + "|    " & Me.Costo & vbTab + "  |    " & Me.Precio & vbTab + "|" + vbTab + Me.NombreProducto

    End Function

    Public Function GenerarXml(xmlDom As XmlDocument)
        Dim item As XmlElement = xmlDom.CreateElement("Item")
        Dim codigo As XmlElement = xmlDom.CreateElement("id_producto")
        Dim descripcion As XmlElement = xmlDom.CreateElement("descripcion")
        Dim costo As XmlElement = xmlDom.CreateElement("costo")
        Dim precio As XmlElement = xmlDom.CreateElement("precio")

        codigo.InnerText = Me.CodigoProducto
        descripcion.InnerText = Me.NombreProducto
        costo.InnerText = Me.Costo
        precio.InnerText = Me.Precio

        item.AppendChild(codigo)
        item.AppendChild(descripcion)
        item.AppendChild(costo)
        item.AppendChild(precio)
        Return item
    End Function
End Class
