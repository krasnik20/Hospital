using Hospital.Services;
using Hospital.Views.Dialogues;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;

namespace Hospital.ViewModels
{
    class BaseTabViewModel<T> : BaseViewModel where T: class
    {
        private readonly ICRUD<T> entityService;

        private ObservableCollection<T> entities;
        public ObservableCollection<T> Entities { get => entities; set => SetProperty(ref entities, value); }
        public Command EditCommand { get; }
        public Command AddCommand { get; }
        public Command RemoveCommand { get; }

        public BaseTabViewModel()
        {
            EditCommand = new Command(edit);
            AddCommand = new Command(add);
            RemoveCommand = new Command(remove);

            entityService = ServiceProvider.Instance.GetRequiredService<ICRUD<T>>();

            LoadData();
        }

        private void LoadData()
        {
            Entities = new ObservableCollection<T>(entityService.Read());
        }

        private void add(object obj)
        {
            var dialog = ServiceProvider.Instance.GetRequiredService<IEditDialog<T>>();
            (dialog as Window).ShowDialog();
            LoadData();
        }

        private void edit(object param)
        {
            var dialog = ServiceProvider.Instance.GetRequiredService<IEditDialog<T>>();
            dialog.SetEntity(param as T);
            (dialog as Window).ShowDialog();
            LoadData();
        }

        private void remove(object param)
        {
            try
            {
                entityService.Delete(param as T);
                LoadData();
            }
            catch
            {
                MessageBox.Show("Нельзя удалить палату, т.к. к ней относятся пациенты.", "Ошибка");
            }
        }
    }
}
