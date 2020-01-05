using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongLibrary
{
    public class PlayerPad
    {
        public PlayerPad(int position, byte padSpeed = 10)
        {
            PlayerPadPosition = position;
            PlayerPadSpeed = padSpeed;
        }


        public int PlayerPadPosition { get; set; }
        public byte PlayerPadSpeed { get; set; }
    }
}
