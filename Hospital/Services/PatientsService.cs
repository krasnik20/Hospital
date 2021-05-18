using Microsoft.EntityFrameworkCore;
using Model.Model;
using System;
using System.Linq;

namespace Hospital.Services
{
    public class PatientsService : EntityServiceBase<Patient>
    {
        public PatientsService()
        {
            AfterRead += (Patient[] items) =>
            {
                foreach (var item in items)
                {
                    dbctx.Entry(item).Reference(i => i.Room).Load();
                    dbctx.Entry(item).Collection(i => i.Diseases).Query().Include(d => d.Disease).Load();
                    dbctx.Entry(item).Collection(i => i.Treatment).Query().Include(d => d.Cure).Load();
                }
            };
            
            Action<Patient> configureDiseases = (Patient item) =>
            {
                if (item.Diseases == null) return;
                item.Diseases.AsParallel().ForAll(d => d.Patient = item);
                dbctx.PatientDiseases.RemoveRange(dbctx.PatientDiseases.Where(d => d.Patient.Id == item.Id && !item.Diseases.Select(pd => pd.Disease.Id).Contains(d.Disease.Id)));
            };

            Action<Patient> configureTreatment = (Patient item) =>
            {
                if (item.Treatment == null) return;
                item.Treatment.AsParallel().ForAll(t => t.Patient = item);
                dbctx.CureRecords.RemoveRange(dbctx.CureRecords.Where(t => t.Patient.Id == item.Id && !item.Treatment.Select(pd => pd.Cure.Id).Contains(t.Cure.Id)));
            };

            Action<Patient> CheckDataAccuracy = (Patient item) =>
            {
                if (item.Treatment != null && item.Treatment.Count != 0 && item.Treatment.Any(c => c.Duration < 1))
                    throw new Exception();
                if(item.ArrivalDate.CompareTo(item.DepartDate) > 0)
                    throw new Exception();
            };

            BeforeCreate += CheckDataAccuracy;
            BeforeCreate += configureDiseases;
            BeforeCreate += configureTreatment;

            BeforeUpdate += CheckDataAccuracy;
            BeforeUpdate += configureDiseases;
            BeforeUpdate += configureTreatment;
        }
    }
}
