using Hospital.Views.Dialogues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    class PatientsViewModel : BaseViewModel
    {
        public RelayCommand AddPatientCommand { get; }

        public PatientsViewModel()
        {
            AddPatientCommand = new RelayCommand(addPatient);
        }

        private void addPatient(object param)
        {
            var dialog = new AddPatientDialogue();
            dialog.ShowDialog();
        }
    }
}
