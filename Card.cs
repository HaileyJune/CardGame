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
    }

}