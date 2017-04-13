using System.Collections.Generic;

namespace KiwiPoker.Services
{
    public interface IDeckOfCards
    {
        List<Card> CardsDeck { get; set; }

        List<Card> ShuffleCards(List<Card> deck);
    }
}