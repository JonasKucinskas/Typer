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
using System.Windows.Threading;

namespace Typer
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        public GamePage()
        {
            InitializeComponent();
        }

        config settings = config.returnConfigObject();

        //TODO fix this mess:
        int score = 0;
        DispatcherTimer Timer = new DispatcherTimer();

        //
        
        string FileName;

        /// <summary>
        /// Page load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FileName = Environment.CurrentDirectory + "\\Data\\Word Files\\" + settings.Language + ".txt";
            MainWordLabel.Text = words.ReturnRandomWord(FileName);
            ScoreLabel.Text = "Score: 0";
            TimerLabel.Text = string.Format("{0}: {1}", "Time left", settings.Time.ToString());
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Every key press in AnswerField text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void KeyPress(object sender, KeyEventArgs e)
        {
            Timer.Start();

            if (AnswerField.Foreground == Brushes.Red)//If text is red, change it back to black.
            {
                AnswerField.Foreground = Brushes.Black;
            }

            if (e.Key == Key.Enter) //If enter is pressed.
            {
                if (AnswerField.Text == MainWordLabel.Text)//if correct word is typed
                {
                    score++;
                    ScoreLabel.Text = string.Format("{0}: {1}", "Score", score.ToString());

                    AnswerField.Text = ""; //Clear answer field, so that next word can be typed.
                    MainWordLabel.Text = words.ReturnRandomWord(FileName);//Set new word to type.

                }
                else
                {
                    AnswerField.Foreground = Brushes.Red;//if wrong word is typed, set text colour to red.
                }
            }
        }

        /// <summary>
        /// Timer tick event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Timer_Tick(object? sender, EventArgs e)
        {
            settings.Time--;
            TimerLabel.Text = string.Format("{0}: {1}", "Time left", settings.Time.ToString());

            if (settings.Time == 0)
            {
                MainWordLabel.Text = "Try again?";
                AnswerField.IsEnabled = false;//Disable answer field.
                Timer.Stop();
                TryAgainButton.Visibility = Visibility.Visible;//Show try again button.
            }

            if (settings.Time <= 10)//If there is less than 10 seconds left, set timer colout to red.
            {
                TimerLabel.Foreground = Brushes.Red;
            }
        }

        /// <summary>
        /// Try again button click event. When clicked, page is reset.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TryAgainButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
        }
    }
}
