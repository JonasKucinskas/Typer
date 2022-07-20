using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ScorePage.xaml
    /// </summary>
    public partial class ScorePage : Page
    {

        public class Score
        {
            public string Name { get; set; }
            public int WordsTyped { get; set; }
            public int Time { get; set; }
        }



        public ScorePage()
        {
            InitializeComponent();


            ScoreList.CanUserAddRows = true;

            var list = new ObservableCollection<Score>();
            list.Add(new Score() { Name = "testas", WordsTyped = 7, Time = 5 });
            this.ScoreList.ItemsSource = list;
        }
    }
}
