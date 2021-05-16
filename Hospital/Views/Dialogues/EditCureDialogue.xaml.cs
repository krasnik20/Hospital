using Hospital.ViewModels;
using Model.Model;
using System.Windows;

namespace Hospital.Views.Dialogues
{
    public partial class EditCureDialogue : Window
    {
        public EditCureDialogue()
        {
            InitializeComponent();
            (DataContext as EditCureViewModel).OnCommandPerformed += () => Close();
        }

        public void SetCure(Cure cure)
        {
            (DataContext as EditCureViewModel).CurrentCure = cure;
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            (DataContext as EditCureViewModel).CancelCommand.Execute(null);
        }
    }
}
