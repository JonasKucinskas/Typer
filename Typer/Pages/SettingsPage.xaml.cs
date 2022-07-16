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
using Microsoft.Win32;
using Path = System.IO.Path;

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

            LanguageSelectBox.IsEditable = true;
            LanguageSelectBox.Text = settings.Language;
        }

        private void LanguageSelect_Open(object sender, EventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\Data\\Word Files\\";
            List<string> fileNames = files.ReturnFileList(path);

            LanguageSelectBox.ItemsSource = fileNames;
        }

        

        private void DeleteWordFiles_Click_1(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\Data\\Word Files\\";
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = path;
            dialog.Multiselect = true;



            if (dialog.ShowDialog() == true)
            {
                string[] filenames = dialog.FileNames;

                for (int i = 0; i < dialog.FileNames.Count(); i++)
                {
                    File.Delete(Path.Combine(path, filenames[i]));
                }
                MessageBox.Show("Files deleted successfuly", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void UploadWordFiles_Click_1(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\Data\\Word Files\\";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;


            if (dialog.ShowDialog() == true)
            {
                //Path.GetFileName(dialog.FileName))
                string[] fileNames = dialog.FileNames;

                for (int i = 0; i < fileNames.Count(); i++)
                {
                    string fileName = Path.GetFileName(fileNames[i]);

                    if (!File.Exists(Path.Combine(path, fileName)))
                    {
                        File.Copy(fileNames[i], Path.Combine(path, fileName));
                    }
                    else MessageBox.Show("Error: File with this name already exists", "File error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                MessageBox.Show("Files uploaded successfuly", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\Data\\Word Files\\";


            config settings = new config();
            try
            {
                settings.Time = Int32.Parse(TimeSelectField.Text);
                settings.Language = LanguageSelectBox.Text;
            }
            catch (FormatException ex)
            {
                MessageBox.Show("An error just occurred: " + ex.Message, "Wrong Format", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (!files.ReturnFileList(path).Contains(LanguageSelectBox.Text))
            {
                MessageBox.Show("An error just occurred: Entered file name does not exist", "File does not exits", MessageBoxButton.OK, MessageBoxImage.Error);
                LanguageSelectBox.Focus();
            }


            config.WriteToConfig(JsonConvert.SerializeObject(settings));
        }
    }
}
