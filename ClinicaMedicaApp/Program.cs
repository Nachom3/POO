using ClinicaMedica;
using Microsoft.EntityFrameworkCore;

namespace ClinicaMedica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new ClinicaContext();
            context.Database.EnsureCreated();

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE TURNOS - CLINICA MEDICA ===");
                Console.WriteLine("1 - Registrar nuevo turno");
                Console.WriteLine("2 - Salir");
                Console.Write("Opcion: ");
                string opcion = Console.ReadLine() ?? "";

                if (opcion == "1")
                {
                    RegistrarTurno(context);
                }
                else if (opcion == "2")
                {
                    salir = true;
                }
            }
        }

        static void RegistrarTurno(ClinicaContext context)
        {
            Console.Write("Ingrese DNI del paciente: ");
            int dni = int.Parse(Console.ReadLine() ?? "0");

            Paciente paciente = context.Pacientes.FirstOrDefault(p => p.Dni == dni);

            if (paciente != null)
            {
                Console.WriteLine($"\nPaciente encontrado: {paciente.Nombre} {paciente.Apellido}");
                Console.WriteLine($"Telefono: {paciente.Telefono}");
                Console.WriteLine($"Email: {paciente.Email}");
                Console.WriteLine($"Fecha de nacimiento: {paciente.FechaNacimiento}");

                var turnos = context.Turnos
                    .Include(t => t.Paciente)
                    .Include(t => t.Medico)
                    .Include(t => t.Especialidad)
                    .Include(t => t.Estado)
                    .Where(t => t.Dni == dni && t.Estado.Descripcion == "reservado")
                    .ToList();

                if (turnos.Count > 0)
                {
                    Console.WriteLine("\nTurnos reservados:");
                    for (int i = 0; i < turnos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1} - {turnos[i].Fecha} {turnos[i].Hora} | {turnos[i].Medico.Nombre} {turnos[i].Medico.Apellido} | {turnos[i].Especialidad.Nombre}");
                    }
                    Console.Write("Desea cancelar un turno? (s/n): ");
                    if (Console.ReadLine()?.ToLower() == "s")
                    {
                        Console.Write("Seleccione el numero del turno a cancelar: ");
                        int numTurno = int.Parse(Console.ReadLine() ?? "0");
                        if (numTurno >= 1 && numTurno <= turnos.Count)
                        {
                            Turno turnoACancelar = turnos[numTurno - 1];
                            Estado cancelado = context.Estados.FirstOrDefault(e => e.Descripcion == "cancelado");
                            turnoACancelar.IdEstado = cancelado.IdEstado;
                            context.SaveChanges();
                            Console.WriteLine("Turno cancelado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Numero invalido.");
                        }
                        Console.Write("Presione una tecla para continuar...");
                        Console.ReadKey();
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("No tiene turnos reservados.");
                }
            }
            else
            {
                Console.WriteLine("\nPaciente no encontrado. Registre sus datos:");
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine() ?? "";
                Console.Write("Apellido: ");
                string apellido = Console.ReadLine() ?? "";
                Console.Write("Telefono: ");
                string telefono = Console.ReadLine() ?? "";
                Console.Write("Email: ");
                string email = Console.ReadLine() ?? "";
                Console.Write("Fecha de nacimiento (dd/mm/aaaa): ");
                string fechaNac = Console.ReadLine() ?? "";

                paciente = new Paciente
                {
                    Dni = dni,
                    Nombre = nombre,
                    Apellido = apellido,
                    Telefono = telefono,
                    Email = email,
                    FechaNacimiento = fechaNac
                };
                context.Pacientes.Add(paciente);
                context.SaveChanges();
                Console.WriteLine("Paciente registrado correctamente.");
            }

            Console.Write("\nPresione una tecla para continuar con el turno...");
            Console.ReadKey();

            var especialidades = context.Especialidades.ToList();
            Console.WriteLine("\nEspecialidades disponibles:");
            for (int i = 0; i < especialidades.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {especialidades[i].Nombre}");
            }
            Console.Write("Seleccione especialidad: ");
            int espIndex = int.Parse(Console.ReadLine() ?? "0") - 1;

            if (espIndex < 0 || espIndex >= especialidades.Count)
            {
                Console.WriteLine("Especialidad invalida.");
                Console.Write("Presione una tecla...");
                Console.ReadKey();
                return;
            }

            Especialidad espElegida = especialidades[espIndex];

            var medicos = context.Medicos
                .Where(m => context.Disponibilidades.Any(d => d.Matricula == m.Matricula && d.IdEspecialidad == espElegida.IdEspecialidad))
                .ToList();

            Console.WriteLine($"\nMedicos de {espElegida.Nombre}:");
            for (int i = 0; i < medicos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - Dr/a. {medicos[i].Nombre} {medicos[i].Apellido}");
            }
            Console.Write("Seleccione medico: ");
            int medIndex = int.Parse(Console.ReadLine() ?? "0") - 1;

            if (medIndex < 0 || medIndex >= medicos.Count)
            {
                Console.WriteLine("Medico invalido.");
                Console.Write("Presione una tecla...");
                Console.ReadKey();
                return;
            }

            Medico medElegido = medicos[medIndex];

            var disponibilidades = context.Disponibilidades
                .Include(d => d.Medico)
                .Include(d => d.Especialidad)
                .Where(d => d.Matricula == medElegido.Matricula && d.IdEspecialidad == espElegida.IdEspecialidad)
                .OrderBy(d => d.DiaSemana)
                .ToList();

            Console.WriteLine($"\nDisponibilidad del Dr/a. {medElegido.Nombre} {medElegido.Apellido} en {espElegida.Nombre}:");
            for (int i = 0; i < disponibilidades.Count; i++)
            {
                string dia = DiaDeSemana(disponibilidades[i].DiaSemana);
                Console.WriteLine($"{i + 1} - {dia} de {disponibilidades[i].HoraInicio} a {disponibilidades[i].HoraFin}");
            }
            Console.Write("Seleccione un dia: ");
            int dispIndex = int.Parse(Console.ReadLine() ?? "0") - 1;

            if (dispIndex < 0 || dispIndex >= disponibilidades.Count)
            {
                Console.WriteLine("Opcion invalida.");
                Console.Write("Presione una tecla...");
                Console.ReadKey();
                return;
            }

            Disponibilidad dispElegida = disponibilidades[dispIndex];

            Console.Write("Ingrese fecha del turno (dd/mm/aaaa): ");
            string fecha = Console.ReadLine() ?? "";
            Console.Write("Ingrese hora del turno (hh:mm): ");
            string hora = Console.ReadLine() ?? "";

            Console.WriteLine("\n--- RESUMEN DEL TURNO ---");
            Console.WriteLine($"Paciente: {paciente.Nombre} {paciente.Apellido} (DNI: {paciente.Dni})");
            Console.WriteLine($"Medico: Dr/a. {medElegido.Nombre} {medElegido.Apellido}");
            Console.WriteLine($"Especialidad: {espElegida.Nombre}");
            Console.WriteLine($"Fecha: {fecha} a las {hora}");
            Console.Write("\nConfirma el turno? (s/n): ");
            string confirmar = Console.ReadLine()?.ToLower() ?? "";

            if (confirmar == "s")
            {
                Estado reservado = context.Estados.FirstOrDefault(e => e.Descripcion == "reservado");
                Turno nuevoTurno = new Turno
                {
                    Dni = paciente.Dni,
                    Matricula = medElegido.Matricula,
                    IdEspecialidad = espElegida.IdEspecialidad,
                    Fecha = fecha,
                    Hora = hora,
                    IdEstado = reservado.IdEstado
                };
                context.Turnos.Add(nuevoTurno);
                context.SaveChanges();
                Console.WriteLine("Turno registrado correctamente.");
            }
            else
            {
                Console.WriteLine("Turno cancelado.");
            }

            Console.Write("Presione una tecla para volver al menu...");
            Console.ReadKey();
        }

        static string DiaDeSemana(int dia)
        {
            if (dia == 1) return "Lunes";
            if (dia == 2) return "Martes";
            if (dia == 3) return "Miercoles";
            if (dia == 4) return "Jueves";
            if (dia == 5) return "Viernes";
            if (dia == 6) return "Sabado";
            if (dia == 7) return "Domingo";
            return "Desconocido";
        }
    }
}
