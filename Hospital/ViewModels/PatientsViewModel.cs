using Hospital.Services;
using Hospital.Views.Dialogues;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Hospital.ViewModels
{
    class PatientsViewModel : BaseViewModel
    {
        private readonly ICRUD<Patient> patientsService;

        private ObservableCollection<Patient> patients;
        public ObservableCollection<Patient> Patients { get => patients; set => SetProperty(ref patients, value); }

        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand RemoveCommand { get; }

        public PatientsViewModel()
        {
            AddCommand = new RelayCommand(addPatient);
            EditCommand = new RelayCommand(editPatient);
            RemoveCommand = new RelayCommand(removePatient);

            patientsService = ServiceProvider.Instance.GetRequiredService<ICRUD<Patient>>();

            LoadData();
        }

        private void addPatient(object param)
        {
            var dialog = new EditPatientDialogue();
            dialog.ShowDialog();

            LoadData();
        }

        private void LoadData() => Patients = new ObservableCollection<Patient>(patientsService.Read());

        private void editPatient(object disease)
        {
            var dialog = new EditPatientDialogue();
            dialog.SetPatient(disease as Patient);
            dialog.ShowDialog();
            LoadData();
        }

        private void removePatient(object param)
        {
            try
            {
                patientsService.Delete(param as Patient);
                LoadData();
            }
            catch
            {
                MessageBox.Show("Нельзя удалить этого пациента.", "Ошибка");
            }
        }
    }
}
