using Model.Model;

namespace Hospital.ViewModels
{
    class EditTreatmentViewModel : BaseViewModel
    {
        private CureRecord currentCureRecord;
        private Cure[] availableCures;

        public CureRecord CurrentCureRecord { get => currentCureRecord; set => SetProperty(ref currentCureRecord, value); }
        public Cure[] AvailableCures { get => availableCures; set => SetProperty(ref availableCures, value); }

        public EditTreatmentViewModel()
        {

        }
    }
}
