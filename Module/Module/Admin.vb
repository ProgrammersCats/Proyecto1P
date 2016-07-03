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
    Private _repositorio As RepositorioProductos
    Public Property Repositorio() As RepositorioProductos
        Get
            Return _repositorio
        End Get
        Set(ByVal value As RepositorioProductos)
            _repositorio = value
        End Set
    End Property
    Private _repositorioProvincias As RepositorioProvincias
    Public Property RepositorioProvincias() As RepositorioProvincias
        Get
            Return _repositorioProvincias
        End Get
        Set(ByVal value As RepositorioProvincias)
            _repositorioProvincias = value
        End Set
    End Property

    Public Sub AsignarRepositorio(repositorio As RepositorioProductos)
        Me.Repositorio = repositorio
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

    Public Sub EliminarProducto()
        Dim cod As Short = 0
        Console.WriteLine("Ingrese el codigo del producto a eliminar: ")
        cod = Console.ReadLine()
        Repositorio.EliminarProductoPorCodigo(cod)
    End Sub

    Public Sub AgregarProducto()
        Dim codigo, descripcion, precioFab, pvp As String

        Console.WriteLine(" /////// AGREGAR PRODUCTO \\\\\\\")
        Console.WriteLine("Codigo: ")
        codigo = Console.ReadLine()
        Console.WriteLine("Descripcion: ")
        descripcion = Console.ReadLine()
        Console.WriteLine("Precio de Fabrica: ")
        precioFab = Console.ReadLine()
        Console.WriteLine("PVP: ")
        pvp = Console.ReadLine()
        Dim newProd As New Producto(codigo, descripcion, CDbl(pvp), CDbl(precioFab))
        Me.Repositorio.AgregarProducto(newProd)
        Me.Repositorio.actualizarXml()
    End Sub

End Class
