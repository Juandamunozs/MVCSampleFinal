namespace MvcSample.Models.Dto
{
    public class ProductoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
