using System.Collections.Generic;

namespace Model.Model
{
    public class Room
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
