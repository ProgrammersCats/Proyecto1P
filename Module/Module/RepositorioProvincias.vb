Imports System.Xml

Public Class RepositorioProvincias

    Dim path As String = "E:\Visual\Proyecto1P\Module\Module\provincias.xml"
    Dim xmlDom As New XmlDocument()

    Private _repositorioProv As ArrayList
    Public Property ArrayProvincias() As ArrayList
        Get
            Return _repositorioProv
        End Get
        Set(ByVal value As ArrayList)
            _repositorioProv = value
        End Set
    End Property
    Public Sub AgregarProvincia(pro As Provincia)

        Me.ArrayProvincias.Add(pro)
        'Me.actualizarXml()
    End Sub
    Public Sub cargarDatos()
        Dim path As String = "E:\Visual\Proyecto1P\Module\Module\provincias.xml"
        Dim xmlDom As New XmlDocument()
        xmlDom.Load(path)
        Dim raiz As XmlNodeList = xmlDom.GetElementsByTagName("collection")
        For Each nodo As XmlNode In raiz
            For Each item As XmlNode In nodo.ChildNodes
                Dim nombre, capital As String
                Dim iva As Double
                For Each infoItem As XmlNode In item.ChildNodes

                    Select Case infoItem.Name
                        Case "nombre"
                            nombre = infoItem.InnerText
                        Case "capital"
                            capital = infoItem.InnerText
                        Case "iva"
                            iva = infoItem.InnerText
                    End Select

                Next
                Dim prov As New Provincia(nombre, capital, CDbl(iva))
                Me.AgregarProvincia(prov)
            Next
        Next
    End Sub
    Public Sub MostrarProvincias()
        Console.WriteLine(" LISTA DE PROVINCIAS **")
        For Each provincia As Provincia In Me.ArrayProvincias
            Console.WriteLine(provincia.ToString() + vbNewLine + "....................................")
        Next
    End Sub

    Public Sub actualizarXml()
        Dim nodoRaiz As XmlElement = xmlDom.CreateElement("nodoRaiz")
        Dim collection As XmlElement = xmlDom.CreateElement("collection")
        nodoRaiz.AppendChild(collection)
        For Each pro As Provincia In Me.ArrayProvincias
            Dim item As XmlElement = pro.GenerarXml(xmlDom)
            collection.AppendChild(item)
        Next


        Dim xmlFile As XmlTextWriter = New XmlTextWriter(path, Nothing)
        xmlFile.Formatting = Formatting.Indented
        nodoRaiz.WriteContentTo(xmlFile)
        xmlFile.Close()
        Console.WriteLine(" GUARDADO EXITOSO ")

    End Sub

End Class