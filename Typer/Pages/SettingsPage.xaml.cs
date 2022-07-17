using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Win32;

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
            UpdateSettingsPageData();
        }


        private void UpdateSettingsPageData()
        {
            config settings = config.returnConfigObject();

            TimeSelectField.Text = settings.Time.ToString();
            LanguageSelectBox.IsEditable = true;
            LanguageSelectBox.IsReadOnly = false;

            List<string> fileNames = wordFiles.ReturnFileNames(Environment.CurrentDirectory + "\\Data\\Word Files\\");

            if (fileNames.Contains(settings.Language) && fileNames.Count() > 0)
            {
                LanguageSelectBox.Text = settings.Language;
            }
            else if (!fileNames.Contains(settings.Language) && fileNames.Count() > 0)
            {
                LanguageSelectBox.Text = fileNames[0];
                settings.Language = fileNames[0];
            }
            else
            {
                LanguageSelectBox.Text = "No files exist";
            }
        }

        private void LanguageSelect_Open(object sender, EventArgs e)
        {
            List<string> fileNames = wordFiles.ReturnFileNames(Environment.CurrentDirectory + "\\Data\\Word Files\\");

            if (fileNames.Count() > 0)
            {
                LanguageSelectBox.ItemsSource = fileNames;
            }
            UpdateSettingsPageData();
        }

        private void DeleteWordFilesButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\Data\\Word Files\\";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.DefaultExt = ".txt";
            dialog.InitialDirectory = path;

            if (dialog.ShowDialog() == true)
            {

                string[] fileNames = dialog.FileNames;

                for (int i = 0; i < fileNames.Count(); i++)
                {
                    File.Delete(fileNames[i]);
                }

                UpdateSettingsPageData();

                MessageBox.Show(fileNames.Count() + " Files deleted", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {

            string path = Environment.CurrentDirectory + "\\Data\\Word Files\\";

            config settings = new config();
            try
            {
                settings.Time = Int32.Parse(TimeSelectField.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            if (File.Exists(Path.Combine(path, LanguageSelectBox.Text + ".txt")))
            {
                settings.Language = LanguageSelectBox.Text;
            }
            else MessageBox.Show("This file does not exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);





            config.WriteToConfig(JsonConvert.SerializeObject(settings));
        }

        private void UploadWordFilesButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\Data\\Word Files\\";

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.DefaultExt = ".txt";

            if (dialog.ShowDialog() == true)
            {

                string[] fileNames = dialog.FileNames;

                for (int i = 0; i < fileNames.Count(); i++)
                {
                    string currentFileName = Path.GetFileName(fileNames[i]);

                    if (!File.Exists(Path.Combine(path, currentFileName)))
                    {
                        File.Copy(fileNames[i], Path.Combine(path, currentFileName));
                    }
                }
                UpdateSettingsPageData();

                MessageBox.Show(fileNames.Count() + " Files uploaded", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
