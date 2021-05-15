using Hospital.Services;
using Model.Model;
using System.Windows;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var serv = new PatientService();
            var pat = new Patient { FirstName = "test", Diagnosis = new System.Collections.Generic.List<PatientDisease> { new PatientDisease { Disease = new Disease { Name = "Disease1" } }, new PatientDisease { Disease = new Disease { Name = "Disease2" } } } };
            serv.Create(pat);

            var serv3 = new PatientService();
            pat = serv3.Read()[4];
            pat.Diagnosis = null;
            pat.FirstName = "TEST";
            serv3.Update(pat);

            var serv2 = new PatientService();
            var result = serv2.Read();
        }
    }
}
