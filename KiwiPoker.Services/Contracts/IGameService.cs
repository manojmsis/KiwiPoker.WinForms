using System.Collections.Generic;

namespace KiwiPoker.Services
{
    public interface IGameService
    {
        int? NumberOfPlayers { get; set; }
        int? NumberOfRounds { get; set; }
        int? NumberOfShuffles { get; set; }

       
        List<Player> GetHandRanksAndScore(List<Player> servedCards);
      
        List<Player> ServeCards(List<Card> shuffledcards, int round);
        List<Card> ShuffleCardsXTimes();

        bool Validate();

        string ListWinnersByRound(List<Player> PlayersWithScore);
        string FinalWinners(List<Player> FinalScore);
    }
}