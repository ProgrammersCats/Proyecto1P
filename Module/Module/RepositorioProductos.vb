Imports System.Xml

Public Class RepositorioProductos
    Private _arrayProductos As New ArrayList()
    Public Property ArrayProductos() As ArrayList
        Get
            Return _arrayProductos
        End Get
        Set(ByVal value As ArrayList)
            _arrayProductos = value
        End Set
    End Property

    Public Sub AgregarProducto(producto As Producto)
        Me.ArrayProductos.Add(producto)
    End Sub

    Public Sub cargarDatos()
        Dim path As String = "E:\Visual\Proyecto1P\Module\Module\productos.xml"
        Dim xmlDom As New XmlDocument()
        xmlDom.Load(path)
        Dim raiz As XmlNodeList = xmlDom.GetElementsByTagName("collection")
        For Each nodo As XmlNode In raiz
            For Each item As XmlNode In nodo.ChildNodes
                Dim codigo, descripcion, precio_fab, pvp As String
                For Each infoItem As XmlNode In item.ChildNodes

                    Select Case infoItem.Name
                        Case "id_producto"
                            codigo = infoItem.InnerText
                        Case "descripcion"
                            descripcion = infoItem.InnerText
                        Case "precio_fabrica"
                            precio_fab = infoItem.InnerText
                        Case "pvp"
                            pvp = infoItem.InnerText
                    End Select

                Next
                Dim prod As New Producto(codigo, descripcion, CDbl(pvp), CDbl(precio_fab))
                Me.AgregarProducto(prod)
            Next
        Next
    End Sub

    Public Sub MostrarInventario()
        Console.WriteLine("********* INVENTARIO DE PRODUCTOS ***********")
        For Each producto As Producto In Me.ArrayProductos
            Console.WriteLine(producto.ToString())
        Next
    End Sub

End Class
