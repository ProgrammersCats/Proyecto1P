Imports System.Xml

Module Module1

    Sub Main()
        'For i As Integer = 0 To 5 Step 1
        '    Console.WriteLine("Te amo mucho")
        '    Console.WriteLine("Te amo muuuuuuucho mas <3")
        'Next


        Dim repositorioProd As New RepositorioProductos()
        Dim repositorioProv As New RepositorioProvincias()
        Dim repositorioFact As New RepositorioFactura()
        Dim pagos As New TipoPagos()
        repositorioProd.CargarDatos()
        repositorioProv.CargarDatos()
        pagos.CargarDatos()
        Dim usuario, contraseña As String
        Dim contadorFactura As Integer
        Do While (True)

            Console.WriteLine("****************************   " + "INICIAR SESIÓN" + "   ***************************")
            Console.WriteLine("1.  Administrador")
            Console.WriteLine("2.  Vendedor")
            Console.WriteLine("3.  Salir")
            Console.Write("Elija una opcion(1-3): ")
            Dim op1 As String
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
                        adm.AsignarRepositorios(repositorioProd, repositorioProv, pagos, repositorioFact)
                        Do While (True)

                            Console.WriteLine("================================ " + "ADMINISTRADOR" + " ================================")
                            Console.WriteLine("1.  Agregar Producto")
                            Console.WriteLine("2.  Eliminar Producto")
                            Console.WriteLine("3.  Modificar IVA de provincias")
                            Console.WriteLine("4.  Modificar Tipos de Pago")
                            Console.WriteLine("5.  Cerrar Sesión")
                            Console.WriteLine("6. Mostrar Reporte de Ventas")
                            Console.Write("Elija una opción(1-6): ")
                            Dim op2 As String
                            op2 = Console.ReadLine()

                            Select Case op2


                                Case 1

                                    adm.AgregarProducto()
                                    Salir()
                                Case 2
                                    adm.EliminarProducto()

                                    Salir()
                                Case 3

                                    adm.ModificarIva()
                                    Salir()
                                Case 4
                                    Console.WriteLine(pagos.ToString)
                                    adm.ModificarPagos()
                                    Salir()
                                Case 5
                                    Salir()
                                    Exit Do
                                Case 6
                                    adm.MostrarReporteVentas()
                                Case Else
                                    Console.WriteLine("* OPCIÓN INCORRECTA !! *")
                                    Salir()
                            End Select
                        Loop
                    Else
                        Console.WriteLine("* USUARIO O CONTRASEÑA INCORRECTA *")
                        Salir()
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

                            Console.WriteLine("============================ " + "VENDEDOR" + " ============================")
                            Console.WriteLine("1.  Pedir datos del cliente")
                            Console.WriteLine("2.  Crear Factura")
                            Console.WriteLine("3.  Buscar producto por nombre")
                            Console.WriteLine("4.  Mostrar facturas")
                            Console.WriteLine("5.  Salir")
                            Console.Write("Elija una opción(1-5): ")
                            Dim op As String
                            op = Console.ReadLine()
                            Select Case op
                                Case 4
                                    repositorioFact.MostrarFacturas()
                                    Salir()
                                Case 1

                                    Console.WriteLine(" /////////// DATOS CLIENTE \\\\\\\\\\\")

                                    cliente1 = New Cliente()
                                    If (cliente1.PedirDatosCliente()) Then
                                    Else
                                        Console.WriteLine("* No se agregó ningun cliente *")

                                        cliente1 = Nothing
                                    End If

                                    Salir()
                                Case 2
                                    Console.WriteLine(" /////////// FACTURACIÓN \\\\\\\\\\\")

                                    fact = New Factura()

                                    If cliente1 Is Nothing Then
                                        Console.WriteLine("** Primero ingrese los datos del cliente **")
                                        Salir()
                                    Else
                                        fact.Cliente = cliente1
                                        Dim flagProv As Boolean = True
                                        Do While (flagProv)
                                            Dim provincia As String
                                            Console.Write("Ingrese el lugar de emisión (Provincia): ")
                                            provincia = Console.ReadLine()
                                            If (repositorioProv.ValidarProvincia(provincia) Is Nothing) Then
                                                Console.WriteLine("* No existe esa provincia")
                                            Else
                                                fact.LugarEmision = repositorioProv.ValidarProvincia(provincia)
                                                flagProv = False
                                            End If
                                        Loop


                                        fact.Vendedor = vendedor
                                        fact.LugarEmision = repositorioProv.ArrayProvincias.Item(0)
                                        Dim flagItems As Boolean = True
                                        Do While (flagItems)
                                            Dim opVender As Integer
                                            Console.WriteLine("¿Desea agregar un producto?")
                                            Console.WriteLine("1. Si")
                                            Console.WriteLine("0. Cancelar")
                                            Console.Write("Eliga una opción: ")
                                            opVender = Console.ReadLine()
                                            If opVender = 1 Then
                                                Dim cod As String
                                                Console.Write("Ingrese código de producto: ")
                                                cod = Console.ReadLine()
                                                If (repositorioProd.BuscarPorCodigo(cod) Is Nothing) Then
                                                    Console.WriteLine("* No existe un producto con ese código *")
                                                    Salir()
                                                Else
                                                    Dim prod As Producto
                                                    prod = repositorioProd.BuscarPorCodigo(cod)
                                                    fact.AgregarProducto(prod)
                                                    'fact.MostrarDetalles()
                                                    Salir()
                                                End If
                                            Else
                                                flagItems = False
                                                'Salir()
                                            End If
                                        Loop
                                        Dim flagGuardar As Boolean = True
                                        Do While (flagGuardar)
                                            Dim guardar As String
                                            Console.WriteLine("¿Desea guardar la factura?")
                                            Console.WriteLine("1. Si")
                                            Console.WriteLine("0. No")
                                            Console.Write("Eliga una opción: ")
                                            guardar = Console.ReadLine()
                                            Select Case guardar
                                                Case 1
                                                    Console.WriteLine(pagos.ToString())
                                                    fact.Devolucion = pagos.ElegirTipoPago()
                                                    fact.NumeroFactura = contadorFactura
                                                    repositorioFact.AgregarFactura(fact)
                                                    repositorioFact.ActualizarXml()
                                                    flagGuardar = False
                                                    contadorFactura += 1
                                                    Console.WriteLine("* FACTURA GUARDADA CON ÉXITO *")
                                                    fact.MostrarFactura()
                                                    Salir()
                                                Case 0
                                                    Console.WriteLine("* No se guardó la factura *")
                                                    flagGuardar = False
                                                    Salir()
                                                Case Else
                                                    Console.WriteLine("* OPCIÓN INCORRECTA *")
                                                    Salir()
                                            End Select
                                        Loop
                                    End If
                                Case 3
                                    repositorioProd.BucarPorNombre()
                                    Salir()
                                Case 5
                                    flag = 1
                                    Console.Clear()
                                    Exit Select

                                Case Else
                                    Console.WriteLine("* OPCIÓN INCORRECTA !! *")
                                    Salir()
                            End Select
                        Loop
                    Else

                        Console.WriteLine("* USUARIO O CONTRASEÑA INCORRECTA *")
                        Salir()
                    End If



                Case 3
                    Salir()
                    End
                Case Else
                    Console.WriteLine(" * OPCIÓN INCORRECTA !! *")
                    Salir()

            End Select
        Loop



        Console.ReadLine()
        Console.WriteLine("miau skynet")
    End Sub
    Sub Salir()
        Console.WriteLine("Presione Enter para continuar....")
        Console.ReadLine()
        Console.Clear()
    End Sub
End Module
