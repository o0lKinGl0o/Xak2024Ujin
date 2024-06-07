using System.ComponentModel.DataAnnotations;

namespace WebApplication3
{
    public class AuthRequest
    {
        public string? email { get; set; }

        public string? password { get; set; }
    }
}
