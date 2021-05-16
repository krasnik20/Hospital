using Hospital.ViewModels;
using Model.Model;
using System.Windows;

namespace Hospital.Views.Dialogues
{
    public partial class EditPatientDialogue : Window
    {
        public EditPatientDialogue()
        {
            InitializeComponent();
        }

        public void SetPatient(Patient patient)
        {
            (DataContext as EditPatientViewModel).CurrentPatient = patient;
        }
    }
}
