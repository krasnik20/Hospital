using Hospital.Services;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System;
using System.Linq;

namespace Hospital.ViewModels
{
    class EditCureViewModel : BaseViewModel
    {
        private readonly ICRUD<Cure> cureService;

        private Cure currentCure;
        private Disease[] availableDiseases;

        public Cure CurrentCure { get => currentCure; set => SetProperty(ref currentCure, value); }
        public Disease[] AvailableDiseases { get => availableDiseases; set => SetProperty(ref availableDiseases, value); }

        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }

        public Action OnCommandPerformed { get; set; }

        public EditCureViewModel()
        {
            CurrentCure = new Cure();
            cureService = ServiceProvider.Instance.GetRequiredService<ICRUD<Cure>>();
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Cancel(object obj)
        {
            if (CurrentCure.Id != 0)
                CurrentCure = cureService.Read(cure => cure.Id == CurrentCure.Id).FirstOrDefault();

            OnCommandPerformed?.Invoke();
        }

        private void Save(object obj)
        {
            if (CurrentCure.Id == 0)
                cureService.Create(CurrentCure);
            else
                cureService.Update(CurrentCure);

            OnCommandPerformed?.Invoke();
        }
    }
}
