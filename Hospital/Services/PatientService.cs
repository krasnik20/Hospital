using Microsoft.EntityFrameworkCore;
using Model.Model;
using System.Linq;

namespace Hospital.Services
{
    public class PatientService : EntityServiceBase<Patient>
    {
        public PatientService()
        {
            AfterRead += (Patient[] items) =>
            {
                foreach (var item in items)
                {
                    dbctx.Entry(item).Collection(i => i.Diagnosis).Query().Include(d => d.Disease).Load();
                    dbctx.Entry(item).Collection(i => i.Treatment).Query().Include(d => d.Cure).Load();
                }
            };
        }
    }
}
