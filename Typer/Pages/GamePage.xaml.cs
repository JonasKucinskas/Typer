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
using System.IO;
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
        
        

        /// <summary>
        /// Page load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\Data\\Word Files\\";
            string FileName = Environment.CurrentDirectory + "\\Data\\Word Files\\" + settings.Language + ".txt";


            //if settings.language file does not exist, just load first file in folder.
            //List<string> fileNames = files.ReturnFileList(FileName);


            try
            {
                MainWordLabel.Text = words.ReturnRandomWord(FileName);
            }
            catch
            {
                MessageBox.Show("Selected word file does not exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                Frame frame = new Frame();

                frame.Content = new Pages.SettingsPage();

                this.Content = frame;
            }

            ScoreLabel.Text = string.Format("Score: ", score);
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
            string FileName = Environment.CurrentDirectory + "\\Data\\Word Files\\" + settings.Language + ".txt";

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
                TryAgainButton.Visibility = Visibility.Visible;//Show "try again" button.

                //Show failscreen
                Frame frame = new Frame();
                frame.Content = new Pages.GameFailPage();
                this.Content = frame;
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
