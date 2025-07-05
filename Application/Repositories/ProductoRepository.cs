using Database.Context;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class ProductoRepository
    {
        private readonly CrudProductosContext _context;

        public ProductoRepository(CrudProductosContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> ObtenerTodos()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> ObtenerPorId(int id)
        {
            return await _context.Productos.FindAsync(id);
        }

        public async Task Crear(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
        }

        public void Actualizar(Producto producto)
        {
            _context.Productos.Update(producto);
        }

        public void Eliminar(Producto producto)
        {
            _context.Productos.Remove(producto);
        }

        public async Task GuardarCambios()
        {
            await _context.SaveChangesAsync();
        }
    }
}
