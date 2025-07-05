using Application.Dtos;
using Application.Repositories;
using Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductoService
    {
        private readonly ProductoRepository _repo;

        public ProductoService(ProductoRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Producto>> ObtenerTodos()
        {
            return await _repo.ObtenerTodos();
        }

        public async Task<Producto?> ObtenerPorId(int id)
        {
            return await _repo.ObtenerPorId(id);
        }

        public async Task Crear(ProductoDto dto)
        {
            var producto = new Producto
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Cantidad = dto.Cantidad,
                FechaRegistro = DateTime.Now
            };

            await _repo.Crear(producto);
            await _repo.GuardarCambios();
        }

        public async Task<bool> Actualizar(int id, ProductoDto dto)
        {
            var producto = await _repo.ObtenerPorId(id);
            if (producto == null) return false;

            producto.Nombre = dto.Nombre;
            producto.Descripcion = dto.Descripcion;
            producto.Precio = dto.Precio;
            producto.Cantidad = dto.Cantidad;

            _repo.Actualizar(producto);
            await _repo.GuardarCambios();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            var producto = await _repo.ObtenerPorId(id);
            if (producto == null) return false;

            _repo.Eliminar(producto);
            await _repo.GuardarCambios();
            return true;
        }
    }
}
