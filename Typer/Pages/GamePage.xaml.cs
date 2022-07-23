using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Windows.Threading;
using NAudio.Wave;
using System.Collections.Generic;

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

        Config config = Config.returnConfigObject();

        //TODO: clean the code up my boy:
        //TODO: implement more sounds;
        //TODO: implement save score function.
        //TODO: show more words at the same timeLeft.

        int score = 0;
        int timeLeft; 
        DispatcherTimer timer = new DispatcherTimer();
        Score score1 = new Score();

        /// <summary>
        /// Page load.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            timeLeft = config.Time;

            string path = Environment.CurrentDirectory + "\\Data\\Word Files\\";
            string filePath = path + config.FileName + ".txt";

            try
            {
                MainWordLabel.Text = words.ReturnRandomWord(filePath);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                
                Pages.SettingsPage page = new Pages.SettingsPage();
                this.NavigationService.Navigate(page);
            }

            ScoreLabel.Text = string.Format("{0}: {1}","Score", score);
            TimerLabel.Text = string.Format("{0}: {1}", "Time left", timeLeft);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Every key press in AnswerField text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void KeyPress(object sender, KeyEventArgs e)
        {
            string filePath = Environment.CurrentDirectory + "\\Data\\Word Files\\" + config.FileName + ".txt";

            timer.Start();

            if (AnswerField.Foreground == Brushes.Red)//If text is red, change it back to black.
            {
                AnswerField.Foreground = Brushes.Black;
            }

            if (e.Key == Key.Enter) //If enter is pressed.
            {
                //Sound player setup.
                WaveOutEvent outputDevice = new WaveOutEvent();
                AudioFileReader audioFile;

                TimerLabel.Foreground = Brushes.Red;

                if (AnswerField.Text == MainWordLabel.Text)//if correct word is typed
                {
                    audioFile = new AudioFileReader(Environment.CurrentDirectory + "\\Data\\Resources\\Sounds\\Success.wav"); 
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

                    score++;
                    ScoreLabel.Text = string.Format("{0}: {1}", "Score", score.ToString());

                    AnswerField.Clear(); //Clear answer field, so that next word can be typed.
                    MainWordLabel.Text = words.ReturnRandomWord(filePath);//Set new word to type.
                }
                else
                {
                    //TODO: ideti i metoda:
                    audioFile = new AudioFileReader(Environment.CurrentDirectory + "\\Data\\Resources\\Sounds\\Mistake.wav");
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    //
                    AnswerField.Foreground = Brushes.Red;//if wrong word is typed, set text colour to red.
                }
            }
        }

        /// <summary>
        /// timer tick event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            timeLeft--;
            TimerLabel.Text = string.Format("{0}: {1}", "Time left", timeLeft.ToString());

            if (timeLeft == 0)
            {
                MainWordLabel.Text = "Try again?";
                AnswerField.IsEnabled = false;//Disable answer field.
                timer.Stop();

                //Show failscreen
                Pages.GameFailPage failPage = new Pages.GameFailPage();
                this.NavigationService.Navigate(failPage);
                //

                score1.WordCount = score;
                score1.Time = config.Time;
                score1.Name = "";
                score1.FileName = config.FileName;
                score1.WriteScoreToXmlFile();



                List<Score> score12 = Score.ReturnScoreObject();

            }

            if (timeLeft == 10)//If there is less than 10 seconds left, set timer colout to red.
            {
                WaveOutEvent outputDevice =  new WaveOutEvent();
                AudioFileReader audioFile = new AudioFileReader(Environment.CurrentDirectory + "\\Data\\Resources\\Sounds\\Clock.wav");
                outputDevice.Init(audioFile);
                 
                outputDevice.Play();

                TimerLabel.Foreground = Brushes.Red;
            }
        }
    }
}
