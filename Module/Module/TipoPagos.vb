Imports System.Xml

Public Class TipoPagos
    Dim path As String = "..\..\tiposPagos.xml"
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

    Private _tarjeta As Double
    Public Property Tarjeta() As Double
        Get
            Return _tarjeta
        End Get
        Set(ByVal value As Double)
            _tarjeta = value
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
                        Case "tarjeta"
                            Me.Tarjeta = datos.InnerText
                        Case "dinero_electronico"
                            Me.DineroElectronico = datos.InnerText

                    End Select
                Next

            Next
        Next
    End Sub

    Sub New(efectivo As Double, tarjeta As Double, dineroE As Double)
        Me.Efectivo = efectivo
        Me.Tarjeta = tarjeta
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
                Console.WriteLine("Ingrese nuevo valor para Tarjeta:")
                Me.Tarjeta = Console.ReadLine()
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
        Dim tarjeta As XmlElement = xmlDom.CreateElement("tarjeta")
        Dim dineroE As XmlElement = xmlDom.CreateElement("dinero_electronico")

        efectivo.InnerText = Me.Efectivo
        tarjeta.InnerText = Me.Tarjeta
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
        "|1. Efectivo: " + vbTab + vbTab + vbTab + " |  " & Me.Efectivo & vbTab + " |" + vbTab + vbNewLine + "|2. Tarjeta:                " + vbTab + " |  " & Me.Tarjeta & vbTab +
        " |" + vbNewLine + "|3. Dinero electronico: " + vbTab + " |  " & Me.DineroElectronico & vbTab + " |" + vbNewLine +
        "......................................................................"
    End Function

    Public Function ElegirTipoPago()
        Dim devolucion As Double
        Do While (True)
            Dim opPago As Integer
            Console.Write("Eliga un tipo de pago:")
            opPago = Console.ReadLine()
            Select Case opPago
                Case 1
                    devolucion = Me.Efectivo
                    Exit Do
                Case 2
                    devolucion = Me.Tarjeta
                    Exit Do
                Case 3
                    devolucion = Me.DineroElectronico
                    Exit Do
                Case Else
                    Console.WriteLine("Opcion no válida")
            End Select
        Loop
        Return devolucion
    End Function
End Class
