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
        Dim path As String = "C:\Users\Marcitech\Source\Repos\Proyecto1P\Module\Module\tiposPagos.xml"
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
    Public Sub ModificarPagos()
        Dim opcion As String = 0
        Console.WriteLine("Escriba el nombre del tipo de pago que desea modificar: ")
        opcion = Console.ReadLine()
        Select Case opcion
            Case 0

            Case Else
                Console.WriteLine(" Nombre incorrecto ")
        End Select
    End Sub
    Public Overrides Function ToString() As String

        Return "************************** TIPOS DE PAGO ****************************" + vbNewLine +
            "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - " + vbNewLine +
        "| Tipo" + vbTab + vbTab + vbTab + " |" + vbTab + " Valor" + vbTab + " | " + vbNewLine +
        "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - " + vbNewLine +
        "|Efectivo: " + vbTab + vbTab + " |" + vbTab & Me.Efectivo & vbTab + " |" + vbTab + vbNewLine + "|Tarjeta de Credito: " + vbTab + " |" + vbTab & Me.TarjetaCredito & vbTab +
        " |" + vbNewLine + "|Dinero electronico: " + vbTab + " |" + vbTab & Me.DineroElectronico & vbTab + " |" + vbNewLine +
        "......................................................................"
    End Function
End Class
