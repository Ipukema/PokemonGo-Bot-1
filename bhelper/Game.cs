﻿using PokemonGo.RocketAPI.Extensions;
using System.Linq;

namespace bhelper
{
    public class Game
    {
        public static short softbanned_detection;


        /// <summary>
        ///     returns xp needed to the next level
        /// </summary>
        /// <param name="level">15</param>
        /// <returns>15000</returns>
        public static int GetXpDiff(int level)
        {
            switch (level)
            {
                case 1:
                    return 0;
                case 2:
                    return 1000;
                case 3:
                    return 2000;
                case 4:
                    return 3000;
                case 5:
                    return 4000;
                case 6:
                    return 5000;
                case 7:
                    return 6000;
                case 8:
                    return 7000;
                case 9:
                    return 8000;
                case 10:
                    return 9000;
                case 11:
                    return 10000;
                case 12:
                    return 10000;
                case 13:
                    return 10000;
                case 14:
                    return 10000;
                case 15:
                    return 15000;
                case 16:
                    return 20000;
                case 17:
                    return 20000;
                case 18:
                    return 20000;
                case 19:
                    return 25000;
                case 20:
                    return 25000;
                case 21:
                    return 50000;
                case 22:
                    return 75000;
                case 23:
                    return 100000;
                case 24:
                    return 125000;
                case 25:
                    return 150000;
                case 26:
                    return 190000;
                case 27:
                    return 200000;
                case 28:
                    return 250000;
                case 29:
                    return 300000;
                case 30:
                    return 350000;
                case 31:
                    return 500000;
                case 32:
                    return 500000;
                case 33:
                    return 750000;
                case 34:
                    return 1000000;
                case 35:
                    return 1250000;
                case 36:
                    return 1500000;
                case 37:
                    return 2000000;
                case 38:
                    return 2500000;
                case 39:
                    return 1000000;
                case 40:
                    return 1000000;
            }
            return 0;
        }

        public static async System.Threading.Tasks.Task Unban(Hero hero)
        {
            var mapObjects = await hero.Client.GetMapObjects();
            var pokeStops = mapObjects.MapCells.SelectMany(i => i.Forts).Where(i => i.Type == AllEnum.FortType.Checkpoint && i.CooldownCompleteTimestampMs < System.DateTime.UtcNow.ToUnixTime());
            foreach (var pokeStop in pokeStops)
                for (int i = 0; i < 1000; i++)
                {
                    PokemonGo.RocketAPI.GeneratedCode.FortSearchResponse unban = await hero.Client.SearchFort(pokeStop.Id, pokeStop.Latitude, pokeStop.Longitude);
                    if (unban.ExperienceAwarded > 0)
                        break;
                    await System.Threading.Tasks.Task.Delay(30);
                }
        }
    }
}