using System.Data.Entity;
using Domain.Core.Entities;

namespace Infrastructure.Context.Configuration
{
    public class ConfigurationContext
    {
        public static void ConfiguracionApiFluent(DbModelBuilder modelBuilder)
        {
            // ================================================================== //
            // ==============  Desactivado el Borrado en Cascada  =============== //
            // ================================================================== //

            modelBuilder.Entity<Turno>()
                .HasRequired(e => e.Empleado)
                .WithMany(t => t.TurnosEmpleados)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Turno>()
                .HasRequired(e => e.Profesional)
                .WithMany(t => t.TurnosProfesionales)
                .WillCascadeOnDelete(false);
        }
    }
}
