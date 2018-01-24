using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for HexagonWidget.xaml
    /// </summary>
    public partial class HexagonWidget : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// Property to indicate that the control is selected
        /// </summary>
        public ICommand Click
        {
            get => (ICommand)GetValue(ClickProperty);
            set => SetValue(ClickProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClickProperty =
            DependencyProperty.Register(nameof(Click), typeof(ICommand), typeof(HexagonWidget), new PropertyMetadata(null));

        /// <summary>
        /// Property to indicate that the control is selected
        /// </summary>
        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register(nameof(IsSelected), typeof(bool), typeof(HexagonWidget), new PropertyMetadata(null));

        /// <summary>
        /// Background image of the control
        /// </summary>
        public string Image
        {
            get => (string)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register(nameof(Image), typeof(string), typeof(HexagonWidget), new PropertyMetadata(string.Empty, ImagePropertyChanged));

        

        #endregion

        public HexagonWidget()
        {
            InitializeComponent();
        }

        private static void ImagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
        }
    }
}
