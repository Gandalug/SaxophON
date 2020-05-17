using Saxophon.Models;
using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace Saxophon.Converters
{
    class InstrumentToOrientationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var instrument = (Instrument)value;

            return instrument == Instrument.Querflöte ? Orientation.Vertical : Orientation.Horizontal;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
