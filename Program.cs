using System;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            bool Game = true;
            string Boop = "1";

            while (Game)
            {
                Deck GameDeck = new Deck();
                System.Console.WriteLine("WELCOME TO WAR 2018");
                System.Console.WriteLine("###########");
                // Deck GameDeck = new Deck();
                // System.Console.WriteLine("WELCOME TO WAR 2018");
                // System.Console.WriteLine("###########");
                // System.Console.WriteLine("Select 1-2 Players");
                // string Boop = Console.ReadLine();
                // int Players = Int32.Parse(Boop);
                // int cardsNeeded = 0;
                System.Console.WriteLine("Enter Your Name: ");
                Boop = Console.ReadLine();
                    System.Console.WriteLine("###########");
                    System.Console.WriteLine("###########");
                    System.Console.WriteLine("###########");
                System.Console.WriteLine("To exit input 0");

                Player player1 = new Player(Boop);
                int cardsNeeded = 3;
                Boss EO = new Boss();

                // if (Players == 1)
                // {
                //     System.Console.WriteLine("###########");
                //     System.Console.WriteLine("Enter Your Name: ");
                //     Boop = Console.ReadLine();
                //     Player player1 = new Player(Boop);
                //     cardsNeeded = 3;
                //     // create boss with 100hp
                // }
                // else if (Players == 2)
                // {
                //     System.Console.WriteLine("###########");
                //     System.Console.WriteLine("Enter Player 1's Name: ");
                //     Boop = Console.ReadLine();
                //     Player player1 = new Player(Boop);
                //     System.Console.WriteLine("###########");
                //     System.Console.WriteLine("Enter Player 2's Name: ");
                //     Boop = Console.ReadLine();
                //     Player player2 = new Player(Boop);
                //     // create boss with 200hp
                // }
                // else
                // {
                //     System.Console.WriteLine("You sure ###### up now, huh?");
                //     Game = false;
                // }

                while (player1.health > 0 && EO.health > 0)//and boss health
                {
                    System.Console.WriteLine("###########");
                    System.Console.WriteLine("Your health is: {0}", player1.health);
                    System.Console.WriteLine("Boss's health is: {0}", EO.health);
                    System.Console.WriteLine("###########");

                    EO.DrawCard(GameDeck);
                    // System.Console.WriteLine("The {0} drew a card.", EO.name);
                    System.Console.WriteLine("Drawing Cards");
                    player1.Draw(GameDeck);
                    player1.Draw(GameDeck);
                    // System.Console.WriteLine("You drew two cards.");
                    System.Console.WriteLine("###########");
                    player1.DisplayHand();
                    System.Console.WriteLine("###########");
                    System.Console.WriteLine("Would you like to play the first card or the second card?");
                    System.Console.WriteLine("Type 'A' for the first card and 'B' for the second card.");

                    bool errorCheck = true;
                    while (errorCheck == true)
                    {
                    Boop = Console.ReadLine();
                    System.Console.WriteLine("###########");
                    System.Console.WriteLine("###########");
                    System.Console.WriteLine("###########");

                        if (Boop == "A" || Boop == "a")
                        {
                            player1.Attack(player1.Discard(0), EO);

                            // Card cardplayed = player1.Discard(0);
                            // cardplayed.Attack(EO);
                            // player1.Discard(0);
                            errorCheck = false;
                        }
                        else if(Boop == "B" || Boop == "b")
                        {
                            player1.Attack(player1.Discard(1), EO);
                            
                            // Card cardplayed = player1.Discard(1);
                            // cardplayed.Attack(EO);
                            errorCheck = false;
                        }
                        else
                        {
                            System.Console.WriteLine("Try writing 'a' or 'b' please.");
                        }
                    }

                    System.Console.WriteLine("###########");
                    // Card cardplayed1 = EO.Discard();
                    // cardplayed1.Attack(player1);
                    EO.Attack(EO.Discard(), player1);
                    System.Console.WriteLine("###########");
                    
                    if (GameDeck.cards.Count < cardsNeeded)
                    {
                        System.Console.WriteLine("Re-Shuffling Deck");
                        GameDeck.Reset();
                    }
                }

                // if someone won say who won
                if (EO.health <= 0)
                {
                    System.Console.WriteLine("****************************");
                    System.Console.WriteLine("*    Fuck yeah you won.    *");
                    System.Console.WriteLine("****************************");
                }
                else if (player1.health <= 0)
                {
                    System.Console.WriteLine("You died. Very dead.");
                }
                else
                {
                    System.Console.WriteLine("How the hell?");
                }

                System.Console.WriteLine("Type a to continue and b to quit.");
                bool errorCheck1 = true;
                while (errorCheck1)
                {
                    Boop = Console.ReadLine();
                    if (Boop == "b" || Boop == "B")
                    {
                        Game = false;
                        errorCheck1 = false;
                    }
                    else if (Boop == "a" || Boop == "A")
                    {
                        errorCheck1 = false;
                    }
                    else
                    {
                    System.Console.WriteLine("Type a to continue and b to quit.");
                    }
                }
            }
        }
    }
}
