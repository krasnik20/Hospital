using Hospital.Services;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Hospital.ViewModels
{
    class EditTreatmentViewModel : BaseViewModel
    {
        private readonly ICRUD<Cure> curesService;

        private CureRecord currentCureRecord;
        private ObservableCollection<Cure> availableCures;
        private Patient currentPatient;
        private Cure selectedCure;

        public Patient CurrentPatient { get => currentPatient; set { SetProperty(ref currentPatient, value); LoadData(); } }

        public CureRecord CurrentCureRecord { get => currentCureRecord; set { SetProperty(ref currentCureRecord, value); SetCurrentCure(); } }

        public ObservableCollection<Cure> AvailableCures { get => availableCures; set => SetProperty(ref availableCures, value); }

        public Cure SelectedCure { get => selectedCure; set { SetProperty(ref selectedCure, value); } }

        public Command SaveCureCommand { get; }

        public Action OnCommandPerformed { get; set; }

        public EditTreatmentViewModel()
        {
            CurrentCureRecord = new CureRecord();
            curesService = ServiceProvider.Instance.GetRequiredService<ICRUD<Cure>>();

            SaveCureCommand = new Command(saveCure);
        }

        private void LoadData()
        {
            IEnumerable<Cure> result;
            if (CurrentPatient.Treatment == null || CurrentPatient.Treatment.Count == 0)
                result = curesService.Read();
            else
            {
                var cureIds = CurrentPatient.Treatment.Select(c => c.Cure.Id);
                result = curesService.Read(c => !cureIds.Contains(c.Id));
            }
            AvailableCures = new ObservableCollection<Cure>(result);
        }

        private void SetCurrentCure()
        {
            if(AvailableCures != null)
            {
                AvailableCures.Add(CurrentCureRecord.Cure);
                SelectedCure = AvailableCures.Last();
            }
        }

        private void saveCure(object obj)
        {
            if (CurrentPatient == null) return;
            if(SelectedCure == null)
            {
                MessageBox.Show("Выберите услугу.", "Ошибка");
                return;
            }
            CurrentCureRecord.Cure = SelectedCure;
            CurrentCureRecord.Patient = CurrentPatient;
            if(CurrentCureRecord.Id == 0)
                CurrentPatient.Treatment.Add(CurrentCureRecord);
            OnCommandPerformed?.Invoke();
        }
    }
}
