using Microsoft.VisualStudio.TestTools.UnitTesting;
using DnDAssistant.Wpf;

namespace DnDAssistant.UnitTester
{
    [TestClass]
    public class CharacterCreatorBasicTester
    {
        [TestMethod]
        public void CheckDataBinding()
        {
            var Model = new BasicCreatorViewModel() { PlayerName = "Wally"};
            
        }
    }
}
