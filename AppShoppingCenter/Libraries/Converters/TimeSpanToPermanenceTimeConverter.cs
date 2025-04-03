using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShoppingCenter.Models;

namespace AppShoppingCenter.Libraries.Converters
{
    public class TimeSpanToPermanenceTimeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null) return null;
            Ticket ticket = (Ticket)value;
            var dif = ticket.DateOut.Ticks - ticket.DateIn.Ticks;
            var difTS = new TimeSpan(dif);
            return string.Format("{0:D2}h {1:D2}m", difTS.Hours, difTS.Minutes);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
