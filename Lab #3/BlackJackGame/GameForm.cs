using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BlackJackGame
{
    public partial class GameForm : Form
    {
        private Deck deck;
        private List<Card> playerHand = new List<Card>();
        private List<Card> dealerHand = new List<Card>();
        private int balance = 100;
        private int bet = 0;
        private List<GameResult> gameHistory = new List<GameResult>();

        public GameForm()
        {
            InitializeComponent();
            UpdateBalance();
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Deal clicked!");

            lstPlayer.Items.Clear();
            lstDealer.Items.Clear();
            playerHand.Clear();
            dealerHand.Clear();

            if (!int.TryParse(txtBet.Text, out bet) || bet <= 0 || bet > balance)
            {
                MessageBox.Show("Invalid bet amount.");
                return;
            }

            deck = new Deck();
            playerHand.Add(deck.DrawCard());
            playerHand.Add(deck.DrawCard());
            dealerHand.Add(deck.DrawCard());
            dealerHand.Add(deck.DrawCard());

            ShowCards(false);

            btnHit.Enabled = true;
            btnStay.Enabled = true;
            btnDeal.Enabled = false;
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hit clicked!");

            playerHand.Add(deck.DrawCard());
            ShowCards(false);

            if (GetScore(playerHand) > 21)
            {
                EndRound("Player busts! Dealer wins.");
            }
        }

        private void btnStay_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Stay clicked!");

            while (GetScore(dealerHand) < 17)
            {
                dealerHand.Add(deck.DrawCard());
            }

            int playerScore = GetScore(playerHand);
            int dealerScore = GetScore(dealerHand);
            string result;

            if (dealerScore > 21 || playerScore > dealerScore)
            {
                result = "Player wins!";
            }
            else if (playerScore < dealerScore)
            {
                result = "Dealer wins!";
            }
            else
            {
                result = "It's a tie!";
            }

            EndRound(result);
        }

        private void EndRound(string result)
        {
            MessageBox.Show("EndRound ran: " + result);

            lblResult.Text = result;
            ShowCards(true);

            if (result == "Player wins!")
                balance += bet;
            else if (result == "Dealer wins!")
                balance -= bet;

            UpdateBalance();

            gameHistory.Add(new GameResult
            {
                Bet = bet,
                PlayerCards = string.Join(", ", playerHand),
                DealerCards = string.Join(", ", dealerHand),
                Result = result,
                Balance = balance
            });

            btnHit.Enabled = false;
            btnStay.Enabled = false;
            btnDeal.Enabled = true;
        }

        private void ShowCards(bool showDealer)
        {
            lstPlayer.Items.Clear();
            foreach (var card in playerHand)
                lstPlayer.Items.Add(card.ToString());

            lstDealer.Items.Clear();
            if (showDealer)
            {
                foreach (var card in dealerHand)
                    lstDealer.Items.Add(card.ToString());
            }
            else
            {
                lstDealer.Items.Add(dealerHand[0].ToString());
                lstDealer.Items.Add("Hidden");
            }
        }

        private int GetScore(List<Card> hand)
        {
            int score = 0;
            int aceCount = 0;

            foreach (var card in hand)
            {
                if (int.TryParse(card.Value, out int val))
                    score += val;
                else if (card.Value == "A")
                {
                    score += 11;
                    aceCount++;
                }
                else
                    score += 10;
            }

            while (score > 21 && aceCount > 0)
            {
                score -= 10;
                aceCount--;
            }

            return score;
        }

        private void UpdateBalance()
        {
            lblBalance.Text = $"Balance: ${balance}";
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("History clicked!");

            HistoryForm historyForm = new HistoryForm(gameHistory);
            historyForm.Show();
        }
    }
}
