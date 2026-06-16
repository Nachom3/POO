using Microsoft.EntityFrameworkCore;

namespace ClinicaMedica
{
    public class ClinicaContext : DbContext
    {
        public DbSet<Especialidad> Especialidades { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Disponibilidad> Disponibilidades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=/home/nacho/Documentos/POO/ClinicaMedicaApp/ClinicaMedica.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>()
                .ToTable("especialidad")
                .HasKey(e => e.IdEspecialidad);
            modelBuilder.Entity<Especialidad>()
                .Property(e => e.IdEspecialidad).HasColumnName("id_especialidad");
            modelBuilder.Entity<Especialidad>()
                .Property(e => e.DuracionTurnoMin).HasColumnName("duracion_turno_min");

            modelBuilder.Entity<Medico>()
                .ToTable("medico")
                .HasKey(m => m.Matricula);
            modelBuilder.Entity<Medico>()
                .Property(m => m.Activo).HasColumnName("activo");

            modelBuilder.Entity<Paciente>()
                .ToTable("paciente")
                .HasKey(p => p.Dni);
            modelBuilder.Entity<Paciente>()
                .Property(p => p.FechaNacimiento).HasColumnName("fecha_nacimiento");

            modelBuilder.Entity<Estado>()
                .ToTable("estado")
                .HasKey(e => e.IdEstado);
            modelBuilder.Entity<Estado>()
                .Property(e => e.IdEstado).HasColumnName("id_estado");

            modelBuilder.Entity<Disponibilidad>()
                .ToTable("disponibilidad")
                .HasKey(d => new { d.Matricula, d.IdEspecialidad, d.DiaSemana });
            modelBuilder.Entity<Disponibilidad>()
                .Property(d => d.IdEspecialidad).HasColumnName("id_especialidad");
            modelBuilder.Entity<Disponibilidad>()
                .Property(d => d.DiaSemana).HasColumnName("dia_semana");
            modelBuilder.Entity<Disponibilidad>()
                .Property(d => d.HoraInicio).HasColumnName("hora_inicio");
            modelBuilder.Entity<Disponibilidad>()
                .Property(d => d.HoraFin).HasColumnName("hora_fin");
            modelBuilder.Entity<Disponibilidad>()
                .HasOne(d => d.Medico)
                .WithMany()
                .HasForeignKey(d => d.Matricula);
            modelBuilder.Entity<Disponibilidad>()
                .HasOne(d => d.Especialidad)
                .WithMany()
                .HasForeignKey(d => d.IdEspecialidad);

            modelBuilder.Entity<Turno>()
                .ToTable("turno")
                .HasKey(t => t.IdTurno);
            modelBuilder.Entity<Turno>()
                .Property(t => t.IdEspecialidad).HasColumnName("id_especialidad");
            modelBuilder.Entity<Turno>()
                .Property(t => t.IdEstado).HasColumnName("id_estado");
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Paciente)
                .WithMany()
                .HasForeignKey(t => t.Dni);
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Medico)
                .WithMany()
                .HasForeignKey(t => t.Matricula);
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Especialidad)
                .WithMany()
                .HasForeignKey(t => t.IdEspecialidad);
            modelBuilder.Entity<Turno>()
                .HasOne(t => t.Estado)
                .WithMany()
                .HasForeignKey(t => t.IdEstado);

            modelBuilder.Entity<Estado>().HasData(
                new Estado { IdEstado = 1, Descripcion = "reservado" },
                new Estado { IdEstado = 2, Descripcion = "cancelado" }
            );

            modelBuilder.Entity<Especialidad>().HasData(
                new Especialidad { IdEspecialidad = 1, Nombre = "Clinica General", DuracionTurnoMin = 30 },
                new Especialidad { IdEspecialidad = 2, Nombre = "Cardiologia", DuracionTurnoMin = 45 },
                new Especialidad { IdEspecialidad = 3, Nombre = "Pediatria", DuracionTurnoMin = 30 },
                new Especialidad { IdEspecialidad = 4, Nombre = "Traumatologia", DuracionTurnoMin = 40 }
            );

            modelBuilder.Entity<Medico>().HasData(
                new Medico { Matricula = 1001, Nombre = "Carlos", Apellido = "Lopez", Activo = 1 },
                new Medico { Matricula = 1002, Nombre = "Maria", Apellido = "Garcia", Activo = 1 },
                new Medico { Matricula = 1003, Nombre = "Pedro", Apellido = "Rodriguez", Activo = 1 },
                new Medico { Matricula = 1004, Nombre = "Ana", Apellido = "Martinez", Activo = 1 }
            );

            modelBuilder.Entity<Disponibilidad>().HasData(
                new Disponibilidad { Matricula = 1001, IdEspecialidad = 1, DiaSemana = 1, HoraInicio = "08:00", HoraFin = "12:00" },
                new Disponibilidad { Matricula = 1001, IdEspecialidad = 1, DiaSemana = 3, HoraInicio = "08:00", HoraFin = "12:00" },
                new Disponibilidad { Matricula = 1002, IdEspecialidad = 2, DiaSemana = 2, HoraInicio = "09:00", HoraFin = "13:00" },
                new Disponibilidad { Matricula = 1002, IdEspecialidad = 2, DiaSemana = 4, HoraInicio = "09:00", HoraFin = "13:00" },
                new Disponibilidad { Matricula = 1003, IdEspecialidad = 3, DiaSemana = 1, HoraInicio = "10:00", HoraFin = "14:00" },
                new Disponibilidad { Matricula = 1003, IdEspecialidad = 3, DiaSemana = 5, HoraInicio = "10:00", HoraFin = "14:00" },
                new Disponibilidad { Matricula = 1004, IdEspecialidad = 4, DiaSemana = 2, HoraInicio = "08:00", HoraFin = "12:00" },
                new Disponibilidad { Matricula = 1004, IdEspecialidad = 4, DiaSemana = 4, HoraInicio = "08:00", HoraFin = "12:00" }
            );
        }
    }
}
