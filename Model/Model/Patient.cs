using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Model
{
    public class Patient : Entity
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Anamnesis { get; set; }
        public List<PatientDisease> Diseases { get; set; }
        public List<CureRecord> Treatment { get; set; }
        public DateTime ArrivalDate { get; set; } = DateTime.Now;
        public DateTime DepartDate { get; set; } = DateTime.Now;
        public Room Room { get; set; }
        [NotMapped]
        public int Invoice
        {
            get
            {
                int sum = 0;
                foreach(var c in Treatment)
                    sum += c.Cost;
                return sum;
            }
        }
    }
}
