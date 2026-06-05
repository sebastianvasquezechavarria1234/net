using System;
using System.Globalization;

namespace BodyCheck
{
    internal class Program
    {
        static (string nombre, float valor) SeleccionarPlan()
        {
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine(" Selecciona un plan de mensualidad:");
            Console.WriteLine("  1 - Black ($90.000)");
            Console.WriteLine("  2 - Smart ($75.000)");
            Console.WriteLine("  3 - Black sin permanencia ($100.000)");
            Console.WriteLine("------------------------------------------------------");

            int plan;
            while (true)
            {
                Console.Write("Opción (1–3): ");
                string entrada = Console.ReadLine();
                bool ok = int.TryParse(entrada, out plan) && (plan >= 1 && plan <= 3);
                if (ok) break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Opción inválida. Debes ingresar 1, 2 o 3.");
                Console.ResetColor();
            }
            Console.WriteLine();

            switch (plan)
            {
                case 1: return ("Black", 90000);
                case 2: return ("Smart", 75000);
                case 3: return ("Black sin permanencia", 100000);
                default: return ("", 0);
            }
        }

        static void Main(string[] args)
        {
            int ContadorUsuarios = 0;
            int ContadorPlanes = 0;
            float TotalIngresos = 0f; 

            while (true)
            {
                Console.Clear();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("Bienvenido al Gimnasio ");
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine("1 - Registrar un cliente");
                Console.WriteLine("2 - Pagar mensualidad");
                Console.WriteLine("3 - Revisión con el nutricionista");
                Console.WriteLine("4 - Ver ingresos en el dia ");
                Console.WriteLine("5 - Salir de la aplicación ");
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine();
                Console.Write("Elige una opción (1–5): ");

                bool parseoExitoso = int.TryParse(Console.ReadLine(), out int Opcion);
                if (!parseoExitoso || Opcion < 1 || Opcion > 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("¡Debes ingresar un número entre 1 y 5!");
                    Console.ResetColor();
                    Console.WriteLine("Presiona una tecla para continuar...");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine();

                // Opción 1: Registrar un cliente
                if (Opcion == 1)
                {
                    bool registrarOtro = true;

                    while (registrarOtro)
                    {
                        Console.Clear();
                        Console.WriteLine("---------------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Registrar un cliente - llena los siguientes datos:");
                        Console.ResetColor();
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine();


                       
                        // Edad (solo números, > 0)
                        int Edad;
                        while (true)
                        {
                            Console.Write("Edad (Ejem: 18): ");
                            string entradaEdad = Console.ReadLine();
                            bool edadOK = int.TryParse(entradaEdad, out Edad) && Edad > 0;
                            if (edadOK) break;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Formato invalido ingresa solo numeros");
                            Console.ResetColor();
                        }
                        Console.WriteLine();

                        // Validar edad de 15 a80
                        if (Edad < 15)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("---------------------------------------------------");
                            Console.WriteLine("¡Los menores de 15 años no se pueden inscribir!");
                            Console.ResetColor();
                            Console.WriteLine();

                            // Preguntar si desea intentar con otro cliente
                            Console.Write("¿Deseas intentar registrar otro cliente? (S/N): ");
                            string respMenor = Console.ReadLine()?.Trim().ToUpper();
                            if (respMenor == "S")
                                continue; // Vuelve a pedir datos desde el inicio del while
                            else
                                break;    // Sale al menú principal
                        }
                        else if (Edad > 80)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("----------------------------------------------------");
                            Console.WriteLine("No se pueden registrar personas mayores de 80 años.");
                            Console.ResetColor();
                            Console.WriteLine();

                            // Preguntar si desea intentar con otro cliente
                            Console.Write("¿Deseas intentar registrar otro cliente? (S/N): ");
                            string respMayor = Console.ReadLine()?.Trim().ToUpper();
                            if (respMayor == "S")
                                continue;
                            else
                                break;
                        }
                        else if (Edad > 70)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("Cliente mayor de 70 años, se le asignará instructor especial.");
                            Console.ResetColor();
                            Console.WriteLine();
                        }

                        // Nombre
                        string Nombre;
                        while (true)
                        {
                            Console.Write("Nombre (Ejem: Sebastian vasquez): ");
                            Nombre = Console.ReadLine()?.Trim();

                            // si esta vacido
                            if (string.IsNullOrWhiteSpace(Nombre))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El nombre no puede quedar vacío.");
                                Console.ResetColor();
                                continue;
                            }

                            // si es menor a 4 caracte
                            if (Nombre.Length < 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El nombre debe tener al menos 4 caracteres.");
                                Console.ResetColor();
                                continue;
                            }

                            // contamos los carateres
                            bool Contardigitos = false;
                            foreach (char c in Nombre)
                            {
                                if (char.IsDigit(c))
                                {
                                    Contardigitos = true;
                                    break;
                                }
                            }

                            if (Contardigitos)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El nombre no puede contener números.");
                                Console.ResetColor();
                                continue;
                            }

                            // si es valido sale del while
                            break;
                        }
                        Console.WriteLine();

