using System;
using System.ComponentModel.DataAnnotations;

namespace Model.Model
{
    public class CureRecord
    {
        public int Id { get; set; }
        [Required]
        public Cure Cure { get; set; }
        public TimeSpan Duration { get; set; }
        public string Instructions { get; set; }
        [Required]
        public Patient Patient { get; set; }
    }
}
