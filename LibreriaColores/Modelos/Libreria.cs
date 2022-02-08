using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LibreriaColores.Modelos
{
    public class Libreria:DbContext 
    {
        public Libreria(DbContextOptions<Libreria> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source = 192.168.1.100; Initial Catalog = VacunWebContext; User Id = sa; Password = 123; MultipleActiveResultSets = True");
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=DbLibreriaContext; User Id = mati; Password = 12345; MultipleActiveResultSets = True;");
            //string carpetalocal = Directory.GetCurrentDirectory();
            //cadenaConexion = $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = {carpetalocal}\AddData\DbNatatorioContext.mdf; Integrated Security = True; Connect Timeout = 30";
        }

       





        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Venta> Ventas { get; set; }

        public DbSet<DetalleDeVenta> DetalleDeVentas { get; set; }

        public DbSet<Localidad> Localidades { get; set; }

        public Libreria()
        {

        }

        internal object ShowDialog()
        {
            throw new NotImplementedException();
        }
    }
}
