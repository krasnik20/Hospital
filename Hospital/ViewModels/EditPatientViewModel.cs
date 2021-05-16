using Hospital.Views.Dialogues;
using Model.Model;


namespace Hospital.ViewModels
{
    class EditPatientViewModel : BaseViewModel
    {
        private Patient currentPatient;
        private Disease[] availableDiseases;
        private Room[] availableRooms;

        public Patient CurrentPatient { get => currentPatient; set => SetProperty(ref currentPatient, value); }
        public Disease[] AvailableDiseases { get => availableDiseases; set => SetProperty(ref availableDiseases, value); }
        public Room[] AvailableRooms { get => availableRooms; set => SetProperty(ref availableRooms, value); }

        public RelayCommand AddTreatmentCommand { get; }

        public EditPatientViewModel()
        {
            AddTreatmentCommand = new RelayCommand(addTreatment);
        }

        private void addTreatment(object param)
        {
            var dialog = new EditTreatmentDialogue();
            dialog.ShowDialog();
        }
    }
}
