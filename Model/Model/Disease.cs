using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Disease : Entity
    {
        [Required]
        public string Name { get; set; }
        public string Symptoms { get; set; }
        public override string ToString() => Name;
    }
}
