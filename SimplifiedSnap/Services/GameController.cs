using System;
using System.Collections.Generic;
using System.Timers;
using SimplifiedSnap.Enums;
using SimplifiedSnap.Model;

namespace SimplifiedSnap.Services
{
    public class GameController
    {
        int _numberOfDecks;
        SnapConditions _snapRule;
        private int _remainingCards;
        int _userScore;
        int _pcScore;

        DeckFactory _deckFactory;
        DeckManager _deckManager;
        private Queue<Card> _cardPile;
        private Timer _gameTimer;
        private bool prevDrawFinished = true;

        public GameController(DeckFactory deckFactory, DeckManager deckManager, int numberOfDecks, SnapConditions snapRule)
        {
            _deckFactory = deckFactory;
            _deckManager = deckManager;
           
            _numberOfDecks = numberOfDecks;
            _snapRule = snapRule;

            _userScore = 0;
            _pcScore = 0;
            Init();
            GameCourse();
        }

        private void Init()
        {
           var decks = _deckFactory.CreateDecks(_numberOfDecks);

            _deckManager.Decks = decks;

            CreateCardPile(_deckManager.AllCards);

            _gameTimer = new Timer();
            _gameTimer.AutoReset = true;
            _gameTimer.Interval = 5000;
            _gameTimer.Elapsed += _gameTimer_Elapsed;


        }

        private void _gameTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Console.ReadLine() == "s")
            {
                _userScore++;
            }
            else
            {
                _pcScore++;
            }

            _remainingCards = _remainingCards - 2;
            prevDrawFinished = true;
            
        }

        private void CreateCardPile(List<Card> cards)
        {
            if (cards != null)
            {
                _cardPile = new Queue<Card>(cards);
                _remainingCards = cards.Count;
            }
           

        }

        public Card DrawCard()
        {
            Card card = _cardPile.Dequeue();
            card.TurnCard();
            return card;
        }

        private void GameCourse()
        {
            //assume that PC starts first
            
            while (_remainingCards > 0 && prevDrawFinished)
            {
                prevDrawFinished = false;

                Console.WriteLine("PC draws a card...");
                var pcCard = DrawCard();
                Console.WriteLine(pcCard);

                Console.WriteLine("User draws a card...");
                var userCard = DrawCard();
                Console.WriteLine(userCard);

                if (userCard.Rank == pcCard.Rank)
                {
                    _gameTimer.Start();
                }
                else
                {
                    prevDrawFinished = true;
                }
                
            }
            

        }
    }
}
