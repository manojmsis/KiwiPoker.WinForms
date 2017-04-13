using System.Collections.Generic;

namespace KiwiPoker.Services
{
    public class Player
    {
        public int PlayerID { get; set; }
        public List<Card> cards { get; set; }
        public HandRankType? HandRank { get; set; }
        public int Round { get; set; }
        public int Score { get; set; }
    }
}
