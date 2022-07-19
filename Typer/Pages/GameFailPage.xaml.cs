using System.Windows;
using System.Windows.Controls;

namespace Typer.Pages
{
    /// <summary>
    /// Interaction logic for GameFailPage.xaml
    /// </summary>
    public partial class GameFailPage : Page
    {
        public GameFailPage()
        {
            InitializeComponent();
        }

        private void TryAgainButton_Click(object sender, RoutedEventArgs e)
        {
            Frame frame = new Frame();

            frame.Content = new GamePage();
            this.Content = frame;
        }

        private void GoToMenuPageButton_Click(object sender, RoutedEventArgs e)
        {
            Frame frame = new Frame();

            frame.Content = new MainPage();
            this.Content = frame;
        }
    
    }
}
