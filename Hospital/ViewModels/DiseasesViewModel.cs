using Model.Model;

namespace Hospital.ViewModels
{
    class DiseasesViewModel : BaseTabViewModel<Disease>
    {
        //private readonly ICRUD<Disease> diseaseService;

        //private ObservableCollection<Disease> diseases;
        //public ObservableCollection<Disease> Diseases { get => diseases; set => SetProperty(ref diseases, value); }

        //public Command AddCommand { get; }
        //public Command EditCommand { get; }
        //public Command RemoveCommand { get; }


        //public DiseasesViewModel()
        //{
        //    AddCommand = new Command(addDisease);
        //    EditCommand = new Command(editDisease);
        //    RemoveCommand = new Command(removeDisease);

        //    diseaseService = ServiceProvider.Instance.GetRequiredService<ICRUD<Disease>>();

        //    LoadData();
        //}

        //private void LoadData() => Diseases = new ObservableCollection<Disease>(diseaseService.Read());

        //private void editDisease(object disease)
        //{
        //    var dialog = new EditDiseaseDialogue();
        //    dialog.SetCure(disease as Disease);
        //    dialog.ShowDialog();
        //    LoadData();
        //}

        //private void addDisease(object param)
        //{
        //    var dialog = new EditDiseaseDialogue();
        //    dialog.ShowDialog();
        //    LoadData();
        //}

        //private void removeDisease(object param)
        //{
        //    try
        //    {
        //        diseaseService.Delete(param as Disease);
        //        LoadData();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Нельзя удалить болезнь, т.к. она указана у кого-то из пациентов.", "Ошибка");
        //    }
        //}
    }
}
