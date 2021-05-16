using Model.Model;

namespace Hospital.ViewModels
{
    class AddServiceViewModel : BaseViewModel
    {
        private Cure currentCure;
        private Disease[] availableDiseases;

        public Cure CurrentCure { get => currentCure; set => SetProperty(ref currentCure, value); }
        public Disease[] AvailableDiseases { get => availableDiseases; set => SetProperty(ref availableDiseases, value); }

        public AddServiceViewModel()
        {

        }
    }
}
