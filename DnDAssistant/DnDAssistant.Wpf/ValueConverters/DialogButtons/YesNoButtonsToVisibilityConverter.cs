﻿using System;
using System.Globalization;
using System.Windows;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    public class YesNoButtonsToVisibilityConverter : BaseValueConverter<YesNoButtonsToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) => ((Buttons)value == Buttons.YesNo) ? Visibility.Visible : Visibility.Collapsed;

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
