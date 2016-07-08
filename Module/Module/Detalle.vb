Imports System.Xml

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
            Return Me.Cantidad * Me.Item.Precio
        End Get

    End Property
    Sub New(item As Producto, cant As Integer)
        Me.Item = item
        Me.Cantidad = cant
    End Sub

    Public Overrides Function ToString() As String
        Return Me.Item.CodigoProducto + vbTab + vbTab + Me.Item.NombreProducto & vbTab + vbTab & Me.Cantidad & vbTab + vbTab & Me.Item.Precio & vbTab + vbTab & Me.TotalDetalle
    End Function

    Public Function GenerarXml(xmlDom As XmlDocument) As XmlNode
        Dim item As XmlElement = xmlDom.CreateElement("detalle")
        Dim codigo As XmlElement = xmlDom.CreateElement("codigo")
        Dim producto As XmlElement = xmlDom.CreateElement("producto")
        Dim cantidad As XmlElement = xmlDom.CreateElement("cantidad")
        Dim totalDetalle As XmlElement = xmlDom.CreateElement("totalDetalle")
        Return item
    End Function
End Class
