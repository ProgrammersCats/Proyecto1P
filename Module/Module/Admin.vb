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
    Public Sub New(nombre As String, apellido As String, direccion As String, idAdministrador As Integer)
        MyBase.New(nombre, apellido, direccion)
        Me.IdAdmin = idAdministrador
    End Sub

End Class
