using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiwiPoker.Services
{
    public class GameService : IGameService
    {
        private IDeckOfCards _dc;
        public GameService(IDeckOfCards dc)
        {
            _dc = dc;
        }
        protected const int maxPlayers = 6;
        protected const int minPlayers = 2;
        protected const int minRounds = 2;
        protected const int maxRounds = 5;

        public int? NumberOfPlayers { get; set; }
        public int? NumberOfRounds { get; set; }
        public int? NumberOfShuffles { get; set; }
        // private List<Player> PlayerCardsList;

        public bool Validate()
        {
           
            if (NumberOfPlayers < minPlayers || NumberOfPlayers > maxPlayers|| !NumberOfPlayers.HasValue)
            {
                throw new ArgumentOutOfRangeException(String.Format("Number of Players Should be in Range {0} and {1}", minPlayers, maxPlayers));
            }
            if (NumberOfRounds < minRounds || NumberOfRounds > maxRounds||!NumberOfRounds.HasValue)
            {
                throw new ArgumentOutOfRangeException(String.Format("Number of Players Should be in Range {0} and {1}", minPlayers, maxPlayers));
            }
            return true;
        }
        public List<Card> ShuffleCardsXTimes()
        {
            try
            {
                if (!NumberOfShuffles.HasValue)
                {
                    throw new ArgumentOutOfRangeException("NumberofShuffels must have value");
                }
            var cards = _dc.CardsDeck;
            for (int i = 0; i < NumberOfShuffles; i++)
            {
             cards=   _dc.ShuffleCards(cards);
            }
            return cards;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception in Shuffle Cards", ex);
            }
        }
        public List<Player> ServeCards(List<Card> shuffledcards, int round)
        {
            try
            {
                Validate();
                //  var shufflecards = ShuffleCardsXTimes();
                List<Player> PlayerCardsList = new List<Player>();
                for (int i = 0; i < NumberOfPlayers; i++)
                {
                    var _cards = shuffledcards.Take(2).ToList();
                    shuffledcards.RemoveRange(0, 2);
                    PlayerCardsList.Add(new Player() { cards = _cards, PlayerID = i, Round = round });
                }
                return PlayerCardsList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Player> GetHandRanksAndScore(List<Player> servedCards)
        {
            foreach (var player in servedCards)
            {
               var rank= GetRank(player);
                player.HandRank = rank;
            }
            var PlayersWithScore = GetScore(servedCards);
            return PlayersWithScore;
        }

        public string ListWinnersByRound(List<Player> PlayersWithScore)
        {
            StringBuilder sb = new StringBuilder();
            var PlayersWithScoreOrder = PlayersWithScore.OrderByDescending(x => x.Score);
            foreach (var player in PlayersWithScoreOrder)
            {
                sb.Append("Player ID: " + player.PlayerID + " HandRank: " + player.HandRank.ToString() + " Score : " + player.Score.ToString());
                sb.Append(System.Environment.NewLine);
            }

            return sb.ToString();
        }

   
        public string FinalWinners(List<Player> FinalScore)
        {
            StringBuilder sb = new StringBuilder();
            var score = FinalScore.GroupBy(x => x.PlayerID).OrderByDescending(y => y.Sum(x => x.Score));
            int i = 1;
            foreach (var item in score)
            {
                sb.Append("Winner " + i.ToString() +" Player ID: " + item.Key + " Player Score: " + item.Sum(x => x.Score));
                sb.Append(System.Environment.NewLine);
                i++;
            }
            return sb.ToString();
        }

        private List<Player> GetScore(List<Player> servedCardsWithRank)
        {
            //since there is possibility of tie, I assume the folllowing
            //in case of Tie,
            //Compare first with highest Ranked card A to 2
            //Highest ranked card tie, then  value of card. Spade to diamond
           
            //var lstStraightFlush = servedCardsWithRank.OrderBy(x => x.HandRank.Value).ThenBy(x => x.cards.OrderBy (y=>(int)y.Suite)).ThenBy(y=>y.cards.OrderBy(z=>z.Value )).ToList();
            var lstStraightFlush = servedCardsWithRank.OrderBy(x => x.HandRank.Value).ThenBy(x => x.cards.Min(y=>(int)y.Value)).ThenBy(x => x.cards.Sum(y => (int)y.Value)).ToList();
            //var lstStraightFlush = servedCardsWithRank.OrderBy(x => x.HandRank.Value).ThenBy(x => x.cards.Sum(y => (int)y.Suite)).ThenBy(x => x.cards.Sum(y => (int)y.Value)).ToList();


            int i = 0;
            foreach (var item in lstStraightFlush)
            {
                item.Score = i;
                i++;
            }
            return lstStraightFlush;
        }

        private HandRankType GetRank(Player player)
        {
            //ranked A (highest), K, Q, J, 10, 9, 8, 7, 6, 5, 4, 3, 2 (lowest).
            //Suit order (strongest to weakest): Spades, Clubs, Hearts, Diamonds
            var lst = player.cards.OrderBy(o => o.Rank).ToList();
            int rank1 = (int)lst[0].Rank;
            int rank2 = (int)lst[1].Rank;
            int suite1 = (int)lst[0].Suite;
            int suite2 = (int)lst[1].Suite;
            /*
             1. Straight Flush (2 cards of sequential rank, same suit)
             2. Flush (2 cards, same suit)
             3. Straight (2 cards of sequential rank, different suit)
             4. 1 pair (2 cards of same rank)? different Suite? should be
             5. High Card (2 cards, different rank, suit and not in sequence. Highest card wins)
            */

            if (suite1 == suite2)
            {
                //Not Sure the scenario if Ace, two considered as sequence?
                if (rank1 + 1 == rank2)
                {
                    return HandRankType.StraightFlush;
                }
                return HandRankType.Flush;
            }
            else if(rank1 + 1 == rank2)
            {
                return HandRankType.Straight;
            }
            else if(rank1==rank2)
            {
                return HandRankType.OnePair;
            }
            else {
                return HandRankType.HighCard;
            }
        }

     
    }
}
