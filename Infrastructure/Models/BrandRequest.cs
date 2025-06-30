namespace Farmacheck.Infrastructure.Models
{
    public class BrandRequest
    {
        public int Id { get; set; }
        public int UnidadDeNegocio { get; set; }
        public string Nombre { get; set; } = null!;
        public string Logotipo { get; set; } = null!;
    }
}
