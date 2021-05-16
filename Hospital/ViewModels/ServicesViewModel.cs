using Hospital.Views.Dialogues;

namespace Hospital.ViewModels
{
    class ServicesViewModel : BaseViewModel
    {
        public RelayCommand AddServiceCommand { get; }

        public ServicesViewModel()
        {
            AddServiceCommand = new RelayCommand(addService);
        }

        private void addService(object param)
        {
            var dialog = new AddServiceDialogue();
            dialog.ShowDialog();
        }
    }
}
