using Hospital.Views.Dialogues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    class ServicesViewModel : BaseViewModel
    {
        public RelayCommand AddServiceCommand { get; }

        public ServicesViewModel()
        {
            AddServiceCommand = new RelayCommand(addService);
        }

        private void addService(object param)
        {
            var dialog = new AddServiceDialogue();
            dialog.ShowDialog();
        }
    }
}
