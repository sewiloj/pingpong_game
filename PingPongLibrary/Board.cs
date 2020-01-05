using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongLibrary
{
    class Board
    {
        public Board(int height, int width)
        {
            BoardHeight = height;
            BoardWidth = width;
        }

        public int BoardHeight{get; set;}
        public int BoardWidth { get; set; }

    }
}
