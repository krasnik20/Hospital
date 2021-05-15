using System;

namespace Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartDate { get; set; }
        public Room Room { get; set; }
        public Cure Cure { get; set; }
    }
}
