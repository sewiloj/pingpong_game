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
        private int computerPadPosition;
        public ComputerPad(int position)
        {
            computerPadPosition = position;
        }

        public int ComputerPadPosition
        {
            get { return computerPadPosition; }
            set
            {
                computerPadPosition = value;
            }
        }
    }
}
