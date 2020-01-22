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
        private Pad playerPad;
        private ComputerPad computerPad;
        private Ball ball;
        private bool gameActive = false;
        public Game(int boardHeight, int boardWidth)
        {
            board = new Board(boardHeight, boardWidth);
            playerPad = new Pad(180);
            computerPad = new ComputerPad(180);
            ball = new Ball((boardWidth / 2 - 15), (boardHeight / 2 - 15));
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
            get { return playerPad.PadPosition; }
            set
            {
                playerPad.PadPosition = value;
                OnPropertyChanged("PlayerPadPosition");
            }
        }
        public int ComputerPadPosition
        {
            get { return computerPad.PadPosition; }
            set
            {
                computerPad.PadPosition = value;
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
                position = playerPad.MoveUp();
            }
            else if(upOrDown == 0)
            {
                position = playerPad.MoveDown();
            }

             PlayerPadPosition = verifyBounds(position);
        }

        public void MoveComputerPad()
        {
            if (GameActive)
            {
                int position = 0;
                byte upOrDown = computerPad.MoveComputerPad(BallPositionY);
                if (upOrDown == 2)
                {
                    position = computerPad.MoveUp();
                    ComputerPadPosition = verifyBounds(position);
                }
                else if (upOrDown == 1)
                {
                    position = computerPad.MoveDown();
                    ComputerPadPosition = verifyBounds(position);
                }                
            }
        }

        public void MoveBall()
        {
            if(GameActive)
            {
                if(BallPositionX <= 20 && (BallPositionY >= PlayerPadPosition && BallPositionY <= PlayerPadPosition+100))
                {
                    ball.ChangeDirectionX();
                    ball.ChangeDirectionY();
                }
                else if (BallPositionX >= (board.BoardWidth - 50) && (BallPositionY >= ComputerPadPosition && BallPositionY <= ComputerPadPosition + 100))
                {
                    ball.ChangeDirectionX();
                    ball.ChangeDirectionY();
                }
                else if (BallPositionX <= 0 || BallPositionX >= board.BoardWidth - 20)
                {
                    GameActive = false;
                    ball.ResetPosition();
                }
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
