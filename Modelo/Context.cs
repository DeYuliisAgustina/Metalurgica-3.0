using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Entidades.Seguridad;
using Microsoft.EntityFrameworkCore;

namespace Modelo
{

    public class Context : DbContext
    {
        private static Context instancia;
        public static Context Instancia
        {

            get
            {
                if (instancia == null)
                    instancia = new Context();
                return instancia;
            }
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Accion> Acciones { get; set; }
        public DbSet<Componente> Componentes { get; set; }
        public DbSet<EstadoGrupo> EstadoGrupos { get; set; }
        public DbSet<EstadoUsuario> EstadoUsuarios { get; set; }
        public DbSet<Formulario> Formularios { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<NotaCompra> NotaCompras { get; set; }
        public DbSet<EstadoNotaCompra> EstadoNotaCompras { get; set; }
        public DbSet<NotaVenta> NotaVentas { get; set; }
        public DbSet<DetalleNotaCompra> DetalleNotaCompras { get; set; }
        public DbSet<DetalleNotaVenta> DetalleNotaVentas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.EnableSensitiveDataLogging(true);
            options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Metalurgica;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Componente>()
            .HasDiscriminator<string>("TipoComponente")
            .HasValue<Accion>("Accion")
            .HasValue<Grupo>("Grupo");

            // Configurar la relación Cliente-NotaCompra
            modelBuilder.Entity<NotaCompra>()
                .HasOne(nc => nc.Cliente)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict); // Cambia CASCADE a RESTRICT

            // Configurar la relación Proveedor-NotaCompra
            modelBuilder.Entity<NotaCompra>()
                .HasOne(nc => nc.Proveedor)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict); // Cambia CASCADE a RESTRICT

            // Configurar la relación Cliente-NotaVenta
            modelBuilder.Entity<NotaVenta>()
                .HasOne(nv => nv.Cliente)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict); // Cambia CASCADE a RESTRICT

            // Configurar la relación Usuario-Persona
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Persona)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>("PersonaId")
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración de la relación many-to-many entre Usuario y Componente
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Perfil)
                .WithMany(c => c.Usuarios);

            base.OnModelCreating(modelBuilder);


        }

    }
}
