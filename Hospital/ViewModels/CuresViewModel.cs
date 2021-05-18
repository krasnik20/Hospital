using Model.Model;

namespace Hospital.ViewModels
{
    class CuresViewModel : BaseTabViewModel<Cure>
    {
        //private readonly ICRUD<Cure> cureService;

        //private ObservableCollection<Cure> cures;
        //public ObservableCollection<Cure> Cures { get => cures; set => SetProperty(ref cures, value); }

        //public Command AddCureCommand { get; }
        //public Command EditCureCommand { get; }
        //public Command RemoveCureCommand { get; }


        //public CuresViewModel()
        //{
        //    AddCureCommand = new Command(addCure);
        //    EditCureCommand = new Command(editCure);
        //    RemoveCureCommand = new Command(removeCure);

        //    cureService = ServiceProvider.Instance.GetRequiredService<ICRUD<Cure>>();

        //    LoadData();
        //}

        //private void LoadData() => Cures = new ObservableCollection<Cure>(cureService.Read());

        //private void editCure(object cure)
        //{
        //    var dialog = new EditCureDialogue();
        //    dialog.SetCure(cure as Cure);
        //    dialog.ShowDialog();
        //    LoadData();
        //}

        //private void addCure(object param)
        //{
        //    var dialog = new EditCureDialogue();
        //    dialog.ShowDialog();
        //    LoadData();
        //}

        //private void removeCure(object param)
        //{
        //    try
        //    {
        //        cureService.Delete(param as Cure);
        //        LoadData();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Нельзя удалить услугу, т.к. ее использует кто-то из пациентов.", "Ошибка");
        //    }
        //}
    }
}
