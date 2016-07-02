﻿Public Class Producto
    Private _nombreProducto As String
    Private _codigoProd As String
    Public Property CodigoProducto() As String
        Get
            Return _codigoProd
        End Get
        Set(ByVal value As String)
            _codigoProd = value
        End Set
    End Property
    Public Property NombreProducto As String
        Get
            Return _nombreProducto
        End Get
        Set(ByVal value As String)
            _nombreProducto = value
        End Set
    End Property

    Private _pvp As Double
    Public Property Pvp() As Double
        Get
            Return _pvp
        End Get
        Set(ByVal value As Double)
            _pvp = value
        End Set
    End Property

    Private _precioFabrica As Double
    Public Property PrecioFabrica() As Double
        Get
            Return _precioFabrica
        End Get
        Set(ByVal value As Double)
            _precioFabrica = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Sub New(codigo As String, nombreProducto As String, pvp As Double, precioFabrica As Double)
        Me.CodigoProducto = codigo
        Me.NombreProducto = nombreProducto
        Me.Pvp = pvp
        Me.PrecioFabrica = precioFabrica
    End Sub

    Public Overrides Function ToString() As String
        Return "Codigo: " + vbTab + Me.CodigoProducto + vbNewLine + "Descripcion: " + vbTab + Me.NombreProducto +
                    vbNewLine + "Precio Fabrica:" & Me.PrecioFabrica & vbNewLine + "PVP:" & Me.Pvp

    End Function
End Class
