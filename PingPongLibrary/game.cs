using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingPongLibrary
{
    public class Game : INotifyPropertyChanged
    {
        private Board board;
        private PlayerPad playerPad;
        private ComputerPad computerPad;
        private Ball ball;
        private bool gameActive = false;
        public Game(int boardHeight, int boardWidth)
        {
            board = new Board(boardHeight, boardWidth);
            playerPad = new PlayerPad(180);
            computerPad = new ComputerPad(180);
            ball = new Ball();
        }

        public bool GameActive
        {
            get { return gameActive; }
            set
            {
                if (GameActive == true)
                    gameActive = false;
                else
                {
                    gameActive = true;
                }
                
            }
        }
        public int PlayerPadPosition
        {
            get { return playerPad.PlayerPadPosition; }
            set
            {
                playerPad.PlayerPadPosition = value;
                OnPropertyChanged("PlayerPadPosition");
            }
        }
        public int ComputerPadPosition
        {
            get { return computerPad.ComputerPadPosition; }
            set
            {
                computerPad.ComputerPadPosition = value;
                OnPropertyChanged("ComputerPadPosition");
            }
        }

        public int BallPositionX
        {
            get { return ball.BallPositionX; }
            set
            {
                ball.BallPositionX = value;
                OnPropertyChanged("BallPositionX");
            }
        }

        public int BallPositionY
        {
            get { return ball.BallPositionY; }
            set
            {
                ball.BallPositionY = value;
                OnPropertyChanged("BallPositionY");
            }
        }

        public void MovePlayerPad(byte upOrDown)
        {
            int position = 0;

            if(upOrDown == 1)
            {
                position = PlayerPadPosition - playerPad.PlayerPadSpeed;
            }
            else if(upOrDown == 0)
            {
                position = PlayerPadPosition + playerPad.PlayerPadSpeed;
            }

             PlayerPadPosition = verifyBounds(position);
        }

        public void MoveBall()
        {
            if (BallPositionX <= 0 || BallPositionX >= board.BoardWidth - 30)
                ball.ChangeDirectionX();
            if (BallPositionY <= 0 || BallPositionY >= board.BoardHeight - 30)
                ball.ChangeDirectionY();
            if (ball.BallDirectionX == 1)
                BallPositionX += ball.BallSpeed;
            else
                BallPositionX -= ball.BallSpeed;
            if (ball.BallDirectionY == 1)
                BallPositionY += ball.BallSpeed;
            else
                BallPositionY -= ball.BallSpeed;
        }

        private int verifyBounds(int position)
        {
            if (position < 0)
                position = 0;
            if (position > board.BoardHeight - 100)
                position = board.BoardHeight - 100;

            return position;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
