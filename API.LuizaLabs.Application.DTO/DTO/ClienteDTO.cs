using System;
using System.ComponentModel.DataAnnotations;

namespace API.LuizaLabs.Application.DTO.DTO
{
    public class ClienteDTO
    {

        public int? ID { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

    }
}
