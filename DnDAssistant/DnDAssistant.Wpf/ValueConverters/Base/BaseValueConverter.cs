using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// A base value converter that allows direct xaml usage
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T : class, new()
    {

        #region Private Members
        /// <summary>
        /// A single static instance of the value converter
        /// </summary>
        private static T MConverter = null;

        #endregion

        #region Markup Extension Members
        /// <summary>
        /// Provides a static instance of this value converter
        /// </summary>
        /// <param name="serviceProvider">The service provider</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            /*
                if (mConverter == null)
                    mConverter = new T();
                return mConverter;
             */
            return MConverter ?? (MConverter = new T());
        }

        #endregion

        #region Value Converter Methods
        /// <summary>
        /// The method to convert one type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
