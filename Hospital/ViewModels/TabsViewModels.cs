using Model.Model;

namespace Hospital.ViewModels
{
    class CuresViewModel : BaseTabViewModel<Cure>
    {
        public CuresViewModel() : base("Нельзя удалить услугу, т.к. ее использует кто-то из пациентов.") { }
    }

    class DiseasesViewModel : BaseTabViewModel<Disease>
    {
        public DiseasesViewModel() : base("Нельзя удалить болезнь, т.к. она указана у кого-то из пациентов.") { }
    }

    class DoctorsViewModel : BaseTabViewModel<Doctor>
    {
        public DoctorsViewModel() : base("Нельзя удалить врача, т.к. он относится к какой-то палате") { }
    }

    class PatientsViewModel : BaseTabViewModel<Patient>
    {
        public PatientsViewModel() : base("Нельзя удалить этого пациента.") { }
    }

    class RoomsViewModel : BaseTabViewModel<Room>
    {
        public RoomsViewModel() : base("Нельзя удалить палату, т.к. к ней относятся пациенты.") { }
    }
}
