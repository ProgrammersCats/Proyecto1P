Imports System.Xml

Public Class TipoPagos
    Dim path As String = "E:\Visual\Proyecto1P\Module\Module\tiposPagos.xml"
    Dim xmlDom As New XmlDocument()
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
    Public Sub ModificarPagos(opcion As String)

        Select Case opcion
            Case "1"
                Console.WriteLine("Ingrese nuevo valor para Efectivo:")
                Me.Efectivo = Console.ReadLine()

            Case "2"
                Console.WriteLine("Ingrese nuevo valor para Tarjeta de Credito:")
                Me.TarjetaCredito = Console.ReadLine()
            Case "3"
                Console.WriteLine("Ingrese nuevo valor para Dinero Electronico:")
                Me.DineroElectronico = Console.ReadLine()

            Case Else
                Console.WriteLine(" OPCION INCORRECTA !! ")
        End Select
        Me.ActualizarPago()

    End Sub

    Public Sub ActualizarPago()
        Dim nodoRaiz As XmlElement = xmlDom.CreateElement("nodoRaiz")
        Dim collection As XmlElement = xmlDom.CreateElement("collection")
        nodoRaiz.AppendChild(collection)
        Dim tipo As XmlElement = xmlDom.CreateElement("TipoPago")
        Dim efectivo As XmlElement = xmlDom.CreateElement("efectivo")
        Dim tarjeta As XmlElement = xmlDom.CreateElement("tarjeta_credito")
        Dim dineroE As XmlElement = xmlDom.CreateElement("dinero_electronico")

        efectivo.InnerText = Me.Efectivo
        tarjeta.InnerText = Me.TarjetaCredito
        dineroE.InnerText = Me.DineroElectronico

        tipo.AppendChild(efectivo)
        tipo.AppendChild(tarjeta)
        tipo.AppendChild(dineroE)

        collection.AppendChild(tipo)


        Dim xmlFile As XmlTextWriter = New XmlTextWriter(path, Nothing)
        xmlFile.Formatting = Formatting.Indented
        nodoRaiz.WriteContentTo(xmlFile)
        xmlFile.Close()
        Console.WriteLine(" GUARDADO EXITOSO ")
    End Sub

    Public Overrides Function ToString() As String

        Return "************************** TIPOS DE PAGO ****************************" + vbNewLine +
            "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - " + vbNewLine +
        "| Tipo" + vbTab + vbTab + vbTab + " |" + vbTab + " Valor" + vbTab + " | " + vbNewLine +
        "- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - " + vbNewLine +
        "|1. Efectivo: " + vbTab + vbTab + vbTab + " |" + vbTab & Me.Efectivo & vbTab + " |" + vbTab + vbNewLine + "|2. Tarjeta de Credito: " + vbTab + " |" + vbTab & Me.TarjetaCredito & vbTab +
        " |" + vbNewLine + "|3. Dinero electronico: " + vbTab + " |" + vbTab & Me.DineroElectronico & vbTab + " |" + vbNewLine +
        "......................................................................"
    End Function
End Class
