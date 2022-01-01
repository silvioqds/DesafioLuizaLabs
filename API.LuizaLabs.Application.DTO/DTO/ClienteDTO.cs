using System;
using System.ComponentModel.DataAnnotations;

namespace API.LuizaLabs.Application.DTO.DTO
{
    public class ClienteDTO
    {

        public int? ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

    }
}
