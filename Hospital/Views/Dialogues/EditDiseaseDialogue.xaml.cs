using Hospital.ViewModels;
using Model.Model;
using System.Windows;

namespace Hospital.Views.Dialogues
{
    public partial class EditDiseaseDialogue : Window, IEditDialog<Disease>
    {
        public EditDiseaseDialogue()
        {
            InitializeComponent();
            (DataContext as EditDiseaseViewModel).OnCommandPerformed += () => Close();
        }

        public void SetEntity(Disease entity)
        {
            (DataContext as EditDiseaseViewModel).CurrentDisease = entity;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
