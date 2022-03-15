using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace
{
    public static class AppManager
    {
        public static List<Horse> Horses { get; set; } = CreateHorses();
        public static List<Bid> Bids { get; set; } = new List<Bid>();

        public static double TrackLengthInKilometer = 4;

        public static List<Horse> CreateHorses()
        {
            if (Horses == null || Horses.Any())
            {
                Horses = new List<Horse>()
                {
                    new Horse
                    {
                        HorseId = 0,
                        Name = "Malcolm",
                        Weight = 300,
                        Height = 170
                    },
                    new Horse
                    {
                        HorseId = 1,
                        Name = "Vince",
                        Weight = 260,
                        Height = 180
                    },
                    new Horse
                    {
                        HorseId = 2,
                        Name = "Elisa",
                        Weight = 320,
                        Height = 186
                    },
                    new Horse
                    {
                        HorseId = 3,
                        Name = "Brock",
                        Weight = 275,
                        Height = 165
                    },
                    new Horse
                    {
                        HorseId = 4,
                        Name = "Golden Lightning",
                        Weight = 260,
                        Height = 177
                    },
                    new Horse
                    {
                        HorseId = 5,
                        Name = "Fireball",
                        Weight = 277,
                        Height = 177
                    },
                    new Horse
                    {
                        HorseId = 6,
                        Name = "The Devil",
                        Weight = 300,
                        Height = 190
                    }
                };
            }
            return Horses;
        }

        public static void RandomizeSpeedToHorses()
        {
            Random random = new Random();
            foreach (var h in Horses)
            {
                double speed = random.Next(50, 85);
                h.Speed = speed;
            }
        }

        public static void PlaceBid()
        {
            bool horseIdFound = false;
            int horseId;
            Console.Clear();
            foreach (var h in Horses)
            {
                Console.Write($"{h.Name}: {h.HorseId},");
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("What is your name?");
            string? name = Console.ReadLine();

            do
            {
                Console.WriteLine("What horse would you like to bet on? (ENTER HORSE ID....)");
                horseId = Convert.ToInt32(Console.ReadLine());

                if (!Horses.Any(h => h.HorseId == horseId))
                {
                    Console.WriteLine("No horse with that ID exists. Try again.");
                    Console.WriteLine("Press KEY to continue.....");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    horseIdFound = true;
                }

            } while (!horseIdFound);

            
            Console.WriteLine("How much would you like to bet?");
            double amount = Convert.ToDouble(Console.ReadLine());
            Bid bid = new(amount, name, horseId);

            Bids.Add(bid);
        }

        public static void CalculateHorseSpeed()
        {
            var secondsPerHour = 3600;

            foreach (var h in Horses)
            {
                //Calculates how long it takes for the horses to run the track.
                var distancePerHour = TrackLengthInKilometer / h.Speed;
                h.FinalRaceTimeInSec = Math.Round(distancePerHour * secondsPerHour, 3);
            }
        }

        public static void CalculateWinningHorse()
        {
            Horses = Horses.OrderBy(h => h.FinalRaceTimeInSec).ToList();
            Horses[0].IsWinner = true;
            Horses[1].SecondPlace = true;
            Horses[2].ThirdPlace = true;
        }

        public static void WinningBids()
        {
            foreach (var bid in Bids)
            {
                foreach (var horse in Horses.Where(h => h.IsWinner))
                {
                    if (bid.HorseId == horse.HorseId)
                    {
                        bid.WinningBid = true;
                    }
                }
            }
        }

        public static void AddHorseToRace()
        {
            int nextId = Horses.Count;
            Console.WriteLine("Horse name?");
            string? name = Console.ReadLine();
            Console.WriteLine("Height?");
            int height = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Weight?");
            int weight = int.Parse(Console.ReadLine());
            Horse newHorse = new(nextId, name, weight, height);
            Horses.Add(newHorse);
        }

        public static void ResetHorses()
        {

            foreach (var h in Horses)
            {
                if (h.IsWinner)
                {
                    h.IsWinner = false;
                }
                else if (h.SecondPlace)
                {
                    h.SecondPlace = false;
                }
                else if (h.ThirdPlace)
                {
                    h.ThirdPlace = false;
                }
            }
                
            Horses.OrderBy(h => h.HorseId);

        }


    }
}
