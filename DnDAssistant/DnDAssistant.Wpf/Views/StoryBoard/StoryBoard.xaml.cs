using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using DnDAssistant.Core;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Interaction logic for StoryBoard.xaml
    /// </summary>
    public partial class StoryBoard : BasePage
    {
        private Point _Start;
        private Point _End;

        public StoryBoard()
        {
            InitializeComponent();
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if((DataContext as StoryBoardViewModel).ChapterTool.CreateChapterActive == true)
            {
                _Start = e.GetPosition((sender as Grid));
            }
        }

        private void Grid_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var grid = sender as Grid;
            if ((DataContext as StoryBoardViewModel).ChapterTool.CreateChapterActive == true)
            {
                _End = e.GetPosition(grid);
            }

            if(_Start != null && _End != null)
            {
                var b = new Border
                {
                    Width = _End.X - _Start.X,
                    Height = _End.Y - _Start.Y,
                    Background = (SolidColorBrush)Application.Current.Resources["RedBrush"],
                };

                grid.Children.Add(b);
            }
        }
    }
}
