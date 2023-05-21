using Ngopi.Helpers;

namespace Ngopi.Models
{
    public class DetailProduct : Auditable
    {
        public Guid Id { get; set; }
        public Product? Product { get; set; }
        public string[]? Images { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        public string? Dimensi { get; set; }
        public string? Berat { get; set; }
        public string? Kapasitas { get; set; }
        public string? Warna { get; set; }
    }
}
