using Hospital.Services;
using Hospital.Views.Dialogues;
using Model.Model;
using System.Collections.Generic;
using System.Windows;

namespace Hospital
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //var serv = new PatientService();
            //var pat = new Patient 
            //{ 
            //    FirstName = "adding", 
            //    Diagnosis = new List<PatientDisease> 
            //    { 
            //        new PatientDisease { Disease = new Disease { Name = "Disease1" } }, 
            //        new PatientDisease { Disease = new Disease { Name = "Disease2" } } 
            //    },
            //    Treatment = new List<CureRecord>
            //    {
            //        new CureRecord { Cure = new Cure {Name = "Cure1"}, Instructions="пошел нахуй"},
            //        new CureRecord { Cure = new Cure {Name = "Cure2"}, Instructions="пошел в пизду"}
            //    }
            //};
            //serv.Create(pat);

            //var serv3 = new PatientService();
            //pat = serv3.Read()[0];
            //pat.Diagnosis = null;
            //pat.FirstName = "TEST";
            //serv3.Update(pat);

            //var serv2 = new PatientService();
            //var result = serv2.Read();
        }
    }
}
