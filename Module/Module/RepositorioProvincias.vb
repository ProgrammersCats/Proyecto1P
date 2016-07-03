Public Class RepositorioProvincias
    Private _repositorioProv As ArrayList
    Public Property ArrayProvincias() As ArrayList
        Get
            Return _repositorioProv
        End Get
        Set(ByVal value As ArrayList)
            _repositorioProv = value
        End Set
    End Property
End Class
