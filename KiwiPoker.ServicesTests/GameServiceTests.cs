using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KiwiPoker.Services.Tests
{
    [TestClass()]
    public class GameServiceTests
    {
        private IDeckOfCards _dc;
        private GameService gs;

        [TestInitialize]
        private void setUP()
        {
            _dc = new DeckOfCards();
            gs = new GameService(_dc);
          
        }
        private List<Player> setupPlayercardsForStraightFlush()
        {
            List<Player> playerCards = new List<Player>()
            {
                 new Player()
                {
                    cards = new List<Card>()
                    { new Card()
                        { Suite=SuiteType.Clubs, Rank=RankType.Ace ,Value=42},
                        new Card()
                        { Suite=SuiteType.Clubs, Rank=RankType.King ,Value=39},
                    },
                  //  HandRank=HandRankType.StraightFlush ,
                    PlayerID=0,
                    Round=1
                },
                new Player()
                {
                    cards = new List<Card>()
                    { new Card()
                        { Suite=SuiteType.Spades, Rank=RankType.Two ,Value=8},
                        new Card()
                        { Suite=SuiteType.Spades, Rank=RankType.Four ,Value=16},
                    },
                  //  HandRank=HandRankType.Flush,
                    PlayerID=1,
                    Round=1
                }

            };
            return playerCards;
        }

        [TestMethod ]
        public void GetHandRankByScoreTest_Expected_HandsAreTestedOK()
        {
            setUP();
            gs.NumberOfPlayers = 2;
            gs.NumberOfRounds = 2;
            gs.NumberOfShuffles = 2;

          var rankAndScore=  gs.GetHandRanksAndScore(setupPlayercardsForStraightFlush());

            Assert.AreEqual(HandRankType.StraightFlush, rankAndScore.FirstOrDefault(x => x.PlayerID == 0).HandRank);
            Assert.AreEqual(HandRankType.Flush, rankAndScore.FirstOrDefault(x => x.PlayerID == 1).HandRank);

        }
        [TestMethod()]
        public void ServeCardsTest_ServerToCorrectNumberOfPlayers()
        {
            setUP();
            gs.NumberOfPlayers = 5;
            gs.NumberOfRounds = 5;
            gs.NumberOfShuffles = 2;
            var deck = _dc.CardsDeck;

            var t1 = gs.ServeCards(_dc.ShuffleCards(deck), 1);
            Assert.AreEqual(5, t1.Count);

            gs.NumberOfPlayers = 3;
            var t2 = gs.ServeCards(_dc.ShuffleCards(deck), 1);
            Assert.AreEqual(3, t2.Count);
        }

        [TestMethod ]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void VlaidationTest_ThrowsExceptionIfNumberOfPlayersExceed_6()
        {
            setUP();
          //  gs.NumberOfPlayers = 5;
            gs.NumberOfRounds = 5;
            gs.NumberOfShuffles = 2;
            gs.NumberOfPlayers = 7;
            gs.Validate();
        }
    }
}