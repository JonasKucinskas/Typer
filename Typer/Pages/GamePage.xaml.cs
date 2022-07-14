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

        private int Time = config.ReadConfig();
        private int score = 0;
        DispatcherTimer Timer = new DispatcherTimer();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MainWordLabel.Text = words.ReturnRandomWord();
            ScoreLabel.Text = "Score: 0";
            TimerLabel.Text = string.Format("{0}: {1}", "Time left", Time.ToString());
        }
        private void KeyPress(object sender, KeyEventArgs e)
        {
            Timer.Interval = TimeSpan.FromSeconds(1);
            
            Timer.Tick += Timer_Tick;
            Timer.Start();

            
            if (AnswerField.Foreground == Brushes.Red)
            {
                AnswerField.Foreground = Brushes.Black;
            }

            if (e.Key == Key.Enter) //If enter is pressed.
            {
                if (AnswerField.Text == MainWordLabel.Text)
                {
                    score++;
                    ScoreLabel.Text = string.Format("{0}: {1}", "Score", score.ToString());

                    AnswerField.Text = "";
                    MainWordLabel.Text = words.ReturnRandomWord();

                }
                else
                {
                    AnswerField.Foreground = Brushes.Red;
                }
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Time--;
            TimerLabel.Text = string.Format("{0}: {1}", "Time left", Time.ToString());

            if (Time == 0)
            {
                MainWordLabel.Text = "Try again?";
                AnswerField.IsEnabled = false;
                Timer.Stop();
                TryAgainButton.Visibility = Visibility.Visible;
            }

            if (Time <= 10)
            {
                TimerLabel.Foreground = Brushes.Red;
            }
        }

        private void TryAgainButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Refresh();
        }
    }
}
