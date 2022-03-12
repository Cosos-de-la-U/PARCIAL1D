using Microsoft.EntityFrameworkCore;
using PARCIAL1D.Models;

namespace PARCIAL1D.Data;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
    
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<EncabezadoOrden>  EncabezadoOrden{ get; set; }
        public DbSet<Plato> Plato { get; set; }
        public DbSet<Pago> Pago { get; set; }
        public DbSet<Detalle_Orden> Detalle_Orden { get; set; }
    }