using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

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
                context.SaveChanges(); // Guardar antes de hacer commit
                Comit();
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
                if (producto != null)
                {
                    context.Productos.Remove(producto);
                    context.SaveChanges(); // Guardar antes de hacer commit
                    Comit();
                }
                else
                {
                    throw new InvalidOperationException("El producto no existe.");
                }
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
                var existingProducto = context.Productos.Find(producto.Id);
                if (existingProducto != null)
                {
                    context.Entry(existingProducto).CurrentValues.SetValues(producto);
                    context.SaveChanges(); // Guardar los cambios
                    Comit(); // Confirmar la transacción
                }
                else
                {
                    throw new InvalidOperationException("El producto no existe.");
                }
            }
            catch (Exception ex)
            {
                RollBack(); // Revertir en caso de error
                throw ex;
            }
        }


    }
}

