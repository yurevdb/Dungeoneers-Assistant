using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnDAssistant.Core;
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


    }
}
