using Hospital.Services;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System;
using System.Windows;

namespace Hospital.ViewModels
{
    class EditDoctorViewModel : BaseViewModel
    {
        private readonly ICRUD<Doctor> doctorsService;
        private Doctor currentDoctor;

        public Doctor CurrentDoctor { get => currentDoctor; set { SetProperty(ref currentDoctor, value); } }
        public Command SaveCommand { get; }

        public Action OnCommandPerformed { get; set; }

        public EditDoctorViewModel()
        {
            doctorsService = ServiceProvider.Instance.GetRequiredService<ICRUD<Doctor>>();

            CurrentDoctor = new Doctor();
            SaveCommand = new Command(Save);
        }

        private void Save(object obj)
        {
            try
            {

                if (CurrentDoctor.Id == 0)
                    doctorsService.Create(CurrentDoctor);
                else
                    doctorsService.Update(CurrentDoctor);

                OnCommandPerformed?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Заполнены не все поля", "Ошибка");
            }
        }
    }
}
