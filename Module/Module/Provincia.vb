﻿Public Class Provincia
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

    Public Sub New(nombre As String, capital As String, ivas As Double)
        Me.NombreProvincia = nombre
        Me.Capital = capital
        Me.Iva = Iva
    End Sub
    Public Sub New()

    End Sub
End Class
