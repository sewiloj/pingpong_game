using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPongLibrary
{
    public class Game : INotifyPropertyChanged
    {
        private PlayerPad playerPad;
        private ComputerPad computerPad;
        private readonly byte padSpeed = 10;
        public Game()
        {
            playerPad = new PlayerPad(180);
            computerPad = new ComputerPad(180);
        }

        public int PlayerPadPosition
        {
            get { return playerPad.PlayerPadPosition; }
            set
            {
                playerPad.PlayerPadPosition = value;
                OnPropertyChanged("PlayerPadPosition");
            }
        }
        public int ComputerPadPosition
        {
            get { return computerPad.ComputerPadPosition; }
            set
            {
                computerPad.ComputerPadPosition = value;
                OnPropertyChanged("ComputerPadPosition");
            }
        }

        public void MovePlayerPad(byte upOrDown)
        {
            int position = 0;

            if(upOrDown == 1)
            {
                position = PlayerPadPosition - padSpeed;
            }
            else if(upOrDown == 0)
            {
                position = PlayerPadPosition + padSpeed;
            }

             PlayerPadPosition = verifyBounds(position);
        }

        private int verifyBounds(int position)
        {
            if (position < 0)
                position = 0;
            if (position > 475 - 90)
                position = 475 - 90;

            return position;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
