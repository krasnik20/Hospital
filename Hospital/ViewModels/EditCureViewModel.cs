using Hospital.Services;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System;

namespace Hospital.ViewModels
{
    class EditCureViewModel : BaseViewModel
    {
        protected readonly ICRUD<Cure> cureService;
        private Cure currentCure;

        public Cure CurrentCure
        {
            get => currentCure;
            set => SetProperty(ref currentCure, value);
        }

        public Command SaveCommand { get; }

        public Action OnCommandPerformed { get; set; }

        public EditCureViewModel()
        {
            CurrentCure = new Cure();
            cureService = ServiceProvider.Instance.GetRequiredService<ICRUD<Cure>>();
            SaveCommand = new Command(Save);
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
