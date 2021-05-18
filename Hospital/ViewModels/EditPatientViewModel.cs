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
        private List<CureRecord> treatment;
        private PatientDisease selectedDisease;
        private Room[] availableRooms;
        private Room selectedRoom;

        public Patient CurrentPatient { get => currentPatient; set { SetProperty(ref currentPatient, value); LoadData(); } }
        public ObservableCollection<PatientDisease> AvailableDiseases { get => availableDiseases; set => SetProperty(ref availableDiseases, value); }
        public ObservableCollection<PatientDisease> SelectedDiseases { get => selectedDiseases; set => SetProperty(ref selectedDiseases, value); }
        public List<CureRecord> Treatment { get => treatment; set => SetProperty(ref treatment, value); }
        public PatientDisease SelectedDisease { get => selectedDisease; set => SetProperty(ref selectedDisease, value); }
        public Room[] AvailableRooms { get => availableRooms; set => SetProperty(ref availableRooms, value); }
        public Room SelectedRoom { get => selectedRoom; set => SetProperty(ref selectedRoom, value); }

        public Command AddTreatmentCommand { get; }
        public Command EditTreatmentCommand { get; }
        public Command RemoveTreatmentCommand { get; }

        public Command AddDiseaseCommand { get; }
        public Command RemoveDiseaseCommand { get; }

        public Command SaveCommand { get; }

        public Action OnCommandPerformed { get; set; }

        public EditPatientViewModel()
        {
            diseaseService = ServiceProvider.Instance.GetRequiredService<ICRUD<Disease>>();
            patientService = ServiceProvider.Instance.GetRequiredService<ICRUD<Patient>>();

            CurrentPatient = new Patient() { Diseases = new List<PatientDisease>(), Treatment = new List<CureRecord>() };

            AvailableRooms = ServiceProvider.Instance.GetRequiredService<ICRUD<Room>>().Read();
            AddTreatmentCommand = new Command(addTreatment);
            EditTreatmentCommand = new Command(editTreatment);
            RemoveTreatmentCommand = new Command(removeTreatment);

            AddDiseaseCommand = new Command(addDisease);
            RemoveDiseaseCommand = new Command(removeDisease);
            SaveCommand = new Command(Save);

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
            UpdateTreatment();

            if (CurrentPatient.Room != null)
                SelectedRoom = AvailableRooms.FirstOrDefault(r => r.Id == CurrentPatient.Room.Id);
        }

        private void UpdateTreatment()
        {
            Treatment = null;
            Treatment = currentPatient.Treatment;
        }

        private void addTreatment(object param)
        {
            var dialog = new EditTreatmentDialogue();
            dialog.SetPatient(CurrentPatient);
            dialog.ShowDialog();
            UpdateTreatment();
        }

        private void editTreatment(object param)
        {
            var dialog = new EditTreatmentDialogue();
            dialog.SetPatient(CurrentPatient);
            dialog.SetCureRecord(param as CureRecord);
            dialog.ShowDialog();
            UpdateTreatment();
        }

        private void removeTreatment(object param)
        {
            Treatment.Remove(param as CureRecord);
            UpdateTreatment();
        }

        private void Save(object obj)
        {
            try
            {
                CurrentPatient.Diseases = SelectedDiseases.ToList();
                CurrentPatient.Treatment = Treatment.ToList();
                CurrentPatient.Room = SelectedRoom;

                if (CurrentPatient.Id == 0)
                    patientService.Create(CurrentPatient);
                else
                    patientService.Update(CurrentPatient);

                OnCommandPerformed?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Заполнены не все поля или заполнены с ошибкой.", "Ошибка");
            }
        }
    }
}
