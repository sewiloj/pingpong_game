using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using PingPongLibrary;

namespace pingpong_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;
        public MainWindow()
        {
            InitializeComponent();            
        }
        private void MainWindow_OnKeyDown(object sender, KeyboardEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Space)) game.GameActive = true;
            if (Keyboard.IsKeyDown(Key.W)) game.MovePlayerPad(1);
            if (Keyboard.IsKeyDown(Key.S)) game.MovePlayerPad(0);
        }

        private void ball_Thick(object sender, EventArgs e)
        {
            game.MoveBall();
        }
        private void computer_Thick(object sender, EventArgs e)
        {
            game.MoveComputerPad();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            game = new Game((int)MainCanvas.ActualHeight, (int)MainCanvas.ActualWidth);
            DataContext = game;

            //  DispatcherTimer setup
            DispatcherTimer ballTimer = new DispatcherTimer();
            ballTimer.Tick += new EventHandler(ball_Thick);
            ballTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            ballTimer.Start();
            DispatcherTimer computerTimer = new DispatcherTimer();
            computerTimer.Tick += new EventHandler(computer_Thick);
            computerTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            computerTimer.Start();
        }


    }
}
