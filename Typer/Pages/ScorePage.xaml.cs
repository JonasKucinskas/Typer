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

namespace Typer.Pages
{
    /// <summary>
    /// Interaction logic for ScorePage.xaml
    /// </summary>
    public partial class ScorePage : Page
    {
        List<Score> scores = Score.ReturnScores();
        public ScorePage()
        {

            Score score = new Score();

            score.WordCount = 80;
            score.Name = GamePage.ScoreInstance.Name;
            score.Time = GamePage.ScoreInstance.Time;
            score.FileName = GamePage.ScoreInstance.FileName;

            scores.Add(score);

            InitializeComponent();
            Score.SetTable(ScoreTable, scores);
            score.WriteScoreToXmlFile();
        }

        private void ScoreTable_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            DataGridRow row = e.Row;
            DataGridColumn column = e.Column;

            var viewModel = (DataRowView)row.Item;
            List<object> scoreList = viewModel.Row.ItemArray.ToList();
            
            DateTime date = DateTime.Parse(scoreList[5].ToString());

            if (date.ToString() != scores[scores.Count - 1].Date)
            {
                e.Cancel = true;
            }
        }
    }
}
