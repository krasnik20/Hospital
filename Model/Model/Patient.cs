using System;
using System.Collections.Generic;

namespace Model.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<PatientDisease> Diagnosis { get; set; }
        public List<CureRecord> Treatment { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartDate { get; set; }
        public Room Room { get; set; }
    }
}
