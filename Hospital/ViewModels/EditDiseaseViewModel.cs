using Hospital.Services;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System;

namespace Hospital.ViewModels
{
    class EditDiseaseViewModel : BaseViewModel
    {
        private readonly ICRUD<Disease> diseaseService;
        private Disease currentDisease;

        public Disease CurrentDisease { get => currentDisease; set => SetProperty(ref currentDisease, value); }

        public Command SaveCommand { get; }

        public Action OnCommandPerformed { get; set; }

        public EditDiseaseViewModel()
        {
            CurrentDisease = new Disease();
            diseaseService = ServiceProvider.Instance.GetRequiredService<ICRUD<Disease>>();
            SaveCommand = new Command(Save);
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
