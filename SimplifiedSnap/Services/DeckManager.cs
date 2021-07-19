using System;
using System.Collections.Generic;
using SimplifiedSnap.Model;

namespace SimplifiedSnap.Services
{
    public class DeckManager
    {
        private const int SplitInHalf = 2;
        private Deck[] _decks;
        private List<Card> _allCards;

        public DeckManager()
        {
            
        }

        public Deck[] Decks
        {
            get
            {
                return _decks;
            }
            set
            {
                _decks = value;
                AggregateCardsFromAllDecks();
            }
        }

        public List<Card> AllCards
        {
            get
            {
                return _allCards;
            }
           
        }

        private void AggregateCardsFromAllDecks()
        {
            _allCards = new List<Card>();
            foreach (Deck deck in _decks)
            {
                _allCards.AddRange(deck.Cards);
            }
        }
        

        
    }
}
