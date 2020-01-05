using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace pingpong_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models model = new Models();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = model;
        }
        private int padSpeed = 10;

        private void MainWindow_OnKeyDown(object sender, KeyboardEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.W)) model.LeftPadPosition = verifyBounds(model.LeftPadPosition, -padSpeed);
            if (Keyboard.IsKeyDown(Key.S)) model.LeftPadPosition = verifyBounds(model.LeftPadPosition, padSpeed);  
        }

        private int verifyBounds(int position, int change)
        {
            position += change;

            if (position < 0)
                position = 0;
            if (position > (int)MainCanvas.ActualHeight - 90)
                position = (int)MainCanvas.ActualHeight - 90;

            return position;
        }
    }
}
