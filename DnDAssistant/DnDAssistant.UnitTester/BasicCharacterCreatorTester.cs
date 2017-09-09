using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnDAssistant.Wpf;
using System.Collections.Generic;

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

        [TestMethod]
        public void CheckSubRacePicker()
        {
            var TestList = new List<string>();
            var CompareList = new List<string>() { "Hill Dwarf", "Mountain Dwarf" };
            TestList = RacialBonusChecker.SubRaceChecker("Dwarf");

            Assert.AreEqual(CompareList, TestList);

           
            var CompareList2 = new List<string>() { "High Elf", "Wood Elf" };
            TestList = RacialBonusChecker.SubRaceChecker("Elf");

            Assert.AreEqual(CompareList2, TestList);
        }


    }
}
