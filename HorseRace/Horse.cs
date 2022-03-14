using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace
{
    public class Horse
    {
        public int HorseId { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        private double speed;
        public bool IsWinner { get; set; }
        public bool SecondPlace { get; set; }
        public bool ThirdPlace { get; set; }
        public double FinalRaceTimeInSec { get; set; }

        public Horse(int _horseID, string _name, int _weight, int _height)
        {
            HorseId = _horseID;
            Name = _name;
            Weight = _weight;
            Height = _height;
            speed = Speed;
        }

        public Horse()
        {
        }

        public double Speed
        {
            get { return speed; }
            set { speed = value; }
        }

    }
}
