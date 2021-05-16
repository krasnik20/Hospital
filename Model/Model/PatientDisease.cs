using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class PatientDisease
    {
        public int Id { get; set; }
        public Patient Patient { get; set; }
        public Disease Disease { get; set; }
    }
}
