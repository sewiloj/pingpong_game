using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongLibrary
{
    public class Pad
    {
        public Pad(int position, byte padSpeed = 10)
        {
            PadPosition = position;
            PadSpeed = padSpeed;
        }


        public int PadPosition { get; set; }
        public byte PadSpeed { get; set; }

        public int MoveUp()
        {
            return this.PadPosition - this.PadSpeed;
        }

        public int MoveDown()
        {
            return this.PadPosition + this.PadSpeed;
        }

    }
}
