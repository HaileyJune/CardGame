using System;
using System.Collections.Generic;

namespace CardGame
{
    class Deck
    {
        public List<Card> cards;
        

        public Deck()
        {
            cards = new List<Card>();
            FillDeck();
        }

        public void FillDeck()
        {
            string[] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};

            // Aces
            string ADes = "Heals the player for 10hp.";
            foreach (string suit in suits)
            {
                cards.Add(new Card("Ace", suit, 1, ADes));
            }
            // 2-10
            for (int i = 2; i <= 10; i ++){
                string des = "Deals {0} damage to target";
                string DES = string.Format(des, i.ToString());
                string face = i.ToString();
                foreach (string suit in suits)
                {
                    cards.Add(new Card(face, suit, i, DES));
                }            
            }
            // Jacks
            string JDes = "Deals a random amount of damage from 1 to 10";
            foreach (string suit in suits)
            {
                cards.Add(new Card("Jack", suit, 11, JDes));
            }
            // Queens
            string QDes = "Deals 5 damage and plays the other card in your hand.";
            foreach (string suit in suits)
            {
                cards.Add(new Card("Queen", suit, 12, QDes));
            }
            // Kings
            string KDes = "Finishes off target if they are under a quarter hp";
            foreach (string suit in suits)
            {
                cards.Add(new Card("King", suit, 13, KDes));
            }
            Shuffle();

        }

        public Card Deal()
        {
            Card cardPulled = cards[0];
            cards.RemoveAt(0);
            return cardPulled;
        }

        public void Reset()
        {
            //must be a way to do without copypaste
            cards.Clear();
            // cards = 
            FillDeck();
        }

        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int shuffle = rand.Next(cards.Count);
                Card temp = cards[i];
                cards[i] = cards[shuffle];
                cards[shuffle] = temp;
            }
        }
    }
}