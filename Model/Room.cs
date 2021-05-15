using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Room
    {
        public int Id { get; set; }
        public Doctor Doctor { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