                        // Cédula (solo números y > 0)
                        int Cedula;
                        while (true)
                        {
                            Console.Write("Cedula (Ejem: 1042151554): ");
                            string entradaCedula = Console.ReadLine();
                            bool cedulaOK = int.TryParse(entradaCedula, out Cedula) && Cedula > 0;
                            if (cedulaOK) break;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Formato inválido ingresa solo numeros.");
                            Console.ResetColor();
                        }
                        Console.WriteLine();


                        // Peso 
                        float Peso;
                        while (true)
                        {
                            Console.Write("Peso (Ejem: 63.2): ");
                            string entradaPeso = Console.ReadLine();
                            bool pesoOK = float.TryParse(entradaPeso, NumberStyles.Float, CultureInfo.InvariantCulture, out Peso) && Peso > 0;
                            if (pesoOK) break;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Formato invalido sole se pueden ingresar numeros");
                            Console.ResetColor();
                        }
                        Console.WriteLine();

                        // Estatura
                        float Estatura;
                        while (true)
                        {
                            Console.Write("Estatura (Ejem: 1.72): ");
                            string entradaEstatura = Console.ReadLine();
                            bool estaturaOK = float.TryParse(entradaEstatura, NumberStyles.Float, CultureInfo.InvariantCulture, out Estatura) && Estatura > 0;
                            if (estaturaOK) break;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Formato invalido solo se pueden numeros");
                            Console.ResetColor();
                        }
                        Console.WriteLine();

                        // Profesión (no vacío)
                        string Profesion;
                        while (true)
                        {
                            Console.Write("Profesion (Ejem: Programador): ");
                            Profesion = Console.ReadLine()?.Trim();
                            if (!string.IsNullOrWhiteSpace(Profesion)) break;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("La profesión no puede quedar vacia.");
                            Console.ResetColor();
                        }
                        Console.WriteLine();

                        // Nivel escolar (no vacío)
                        string NivelEscolar;
                        while (true)
                        {
                            Console.Write("Nivel escolar (Ejem: Bachiller - Tecnico): ");
                            NivelEscolar = Console.ReadLine()?.Trim();
                            if (!string.IsNullOrWhiteSpace(NivelEscolar)) break;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El nivel escolar no puede quedar vacío.");
                            Console.ResetColor();
                        }
                        Console.WriteLine();

                        // Estado civil (no vacío)
                        string EstadoCivil;
                        while (true)
                        {
                            Console.Write("Estado civil (Ejem: Soltero): ");
                            EstadoCivil = Console.ReadLine()?.Trim();
                            if (!string.IsNullOrWhiteSpace(EstadoCivil)) break;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("El estado civil no puede quedar vacío.");
                            Console.ResetColor();
                        }
                        Console.WriteLine();

