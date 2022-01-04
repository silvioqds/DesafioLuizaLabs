using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Domain.Models
{
    public class Favorite : Base
    {

        public int ClienteId { get; set; }
        public int ProductId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Product Product { get; set; }
    }
}
