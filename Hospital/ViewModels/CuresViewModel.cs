using Hospital.Services;
using Hospital.Views.Dialogues;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Hospital.ViewModels
{
    class CuresViewModel : BaseViewModel
    {
        private readonly ICRUD<Cure> cureService;

        private ObservableCollection<Cure> cures;
        public ObservableCollection<Cure> Cures { get => cures; set => SetProperty(ref cures, value); }

        public RelayCommand AddCureCommand { get; }
        public RelayCommand EditCureCommand { get; }
        public RelayCommand RemoveCureCommand { get; }


        public CuresViewModel()
        {
            AddCureCommand = new RelayCommand(addCure);
            EditCureCommand = new RelayCommand(editCure);
            RemoveCureCommand = new RelayCommand(removeCure);

            cureService = ServiceProvider.Instance.GetRequiredService<ICRUD<Cure>>();

            LoadData();
        }

        private void LoadData() => Cures = new ObservableCollection<Cure>(cureService.Read());

        private void editCure(object cure)
        {
            var dialog = new EditCureDialogue();
            dialog.SetCure(cure as Cure);
            dialog.ShowDialog();
            LoadData();
        }

        private void addCure(object param)
        {
            var dialog = new EditCureDialogue();
            dialog.ShowDialog();
            LoadData();
        }

        private void removeCure(object param)
        {
            try
            {
                cureService.Delete(param as Cure);
                LoadData();
            }
            catch
            {
                MessageBox.Show("Нельзя удалить услугу, т.к. ее использует кто-то из пациентов.", "Ошибка");
            }
        }
    }
}
