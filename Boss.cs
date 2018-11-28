using System;

namespace CardGame
{
    class Boss
    {
        public string name;
        public int health;
        public Card bossCard;

        public Boss()
        {
            name = "Evil Overlord";
            health = 100;
            bossCard = null;
        }

        public Card DrawCard(Deck thisDeck)
        {
            bossCard = thisDeck.Deal();
            return bossCard;
        }

        public Card Discard()
        {
            Card temp = bossCard;
            bossCard = null;
            return temp;
        }

        public void Attack(Card play, Player target)
        {
            int val = play.val;
            if (val > 1 && val < 11)
            {
                target.health = target.health - val;
                System.Console.WriteLine("{0} was attacked for {1} damage.", target.name, val);
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
            }
            else if (val == 11)
            {
                Random rand = new Random();
                int damage = rand.Next(1,10);
                target.health = target.health - damage;
                System.Console.WriteLine("{0} was attacked by a wildcard for {1} damage.", target.name, damage);
            }
            else if (val == 12)
            {
                target.health -= 5;
                System.Console.WriteLine("{0} Played a Queen, dealing 5 damage to {1} and allowing them to play another card! But they don't...", name, target.name);
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
            }
        }
    }
}