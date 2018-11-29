using System;
using System.Collections.Generic;

namespace CardGame
{
    class Player
    {
        public string name;
        public List<Card> hand;
        public int health;
        public int maxHealth;

        public Player(string myName)
        {
            name = myName;
            hand = new List<Card>();
            health = 100;
            maxHealth = 100;
        }

        public Player(string myName, int bossHealth)
        {
            name = myName;
            hand = new List<Card>();
            health = bossHealth;
            maxHealth = bossHealth;
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
            System.Console.WriteLine("***   {0}'s cards are: ", name);
            for (int i = 0; i < hand.Count; i++)
            {
            System.Console.WriteLine("***   -----------------------------------");
            System.Console.WriteLine("***   |The {0} of {1}", hand[i].stringVal, hand[i].suit);
            System.Console.WriteLine("***   |" + hand[i].description);
            System.Console.WriteLine("***   -----------------------------------");
            }
        }

        public void Attack(Card play, Player target)
        {
            int val = play.val;
            if (val > 1 && val < 11)
            {
                target.health = target.health - val;
                System.Console.WriteLine("{0} was attacked by {2} for {1} damage.", target.name, val, name);
                Discard(0);

            }
            else if (val == 1)
            {
                if (health + 10 >= maxHealth)
                {
                    health = maxHealth;
                    System.Console.WriteLine("{0} was healed to full health by their Ace.", name);
                }
                else
                {
                    health += 10;
                    System.Console.WriteLine("{0} was healed by their Ace for 10HP.", name);
                }
                Discard(0);
            }
            else if (val == 11)
            {
                Random rand = new Random();
                int damage = rand.Next(1,10);
                target.health = target.health - damage;
                System.Console.WriteLine("{0} was attacked by {2}'s Jack for {1} damage.", target.name, damage, name);
                Discard(0);
            }
            else if (val == 12)
            {
                target.health -= 5;
                System.Console.WriteLine("{0} Played a Queen, dealing 5 damage to {1} and allowing {0} to play their other card!", name, target.name);
                if (QueenCheat(0).val == 12)
                {
                    System.Console.WriteLine("{0} was instantly killed by {1}'s Double Lesbian Queen Duo", target.name, name);
                    target.health = 0;
                }
                else
                {
                Attack(QueenCheat(0), target);
                }
            }
            else if (val == 13)
            {
                if (target.health < (target.maxHealth/4))
                {
                    System.Console.WriteLine("{0} was dealt a killing blow by {1}'s King.", target.name, name);
                    target.health = 0;
                }
                else
                {
                    System.Console.WriteLine("The {0}'s King attacked {1} but it had no effect.",name , target.name);
                }
                Discard(0);
            }
        }
    }
}