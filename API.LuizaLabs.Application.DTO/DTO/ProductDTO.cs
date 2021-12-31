using System;
using System.Collections.Generic;
using System.Text;

namespace API.LuizaLabs.Application.DTO.DTO
{
    public class ProductDTO
    {
        public int? ID { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Brand { get; set; }
        public string Title { get; set; }
        public int ReviewScore { get; set; }


    }
}
