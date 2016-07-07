Imports System.Xml

Public Class Vendedor
    Inherits Persona

    Private _contraseña As String
    Public Property Contraseña() As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property

    Public Overrides Function ValidarDatos()
        Dim path As String = "E:\Visual\Proyecto1P\Module\Module\admin.xml"
        Dim XmlDom As New XmlDocument()
        XmlDom.Load(path)
        Dim raiz As XmlNodeList = XmlDom.GetElementsByTagName("collection")
        Dim cont As Short = 0
        For Each nodo As XmlNode In raiz
            For Each admin As XmlNode In nodo.ChildNodes
                If (admin.Name.Contains("Vendedor")) Then
                    For Each datos As XmlNode In admin.ChildNodes
                        Select Case datos.Name
                            Case "usuario"
                                If (Me.Nombre.Contains(datos.InnerText)) Then
                                    cont = cont + 1
                                End If
                            Case "contraseña"
                                If (Me.Contraseña.Contains(datos.InnerText)) Then
                                    cont = cont + 1
                                End If
                        End Select
                    Next
                End If
            Next


        Next
        If (cont = 2) Then
            Return True
        End If
        Return False
    End Function

    Sub New(nombre As String, contraseña As String)
        Me.Nombre = nombre
        Me.Contraseña = contraseña
    End Sub
End Class
