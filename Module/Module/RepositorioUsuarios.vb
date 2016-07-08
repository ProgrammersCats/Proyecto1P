Imports System.Xml

Public Class RepositorioUsuarios
    Dim path As String = "..\..\admin.xml"
    Dim xmlDom As New XmlDocument()
    Private _arrayVendedores As New ArrayList()
    Public Property ArrayVendedores() As ArrayList
        Get
            Return _arrayVendedores
        End Get
        Set(ByVal value As ArrayList)
            _arrayVendedores = value
        End Set
    End Property

    Private _arrayAdmin As New ArrayList()
    Public Property ArrayAdmins() As ArrayList
        Get
            Return _arrayAdmin
        End Get
        Set(ByVal value As ArrayList)
            _arrayAdmin = value
        End Set
    End Property



    Public Sub AgregarVendedor(ven As Vendedor)

        Me.ArrayVendedores.Add(ven)

    End Sub
    Public Sub AgregarAdmin(adm As Admin)

        Me.ArrayAdmins.Add(adm)

    End Sub

    Public Sub CargarDatos()
        xmlDom.Load(path)
        Dim raiz As XmlNodeList = xmlDom.GetElementsByTagName("collection")
        For Each nodo As XmlNode In raiz
            For Each item As XmlNode In nodo.ChildNodes
                Dim usuario, contraseña As String
                Select Case item.Name
                    Case "Vendedor"
                        For Each infoUser As XmlNode In item.ChildNodes

                            Select Case infoUser.Name
                                Case "usuario"
                                    usuario = infoUser.InnerText
                                Case "contraseña"
                                    contraseña = infoUser.InnerText

                            End Select

                        Next
                        Dim ven As New Vendedor(usuario, contraseña)
                        Me.AgregarVendedor(ven)
                    Case "Admin"
                        For Each infoUser As XmlNode In item.ChildNodes

                            Select Case infoUser.Name
                                Case "usuario"
                                    usuario = infoUser.InnerText
                                Case "contraseña"
                                    contraseña = infoUser.InnerText

                            End Select

                        Next
                        Dim adm As New Admin(usuario, contraseña)
                        Me.AgregarAdmin(adm)
                End Select





            Next
        Next
    End Sub
    Public Sub ActualizarXml()
        Dim nodoRaiz As XmlElement = xmlDom.CreateElement("nodoRaiz")
        Dim collection As XmlElement = xmlDom.CreateElement("collection")
        nodoRaiz.AppendChild(collection)
        For Each adm As Admin In Me.ArrayAdmins

            Dim itema As XmlElement = adm.GenerarXml(xmlDom)
            collection.AppendChild(itema)
        Next
        For Each ven As Vendedor In Me.ArrayVendedores

            Dim itemv As XmlElement = ven.GenerarXml(xmlDom)
            collection.AppendChild(itemv)
        Next

        Dim xmlFile As XmlTextWriter = New XmlTextWriter(path, Nothing)
        xmlFile.Formatting = Formatting.Indented
        nodoRaiz.WriteContentTo(xmlFile)
        xmlFile.Close()
    End Sub
    Public Sub MostrarUsuarios()
        For Each adm As Admin In Me.ArrayAdmins
            Console.WriteLine("ADMIN  " + vbTab + "| " + adm.ToString())

        Next
        For Each ven As Vendedor In Me.ArrayVendedores

            Console.WriteLine("VENDEDOR | " + ven.ToString())
        Next

    End Sub
    Public Function ValidarUsuario(usuario As String, contraseña As String)
        For Each adm As Admin In Me.ArrayAdmins
            If (adm.Usuario = usuario) Then
                Return True
            End If

        Next
        For Each ven As Vendedor In Me.ArrayVendedores
            If (ven.Nombre = usuario) Then
                Return True
            End If

        Next
        Return False
    End Function
End Class
