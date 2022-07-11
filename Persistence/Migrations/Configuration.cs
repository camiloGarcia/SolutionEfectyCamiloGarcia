namespace Persistence.Migrations
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Persistence.ModelEfecty>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Persistence.ModelEfecty context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            if (context.Usuarios.ToList().Count==0)
            {
                context.Usuarios.AddOrUpdate(new Usuario
                {
                    Apellidos = "Garcia",
                    EstadoCivil = EEstadoCivil.Casado,
                    FechaNacimiento = Convert.ToDateTime("1990-05-03 00:00:00"),
                    Nombres = "Camilo",
                    TipoDocumento = ETipoDocumento.Cedula_de_ciudadania,
                    ValorAGanar = 1000
                });
                context.Usuarios.AddOrUpdate(new Usuario
                {
                    Apellidos = "Vergara",
                    EstadoCivil = EEstadoCivil.Casado,
                    FechaNacimiento = Convert.ToDateTime("1990-05-03 00:00:00"),
                    Nombres = "Andres",
                    TipoDocumento = ETipoDocumento.Cedula_de_ciudadania,
                    ValorAGanar = 2000
                });
            }
            
        }
    }
}
