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
            int test;
            if (Keyboard.IsKeyDown(Key.Space)) test = (int)MainCanvas.ActualHeight;
            if (Keyboard.IsKeyDown(Key.W)) game.MovePlayerPad(1);
            if (Keyboard.IsKeyDown(Key.S)) game.MovePlayerPad(0);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            
            game.MoveBall();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            game = new Game((int)MainCanvas.ActualHeight, (int)MainCanvas.ActualWidth);
            DataContext = game;

            //  DispatcherTimer setup
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            dispatcherTimer.Start();
        }


    }
}
