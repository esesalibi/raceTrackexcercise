using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wyścigi_labor1
{
    public class Greyhound
    {
        public int Id;
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random MyRandom;

        public bool Run()
        {
            Location += MyRandom.Next(1, 5);
            SetLocation();
            
            return RacetrackLength < Location;
        }

        public void TakeStartingPosition()
        {
            Location = StartingPosition;
            SetLocation();

        }

        private void SetLocation()
        {
            MyPictureBox.Location = new System.Drawing.Point(Location, MyPictureBox.Location.Y);
        }

    }
}
