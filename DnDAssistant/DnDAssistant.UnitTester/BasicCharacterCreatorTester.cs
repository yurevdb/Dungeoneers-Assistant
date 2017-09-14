using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnDAssistant.Core;
using System.Collections.Generic;
using System.Linq;

namespace DnDAssistant.UnitTester
{
    [TestClass]
    public class CharacterCreatorBasicTester
    {
        //[TestMethod]
        //public void CheckDataBinding()
        //{
        //    var Model = new BasicCreatorViewModel() { PlayerName = "Wally" };

        //}

        /// <summary>
            /// Method to check if the Subrace Lookup works
            /// </summary>
        [TestMethod]
        public void CheckSubRacePicker()
        {
            var TestList = new List<string>();
            var CompareList = new List<string>() { "Hill Dwarf", "Mountain Dwarf" };
            TestList = RacialBonusChecker.SubRaceChecker("Dwarf");
            var i = 0;
            while(i<TestList.Count)
            {
                Assert.AreEqual(CompareList[i], TestList[i]);
                i++;
            }
          
            var CompareList2 = new List<string>() { "High Elf", "Wood Elf" };
            TestList = RacialBonusChecker.SubRaceChecker("Elf");


            while (i < TestList.Count)
            {
                Assert.AreEqual(CompareList2[i], TestList[i]);
                i++;
            }
        }

        /// <summary>
        /// Method to check if the Statsbonus Helper works
        /// </summary>
        [TestMethod]
        public void StatsBonusChecker()
        {
            var StatsArray = new int[] { 10, 10, 12, 11, 10, 10 };
            var ToTestArray = new int[] { 10, 10, 10, 10, 10, 10 };

            ToTestArray = RacialBonusChecker.StatsBonus(StatsArray, "Dwarf", "Hill Dwarf");

            if (!StatsArray.SequenceEqual(ToTestArray))
                Assert.Fail();
        }


    }
}
