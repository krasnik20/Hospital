using Model;
using System;

namespace Hospital.ViewModels
{
    class AddPatientViewModel : BaseViewModel
    {
        private Patient currentPatient;
        private Disease[] availableDiseases;

        public Patient CurrentPatient { get => currentPatient; set => SetProperty(ref currentPatient, value); }
        public Disease[] AvailableDiseases { get => availableDiseases; set => SetProperty(ref availableDiseases, value); }

        public AddPatientViewModel()
        {
        }

    }
}
