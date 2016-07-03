Public Class TipoPagos
    Private _efectivo As Double
    Public Property Efectivo() As Double
        Get
            Return _efectivo
        End Get
        Set(ByVal value As Double)
            _efectivo = value
        End Set
    End Property

    Private _tarjetaCredito As Double
    Public Property TarjetaCredito() As Double
        Get
            Return _tarjetaCredito
        End Get
        Set(ByVal value As Double)
            _tarjetaCredito = value
        End Set
    End Property

    Private _dineroElectronico As Double
    Public Property DineroElectronico() As Double
        Get
            Return _dineroElectronico
        End Get
        Set(ByVal value As Double)
            _dineroElectronico = value
        End Set
    End Property

    Sub New(efectivo As Double, tarjeta As Double, dineroE As Double)
        Me.Efectivo = efectivo
        Me.TarjetaCredito = tarjeta
        Me.DineroElectronico = dineroE

    End Sub

    Sub New()

    End Sub
End Class
