using System;
using Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IProductoRepository
    {

        IList<Producto> GetProductos();

        Producto GetProducto(Guid id);

        void Save(Producto producto);

        void Delete(Guid id);

        void Update(Producto producto);
    }
}
