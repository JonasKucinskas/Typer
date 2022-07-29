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
        WaveOutEvent outputDevice = new WaveOutEvent();

        int wordCount = 0;
        int timeLeft;
        bool soundPlaying = false;

        DispatcherTimer timer = new DispatcherTimer();
        private static readonly Score score = new Score();

        public static Score ScoreInstance
        {
            get { return score; }
        }

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
                NextWordLabel.Text = words.ReturnRandomWord(filePath);
                MainWordLabel.Text = words.ReturnRandomWord(filePath);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                
                Pages.SettingsPage page = new Pages.SettingsPage();
                this.NavigationService.Navigate(page);
            }

            ScoreLabel.Text = string.Format("{0}: {1}","Score", wordCount);
            TimerLabel.Text = string.Format("{0}: {1}", "Time left", timeLeft);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
        }

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
                if (AnswerField.Text == MainWordLabel.Text)//if correct word is typed
                {
                    files.PlaySoundFile(Environment.CurrentDirectory + "\\Data\\Resources\\Sounds\\Success.wav");//Play ding sound.

                    wordCount++;
                    ScoreLabel.Text = string.Format("{0}: {1}", "Score", wordCount.ToString());

                    AnswerField.Clear(); //Clear answer field, so that next word can be typed.
                    MainWordLabel.Text = NextWordLabel.Text;
                    NextWordLabel.Text = words.ReturnRandomWord(filePath);//Set new word to type.
                }
                else
                {
                    files.PlaySoundFile(Environment.CurrentDirectory + "\\Data\\Resources\\Sounds\\Mistake.wav");//Play fail sound.
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
                score.WordCount = wordCount;
                score.Name = "";
                score.Time = config.Time;
                score.FileName = config.FileName;
                
            }

            if (timeLeft <= 10)
            {
                if (!soundPlaying)
                {
                    AudioFileReader audioFile = new AudioFileReader(Environment.CurrentDirectory + "\\Data\\Resources\\Sounds\\Clock.wav");
                    outputDevice.Init(audioFile);
                    outputDevice.Play();
                    soundPlaying = true;
                }
                TimerLabel.Foreground = Brushes.Red;
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            Pages.MainPage page = new Pages.MainPage();
            this.NavigationService.Navigate(page);
            if (soundPlaying)
            {
                files.StopSound(outputDevice);
            }
        }
    }
}
