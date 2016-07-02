Public Class Cliente
    Inherits Persona
    Private _idCliente As Integer
    Public Property IdCliente() As Integer
        Get
            Return _idCliente
        End Get
        Set(ByVal value As Integer)
            _idCliente = value
        End Set
    End Property
    Public Sub New(nombre As String, apellido As String, idcliente As Integer)
        MyBase.New(nombre, apellido)
        Me.IdCliente = idcliente
    End Sub
End Class
