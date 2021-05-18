using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Doctor : Entity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Speciality { get; set; }
        public override string ToString() => $"{FirstName} {LastName} ({Speciality})";
    }
}
