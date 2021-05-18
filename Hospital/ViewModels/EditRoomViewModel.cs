using Hospital.Services;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System;
using System.Linq;
using System.Windows;

namespace Hospital.ViewModels

{
    class EditRoomViewModel : BaseViewModel
    {
        private readonly ICRUD<Room> roomsService;

        private Doctor[] availableDoctors;
        private Doctor selectedDoctor;
        private Room currentRoom;
        private Patient[] patients;

        public Doctor[] AvailableDoctors { get => availableDoctors; set => SetProperty(ref availableDoctors, value); }
        public Doctor SelectedDoctor { get => selectedDoctor; set => SetProperty(ref selectedDoctor, value); }
        public Patient[] Patients { get => patients; set => SetProperty(ref patients, value); }

        public Room CurrentRoom { get => currentRoom; set { SetProperty(ref currentRoom, value); SetCurrentDoctor(); } }

        public Command SaveCommand { get; }

        public Action OnCommandPerformed { get; set; }

        public EditRoomViewModel()
        {
            CurrentRoom = new Room();
            SaveCommand = new Command(Save);

            roomsService = ServiceProvider.Instance.GetRequiredService<ICRUD<Room>>();

            AvailableDoctors = ServiceProvider.Instance.GetRequiredService<ICRUD<Doctor>>().Read();
        }

        private void SetCurrentDoctor()
        {
            if (CurrentRoom?.Doctor != null)
                SelectedDoctor = AvailableDoctors.FirstOrDefault(d => d.Id == CurrentRoom.Doctor.Id);
        }

        private void Save(object obj)
        {
            try
            {
                CurrentRoom.Doctor = SelectedDoctor;

                if (CurrentRoom.Id == 0)
                    roomsService.Create(CurrentRoom);
                else
                    roomsService.Update(CurrentRoom);

                OnCommandPerformed?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Заполнены не все поля, задан некорректный номер палаты или номер, который уже используется другой палатой.", "Ошибка");
            }
        }
    }
}
