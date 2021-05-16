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
                    dbctx.Entry(item).Collection(i => i.Diseases).Query().Include(d => d.Disease).Load();
                    dbctx.Entry(item).Collection(i => i.Treatment).Query().Include(d => d.Cure).Load();
                }
            };

            BeforeUpdate += (Patient item) =>
            {
                if (item.Diseases == null) return;
                item.Diseases.AsParallel().ForAll(d => d.Patient = item);
                dbctx.PatientDiseases.RemoveRange(dbctx.PatientDiseases.Where(d => d.Patient.Id == item.Id && !item.Diseases.Select(pd => pd.Disease.Id).Contains(d.Disease.Id)));
            };
        }
    }
}
