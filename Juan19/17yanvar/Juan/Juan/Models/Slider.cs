using System.ComponentModel.DataAnnotations.Schema;

namespace Juan.Models
{
    public class Slider
    {
        public  int Id { get; set; }    
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Desc { get; set; }
        public string? Image { get; set; }

        [NotMapped]
        public IFormFile? imagefile { get; set; }

    }
}
