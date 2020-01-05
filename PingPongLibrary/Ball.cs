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
        public Ball(int ballPositionX = 385, int ballPositionY = 230, byte ballSpeed = 3)
        {
            BallSpeed = ballSpeed;
            BallPositionX = ballPositionX;
            BallPositionY = ballPositionY;
            BallDirectionX = rnd.Next(0, 2);
            BallDirectionY = rnd.Next(0, 2);
        }

        public byte BallSpeed { get; set; }
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
        }
    }
}
