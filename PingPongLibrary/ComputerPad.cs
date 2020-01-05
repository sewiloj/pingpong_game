using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongLibrary
{
    class ComputerPad
    {
        public ComputerPad(int position, byte padSpeed = 10)
        {
            ComputerPadPosition = position;
            ComputerPadSpeed = padSpeed;
        }

        public int ComputerPadPosition { get; set; }
        public byte ComputerPadSpeed { get; set; }
    }
}
