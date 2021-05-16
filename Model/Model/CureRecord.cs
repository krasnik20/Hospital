using System;

namespace Model.Model
{
    public class CureRecord
    {
        public int Id { get; set; }
        public Cure Cure { get; set; }
        public TimeSpan Duration { get; set; }
        public string Instructions { get; set; }
        public Patient Patient { get; set; }
    }
}
