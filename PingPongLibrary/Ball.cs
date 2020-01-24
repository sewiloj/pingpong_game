using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongLibrary
{
    public class Ball
    {
        private Random rnd = new Random();
        private bool leftCollision;
        private bool rightCollision;
        private bool topCollision;
        private bool bottomCollision;

        public Ball(int ballPositionX = 385, int ballPositionY = 230, byte ballSpeedX = 3, byte ballSpeedY = 3)
        {
            BallSpeedX = ballSpeedX;
            BallSpeedY = ballSpeedY;
            BallPositionX = ballPositionX;
            BallPositionY = ballPositionY;
            BallDirectionX = rnd.Next(0, 2);
            BallDirectionY = rnd.Next(0, 2);
            leftCollision = false;
            rightCollision = false;
            topCollision = false;
            bottomCollision = false;

        }

        public byte BallSpeedX { get; set; }
        public byte BallSpeedY { get; set; }
        public int BallPositionX { get; set; }
        public int BallPositionY { get; set; }
        public int BallDirectionX { get; set; }
        public int BallDirectionY { get; set; }

        public void ChangeDirectionX()
        {
            if (BallDirectionX == 1)
                BallDirectionX = 0;
            else
                BallDirectionX = 1;
        }
        public void ChangeDirectionY()
        {
            if (BallDirectionY == 1)
                BallDirectionY = 0;
            else
                BallDirectionY = 1;
        }

        public void ResetPosition()
        {
            BallPositionX = 385;
            BallPositionY = 230;
            BallDirectionX = rnd.Next(0, 2);
            BallDirectionY = rnd.Next(0, 2);
            BallSpeedX = 3;
            BallSpeedY = 3;
        }

        public bool CheckCollision(int playerPadPosition, int playerPadWidth, int computerPadPosition, int computerPadWidth, int boardHeight, int boardWidth)
        {
            if(!leftCollision && BallPositionX <= playerPadWidth && (BallPositionY + 30 >= playerPadPosition && BallPositionY <= playerPadPosition + 100))
            {
                leftCollision = true;
                rightCollision = false;
                topCollision = false;
                bottomCollision = false;
                return true;
            }
            else if (!rightCollision && BallPositionX + 30 >= boardWidth - computerPadWidth && (BallPositionY + 30 >= computerPadPosition && BallPositionY <= computerPadPosition + 100))
            {
                leftCollision = false;
                rightCollision = true;
                topCollision = false;
                bottomCollision = false;
                return true;
            }


            return false;
        }
        /// <summary>
        /// Test
        /// </summary>
        /// <param name="boardWidth"></param>
        /// <param name="playerPadWidth"></param>
        /// <param name="computerPadWidth"></param>
        /// <returns>true or false</returns>
        public bool CheckBallOut(int boardWidth, int playerPadWidth, int computerPadWidth)
        {
            if (BallPositionX <= 0 + playerPadWidth || BallPositionX + 30 >= boardWidth - computerPadWidth)
            {
                leftCollision = false;
                rightCollision = false;
                topCollision = false;
                bottomCollision = false;
                return true;
            }
            return false;
        }

        public bool CheckWallCollision(int boardHeight)
        {
            if (!topCollision && BallPositionY <= 0)
            {
                leftCollision = false;
                rightCollision = false;
                topCollision = true;
                bottomCollision = false;
                return true;
            }
            else if (!bottomCollision && BallPositionY >= boardHeight - 30)
            {
                leftCollision = false;
                rightCollision = false;
                topCollision = false;
                bottomCollision = true;
                return true;
            }
            return false;
        }

        private void setAngle(int playerPadPosition, int playerPadWidth, int computerPadPosition, int computerPadWidth)
        {

        }
    }
}
