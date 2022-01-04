using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace API.LuizaLabs.Application.DTO.DTO
{
    public class UserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
