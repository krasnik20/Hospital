using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class PatientDisease
    {
        public int Id { get; set; }
        [Required]
        public Patient Patient { get; set; }
        [Required]
        public Disease Disease { get; set; }
        public override string ToString() => Disease.Name;
    }
}
