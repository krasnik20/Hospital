using Hospital.Views.Dialogues;

namespace Hospital.ViewModels
{
    class RoomsViewModel : BaseViewModel
    {
        public RelayCommand EditRoomCommand { get; }

        public RoomsViewModel()
        {
            EditRoomCommand = new RelayCommand(editRoom);
        }

        private void editRoom(object param)
        {
            var dialog = new EditRoomDialogue();
            dialog.ShowDialog();
        }
    }
}
