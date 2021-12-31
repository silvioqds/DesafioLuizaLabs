

namespace API.LuizaLabs.Domain.Models
{
    public class Product : Base
    {

        public double Price { get; set; }
        public string Image { get; set; }
        public string Brand { get; set; }
        public string Title { get; set; }
        public int ReviewScore { get; set; }

    }
}
