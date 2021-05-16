using Hospital.Services;
using Hospital.Views.Dialogues;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System.Collections.ObjectModel;
using System.Windows;

namespace Hospital.ViewModels
{
    class DiseasesViewModel : BaseViewModel
    {
        private readonly ICRUD<Disease> diseaseService;

        private ObservableCollection<Disease> diseases;
        public ObservableCollection<Disease> Diseases { get => diseases; set => SetProperty(ref diseases, value); }

        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand RemoveCommand { get; }


        public DiseasesViewModel()
        {
            AddCommand = new RelayCommand(addDisease);
            EditCommand = new RelayCommand(editDisease);
            RemoveCommand = new RelayCommand(removeDisease);

            diseaseService = ServiceProvider.Instance.GetRequiredService<ICRUD<Disease>>();

            LoadData();
        }

        private void LoadData() => Diseases = new ObservableCollection<Disease>(diseaseService.Read());

        private void editDisease(object disease)
        {
            var dialog = new EditDiseaseDialogue();
            dialog.SetCure(disease as Disease);
            dialog.ShowDialog();
            LoadData();
        }

        private void addDisease(object param)
        {
            var dialog = new EditDiseaseDialogue();
            dialog.ShowDialog();
            LoadData();
        }

        private void removeDisease(object param)
        {
            try
            {
                diseaseService.Delete(param as Disease);
                LoadData();
            }
            catch
            {
                MessageBox.Show("Нельзя удалить болезнь, т.к. она указана у кого-то из пациентов.", "Ошибка");
            }
        }
    }
}
