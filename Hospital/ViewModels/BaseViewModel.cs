using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Hospital.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected void SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            backingStore = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
