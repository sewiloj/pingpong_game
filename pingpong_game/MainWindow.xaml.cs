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
        private Game game = new Game();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = game;
        }
        private void MainWindow_OnKeyDown(object sender, KeyboardEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.W)) game.MovePlayerPad(1);
            if (Keyboard.IsKeyDown(Key.S)) game.MovePlayerPad(0);
        }

    }
}
