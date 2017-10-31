using System;
using System.Windows.Controls;

namespace DnDAssistant.Wpf
{
    /// <summary>
    /// Default class for DiceSelector
    /// </summary>
    public static class DiceSelector
    {
        private static int GetRandom => new Random().Next(1, 7);

        public static UserControl GetDice()
        {
            switch (GetRandom)
            {
                case 1: return new DiceOne();

                case 2: return new DiceTwo();

                case 3: return new DiceThree();

                case 4: return new DiceFour();

                case 5: return new DiceFive();

                case 6: return new DiceSix();

                default: return new DiceOne();
            }
        }
    }
}
