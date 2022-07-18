using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            this.NavigationService.Refresh();
        }
    }
}