                        // EPS (no vacío)
                        string Eps;
                        while (true)
                        {
                            Console.Write("EPS (Ejem: Salud total): ");
                            Eps = Console.ReadLine()?.Trim();
                            if (!string.IsNullOrWhiteSpace(Eps)) break;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("La EPS no puede quedar vacía.");
                            Console.ResetColor();
                        }
                        Console.WriteLine();

                        // Dirección (no vacío)
                        string Direccion;
                        while (true)
                        {
                            Console.Write("Direccion (Ejem: Calle 61-54 int 131): ");
                            Direccion = Console.ReadLine()?.Trim();
                            if (!string.IsNullOrWhiteSpace(Direccion)) break;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("La dirección no puede quedar vacía.");
                            Console.ResetColor();
                        }
                        Console.WriteLine();

                        // Teléfono (solo números, > 0)
                        double Telefono;
                        while (true)
                        {
                            Console.Write("Telefono (Ejem: 3017903270): ");
                            string entradaTel = Console.ReadLine();
                            bool telOK = double.TryParse(entradaTel, out Telefono) && Telefono > 0;
                            if (telOK) break;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Formato inválido solo puedes ingresar numeros.");
                            Console.ResetColor();
                        }
                        Console.WriteLine();

                        // Enfermedad o prescripción médica (no vacío)
                        string Enfermedad;
                        while (true)
                        {
                            Console.Write("¿Tienes alguna enfermedad o prescripción médica? (Escribe: ninguna - si - no): ");
                            Enfermedad = Console.ReadLine()?.Trim();
                            if (!string.IsNullOrWhiteSpace(Enfermedad)) break;

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Este campo no puede quedar vacío.");
                            Console.ResetColor();
                        }
                        Console.WriteLine();

                        // Seleccionar plan
                        var (PlanMensaje, PlanValor) = SeleccionarPlan();

                        // Índice de Masa Corporal (IMC)
                        float IMC = 0f;
                        if (Estatura > 0)
                        {
                            IMC = Peso / (Estatura * Estatura);
                        }

                        // Datos del acudiente si es menor de 18
                        if (Edad < 18)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("---------------------------------------------------------");
                            Console.WriteLine("Tienes menos de 18 años. Ingresa la información de tu acudiente:");
                            Console.WriteLine("---------------------------------------------------------");
                            Console.ResetColor();
                            Console.WriteLine();

                            // Nombre del acudiente (no vacío)
                            string AcudienteNombre;
                            while (true)
                            {
                                Console.Write("Nombre del acudiente: ");
                                AcudienteNombre = Console.ReadLine()?.Trim();
                                if (!string.IsNullOrWhiteSpace(AcudienteNombre)) break;

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("El nombre del acudiente no puede quedar vacío.");
                                Console.ResetColor();
                            }
                            Console.WriteLine();

                            // Teléfono del acudiente (solo números, > 0)
                            double AcudienteTelefono;
                            while (true)
                            {
                                Console.Write("Teléfono del acudiente (solo números): ");
                                string entradaAcudTel = Console.ReadLine();
                                bool acudTelOK = double.TryParse(entradaAcudTel, out AcudienteTelefono) && AcudienteTelefono > 0;
                                if (acudTelOK) break;

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Formato inválido. Debes ingresar un número mayor que 0.");
                                Console.ResetColor();
                            }
                            Console.WriteLine();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("---------------------------------------------------------");
                            Console.WriteLine("Reporte de inscripción (menor de 18):");
                            Console.WriteLine($"Nombre del acudiente: {AcudienteNombre}");
                            Console.WriteLine($"Teléfono del acudiente: {AcudienteTelefono}");
                            Console.WriteLine("---------------------------------------------------------");
                            Console.ResetColor();
                            Console.WriteLine();
                        }

