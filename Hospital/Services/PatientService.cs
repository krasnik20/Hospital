using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Services
{
    public class PatientService : ServiceBase<Patient>
    {
        public PatientService()
        {
            AfterRead += (Patient[] items) =>
            {
                foreach (var item in items)
                    dbctx.Entry(item).Collection(i => i.Diagnosis).Query().Include(d => d.Disease).Load();
            };
        }
    }
}
