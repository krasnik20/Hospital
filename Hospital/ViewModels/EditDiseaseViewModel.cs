using Hospital.Services;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System;
using System.Linq;

namespace Hospital.ViewModels
{
    class EditDiseaseViewModel : BaseViewModel
    {
        private readonly ICRUD<Disease> diseaseService;
        private Disease currentDisease;

        public Disease CurrentDisease { get => currentDisease; set => SetProperty(ref currentDisease, value); }

        public RelayCommand SaveCommand { get; }
        public RelayCommand CancelCommand { get; }

        public Action OnCommandPerformed { get; set; }

        public EditDiseaseViewModel()
        {
            CurrentDisease = new Disease();
            diseaseService = ServiceProvider.Instance.GetRequiredService<ICRUD<Disease>>();
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }

        private void Cancel(object obj)
        {
            if (CurrentDisease.Id != 0)
                CurrentDisease = diseaseService.Read(Disease => Disease.Id == CurrentDisease.Id).FirstOrDefault();

            OnCommandPerformed?.Invoke();
        }

        private void Save(object obj)
        {
            if (CurrentDisease.Id == 0)
                diseaseService.Create(CurrentDisease);
            else
                diseaseService.Update(CurrentDisease);

            OnCommandPerformed?.Invoke();
        }
    }
}
