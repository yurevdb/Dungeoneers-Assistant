using System;

namespace DnDAssistant.Core
{
    /// <summary>
    /// A class for the Die interactions
    /// </summary>
    public static class Dice
    {
        /// <summary>
        /// A method that returns a random integer based on a <see cref="Die"/>
        /// </summary>
        /// <param name="die">The chosen <see cref="Die"/></param>
        /// <returns>random integer based on the die</returns>
        public static int Roll(Die die)
        {
            // Making a random number generator object
            var rnd = new Random();

            // Getting the number of sides from the die enumerator
            var dieValue = (int)die;

            //returns the actual thrown value with a random number generator
            return rnd.Next(1, dieValue + 1);

        }
    }
}
