using System.Collections.Generic;

namespace CardGame
{
    class Player
    {
        public string name;
        public List<Card> hand;
        public int health;

        public Player(string myName)
        {
            name = myName;
            hand = new List<Card>();
            health = 100;
        }

        public Card Draw(Deck thisDeck)
        {
            Card myCard = thisDeck.Deal();
            hand.Add(myCard);
            return myCard;
        }

        public Card Discard(int index){
            Card myCard = hand[index];
            hand.RemoveAt(index);
            return myCard;
        }

        public void DisplayHand()
        {
            System.Console.WriteLine("Your cards are: ");
            for (int i = 0; i < hand.Count; i++)
            {
            System.Console.WriteLine("-----------------------------------");
            System.Console.WriteLine("|The {0} of {1}", hand[i].stringVal, hand[i].suit);
            System.Console.WriteLine("|" + hand[i].description);
            System.Console.WriteLine("-----------------------------------");
            }
        }
    }
}