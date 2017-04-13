using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KiwiPoker.Services
{
    public enum SuiteType
    {
        Diamonds=1,
        Hearts,
        Clubs,
        Spades
    }

    public enum RankType
    {
        //Ace,
        Two = 2, Three, Four, Five, Six, Seven,
        Eight, Nine, Ten, Jack, Queen, King,
        Ace
    }
    public enum HandRankType
    {
        HighCard,

        OnePair,

        Straight,

        Flush,

        StraightFlush,

    }
    //public enum HandRank
    //{
    //    StraightFlush,
    //    Flush,
    //    Straight,
    //    OnePair,
    //    HighCard,
    //}
    // 1. Straight Flush (2 cards of sequential rank, same suit)

    // 2. Flush (2 cards, same suit)

    //3. Straight (2 cards of sequential rank, different suit)

    // 4. 1 pair (2 cards of same rank)

    // 5. High Card (2 cards, different rank, suit and not in sequence. Highest card wins)
    //    * Individual cards are ranked A (highest), K, Q, J, 10, 9, 8, 7, 6, 5, 4, 3, 2 (lowest).

    // * Suit order (strongest to weakest): Spades, Clubs, Hearts, Diamonds
}
