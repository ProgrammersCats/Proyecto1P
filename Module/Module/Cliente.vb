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
End Class
