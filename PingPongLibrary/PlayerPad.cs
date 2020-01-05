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
        private int playerPadPosition;
        public PlayerPad(int position)
        {
            playerPadPosition = position;
        }


        public int PlayerPadPosition
        {
            get { return playerPadPosition; }
            set
            {
                playerPadPosition = value;
            }
        }

    }
}
