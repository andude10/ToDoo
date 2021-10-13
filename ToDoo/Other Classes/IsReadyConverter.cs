using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace ToDoo
{
    class IsReadyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isReady = (bool)value;
            if (isReady)
                return TextDecorations.Strikethrough;
            else
                return TextDecorations.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TextDecorations decorations = (TextDecorations)value;
            if (decorations == TextDecorations.Strikethrough)
                return true;
            else
                return false;
        }
    }
}
