using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KiwiPoker.Services.Tests
{
    [TestClass()]
    public class DeckOfCardsTests
    {
        [TestMethod()]
        public void ShuffleCardsTest_SequenceIsDifferentAfterShuffle()
        {
            IDeckOfCards dc = new DeckOfCards();
            var beforeShuffle = dc.CardsDeck;
            var AfterShuffle = dc.ShuffleCards(beforeShuffle);
            Assert.AreNotEqual(beforeShuffle, AfterShuffle);
        }
    }
}