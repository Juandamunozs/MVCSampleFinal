using System;
using System.Collections.Generic;
using Domain;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository ProductoRepository;
        private readonly IConfiguration configuration;

        public ProductoService(IProductoRepository ProductoRepository, IConfiguration configuration)
        {
            this.ProductoRepository = ProductoRepository;
            this.configuration = configuration;
        }

        public void AddProductoExistences(Producto producto)
        {
            var setting = configuration["Smtp:Server"];
            ProductoRepository.Save(producto);
        }

        public Producto GetProductoExistences(Guid id)
        {
            Producto producto = ProductoRepository.GetProducto(id);
            return producto;
        }

        public IList<Producto> GetProductos()
        {
            return ProductoRepository.GetProductos();
        }

        // Actualizar producto existente
        public void UpdateProductoExistences(Producto producto)
        {
            ProductoRepository.Update(producto);
        }

        // Eliminar producto por su ID
        public void DeleteProductoExistences(Guid id)
        {
            ProductoRepository.Delete(id);
        }
    }
}
