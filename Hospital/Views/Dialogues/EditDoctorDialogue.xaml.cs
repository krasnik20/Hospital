using Hospital.ViewModels;
using Model.Model;
using System.Windows;

namespace Hospital.Views.Dialogues
{
    public partial class EditDoctorDialogue : Window, IEditDialog<Doctor>
    {
        public EditDoctorDialogue()
        {
            InitializeComponent();
            (DataContext as EditDoctorViewModel).OnCommandPerformed += () => Close();
        }

        public void SetEntity(Doctor entity)
        {
            (DataContext as EditDoctorViewModel).CurrentDoctor = entity;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
