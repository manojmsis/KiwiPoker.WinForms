using KiwiPoker.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KiwiPoker.WinForms
{
    public partial class Form1 : Form
    {
        IGameService _gameService;
        public Form1()
        {
            InitializeComponent();
        }
        //DI will inject the dependencies.
        public Form1(IGameService gameService)
        {
            InitializeComponent();
            _gameService = gameService;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Player> FinalScore = new List<Player>();
            // GameService gs = new GameService(new DeckOfCards());
            try
            {
                clientValidate();
                for (int i = 1; i <= _gameService.NumberOfRounds.Value; i++)
                {
                    var shuffledCards = _gameService.ShuffleCardsXTimes();
                    var servedcards = _gameService.ServeCards(shuffledCards, i);
                    var handRankswithScore = _gameService.GetHandRanksAndScore(servedcards);
                    FinalScore.AddRange(handRankswithScore);
                    string Result = _gameService.ListWinnersByRound(handRankswithScore);
                    MessageBox.Show(Result);
                    txtScoreBoard.AppendText("Round " + i + Environment.NewLine  + Result + Environment.NewLine );
                }
                string Finalresult = _gameService.FinalWinners(FinalScore);
                MessageBox.Show(Finalresult);
                txtScoreBoard.AppendText("Over ALL Score " + Environment.NewLine + Finalresult + Environment.NewLine);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool clientValidate()
        {
            int players, rounds, shuffles;
            bool p = int.TryParse(txtNoOfPlayers.Text, out players);
            if (p)
                _gameService.NumberOfPlayers = players;
            bool r = int.TryParse(txtNoOfRounds.Text, out rounds);
            if (r)
                _gameService.NumberOfRounds = rounds;
            bool s = int.TryParse(txtNoOfShuffles.Text, out shuffles);
            if (s)
                _gameService.NumberOfShuffles = shuffles;
           return _gameService.Validate();
        }
    }
}