                        // Reporte general de inscripción
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("---------------------------------------------------------");
                        Console.WriteLine("Reporte de inscripción:");
                        Console.WriteLine("¡Ya estás inscrito en el gimnasio!");
                        Console.WriteLine($"Fecha de inscripción: {DateTime.Now}");
                        Console.WriteLine($"Tu IMC es: {IMC:F2}");
                        Console.WriteLine("---------------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        // Clasificación por IMC
                        string Tabla = "", Recomendacion = "", Rutina = "";
                        if (IMC > 0f && IMC <= 16.00f)
                        {
                            Tabla = "Diagnóstico: Delgado severo. Tu peso es demasiado bajo.";
                            Recomendacion = "Recomendación: Consulta tu médico lo más pronto posible.";
                            Rutina = "Rutina: A";
                        }
                        else if (IMC <= 16.99f)
                        {
                            Tabla = "Diagnóstico: Delgado moderado. Tu peso es bajo.";
                            Recomendacion = "Recomendación: Incluye calorías y carbohidratos.";
                            Rutina = "Rutina: A";
                        }
                        else if (IMC <= 18.49f)
                        {
                            Tabla = "Diagnóstico: Delgado leve. Tu peso es ligeramente bajo.";
                            Recomendacion = "Recomendación: Mejora tus hábitos alimenticios.";
                            Rutina = "Rutina: A";
                        }
                        else if (IMC <= 24.99f)
                        {
                            Tabla = "Diagnóstico: Normal. Tienes un peso saludable.";
                            Recomendacion = "Recomendación: ¡Sigue así!";
                            Rutina = "Rutina: B";
                        }
                        else if (IMC <= 29.99f)
                        {
                            Tabla = "Diagnóstico: Preobeso. Tu peso es elevado.";
                            Recomendacion = "Recomendación: Procura hacer ejercicio.";
                            Rutina = "Rutina: B";
                        }
                        else if (IMC <= 34.99f)
                        {
                            Tabla = "Diagnóstico: Obesidad leve. Tu peso es alto.";
                            Recomendacion = "Recomendación: Controla tu dieta y realiza ejercicio.";
                            Rutina = "Rutina: B";
                        }
                        else if (IMC <= 39.99f)
                        {
                            Tabla = "Diagnóstico: Obesidad media. Tu peso es muy alto.";
                            Recomendacion = "Recomendación: Visita a tu médico y controla tu dieta.";
                            Rutina = "Rutina: C";
                        }
                        else // IMC >= 40
                        {
                            Tabla = "Diagnóstico: Obesidad mórbida. Tu peso es excesivamente alto.";
                            Recomendacion = "Recomendación: ¡Visita a tu médico cuanto antes!";
                            Rutina = "Rutina: C";
                        }

                        Console.WriteLine(Tabla);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine(Recomendacion);
                        Console.WriteLine(Rutina);
                        Console.ResetColor();
                        Console.WriteLine();


                     

                        // Datos generales
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Datos generales:");
                        Console.WriteLine($"Nombre: {Nombre}");
                        Console.WriteLine($"Cédula: {Cedula}");
                        Console.WriteLine($"Profesión: {Profesion}");
                        Console.WriteLine($"Nivel escolar: {NivelEscolar}");
                        Console.WriteLine($"Edad: {Edad}");
                        Console.WriteLine($"Peso: {Peso}");
                        Console.WriteLine($"Estatura: {Estatura}");
                        Console.WriteLine($"Estado civil: {EstadoCivil}");
                        Console.WriteLine($"EPS: {Eps}");
                        Console.WriteLine($"Dirección: {Direccion}");
                        Console.WriteLine($"Teléfono: {Telefono}");
                        Console.WriteLine($"Enfermedad o prescripción médica: {Enfermedad}");
                        Console.ResetColor();
                        Console.WriteLine();

                        // Detalles del plan
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Plan seleccionado:");
                        Console.WriteLine($"Nombre del plan: {PlanMensaje}");
                        Console.WriteLine($"Valor del plan: {PlanValor:N0}");
                        Console.WriteLine("--------------------------------------------------");
                        Console.ResetColor();
                        Console.WriteLine();

                        ContadorUsuarios++;

                        // Preguntar si desea registrar otro cliente
                        Console.Write("¿Deseas registrar otro cliente? (S/N): ");
                        string respuesta = Console.ReadLine()?.Trim().ToUpper();
                        if (respuesta == "S")
                        {
                            continue; // Repite todo el proceso de registro
                        }
                        else
                        {
                            registrarOtro = false; // Sale al menú principal
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine("Presiona una tecla para volver al menú principal...");
                    Console.ReadKey();
                }
                // Opción 2 Pagar mensualidad
                else if (Opcion == 2)
                {
                    Console.Clear();
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Pagar plan: Llena los siguientes datos");
                    Console.ResetColor();
                    Console.WriteLine("------------------------------------------------------------------");
                    Console.WriteLine();

                    // Nombre (no vacío)
                    string PagarNombre;
                    while (true)
                    {
                        Console.Write("Nombre (Ejem: sebastian vasquez): ");
                        PagarNombre = Console.ReadLine()?.Trim();
                        if (!string.IsNullOrWhiteSpace(PagarNombre)) break;

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El nombre no puede quedar vacío.");
                        Console.ResetColor();
                    }
                    Console.WriteLine();

                    // Documento 
                    int PagarDocumento;
                    while (true)
                    {
                        Console.Write("Numero de documento (Ejem: 1042151554): ");
                        string entradaDoc = Console.ReadLine();
                        bool docOK = int.TryParse(entradaDoc, out PagarDocumento) && PagarDocumento > 0;
                        if (docOK) break;

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Formato inválido. Debes ingresar un número entero mayor que 0.");
                        Console.ResetColor();
                    }
                    Console.WriteLine();

                    // Seleccionar plan
                    var (PlanMensajePago, PlanValorPago) = SeleccionarPlan();

                    ContadorPlanes++;
                    TotalIngresos += PlanValorPago; // acumula el valor pagado

                    // Mostrar factura
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("Factura:");
                    Console.WriteLine($"Fecha del pago: {DateTime.Now}");
                    Console.WriteLine($"Nombre: {PagarNombre}");
                    Console.WriteLine($"Documento: {PagarDocumento}");
                    Console.WriteLine($"Plan: {PlanMensajePago}");
                    Console.WriteLine($"Valor: {PlanValorPago:N0}");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.ResetColor();
                    Console.WriteLine();

                    Console.WriteLine("Presiona una tecla para volver al menú principal...");
                    Console.ReadKey();
                }
                // Opción 3 Revisión con nutricionista
                else if (Opcion == 3)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("En construcción");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine("Presiona una tecla para volver al menú principal...");
                    Console.ReadKey();
                }
                // Opción 4 Volver al menú principal 
                else if (Opcion == 4)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"Ingresos en el dia de hoy:");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine($"Usuarios registrados en el día: {ContadorUsuarios}");
                    Console.WriteLine($"Planes pagados en el día: {ContadorPlanes}");
                    Console.WriteLine($"Ingresos totales: {TotalIngresos:N0}"); // suma de los pagos
                    Console.WriteLine();
                    Console.WriteLine("Presiona cualquier tecla para volver al menú principal...");
                    Console.ResetColor();

                    // Con ReadKey no muestra la tecla pero da control inmediato
                    Console.ReadKey(true);
                    continue; // Regresa al menu principal
                }
                
                // Option 5: Exit
                else if (Opcion == 5)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("You chose option 5. Exiting the system...");
                    Console.WriteLine("");
                    Console.WriteLine("Press any key to exit...");
                    Console.ResetColor();
                    Console.ReadKey(true);
                    break;
                }



            } // while principal
        }
    }
}
