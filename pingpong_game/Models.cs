using System.ComponentModel;

namespace pingpong_game
{
    class Models : INotifyPropertyChanged
    {
        private int leftPadPosition = 180;
        private int rightPadPosition = 180;
       
        public int LeftPadPosition
        {
            get { return leftPadPosition; }
            set
            {
                leftPadPosition = value;
                OnPropertyChanged("LeftPadPosition");
            }
        }

        public int RightPadPosition
        {
            get { return rightPadPosition; }
            set
            {
                rightPadPosition = value;
                OnPropertyChanged("RightPadPosition");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
