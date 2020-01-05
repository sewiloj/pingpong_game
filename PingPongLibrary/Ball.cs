using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongLibrary
{
    public class Ball
    {
        public Ball(int ballPositionX = 385, int ballPositionY = 230, byte ballSpeed = 1)
        {
            BallSpeed = ballSpeed;
            BallPositionX = ballPositionX;
            BallPositionY = ballPositionY;
        }

        public byte BallSpeed { get; set; }
        public int BallPositionX { get; set; }
        public int BallPositionY { get; set; }


        public void MoveBall()
        {

        }
    }
}
