﻿using System;
using System.Globalization;

namespace DnDAssistant.Wpf
{
    public class ParentSizeToDieSizeConverter : BaseValueConverter<ParentSizeToDieSizeConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value / 6;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}