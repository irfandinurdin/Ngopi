using Ngopi.Helpers;

namespace Ngopi.Models
{
    public class Product : Auditable
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Brand? Brand { get; set; }
        public int Price { get; set; }
        public int RateStar { get; set; }
        public int TotalRate { get; set; }
        public string? ImageName { get; set; }
        public Origin? Origin { get; set; }
        public Species? Species { get; set; }
        public RoastLevel? RoastLevel { get; set; }
        public Tasted? Tasted { get; set; }
        public Processing? Processing { get; set; }
    }
}
