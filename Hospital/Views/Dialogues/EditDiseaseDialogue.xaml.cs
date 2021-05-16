using Hospital.ViewModels;
using Model.Model;
using System;
using System.Windows;

namespace Hospital.Views.Dialogues
{
    public partial class EditDiseaseDialogue : Window
    {
        public EditDiseaseDialogue()
        {
            InitializeComponent();
            (DataContext as EditDiseaseViewModel).OnCommandPerformed += () => Close();
        }

        public void SetCure(Disease disease)
        {
            (DataContext as EditDiseaseViewModel).CurrentDisease = disease;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            (DataContext as EditDiseaseViewModel).CancelCommand.Execute(null);
        }
    }
}
