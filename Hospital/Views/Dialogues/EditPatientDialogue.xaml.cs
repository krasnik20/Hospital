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
            (DataContext as EditPatientViewModel).OnCommandPerformed += () => Close();
        }

        public void SetPatient(Patient patient)
        {
            (DataContext as EditPatientViewModel).CurrentPatient = patient;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
