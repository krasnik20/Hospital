using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public class CureRecord : Entity
    {
        [Required]
        public Cure Cure { get; set; }
        [Required]
        public int? Duration { get; set; }
        public string Instructions { get; set; }
        [Required]
        public Patient Patient { get; set; }
        [NotMapped]
        public int Cost { get => Cure?.Price * Duration ?? 0; }
    }
}
