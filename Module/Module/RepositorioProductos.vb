Imports System.Xml

Public Class RepositorioProductos
    Dim path As String = "E:\Visual\Proyecto1P\Module\Module\productos.xml"
    Dim xmlDom As New XmlDocument()

    Private _arrayProductos As New ArrayList()
    Public Property ArrayProductos() As ArrayList
        Get
            Return _arrayProductos
        End Get
        Set(ByVal value As ArrayList)
            _arrayProductos = value
        End Set
    End Property

    Public Sub AgregarProducto(pro As Producto)

        Me.ArrayProductos.Add(pro)

    End Sub

    Public Sub CargarDatos()
        xmlDom.Load(path)
        Dim raiz As XmlNodeList = xmlDom.GetElementsByTagName("collection")
        For Each nodo As XmlNode In raiz
            For Each item As XmlNode In nodo.ChildNodes
                Dim codigo, descripcion, costo, precio As String
                For Each infoItem As XmlNode In item.ChildNodes

                    Select Case infoItem.Name
                        Case "id_producto"
                            codigo = infoItem.InnerText
                        Case "descripcion"
                            descripcion = infoItem.InnerText
                        Case "costo"
                            costo = infoItem.InnerText
                        Case "precio"
                            precio = infoItem.InnerText
                    End Select

                Next
                Dim prod As New Producto(codigo, descripcion, CDbl(precio), CDbl(costo))
                Me.AgregarProducto(prod)
            Next
        Next
    End Sub

    Public Sub MostrarInventario()
        Console.WriteLine("************************** INVENTARIO DE PRODUCTOS ****************************")
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -")
        Console.WriteLine("| Id Producto" + vbTab + "| " + " Costo  |   Precio   |" + vbTab + "Descripción")
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -")
        For Each producto As Producto In Me.ArrayProductos
            Console.WriteLine(producto.ToString())
        Next
        Console.WriteLine("...............................................................................")
    End Sub

    Public Sub ActualizarXml()
        Dim nodoRaiz As XmlElement = xmlDom.CreateElement("nodoRaiz")
        Dim collection As XmlElement = xmlDom.CreateElement("collection")
        nodoRaiz.AppendChild(collection)
        For Each pro As Producto In Me.ArrayProductos
            Dim item As XmlElement = pro.GenerarXml(xmlDom)
            collection.AppendChild(item)
        Next

        Dim xmlFile As XmlTextWriter = New XmlTextWriter(path, Nothing)
        xmlFile.Formatting = Formatting.Indented
        nodoRaiz.WriteContentTo(xmlFile)
        xmlFile.Close()


    End Sub

    Public Sub EliminarProductoPorCodigo(cod As Short)
        Dim indice As Short = 0
        For Each prod As Producto In ArrayProductos
            If (prod.CodigoProducto = cod) Then
                Me.ArrayProductos.RemoveAt(indice)
                Exit For
            End If
            indice = indice + 1
        Next
    End Sub

    Function BuscarPorCodigo(cod As String)
        For Each prod As Producto In ArrayProductos
            If (prod.CodigoProducto = cod) Then
                Return prod
                Exit For

            End If
        Next
        Return Nothing
    End Function


End Class
