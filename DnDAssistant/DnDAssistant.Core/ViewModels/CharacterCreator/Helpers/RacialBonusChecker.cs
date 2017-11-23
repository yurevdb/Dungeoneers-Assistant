

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DnDAssistant.Core
{
    public static class RacialBonusChecker
    {
        enum Size { Small = 0, Medium = 1}

        #region Readonly_Lists
        /// <summary>
        /// List containing the subraces of the Dwarf Race
        /// </summary>
        private static readonly List<string> _SubDwarf = new List<string>() { "Hill Dwarf", "Mountain Dwarf" };
        /// <summary>
        /// List containing the subraces of the Elf Race
        /// </summary>
        private static readonly List<string> _SubElf = new List<string>() { "Drow", "High Elf", "Wood Elf" };
        /// <summary>
        /// List containing  the subraces of the Elf Race
        /// </summary>
        private static readonly List<string> _SubGnome = new List<string>() { "Forest Gnome", "Rock Gnome", "Deep Gnome" };
        /// <summary>
        /// List containing the subraces of the Halfling Race
        /// </summary>
        private static readonly List<string> _SubHalfling = new List<string>() { "Lightfoot", "Stout" };
        /// <summary>
        /// List containing the subraces of the Hooman Race
        /// </summary>
        private static readonly List<string> _Hooman = new List<string>() { "None" };
        /// <summary>
        /// List containing the subraces of the Dragonborn Race
        /// </summary>
        private static readonly List<string> _SubDragonborn = new List<string>() { "Black", "Blue", "Brass", "Bronze", "Copper", "Gold", "Green", "Red", "Silver", "White" };
        /// <summary>
        /// List for when the Race has no Subrace
        /// </summary>
        private static readonly List<string> _NoSub = new List<string>() { "None" };
        #endregion


        /// <summary>
        /// Method to check what bonusses (except from stats) a race and or subrace receives
        /// </summary>
        /// <param name="Race"></param>
        /// <param name="SubRace"></param>
        /// <returns></returns>
        public static string BonusCheck(string Race, string SubRace)
        {
            return null;
        }

        /// <summary>
        /// Method to add the racial bonus to the stats
        /// </summary>
        /// <param name="Stats">Array of int containing the stats</param>
        /// <returns></returns>
        public static int[] StatsBonus(int[] Stats, string Race, string SubRace)
        {

            switch(Race)
            {
                case "Dwarf":
                    Stats[2] = Stats[2] + 2;
                    if (SubRace == "Hill Dwarf")
                        Stats[3] = Stats[3] + 1;
                    else
                        Stats[0] = Stats[0] + 1;
                    return Stats;

                case "Dragonborn":
                    Stats[0] = Stats[0] + 2;
                    Stats[5] = Stats[5] + 1;
                    return Stats;

                case "Elf":
                    Stats[1] = Stats[1] + 2;
                    if (SubRace == "High Elf")
                        Stats[4] = Stats[4] + 1;
                    if (SubRace == "Drow")
                        Stats[5] = Stats[5] + 1;
                    else
                        Stats[3] = Stats[3] + 1;
                    return Stats;
                case "Gnome":
                    Stats[4] += 2;
                    switch(SubRace)
                    {
                        case "Forest Gnome":
                            Stats[1] += 1;
                            break;
                        case "Rock Gnome":
                            Stats[2] += 1;
                            break;
                        case "Deep Gnome":
                            Stats[1] += 1;
                            break;
                    }
                    return Stats;

                case "HalfElf":
                    Stats[5] += 1;
                    return Stats;

                case "HalfOrc":
                    Stats[0] += 2;
                    Stats[2] += 1;
                    return Stats;

                case "Halfling":
                    Stats[2] += 2;
                    if (SubRace == "Lightfoot")
                        Stats[5] += 1;
                    if (SubRace == "Stout")
                        Stats[2] += 1;
                    return Stats;

                case "Human":
                   for(var i =0; i<6; i++)
                    {
                        Stats[i] += 1;
                    }
                    return Stats;

                case "Tiefling":
                    Stats[4] += 1;
                    Stats[5] += 2;
                    return Stats;

                default:
                    return null;
                    
                            
            }

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
                case "Halfling":
                    return _SubHalfling;
                case "Human":
                    return _Hooman;
                case "Dragonborn":
                    return _SubDragonborn;
                case "Gnome":
                    return _SubGnome;
                case "HalfElf":
                    return _NoSub;
                case "HalfOrc":
                    return _NoSub;
                case "Tiefling":
                    return _NoSub;
                default:
                    return null;
            }
        }
    }
}
