using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface IProductoService
    {
        // Agregar un nuevo producto
        void AddProductoExistences(Producto producto);

        // Obtener la lista de todos los productos
        IList<Producto> GetProductos();

        // Obtener un producto por su ID
        Producto GetProductoExistences(Guid id);

        // Actualizar un producto existente
        void UpdateProductoExistences(Producto producto);

        // Eliminar un producto por su ID
        void DeleteProductoExistences(Guid id);
    }
}

