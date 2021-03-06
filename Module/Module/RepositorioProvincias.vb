﻿Imports System.Xml

Public Class RepositorioProvincias

    Dim path As String = "..\..\provincias.xml"
    Dim xmlDom As New XmlDocument()

    Private _repositorioProv As New ArrayList()
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
    Public Sub CargarDatos()

        xmlDom.Load(path)
        Dim raiz As XmlNodeList = xmlDom.GetElementsByTagName("collection")
        For Each nodo As XmlNode In raiz
            For Each item As XmlNode In nodo.ChildNodes
                Dim id, nombre, capital As String
                Dim iva As Double
                For Each infoItem As XmlNode In item.ChildNodes

                    Select Case infoItem.Name
                        Case "id"
                            id = infoItem.InnerText
                        Case "nombre"
                            nombre = infoItem.InnerText
                        Case "capital"
                            capital = infoItem.InnerText
                        Case "iva"
                            iva = infoItem.InnerText
                    End Select

                Next
                Dim prov As New Provincia(id, nombre, capital, CDbl(iva))
                Me.AgregarProvincia(prov)
            Next
        Next
    End Sub
    Public Sub MostrarProvincias()
        Console.WriteLine("************************** LISTA DE PROVINCIAS ****************************")
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ")
        Console.WriteLine("|" + "ID  |" + vbTab + " IVA % " + vbTab + " |  NOMBRE   ")
        Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ")
        For Each provincia As Provincia In Me.ArrayProvincias
            Console.WriteLine(provincia.ToString())
        Next
        Console.WriteLine("...............................................................................")
    End Sub

    Public Sub ActualizarXml()
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
    End Sub


    Function ValidarProvincia(provincia As String)
        For Each provi As Provincia In Me.ArrayProvincias
            If (provi.NombreProvincia.ToLower = provincia.ToLower) Then
                Return provi
                Exit For

            End If
        Next
        Return Nothing
    End Function
    Function ValidarProvinciaPorCod(cod As String)
        For Each provi As Provincia In Me.ArrayProvincias
            If (provi.IdProvincia = cod) Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function

End Class