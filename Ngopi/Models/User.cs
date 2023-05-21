using Ngopi.Helpers;

namespace Ngopi.Models
{
    public class User : Auditable
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
