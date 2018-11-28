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
    }
}