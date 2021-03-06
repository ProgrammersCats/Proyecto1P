﻿Imports System.Xml

Public Class RepositorioProductos
    Dim path As String = "..\..\productos.xml"
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

    Public Function EliminarProductoPorCodigo(cod As String)
        Dim indice As Short = 0
        For Each prod As Producto In ArrayProductos
            If (prod.CodigoProducto = cod) Then
                Me.ArrayProductos.RemoveAt(indice)
                Return True
                Exit For
            End If
            indice = indice + 1

        Next
        Return False
    End Function

    Function BuscarPorCodigo(cod As String)
        For Each prod As Producto In ArrayProductos
            If (prod.CodigoProducto = cod) Then
                Return prod
                Exit For

            End If
        Next
        Return Nothing
    End Function

    Public Sub BucarPorNombre()
        Dim productoBuscar As String
        Dim flag As Boolean = False
        Console.WriteLine("==== BUSCANDO PRODUCTO POR NOMBRE ====")
        Console.WriteLine("Ingrese el nombre del producto:")
        productoBuscar = Console.ReadLine()
        For Each producto As Producto In Me.ArrayProductos
            If (productoBuscar.ToLower() = producto.NombreProducto.ToLower) Then
                Console.WriteLine("Se encontró el producto")
                Console.WriteLine("|    " + "Codigo" + vbTab + "| " + "Costo" + "   |    " + "Precio" + "   |" + vbTab + "Nombre")
                Console.WriteLine("--------------------------------------------------------------")

                Console.WriteLine(producto.ToString())
                flag = True
            End If
        Next
        If (flag = False) Then Console.WriteLine("El producto no está en el inventario")

    End Sub
End Class
