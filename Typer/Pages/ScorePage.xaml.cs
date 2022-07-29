using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Typer.Pages
{
    public partial class ScorePage : Page
    {
        List<Score> scores = Score.ReturnScores();
        public ScorePage()
        {
            InitializeComponent();

            ScoreTable.CanUserDeleteRows = false;

            try
            {
                Score score = new Score();
                score.WordCount = GamePage.ScoreInstance.WordCount;
                score.Name = GamePage.ScoreInstance.Name;
                score.Time = GamePage.ScoreInstance.Time;
                score.FileName = GamePage.ScoreInstance.FileName;

                scores.Add(score);
            }
            catch
            {

            }
            Score.SetTable(ScoreTable, scores);
        }

        private void ScoreTable_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            DataGridRow row = e.Row;

            var viewModel = (DataRowView)row.Item;
            List<object> propertyList = viewModel.Row.ItemArray.ToList();

            try
            {
                int numInList = (int)propertyList[0];

                if (numInList != scores.Count)
                {
                    e.Cancel = true;
                }
            }
            catch
            {
                e.Cancel = true;
            }
        }

        private void ScoreTable_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataGridRow row = e.Row;
            var viewModel = (DataRowView)row.Item;
            List<object> propertyList = viewModel.Row.ItemArray.ToList();

            var editedTextbox = e.EditingElement as System.Windows.Controls.TextBox;
            scores[scores.Count - 1].Name = editedTextbox.Text;

            XElement xdoc = XElement.Load(Environment.CurrentDirectory + "\\Data\\Scores\\Scores.xml");
            string date = propertyList[5].ToString();
            bool edited = false;

            foreach (XElement node in xdoc.Elements())
            {
                if (node.Element("Date").Value.ToString() == date)
                {
                    node.Element("Name").Value = editedTextbox.Text;
                    xdoc.Save(Environment.CurrentDirectory + "\\Data\\Scores\\Scores.xml");
                    edited = true;
                    break;
                }
            }

            if (!edited)
            {
                scores[scores.Count - 1].WriteScoreToXmlFile();
            }
        }

        private void SaveExitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (scores[scores.Count - 1].Name != "")
                {
                    MainPage page = new MainPage();
                    this.NavigationService.Navigate(page);
                }
                else System.Windows.MessageBox.Show("Type in your name or delete the score!", "No name.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MainPage page = new MainPage();
                this.NavigationService.Navigate(page);
            }
        }
        /// <summary>
        /// this event is used to check is user is deleting a row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScoreTable_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //I cant delete object from list and re-load score table, so I need to remove needed node(s) from .xml file and then read that file into a new list.

            DataGrid grid = (DataGrid)sender;
            
            if (e.Key == Key.Delete && grid.SelectedItems.Count > 0)
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to delete score?", "Message", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    XElement xdoc = XElement.Load(Environment.CurrentDirectory + "\\Data\\Scores\\Scores.xml");

                    for (int i = 0; i < grid.SelectedItems.Count; i++)
                    {
                        DataRowView selectedFile = (DataRowView)grid.SelectedItems[i];//Get selected row.

                        string date = selectedFile.Row.ItemArray[5].ToString();//Get date string from selected row.

                        foreach (XElement node in xdoc.Elements())
                        {
                            if (node.Element("Date").Value.ToString() == date)//Check if scores are the same by date.
                            {
                                node.Remove();
                            }
                        }
                    }

                    xdoc.Save(Environment.CurrentDirectory + "\\Data\\Scores\\Scores.xml");

                    scores = Score.ReturnScores();
                    Score.SetTable(ScoreTable, scores);
                }
            }
        }
    }
}
