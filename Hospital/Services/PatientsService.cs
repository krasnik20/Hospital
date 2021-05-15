using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Services
{
    public class PatientsService : ServiceBase, ICRUD<Patient>
    {
        public Patient Create(Patient item)
        {
            applicationContext.Patients.Add(item);
            applicationContext.SaveChanges();
            return item;
        }

        public void Update(Patient item)
        {
            throw new NotImplementedException();
        }

        public Patient ReadOne(int id)
        {
            throw new NotImplementedException();
        }

        public Patient[] Read()
        {
            return applicationContext.Patients.ToArray();
        }

        public Patient Delete(Patient item)
        {
            throw new NotImplementedException();
        }
    }
}
