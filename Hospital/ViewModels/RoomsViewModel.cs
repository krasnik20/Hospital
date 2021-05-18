using Model.Model;

namespace Hospital.ViewModels
{
    class RoomsViewModel : BaseTabViewModel<Room>
    {
        //private readonly ICRUD<Room> roomsService;

        //private ObservableCollection<Room> rooms;
        //public ObservableCollection<Room> Rooms { get => rooms; set => SetProperty(ref rooms, value); }
        //public Command EditCommand { get; }
        //public Command AddCommand { get; }
        //public Command RemoveCommand { get; }

        //public RoomsViewModel()
        //{
        //    EditCommand = new Command(editRoom);
        //    AddCommand = new Command(addRoom);
        //    RemoveCommand = new Command(removeRoom);

        //    roomsService = ServiceProvider.Instance.GetRequiredService<ICRUD<Room>>();

        //    LoadData();
        //}

        //private void LoadData()
        //{
        //    Rooms = new ObservableCollection<Room>(roomsService.Read());
        //}

        //private void addRoom(object obj)
        //{
        //    var dialog = new EditRoomDialogue();
        //    dialog.ShowDialog();
        //    LoadData();
        //}

        //private void editRoom(object param)
        //{
        //    var dialog = new EditRoomDialogue();
        //    dialog.SetEntity(param as Room);
        //    dialog.ShowDialog();
        //    LoadData();
        //}

        //private void removeRoom(object param)
        //{
        //    try
        //    {
        //        roomsService.Delete(param as Room);
        //        LoadData();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Нельзя удалить палату, т.к. к ней относятся пациенты.", "Ошибка");
        //    }
        //}
    }
}
