Public Class RepositorioProductos
    Private _arrayProductos As ArrayList
    Public Property ArrayProductos() As ArrayList
        Get
            Return _arrayProductos
        End Get
        Set(ByVal value As ArrayList)
            _arrayProductos = value
        End Set
    End Property

    Public Sub AgregarProducto(producto As Producto)
        Me._arrayProductos.Add(producto)
    End Sub

    Public Sub MostrarInventario()
        Console.WriteLine("********* INVENTARIO DE PRODUCTOS ***********")
        For Each producto As Producto In Me._arrayProductos
            producto.ToString()
        Next
    End Sub

End Class
