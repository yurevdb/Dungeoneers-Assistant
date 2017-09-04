namespace DnDAssistant.Core
{
    /// <summary>
    /// Class for a <see cref="Character"/>
    /// </summary>
   public static class Character
    {
        /// <summary>
        /// Enumerator for the Classes of Dungeons and Dragons
        /// </summary>
        enum Classes   //Classy
        {
            Barbarian = 0,
            Bard = 1,
            Cleric = 2,
            Druid = 3,
            Fighter = 4,
            Monk = 5,
            Paladin = 6,
            Ranger = 7,
            Rogue = 8,
            Sorcerer = 9,
            Warlock = 10,
            Wizard = 11
        }

        /// <summary>
        /// Enumerator for the Races of Dungeons and Dragons
        /// </summary>
        enum Races //don't be so racist...
        {
            Dwarf = 0,
            Elf = 1,
            Halfling = 2,
            Human = 3,
            Dragonborn = 4,
            Gnome = 5,
            HalfElf = 6,
            HalfOrc = 7,
            Thiefling = 8
        }

        /// <summary>
        /// Enumerator for the Subraces
        /// </summary>
        enum Subraces
        {
            VulLaterIn = 0
        }


        /// <summary>
        /// Method to create a character and write it in an xml file
        /// </summary>
        /// <returns></returns>
        public static bool CreateCharacter()
        {

            return false;
        }
    }
}
