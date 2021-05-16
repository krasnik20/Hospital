using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        public Doctor Doctor { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
