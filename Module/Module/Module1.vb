Imports System.Xml

Module Module1

    Sub Main()
        'For i As Integer = 0 To 5 Step 1
        '    Console.WriteLine("Te amo mucho")
        '    Console.WriteLine("Te amo muuuuuuucho mas <3")
        'Next

        'Dim fac As New Factura("222222")
        'fac.MostrarFactura()
        'Dim flag1 As String = 0
        Dim repositorioProd As New RepositorioProductos()
        Dim repositorioProv As New RepositorioProvincias()
        Dim pagos As New TipoPagos()
        repositorioProd.CargarDatos()
        repositorioProv.CargarDatos()
        pagos.CargarDatos()
        Dim usuario, contraseña As String
        Do While (True)
            Console.WriteLine("****************************   " + "INICIAR SESION" + "   ***************************")
            Console.WriteLine("1.  Administrador")
            Console.WriteLine("2.  Vendedor")
            Console.WriteLine("3.  Salir")
            Console.WriteLine("Elija una opcion(1-3): ")
            Dim op1 As Short
            op1 = Console.ReadLine()
            Console.WriteLine("*******************************************************************************")
            Select Case op1
                Case 1

                    Console.WriteLine("USUARIO :")
                    usuario = Console.ReadLine()
                    Console.WriteLine("CONTRASEÑA :")
                    contraseña = Console.ReadLine()
                    Dim adm As New Admin(usuario, contraseña)

                    If (adm.ValidarDatos()) Then
                        adm.AsignarRepositorios(repositorioProd, repositorioProv, pagos)
                        Do While (True)
                            Console.WriteLine("================================ " + "ADMINISTRADOR" + " ================================")
                            Console.WriteLine("1.  Agregar Producto")
                            Console.WriteLine("2.  Eliminar Producto")
                            Console.WriteLine("3.  Modificar IVA")
                            Console.WriteLine("4.  Modificar Tipos de Pago")
                            Console.WriteLine("5.  Cerrar Sesion")
                            Console.WriteLine("Elija una opcion(1-5): ")
                            Dim op2 As Short
                            op2 = Console.ReadLine()
                            Dim pathProd As String = ("C:\Users\Marcitech\Source\Repos\Proyecto1P\Module\Module\productos.xml")
                            Dim XmlDom As New XmlDocument()
                            Select Case op2

                                Case 1
                                    repositorioProd.MostrarInventario()
                                    adm.AgregarProducto()
                                    repositorioProd.MostrarInventario()
                                Case 2
                                    repositorioProd.MostrarInventario()
                                    adm.EliminarProducto()
                                    repositorioProd.MostrarInventario()
                                Case 3
                                    repositorioProv.MostrarProvincias()
                                    adm.ModificarIva()
                                    repositorioProv.MostrarProvincias()
                                Case 4
                                    Console.WriteLine(pagos.ToString)
                                    adm.ModificarPagos()
                                Case 5
                                    Exit Do
                                Case Else
                                    Console.WriteLine(" OPCION INCORRECTA !! ")
                            End Select
                        Loop
                    Else
                        Console.WriteLine(" USUARIO O CONTRASEÑA INCORRECTA !!")
                    End If

                Case 2
                    Console.WriteLine("=============================== " + "VENDEDOR" + " ===============================")
                    Do While (True)
                        Console.WriteLine("NOMBRE :")
                        usuario = Console.ReadLine()
                        Console.WriteLine("CONTRASEÑA :")
                        contraseña = Console.ReadLine()
                        Dim vendedor As New Vendedor(usuario, contraseña)
                        If (vendedor.ValidarDatos()) Then
                            Dim cliente As New Cliente()
                            cliente.PedirDatosCliente()
                            Dim fact As New Factura()
                            fact.Cliente = cliente
                            fact.Vendedor = vendedor
                            Console.WriteLine("Funco")


                        Else
                            Console.WriteLine(" USUARIO O CONTRASEÑA INCORRECTA ")
                        End If
                    Loop


                Case 3
                    'flag1 = flag1 + 1
                    End
                Case Else
                    Console.WriteLine(" OPCION INCORRECTA !! ")

            End Select
        Loop



        Console.ReadLine()
        Console.WriteLine("miau skynet")
    End Sub

End Module
