using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;
using System.Windows.Threading;
using NAudio.Wave;

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

        //TODO: clean the code up my boy:
        //TODO: implement sounds.
        //TODO: implement save score function.
        //TODO: show more words at the same time.

        

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
            string filePath = Environment.CurrentDirectory + "\\Data\\Word Files\\" + settings.FileName + ".txt";

            try
            {
                MainWordLabel.Text = words.ReturnRandomWord(filePath);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                //Page.Content can only be set to frame, so I need to do this.
                Frame frame = new Frame();
                frame.Content = new Pages.SettingsPage();
                this.Content = frame;
            }

            ScoreLabel.Text = string.Format("{0}: {1}","Score", score);
            TimerLabel.Text = string.Format("{0}: {1}", "Time left", settings.Time);
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
            string filePath = Environment.CurrentDirectory + "\\Data\\Word Files\\" + settings.FileName + ".txt";

            Timer.Start();

            if (AnswerField.Foreground == Brushes.Red)//If text is red, change it back to black.
            {
                AnswerField.Foreground = Brushes.Black;
            }

            
                

            if (e.Key == Key.Enter) //If enter is pressed.
            {
                //Sound player setup.
                MediaPlayer mediaPlayer = new MediaPlayer();

                //
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
                    audioFile = new AudioFileReader(Environment.CurrentDirectory + "\\Data\\Resources\\Sounds\\Mistake.wav");
                    outputDevice.Init(audioFile);
                    outputDevice.Play();

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

                //Show failscreen
                Frame frame = new Frame();
                frame.Content = new Pages.GameFailPage();
                this.Content = frame;
                //
            }

            if (settings.Time == 10)//If there is less than 10 seconds left, set timer colout to red.
            {
                //Cant play two sounds at the same time.

                WaveOutEvent outputDevice =  new WaveOutEvent();
                AudioFileReader audioFile = new AudioFileReader(Environment.CurrentDirectory + "\\Data\\Resources\\Sounds\\Clock.wav");
                outputDevice.Init(audioFile);
                outputDevice.Play();

                TimerLabel.Foreground = Brushes.Red;
            }
        }
    }
}
