using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongLibrary
{
    class ComputerPad : Pad
    {
        public ComputerPad(int position, byte padSpeed = 10, int difficulty = 3) : base(position, padSpeed)
        {
            PadPosition = position;
            PadSpeed = padSpeed;
            Difficulty = difficulty;
        }

        private Random rnd = new Random();
        private int _difficulty;
        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                if (value > 3 || value < 1)
                    throw new ArgumentOutOfRangeException();
                else
                    _difficulty = value;
            }
        }

        public byte MoveComputerPad(int ballPositionY)
        {
            int chance = rnd.Next(1, 101);

            if(Difficulty == 1)
            {
                if (chance < 70)
                    return UpOrDown(true, ballPositionY);
                else
                    return UpOrDown(false, ballPositionY);
            }
            else if (Difficulty == 2)
            {
                if (chance < 80)
                    return UpOrDown(true, ballPositionY);
                else
                    return UpOrDown(false, ballPositionY);
            }
            else
            {
                if (chance < 90 )
                    return UpOrDown(true, ballPositionY);
                else
                    return UpOrDown(false, ballPositionY);
            }

        }

        private byte UpOrDown(bool goodMove, int ballPositionY)
        {
            if (PadPosition + 50 > ballPositionY)
            {
                if (goodMove)
                    return 2;
                else
                    return (byte)rnd.Next(0,1);
            }
            else if (PadPosition + 50 < ballPositionY)
            {
                if (goodMove)
                    return 1;
                else
                    return (byte)rnd.Next(2,4);
            }
            else
                return 3;
        }

    }
}
