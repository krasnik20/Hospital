using Hospital.ViewModels;
using Model.Model;
using System.Windows;

namespace Hospital.Views.Dialogues
{
    public partial class EditRoomDialogue : Window, IEditDialog<Room>
    {
        public EditRoomDialogue()
        {
            InitializeComponent();
            (DataContext as EditRoomViewModel).OnCommandPerformed += () => Close();
        }

        public void SetEntity(Room room)
        {
            (DataContext as EditRoomViewModel).CurrentRoom = room;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
