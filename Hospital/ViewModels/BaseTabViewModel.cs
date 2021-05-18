using Hospital.Services;
using Hospital.Views.Dialogues;
using Microsoft.Extensions.DependencyInjection;
using Model.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Hospital.ViewModels
{
    class BaseTabViewModel<T> : BaseViewModel where T: Entity
    {
        protected readonly ICRUD<T> entityService;
        protected string removeErrorMessage;

        private ObservableCollection<T> entities;
        public ObservableCollection<T> Entities { get => entities; set => SetProperty(ref entities, value); }
        public Command EditCommand { get; }
        public Command AddCommand { get; }
        public Command RemoveCommand { get; }

        public BaseTabViewModel(string removeErrorMessage = "Нельзя удалить cущность, т.к. она связана с другой сущностью.")
        {
            EditCommand = new Command(edit);
            AddCommand = new Command(add);
            RemoveCommand = new Command(remove);

            entityService = ServiceProvider.Instance.GetRequiredService<ICRUD<T>>();

            LoadData();
            this.removeErrorMessage = removeErrorMessage;
        }

        protected void LoadData()
        {
            Entities = new ObservableCollection<T>(entityService.Read());
        }

        protected void add(object obj)
        {
            var dialog = ServiceProvider.Instance.GetRequiredService<IEditDialog<T>>();
            (dialog as Window).ShowDialog();
            LoadData();
        }

        protected void edit(object param)
        {
            var dialog = ServiceProvider.Instance.GetRequiredService<IEditDialog<T>>();
            dialog.SetEntity(entityService.Read(e => e.Id == (param as T).Id).FirstOrDefault());
            (dialog as Window).ShowDialog();
            LoadData();
        }

        protected void remove(object param)
        {
            try
            {
                entityService.Delete(param as T);
                LoadData();
            }
            catch
            {
                MessageBox.Show(removeErrorMessage, "Ошибка");
            }
        }
    }
}
