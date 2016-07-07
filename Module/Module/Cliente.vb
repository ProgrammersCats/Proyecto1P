Public Class Cliente
    Inherits Persona
    Private _idCliente As Integer
    Public Property IdCliente() As String
        Get
            Return _idCliente
        End Get
        Set(ByVal value As String)
            _idCliente = value
        End Set
    End Property

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
        Console.Write("Ingrese direccion:")
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

    End Sub

    Public Overrides Function ToString() As String
        Return "Nombre: " + Me.Nombre + " " + Me.Apellido + vbTab + "RUC: " + Me.Ruc + vbNewLine +
                "Direccion: " + Me.Direccion + vbTab + "Telefono: " + Me.Telefono

    End Function
End Class
