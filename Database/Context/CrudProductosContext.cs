using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Database.Context
{
    public class CrudProductosContext : DbContext
    {
        public CrudProductosContext(DbContextOptions<CrudProductosContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }

        // Configuraciones adicionales (opcional)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aquí puedes agregar configuraciones adicionales
            modelBuilder.Entity<Producto>().Property(p => p.Nombre).IsRequired().HasMaxLength(100);
        }
    }
}
