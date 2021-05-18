using Hospital.ViewModels;
using Model.Model;
using System.Windows;

namespace Hospital.Views.Dialogues
{
    public partial class EditPatientDialogue : Window, IEditDialog<Patient>
    {
        public EditPatientDialogue()
        {
            InitializeComponent();
            (DataContext as EditPatientViewModel).OnCommandPerformed += () => Close();
        }

        public void SetEntity(Patient entity)
        {
            (DataContext as EditPatientViewModel).CurrentPatient = entity;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
