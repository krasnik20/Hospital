using Hospital.Services;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System;
using System.Windows;

namespace Hospital.ViewModels
{
    class EditBaseViewModel<T> : BaseViewModel where T : Entity
    {
        protected readonly ICRUD<T> entityService;
        protected T currentEntity;

        protected Action OnCurrentEntityChange;
        protected Action BeforeSave;

        protected string SaveErrorMessage = "Произошла неизвестная ошибка";

        public T CurrentEntity
        {
            get => currentEntity;
            set
            {
                SetProperty(ref currentEntity, value);
                OnCurrentEntityChange?.Invoke();
            }
        }

        public Command SaveCommand { get; }

        public Action OnCommandPerformed { get; set; }

        public EditBaseViewModel()
        {
            entityService = ServiceProvider.Instance.GetRequiredService<ICRUD<T>>();
            SaveCommand = new Command(Save);
        }

        private void Save(object obj)
        {
            try
            {
                BeforeSave?.Invoke();

                if (CurrentEntity.Id == 0)
                    entityService.Create(CurrentEntity);
                else
                    entityService.Update(CurrentEntity);

                OnCommandPerformed?.Invoke();
            }
            catch
            {
                MessageBox.Show(SaveErrorMessage, "Ошибка");
            }
        }
    }
}
