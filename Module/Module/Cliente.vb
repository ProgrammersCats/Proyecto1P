Imports System.Xml

Public Class Cliente
    Inherits Persona


    Private _ruc As String
    Public Property Ruc() As String
        Get
            Return _ruc
        End Get
        Set(ByVal value As String)
            _ruc = value
        End Set
    End Property


    Public Sub New(nombre As String, apellido As String, direccion As String, telefono As String, ruc As String)
        MyBase.New(nombre, apellido, telefono, direccion)

        Me.Ruc = ruc
    End Sub
    Public Sub New()

    End Sub

    Public Sub PedirDatosCliente()
        Console.WriteLine("- Si desea salir digite 0 -")
        Dim nom, ape, dir, tel, ruc As String
        Console.Write("Ingrese nombre:")
        nom = Console.ReadLine()
        If (nom = "0") Then
            Exit Sub
        End If
        Console.Write("Ingrese apellido:")
        ape = Console.ReadLine()
        If (ape = "0") Then
            Exit Sub
        End If
        Console.Write("Ingrese dirección:")
        dir = Console.ReadLine()
        If (dir = "0") Then
            Exit Sub
        End If
        Console.Write("Ingrese RUC:")
        ruc = Console.ReadLine()
        If (ruc = "0") Then
            Exit Sub
        End If
        Console.Write("Ingrese teléfono:")
        tel = Console.ReadLine()
        If (tel = "0") Then
            Exit Sub
        End If

        Me.Nombre = nom
        Me.Apellido = ape
        Me.Ruc = ruc
        Me.Telefono = tel
        Me.Direccion = dir
        Console.WriteLine("* El cliente " + Me.Nombre + " ha sido agregado con éxito *")
    End Sub
    Public Function GenerarXml(xmlDom As XmlDocument) As XmlElement
        Dim item As XmlElement = xmlDom.CreateElement("cliente")
        Dim nombre As XmlElement = xmlDom.CreateElement("nombre")
        Dim apellido As XmlElement = xmlDom.CreateElement("apellido")
        Dim telefono As XmlElement = xmlDom.CreateElement("telefono")
        Dim direccion As XmlElement = xmlDom.CreateElement("direccion")
        Dim ruc As XmlElement = xmlDom.CreateElement("ruc")

        nombre.InnerText = Me.Nombre
        apellido.InnerText = Me.Apellido
        telefono.InnerText = Me.Telefono
        direccion.InnerText = Me.Direccion
        ruc.InnerText = Me.Ruc



        item.AppendChild(nombre)
        item.AppendChild(apellido)
        item.AppendChild(telefono)
        item.AppendChild(direccion)
        item.AppendChild(ruc)
        Return item
    End Function

    Public Overrides Function ToString() As String
        Return "Nombre: " + Me.Nombre + " " + Me.Apellido + vbTab + "RUC: " + Me.Ruc + vbNewLine +
                "Dirección: " + Me.Direccion + vbTab + "Teléfono: " + Me.Telefono

    End Function
End Class
