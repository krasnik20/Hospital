using Hospital.ViewModels;
using Model.Model;
using System.Windows;

namespace Hospital.Views.Dialogues
{
    public partial class EditCureDialogue : Window, IEditDialog<Cure>
    {
        public EditCureDialogue()
        {
            InitializeComponent();
            (DataContext as EditCureViewModel).OnCommandPerformed += () => Close();
        }

        public void SetEntity(Cure entity)
        {
            (DataContext as EditCureViewModel).CurrentCure = entity;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
