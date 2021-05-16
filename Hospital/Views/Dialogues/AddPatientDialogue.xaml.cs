using Hospital.ViewModels;
using Model.Model;
using System.Windows;

namespace Hospital.Views.Dialogues
{
    public partial class AddPatientDialogue : Window
    {
        public AddPatientDialogue()
        {
            InitializeComponent();
        }

        public void SetPatient(Patient patient)
        {
            (DataContext as AddPatientViewModel).CurrentPatient = patient;
        }
    }
}
