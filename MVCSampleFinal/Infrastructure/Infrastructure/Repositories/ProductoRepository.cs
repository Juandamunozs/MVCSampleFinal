using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure.Repositories
{
    public class ProductoRepository : BaseRepository, IProductoRepository
    {

        public ProductoRepository(AppDbContext context) : base(context)
        {

        }

        public IList<Producto> GetProductos()
        {
            return context.Productos.ToList();
        }

        public Producto GetProducto(Guid id)
        {
            return context.Productos.Find(id);
        }

        public void Save(Producto producto)
        {
            try
            {
                Console.WriteLine("Estamos creando" + producto.Id);
                Beguin();
                context.Productos.Add(producto);
                Comit();
                Save();
            }
            catch (Exception ex)
            {
                RollBack();
                throw ex;
            }
        }

        public void Delete(Guid id)
        {
            try
            {
                Beguin();
                var producto = context.Productos.Find(id);
                context.Productos.Remove(producto);
                Comit();
                Save();
            }
            catch (Exception ex)
            {
                RollBack();
                throw ex;
            }

        }

        public void Update(Producto producto)
        {
            try
            {
                Beguin();

                // Verificar si el producto ya existe en el contexto
                var existingEntity = context.Productos.Find(producto.Id);
                if (existingEntity != null)
                {
                    Console.WriteLine("Estamos actualizando" + producto.Id);
                    // Actualizar el estado del objeto existente
                    context.Entry(existingEntity).CurrentValues.SetValues(producto);
                    // No necesitas llamar a context.Productos.Update(producto); ya que estamos actualizando el existente
                }
                else
                {
                    throw new InvalidOperationException("El producto no existe.");
                }

                Comit(); // Asegúrate de que este método realmente está guardando cambios
            }
            catch (Exception ex)
            {
                RollBack();
                throw ex; // Puedes considerar lanzar una excepción más específica
            }
        }


    }
}

