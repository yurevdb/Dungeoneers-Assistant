using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnDAssistant.Core;

namespace DnDAssistant.UnitTester
{
    [TestClass]
    public class DiceTester
    {
        /// <summary>
        /// Checks if the die is thrown correctly within the ranges
        /// </summary>
        [TestMethod]
        public void CheckDiceThrow()
        {
            var testRoll = Dice.Roll(Die.D6);
            var Fail = false;

            for (var i = 0; i < 1000; i++)
            {
                if (testRoll < 1 && testRoll > 6)
                    Fail = true;
            }

            Assert.IsFalse(Fail);
        }
    }
}
