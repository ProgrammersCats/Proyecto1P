Imports System.Xml

Module Module1

    Sub Main()
        'For i As Integer = 0 To 5 Step 1
        '    Console.WriteLine("Te amo mucho")
        '    Console.WriteLine("Te amo muuuuuuucho mas <3")
        'Next


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
            Console.Write("Elija una opcion(1-3): ")
            Dim op1 As Short
            op1 = Console.ReadLine()
            Console.WriteLine("*******************************************************************************")
            Select Case op1
                Case 1

                    Console.Write("USUARIO :")
                    usuario = Console.ReadLine()
                    Console.Write("CONTRASEÑA :")
                    contraseña = Console.ReadLine()
                    Dim adm As New Admin(usuario, contraseña)

                    If (adm.ValidarDatos()) Then
                        adm.AsignarRepositorios(repositorioProd, repositorioProv, pagos)
                        Do While (True)
                            Console.WriteLine("================================ " + "ADMINISTRADOR" + " ================================")
                            Console.WriteLine("1.  Agregar Producto")
                            Console.WriteLine("2.  Eliminar Producto")
                            Console.WriteLine("3.  Modificar IVA de provincias")
                            Console.WriteLine("4.  Modificar Tipos de Pago")
                            Console.WriteLine("5.  Cerrar Sesion")
                            Console.Write("Elija una opcion(1-5): ")
                            Dim op2 As Short
                            op2 = Console.ReadLine()
                            Dim pathProd As String = ("E:\Visual\Proyecto1P\Module\Module\productos.xml")
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
                    Console.Write("NOMBRE :")
                    usuario = Console.ReadLine()
                    Console.Write("CONTRASEÑA :")
                    contraseña = Console.ReadLine()
                    Dim vendedor As New Vendedor(usuario, contraseña)
                    If (vendedor.ValidarDatos()) Then
                        Dim cliente1 As Cliente
                        Dim fact As Factura
                        Dim flag = 0
                        Do While (flag = 0)
                            Console.WriteLine("=============================== " + "VENDEDOR" + " ===============================")
                            Console.WriteLine("1.  Pedir datos Cliente")
                            Console.WriteLine("2.  Crear Factura")
                            Console.WriteLine("3.  Buscar producto por nombre")
                            Console.WriteLine("4.  Salir")
                            Console.Write("Elija una opcion(1-4): ")
                            Dim op As Short
                            op = Console.ReadLine()
                            Select Case op
                                Case 1

                                    Console.WriteLine(" /////////// DATOS CLIENTE \\\\\\\\\\\")

                                    cliente1 = New Cliente()
                                    cliente1.PedirDatosCliente()
                                    Console.WriteLine(cliente1.ToString())

                                Case 2
                                    fact = New Factura()

                                    fact.Cliente = cliente1
                                    fact.Vendedor = vendedor

                                    Console.WriteLine("Funco")
                                Case 3
                                Case 4
                                    Exit Select
                                Case Else
                                    Console.WriteLine(" OPCION INCORRECTA !! ")
                            End Select
                        Loop
                    Else
                        Console.WriteLine(" USUARIO O CONTRASEÑA INCORRECTA ")
                    End If



                Case 3
                    End
                Case Else
                    Console.WriteLine(" OPCION INCORRECTA !! ")

            End Select
        Loop



        Console.ReadLine()
        Console.WriteLine("miau skynet")
    End Sub

End Module
