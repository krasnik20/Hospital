using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Room : Entity
    {
        [Required]
        public int? Number { get; set; }
        public Doctor Doctor { get; set; }
        public override string ToString() => $"№{Number} (Врач: {(Doctor == null ? "(не назначен)" : Doctor)})";
    }
}
