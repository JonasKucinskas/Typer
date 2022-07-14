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
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void SaveSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            config settings = new config();
            try
            {
                settings.Time = Int32.Parse(TimeSelectField.Text);
                settings.Language = LanguageSelectBox.Text;

            }
            catch
            {            

            }

            config.WriteToConfig(settings);
        }
    }
}
