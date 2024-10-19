using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using MvcSample.Models.Dto;
using Services;
using System;
using System.Collections.Generic;

namespace MvcSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase // Cambiar a ControllerBase para API
    {
        private readonly IProductoService _service;
        private readonly IMapper _mapper;

        public ProductosController(IProductoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/productos
        [HttpGet]
        public ActionResult<IList<ProductoDto>> GetProductos()
        {
            var productos = _service.GetProductos();
            var productosDto = _mapper.Map<IList<ProductoDto>>(productos);
            return Ok(productosDto); // Retorna un 200 OK con los productos
        }

        // GET: api/productos/{id}
        [HttpGet("{id}")]
        public ActionResult<ProductoDto> GetProducto(Guid id)
        {
            var producto = _service.GetProductoExistences(id);
            if (producto == null)
            {
                return NotFound(); // Retorna un 404 si no se encuentra el producto
            }
            var productoDto = _mapper.Map<ProductoDto>(producto);
            return Ok(productoDto); // Retorna un 200 OK con el producto
        }

        // POST: api/productos
        [HttpPost]
        public ActionResult<ProductoDto> Add(ProductoDto productoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna un 400 si el modelo es inválido
            }

            var producto = _mapper.Map<Producto>(productoDto);
            _service.AddProductoExistences(producto);

            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, productoDto); // Retorna 201 Created
        }

        // PUT: api/productos/{id}
        [HttpPut("{id}")]
        public ActionResult Update(Guid id, ProductoDto productoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Retorna un 400 si el modelo es inválido
            }

            var productoExistente = _service.GetProductoExistences(id);
            if (productoExistente == null)
            {
                return NotFound(); // Retorna un 404 si no se encuentra el producto
            }

            var producto = _mapper.Map<Producto>(productoDto);
            producto.Id = id;
            _service.UpdateProductoExistences(producto);
            return NoContent(); // Retorna 204 No Content
        }

        // DELETE: api/productos/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var producto = _service.GetProductoExistences(id);
            if (producto == null)
            {
                return NotFound(); // Retorna un 404 si no se encuentra el producto
            }

            _service.DeleteProductoExistences(id);
            return NoContent(); // Retorna 204 No Content
        }
    }
}
