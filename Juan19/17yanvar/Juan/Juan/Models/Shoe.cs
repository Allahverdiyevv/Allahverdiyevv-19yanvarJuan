using System.ComponentModel.DataAnnotations.Schema;

namespace Juan.Models
{
    public class Shoe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double  Price { get; set; }
        public string  Image { get; set; }

        [NotMapped]
        public IFormFile imagefile { get; set; }
    }
}
