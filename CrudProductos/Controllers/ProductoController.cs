using Application.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudProductos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductoController(ProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _service.ObtenerTodos();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _service.ObtenerPorId(id);
            if (producto == null) return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ProductoDto dto)
        {
            await _service.Crear(dto);
            return Ok(new { mensaje = "Producto creado exitosamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] ProductoDto dto)
        {
            var actualizado = await _service.Actualizar(id, dto);
            if (!actualizado) return NotFound();

            return Ok(new { mensaje = "Producto actualizado." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _service.Eliminar(id);
            if (!eliminado) return NotFound();

            return Ok(new { mensaje = "Producto eliminado." });
        }
    }
}
