using System.Collections.Generic;

namespace Model.Model
{
    public class Drug
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public List<Disease> Diseases { get; set; }
    }
}
