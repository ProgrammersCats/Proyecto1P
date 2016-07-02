Imports System.Xml

Public Class Admin
    Inherits Persona
    Private _idAdministrador As Integer
    Public Property IdAdmin() As Integer
        Get
            Return _idAdministrador
        End Get
        Set(ByVal value As Integer)
            _idAdministrador = value
        End Set
    End Property
    Private _usuario As String
    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property
    Private _contraseña As String
    Public Property Contraseña() As String
        Get
            Return _contraseña
        End Get
        Set(ByVal value As String)
            _contraseña = value
        End Set
    End Property
    Public Sub New(usuario As String, contraseña As String)
        Me.Usuario = usuario
        Me.Contraseña = contraseña
    End Sub
    Public Sub New(nombre As String, apellido As String, direccion As String, idAdministrador As Integer)
        MyBase.New(nombre, apellido, direccion)
        Me.IdAdmin = idAdministrador
    End Sub

    Public Function ValidarDatos()
        Dim path As String = "E:\Visual\Proyecto1P\Module\Module\admin.xml"
        Dim XmlDom As New XmlDocument()
        XmlDom.Load(path)
        Dim raiz As XmlNodeList = XmlDom.GetElementsByTagName("collection")
        Dim cont As Short = 0
        For Each nodo As XmlNode In raiz
            For Each admin As XmlNode In nodo.ChildNodes
                For Each datos As XmlNode In admin.ChildNodes
                    Select Case datos.Name
                        Case "usuario"
                            If (Me.Usuario.Contains(datos.InnerText)) Then
                                cont = cont + 1
                            End If

                        Case "contraseña"
                            If (Me.Contraseña.Contains(datos.InnerText)) Then
                                cont = cont + 1
                            End If
                    End Select
                Next
            Next
        Next
        If (cont = 2) Then
            Return True
        End If
        Return False
    End Function
End Class
