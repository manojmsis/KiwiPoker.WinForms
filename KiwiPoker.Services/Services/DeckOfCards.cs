using System;
using System.Collections.Generic;
using System.Linq;

namespace KiwiPoker.Services
{
    public class DeckOfCards : IDeckOfCards
    {
        private List<Card> deck;

        public List<Card> CardsDeck {
            get
            {
                if (deck == null)
                    return setUpDeck();
                return deck;
            }
            set
            {
                deck = value;
            }
        }
       
        private List<Card> setUpDeck()
        {
            List<Card> _deck = new List<Services.Card>();
            foreach (SuiteType s in Enum.GetValues(typeof(SuiteType)))
            {
                foreach (RankType v in Enum.GetValues(typeof(RankType)))
                {
                    _deck.Add(new Card() { Suite = s, Rank = v ,Value=((int)s * (int)v)});
                   
                }
            }
            return _deck;
        }

        public List<Card > ShuffleCards(List<Card> deck )
        {
            var rnd = new Random();
           return deck.OrderBy(item => rnd.Next()).ToList();
        }

      
    }
}
