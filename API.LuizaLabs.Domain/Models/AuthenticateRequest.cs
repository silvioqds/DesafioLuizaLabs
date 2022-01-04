using System.ComponentModel.DataAnnotations;

namespace API.LuizaLabs.Domain.Models
{
    public class AuthenticateRequest
    {

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
