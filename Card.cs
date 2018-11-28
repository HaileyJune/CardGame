using System;

namespace CardGame
{
    class Card
    {
        public string stringVal;
        public string suit;
        public int val;
        public string description;
    
        public Card(string face, string shape, int num, string des)
        {
            stringVal = face;
            suit = shape;
            val = num;
            description = des;
        }

        public void Attack(Player target)
        {
            if (val > 1 && val < 11)
            {
                target.health = target.health - val;
                System.Console.WriteLine("{0} was attacked for {1} damage.", target.name, val);
            }
            else if (val == 1)
            {
                System.Console.WriteLine("Sorry this card is outta commission");
            }
            else if (val == 11)
            {
                Random rand = new Random();
                int damage = rand.Next(1,13);
                target.health = target.health - damage;
                System.Console.WriteLine("{0} was attacked by a wildcard for {1} damage.", target.name, damage);
            }
            else if (val == 12)
            {
                System.Console.WriteLine("Not gonna happen.");
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
        public void Attack(Boss target)
        {
            if (val > 1 && val < 11)
            {
                target.health = target.health - val;
                System.Console.WriteLine("{0} was attacked for {1} damage.", target.name, val);
            }
            else if (val == 1)
            {
                System.Console.WriteLine("Sorry this card is outta commission");
            }
            else if (val == 11)
            {
                Random rand = new Random();
                int damage = rand.Next(1,13);
                target.health = target.health - damage;
                System.Console.WriteLine("{0} was attacked by a wildcard for {1} damage.", target.name, damage);
            }
            else if (val == 12)
            {
                System.Console.WriteLine("Not gonna happen.");
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