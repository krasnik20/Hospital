using Model.Model;

namespace Hospital.ViewModels
{
    class PatientsViewModel : BaseTabViewModel<Patient>
    {
        //private readonly ICRUD<Patient> patientsService;

        //private ObservableCollection<Patient> patients;
        //public ObservableCollection<Patient> Patients { get => patients; set => SetProperty(ref patients, value); }

        //public Command AddCommand { get; }
        //public Command EditCommand { get; }
        //public Command RemoveCommand { get; }

        //public PatientsViewModel()
        //{
        //    AddCommand = new Command(addPatient);
        //    EditCommand = new Command(editPatient);
        //    RemoveCommand = new Command(removePatient);

        //    patientsService = ServiceProvider.Instance.GetRequiredService<ICRUD<Patient>>();

        //    LoadData();
        //}

        //private void addPatient(object param)
        //{
        //    var dialog = new EditPatientDialogue();
        //    dialog.ShowDialog();

        //    LoadData();
        //}

        //private void LoadData() => Patients = new ObservableCollection<Patient>(patientsService.Read());

        //private void editPatient(object disease)
        //{
        //    var dialog = new EditPatientDialogue();
        //    dialog.SetPatient(disease as Patient);
        //    dialog.ShowDialog();
        //    LoadData();
        //}

        //private void removePatient(object param)
        //{
        //    try
        //    {
        //        patientsService.Delete(param as Patient);
        //        LoadData();
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Нельзя удалить этого пациента.", "Ошибка");
        //    }
        //}
    }
}
