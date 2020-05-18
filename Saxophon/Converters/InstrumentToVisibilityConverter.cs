using Saxophon.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Saxophon.Converters
{
    class InstrumentToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var para = (string)parameter;
            var instrument = (Instrument)value;

            if(para == "Flute")
            {
                return instrument == Instrument.Querflöte ? Visibility.Visible : Visibility.Collapsed;
            }
            else if(para == "Sax")
            {           
                return instrument == Instrument.Saxophon ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
