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


    Public Sub New(nombre As String, apellido As String, direccion As String, idcliente As String, ruc As String)
        MyBase.New(nombre, apellido, direccion)
        Me.IdCliente = idcliente
        Me.Ruc = ruc
    End Sub
    Public Sub New()

    End Sub

    Public Sub PedirDatosCliente()
        Console.WriteLine(" /////  DATOS CLIENTE \\\\\")
        Console.WriteLine("Ingrese nombre:")
        Me.Nombre = Console.ReadLine()
        Console.WriteLine("Ingrese apellido:")
        Me.Apellido = Console.ReadLine()
        Console.WriteLine("Ingrese direccion:")
        Me.Direccion = Console.ReadLine()
        Console.WriteLine("Ingrese RUC:")
        Me.Ruc = Console.ReadLine()
        Console.WriteLine("Ingrese teléfono:")
        Me.Telefono = Console.ReadLine()
    End Sub
End Class
