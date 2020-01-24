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
        private int playerPoints;
        private int computerPoints;

        public Game(int boardHeight, int boardWidth)
        {
            board = new Board(boardHeight, boardWidth);
            playerPad = new Pad(180);
            computerPad = new ComputerPad(180);
            ball = new Ball((boardWidth / 2 - 15), (boardHeight / 2 - 15));
            PlayerPoints = 0;
            ComputerPoints = 0;
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
        public int PlayerPoints
        {
            get { return playerPoints; }
            set
            {
                playerPoints = value;
                OnPropertyChanged("PlayerPoints");
            }
        }
        public int ComputerPoints
        {
            get { return computerPoints; }
            set
            {
                computerPoints = value;
                OnPropertyChanged("ComputerPoints");
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
        public int PlayerPadWidth
        {
            get { return playerPad.Width; }
            set
            {
                playerPad.Width = value;
                OnPropertyChanged("PlayerPadWidth");
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
        public int ComputerPadWidth
        {
            get { return computerPad.Width; }
            set
            {
                computerPad.Width = value;
                OnPropertyChanged("ComputerPadWidth");
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

        public bool MoveBall()
        {
            if(GameActive)
            {
                if(ball.CheckCollision(PlayerPadPosition, PlayerPadWidth, ComputerPadPosition, ComputerPadWidth, board.BoardHeight, board.BoardWidth))
                {
                    ball.ChangeDirectionX();
                }
                else if (ball.CheckWallCollision(board.BoardHeight))
                    ball.ChangeDirectionY();
                else if (ball.CheckBallOut(board.BoardWidth, PlayerPadWidth, ComputerPadWidth))
                {
                    GameActive = false;
                    AddPoints();
                    ball.ResetPosition();
                }
                if (ball.BallDirectionX == 1)
                    BallPositionX += ball.BallSpeedX;
                else
                    BallPositionX -= ball.BallSpeedX;
                if (ball.BallDirectionY == 1)
                    BallPositionY += ball.BallSpeedY;
                else
                    BallPositionY -= ball.BallSpeedY;

                return false;
            }
            return true;
        }

        private void AddPoints()
        {
            if (BallPositionX > board.BoardWidth / 2)
                PlayerPoints++;
            else if (BallPositionX < board.BoardWidth / 2)
                ComputerPoints++;

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
