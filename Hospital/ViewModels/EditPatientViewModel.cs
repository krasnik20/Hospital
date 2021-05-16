using Hospital.Services;
using Hospital.Views.Dialogues;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Hospital.ViewModels
{
    class EditPatientViewModel : BaseViewModel
    {
        private readonly ICRUD<Patient> patientService;
        private readonly ICRUD<Disease> diseaseService;
        private Patient currentPatient;
        private ObservableCollection<PatientDisease> availableDiseases;
        private ObservableCollection<PatientDisease> selectedDiseases;
        private PatientDisease selectedDisease;
        //private Room[] availableRooms;

        public Patient CurrentPatient { get => currentPatient; set { SetProperty(ref currentPatient, value); LoadData(); } }
        public ObservableCollection<PatientDisease> AvailableDiseases { get => availableDiseases; set => SetProperty(ref availableDiseases, value); }
        public ObservableCollection<PatientDisease> SelectedDiseases { get => selectedDiseases; set => SetProperty(ref selectedDiseases, value); }
        public PatientDisease SelectedDisease { get => selectedDisease; set => SetProperty(ref selectedDisease, value); }
        //public Room[] AvailableRooms { get => availableRooms; set => SetProperty(ref availableRooms, value); }

        public RelayCommand AddTreatmentCommand { get; }
        public RelayCommand AddDiseaseCommand { get; }
        public RelayCommand RemoveDiseaseCommand { get; }

        public RelayCommand SaveCommand { get; }

        public Action OnCommandPerformed { get; set; }

        public EditPatientViewModel()
        {
            diseaseService = ServiceProvider.Instance.GetRequiredService<ICRUD<Disease>>();
            patientService = ServiceProvider.Instance.GetRequiredService<ICRUD<Patient>>();

            CurrentPatient = new Patient() { Diseases = new List<PatientDisease>(), Treatment = new List<CureRecord>() };
            AddTreatmentCommand = new RelayCommand(addTreatment);
            AddDiseaseCommand = new RelayCommand(addDisease);
            RemoveDiseaseCommand = new RelayCommand(removeDisease);
            SaveCommand = new RelayCommand(Save);

            LoadData();
        }

        private void removeDisease(object param)
        {
            SelectedDiseases.Remove(param as PatientDisease);
            AvailableDiseases.Add(param as PatientDisease);
        }

        private void addDisease(object obj)
        {
            if (SelectedDisease == null) return;
            SelectedDiseases.Add(SelectedDisease);
            AvailableDiseases.Remove(SelectedDisease);
            SelectedDisease = null;
        }

        private void LoadData()
        {
            if (CurrentPatient == null) return;
            var diseaseIds = CurrentPatient.Diseases?.Select(d => d.Disease.Id);
            AvailableDiseases = 
                new ObservableCollection<PatientDisease>(
                    diseaseService.Read(diseaseIds == null || !diseaseIds.Any() ? null : d => !diseaseIds.Contains(d.Id))
                    .Select(d => new PatientDisease { Disease = d, Patient = currentPatient })
                    );
            SelectedDiseases = new ObservableCollection<PatientDisease>(currentPatient.Diseases);
        }

        private void addTreatment(object param)
        {
            var dialog = new EditTreatmentDialogue();
            dialog.ShowDialog();
        }

        private void Save(object obj)
        {
            try
            {
                CurrentPatient.Diseases = SelectedDiseases.ToList();

                if (CurrentPatient.Id == 0)
                    patientService.Create(CurrentPatient);
                else
                    patientService.Update(CurrentPatient);

                OnCommandPerformed?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Заполнены не все поля", "Ошибка");
            }
        }
    }
}
