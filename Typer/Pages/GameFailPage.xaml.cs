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
            GamePage gamePage = new GamePage();
            this.NavigationService.Navigate(gamePage);
        }

        private void GoToMenuPageButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage mainPage = new MainPage();
            this.NavigationService.Navigate(mainPage);
        }

        private void SaveScoreTextBox_Click(object sender, RoutedEventArgs e)
        {
            ScorePage scorePage = new ScorePage();
            this.NavigationService.Navigate(scorePage);
        }
    }
}
