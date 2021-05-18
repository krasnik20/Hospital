using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Cure : Entity
    {
        [Required]
        public string Name { get; set; }
        public int Price { get; set; }
        public override string ToString() => Name;
    }
}
