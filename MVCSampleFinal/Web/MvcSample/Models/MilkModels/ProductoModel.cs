using Domain;


namespace MvcSample.Models.MilkModels
{
    public class ProductoModel

    {
        public Guid Id { get; set; }

        public String Nombre { get; set; }

        public float Precio { get; set; }

        public int stock { get; set; }
    }

    public class ProductosModel
    {
        public IList<ProductoModel> Productos { get; set; } = new List<ProductoModel>();
    }
}


