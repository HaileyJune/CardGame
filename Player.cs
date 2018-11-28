using System;
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
        public Card QueenCheat(int index){
            Card myCard = hand[index];
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

        public void Attack(Card play, Boss target)
        {
            int val = play.val;
            if (val > 1 && val < 11)
            {
                target.health = target.health - val;
                System.Console.WriteLine("{0} was attacked for {1} damage.", target.name, val);
                Discard(0);

            }
            else if (val == 1)
            {
                if (health + 10 >= 100)
                {
                    health = 100;
                    System.Console.WriteLine("{0} was healed to full health.", name);
                }
                else
                {
                    health += 10;
                    System.Console.WriteLine("{0} was healed for 10HP.", name);
                }
                Discard(0);
            }
            else if (val == 11)
            {
                Random rand = new Random();
                int damage = rand.Next(1,10);
                target.health = target.health - damage;
                System.Console.WriteLine("{0} was attacked by a wildcard for {1} damage.", target.name, damage);
                Discard(0);
            }
            else if (val == 12)
            {
                target.health -= 5;
                System.Console.WriteLine("{0} Played a Queen, dealing 5 damage to {1} and allowing them to play another card!", name, target.name);
                Attack(QueenCheat(0), target);
            }
            else if (val == 13)
            {
                if (target.health < (target.health/4))
                {
                    System.Console.WriteLine("{0} was dealt a killing blow.");
                    target.health = 0;
                }
                else
                {
                    System.Console.WriteLine("The king attacked {0} but it had no effect.", target.name);
                }
                Discard(0);
            }
        }
    }
}