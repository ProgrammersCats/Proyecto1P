Imports System.Xml

Public Class Provincia
    Private _idProvincia As String
    Public Property IdProvincia() As String
        Get
            Return _idProvincia
        End Get
        Set(ByVal value As String)
            _idProvincia = value
        End Set
    End Property
    Private _nombreProvincia As String
    Public Property NombreProvincia() As String
        Get
            Return _nombreProvincia
        End Get
        Set(ByVal value As String)
            _nombreProvincia = value
        End Set
    End Property

    Private _capital As String
    Public Property Capital As String
        Get
            Return _capital
        End Get
        Set(ByVal value As String)
            _capital = value
        End Set
    End Property

    Private _iva As Double
    Public Property Iva() As Double
        Get
            Return _iva
        End Get
        Set(ByVal value As Double)
            _iva = value
        End Set
    End Property

    Public Sub New(id As String, nombre As String, capital As String, ivas As Double)
        Me.IdProvincia = id
        Me.NombreProvincia = nombre
        Me.Capital = capital
        Me.Iva = ivas
    End Sub
    Public Sub New()

    End Sub

    Public Overrides Function ToString() As String
        Return "| " + Me.IdProvincia + vbTab & Me.Iva & "%" + vbTab + vbTab + vbTab + vbTab + vbTab + Me.NombreProvincia + "   |"
    End Function

    Public Function GenerarXml(xmlDom As XmlDocument)
        Dim provincia As XmlElement = xmlDom.CreateElement("provincia")
        Dim id As XmlElement = xmlDom.CreateElement("id")
        Dim nombre As XmlElement = xmlDom.CreateElement("nombre")
        Dim capital As XmlElement = xmlDom.CreateElement("capital")
        Dim iva As XmlElement = xmlDom.CreateElement("iva")

        id.InnerText = Me.IdProvincia
        nombre.InnerText = Me.NombreProvincia
        capital.InnerText = Me.Capital
        iva.InnerText = Me.Iva

        provincia.AppendChild(id)
        provincia.AppendChild(nombre)
        provincia.AppendChild(capital)
        provincia.AppendChild(iva)
        Return provincia
    End Function
End Class
