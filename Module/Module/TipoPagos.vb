Imports System.Xml

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

    Public Sub CargarDatos()
        Dim path As String = "E:\Visual\Proyecto1P\Module\Module\tiposPagos.xml"
        Dim xmlDom As New XmlDocument()
        xmlDom.Load(path)
        Dim raiz As XmlNodeList = xmlDom.GetElementsByTagName("collection")
        For Each nodo As XmlNode In raiz
            For Each tipo As XmlNode In nodo.ChildNodes
                For Each datos As XmlNode In tipo.ChildNodes
                    Select Case datos.Name
                        Case "efectivo"
                            Me.Efectivo = datos.InnerText
                        Case "tarjeta_credito"
                            Me.TarjetaCredito = datos.InnerText
                        Case "dinero_electronico"
                            Me.DineroElectronico = datos.InnerText

                    End Select
                Next

            Next
        Next
    End Sub

    Sub New(efectivo As Double, tarjeta As Double, dineroE As Double)
        Me.Efectivo = efectivo
        Me.TarjetaCredito = tarjeta
        Me.DineroElectronico = dineroE

    End Sub

    Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return "| Tipo de pago" + vbTab + vbTab + " |" + vbTab + " Valor" + vbTab + " | " + vbNewLine +
        "|Efectivo: " + vbTab + vbTab + " |" + vbTab & Me.Efectivo & " |" + vbTab + vbNewLine + "|Tarjeta de Credito: " + vbTab + " |" + vbTab & Me.TarjetaCredito & " |" + vbNewLine + "|Dinero electronico: " + vbTab + " |" + vbTab & Me.DineroElectronico & " |"

    End Function
End Class
