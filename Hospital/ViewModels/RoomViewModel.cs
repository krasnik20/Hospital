using Hospital.Views.Dialogues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    class RoomViewModel : BaseViewModel
    {
        public RelayCommand EditRoomCommand { get; }

        public RoomViewModel()
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
