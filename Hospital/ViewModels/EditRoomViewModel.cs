using Model.Model;

namespace Hospital.ViewModels

{
    class EditRoomViewModel : BaseViewModel
    {
        private Doctor[] availableDoctors;

        public Doctor[] AvailableDoctors { get => availableDoctors; set => SetProperty(ref availableDoctors, value); }

        public EditRoomViewModel()
        {

        }
    }
}
