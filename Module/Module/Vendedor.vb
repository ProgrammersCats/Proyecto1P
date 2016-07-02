Public Class Vendedor
    Inherits Persona
    Private _idVendedor As String
    Public Property NewProperty() As String
        Get
            Return _idVendedor
        End Get
        Set(ByVal value As String)
            _idVendedor = value
        End Set
    End Property

End Class
