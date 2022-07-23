using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            Config config = Config.returnConfigObject();

            InitializeComponent();
            TimeSelectField.Text = config.Time.ToString();

            LanguageSelectBox.IsEditable = true;
            LanguageSelectBox.Text = config.FileName;
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
                string[] filePaths = dialog.FileNames;

                for (int i = 0; i < filePaths.Count(); i++)
                {
                    File.Delete(Path.Combine(path, filePaths[i]));
                }

                MessageBox.Show(filePaths.Count() + " Files deleted successfuly", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
                string[] filePaths = dialog.FileNames;//Gets directory for all word files.

                for (int i = 0; i < filePaths.Count(); i++)
                {
                    string fileName = Path.GetFileName(filePaths[i]);//get filename from path

                    if (!File.Exists(Path.Combine(path, fileName)))//if file with this name does'nt exist, create the file.
                    {
                        File.Copy(filePaths[i], Path.Combine(path, fileName));
                    }
                    else MessageBox.Show("Error: File with this name already exists", "File error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                MessageBox.Show(filePaths.Length + " Files uploaded successfuly", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\Data\\Word Files\\";

            Config config = new Config();

            try
            {
                config.Time = Int32.Parse(TimeSelectField.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("An error just occurred: " + ex.Message, "Wrong Format", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (File.Exists(path + LanguageSelectBox.Text + ".txt"))
            {
                config.FileName = LanguageSelectBox.Text;//
                Config.WriteToConfig(config);
            }
            else MessageBox.Show("An error just occurred: Entered file name does not exist", "File does not exits", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
