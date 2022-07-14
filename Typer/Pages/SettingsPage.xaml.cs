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
using System.Text.Json;
using Newtonsoft.Json;
using System.IO;

namespace Typer.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            config settings = config.returnConfigObject();

            InitializeComponent();
            TimeSelectField.Text = settings.Time.ToString();

            LanguageSelectBox.Text = settings.Language;
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

            config.WriteToConfig(JsonConvert.SerializeObject(settings));
            SaveButton.Content = "Saved";
        }

        private void LanguageSelect_Open(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\Data\\Word Files\\";
            List<string> Configurations = Directory.EnumerateFiles(path)
                                          .Select(p => System.IO.Path.GetFileNameWithoutExtension(p))
                                          .ToList();
            LanguageSelectBox.ItemsSource = Configurations;

            SaveButton.Content = "Save";
        }
    }
}
