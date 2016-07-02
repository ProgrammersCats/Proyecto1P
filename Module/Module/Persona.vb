Public Class Persona
    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(nombre As String, apellido As String)
        Me.Nombre = nombre
        Me.Apellido = apellido
    End Sub


End Class
