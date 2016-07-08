Imports System.Xml

Public Class RepositorioFactura
    Dim path As String = "E:\Visual\Proyecto1P\Module\Module\facturas.xml"
    Dim xmlDom As New XmlDocument()

    Private _arrayFacturas As New ArrayList()
    Public Property ArrayFacturas() As ArrayList
        Get
            Return _arrayFacturas
        End Get
        Set(ByVal value As ArrayList)
            _arrayFacturas = value
        End Set
    End Property

    Public Sub AgregarFactura(fact As Factura)

        Me.ArrayFacturas.Add(fact)

    End Sub


    Public Sub ActualizarXml()
        Dim nodoRaiz As XmlElement = xmlDom.CreateElement("nodoRaiz")
        Dim collection As XmlElement = xmlDom.CreateElement("collection")
        nodoRaiz.AppendChild(collection)
        For Each fact As Factura In Me.ArrayFacturas
            Dim item As XmlElement = fact.GenerarXml(xmlDom)
            collection.AppendChild(item)
        Next

        Dim xmlFile As XmlTextWriter = New XmlTextWriter(path, Nothing)
        xmlFile.Formatting = Formatting.Indented
        nodoRaiz.WriteContentTo(xmlFile)
        xmlFile.Close()


    End Sub
    Public Sub MostrarFacturas()
        For Each fact As Factura In ArrayFacturas
            Console.WriteLine("===================================================")
            fact.MostrarFactura()
        Next
    End Sub
End Class
