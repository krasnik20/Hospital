using Hospital.ViewModels;
using Model.Model;
using System.Windows;

namespace Hospital.Views.Dialogues
{
    public partial class EditTreatmentDialogue : Window
    {
        public EditTreatmentDialogue()
        {
            InitializeComponent();
            (DataContext as EditTreatmentViewModel).OnCommandPerformed += () => Close();
        }

        public void SetPatient(Patient patient)
        {
            (DataContext as EditTreatmentViewModel).CurrentPatient = patient;
        }

        public void SetCureRecord(CureRecord record)
        {
            (DataContext as EditTreatmentViewModel).CurrentCureRecord = record;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
