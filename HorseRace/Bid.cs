using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace
{
    public class Bid
    {
        public static int AutoId { get; set; }
        public int BidId { get ; set; }
        public int HorseId { get; set; }
        public string Name { get; set; }
        public double Amount { get; set; }
        public bool WinningBid { get; set; }
        public DateTime DateTime { get; set; }

        public Bid(double _amount, string _name, int _horseId)
        {
            BidId = AutoIncrementID();
            Amount = _amount;
            Name = _name;
            DateTime = DateTime.Now;
            HorseId = _horseId;
        }

        public int AutoIncrementID()
        {
            return ++AutoId;
        }
    }
}
