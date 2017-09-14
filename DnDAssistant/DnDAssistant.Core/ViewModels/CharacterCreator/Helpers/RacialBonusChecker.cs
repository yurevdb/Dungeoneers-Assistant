

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DnDAssistant.Core
{
    public static class RacialBonusChecker
    {
        /// <summary>
        /// List containing the subraces of the Dwarf Race
        /// </summary>
        private static readonly List<string> _SubDwarf = new List<string>() { "Hill Dwarf", "Mountain Dwarf" };
        private static readonly List<string> _SubElf = new List<string>() { "High Elf", "Wood Elf" };
        public static string BonusCheck(string Race)
        {
            return null;
        }

        /// <summary>
        /// Method to add the racial bonus to the stats
        /// </summary>
        /// <param name="Stats">Array of int containing the stats</param>
        /// <returns></returns>
        public static int[] StatsBonus(int[] Stats)
        {
            return null;
        }

        /// <summary>
        /// Static method to check what subraces you have with the picked main Race
        /// </summary>
        /// <param name="Race">String containing the picked race</param>
        /// <returns><see cref="List{T}"/> containing the strings with subraces</returns>
        public static List<string> SubRaceChecker(string Race)
        {
            switch(Race)
            {
                case "Dwarf":
                    return _SubDwarf;
                case "Elf":
                    return _SubElf;
                default:
                    return null;
            }
        }
    }
}
