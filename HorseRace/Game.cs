using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRace
{
    public static class Game
    {
        public static void RunGame()
        {
            //Create new horses so the previous winning-property doesn't go into the new race.
            AppManager.Horses = AppManager.CreateHorses();
            AppManager.RandomizeSpeedToHorses();
            AppManager.CalculateHorseSpeed();
            AppManager.CalculateWinningHorse();
            AppManager.WinningBids();

            foreach (var h in AppManager.Horses)
            {
                if (h.IsWinner)
                {
                    Console.WriteLine($"First place: {h.Name} with {h.FinalRaceTimeInSec} sek around the track");
                }
                else if (h.SecondPlace)
                {
                    Console.WriteLine($"Second place: {h.Name} with {h.FinalRaceTimeInSec} sek");
                }
                else if (h.ThirdPlace)
                {
                    Console.WriteLine($"Third place: {h.Name} with {h.FinalRaceTimeInSec} sek");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("----------------------------------");
            ShowAllBids();
            AppManager.Bids.Clear();
            
        }

        public static void UserMenu()
        {
            var userMenuPick = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Hello User! Pick from the menu:\n1.Place a bid\n2.See all horses\n3.Show all bids\n4.Start race\n5.Exit tracks");
                userMenuPick = Convert.ToInt32(Console.ReadLine());
                switch (userMenuPick)
                {
                    case 1:
                        AppManager.PlaceBid();
                        break;
                    case 2:
                        ShowAllHorses();
                        break;
                    case 3:
                        Console.Clear();
                        ShowAllBids();
                        break;
                    case 4:
                        Console.Clear();
                        RunGame();
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Invalid number!");
                        break;
                }

            } while (userMenuPick != 5);
        }

        public static void ShowAllHorses()
        {
            Console.Clear();
            var table = new ConsoleTable("Horse Id", "Name", "Weight", "Height", "Speed");
            foreach (var h in AppManager.Horses.OrderBy(h => h.HorseId))
            {
                table.AddRow(h.HorseId, h.Name, h.Weight, h.Height, h.Speed);
            }
            table.Write();
            Console.WriteLine("Press KEY to continue....");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowAllBids()
        {
            var table = new ConsoleTable("ID", "Name","Horse Name","Amount", "Winning bid", "Timestamp");
            foreach (var bid in AppManager.Bids)
            {
                var horse = AppManager.Horses.Find(h => h.HorseId == bid.HorseId);
                table.AddRow(bid.BidId, bid.Name, horse.Name,bid.Amount, bid.WinningBid ? "Yes" : "No", bid.DateTime);
            }
            table.Write();
            Console.WriteLine("Press KEY to continue....");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
