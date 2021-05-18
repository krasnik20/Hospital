using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Hospital.Views
{
    public partial class PatientsTab : UserControl
    {
        public PatientsTab()
        {
            InitializeComponent();
        }
    }

    public class DateTimeToDateTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
