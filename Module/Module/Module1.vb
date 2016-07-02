Module Module1

    Sub Main()
        'For i As Integer = 0 To 5 Step 1
        '    Console.WriteLine("Te amo mucho")
        '    Console.WriteLine("Te amo muuuuuuucho mas <3")
        'Next

        'Dim fac As New Factura("222222")
        'fac.MostrarFactura()
        'Dim flag1 As String = 0
        Do While (True)
            Console.WriteLine("*************" + vbTab + " INICIAR SESION" + vbTab + "************")
            Console.WriteLine("1. Administrador")
            Console.WriteLine("2. Vendedor")
            Console.WriteLine("3. Salir")
            Console.WriteLine("Eliga una opcion(1-3): ")
            Dim op1 As Short
            op1 = Console.ReadLine()
            Console.WriteLine("***************************************")
            Select Case op1
                Case 1
                    Dim usuario, contraseña As String
                    Console.WriteLine("Usuario:")
                    usuario = Console.ReadLine()
                    Console.WriteLine("Contraseña:")
                    contraseña = Console.ReadLine()
                    Dim adm As New Admin(usuario, contraseña)
                    If (adm.ValidarDatos()) Then
                        Do While (True)
                            Console.WriteLine("==============" + vbTab + "ADMINISTRADOR" + vbTab + "==============")
                            Console.WriteLine("1. Agregar Producto")
                            Console.WriteLine("2. Eliminar Producto")
                            Console.WriteLine("3. Modificar IVA")
                            Console.WriteLine("4. Cerrar Sesion")
                            Console.WriteLine("Eliga una opcion(1-4): ")
                            Dim op2 As Short
                            op2 = Console.ReadLine()
                            Select Case op2
                                Case 1

                                Case 2

                                Case 3

                                Case 4
                                    Exit Do
                                Case Else
                                    Console.WriteLine(" Opcion Incorrecta !! ")
                            End Select
                        Loop
                    Else
                        Console.WriteLine("Usuario o contraseña incorrecta !!")
                    End If

                Case 2

                Case 3
                    'flag1 = flag1 + 1
                    End
                Case Else
                    Console.WriteLine(" Opcion Incorrecta !! ")

            End Select
        Loop



        Console.ReadLine()
        Console.WriteLine("miau skynet")
    End Sub

End Module
