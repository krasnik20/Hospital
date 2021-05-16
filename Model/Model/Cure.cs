using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Cure
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
