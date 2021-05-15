using System;

namespace Model
{
    public class DrugRecord
    {
        public int Id { get; set; }
        public Drug Drug { get; set; }
        public TimeSpan Duration { get; set; }
        public string Instructions { get; set; }
        public Treatment Treatment { get; set; }
    }
}
