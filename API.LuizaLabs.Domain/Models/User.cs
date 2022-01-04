using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace API.LuizaLabs.Domain.Models
{
    public class User : Base
    {
            
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }        
        public string Password { get; set; }

    }
}
