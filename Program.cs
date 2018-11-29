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
                System.Console.WriteLine("       ************************************       ");
                System.Console.WriteLine("   ********************************************   ");
                System.Console.WriteLine(" **********************************************  ");
                System.Console.WriteLine("*************************************************");
                System.Console.WriteLine("***             *******************           ***");
                System.Console.WriteLine("***             WELCOME TO WAR 2018           ***");
                System.Console.WriteLine("***             *******************           ***");
                System.Console.WriteLine("*************************************************");
                System.Console.WriteLine("*********************          ******************");
                System.Console.WriteLine("*********************          ******************");
                System.Console.WriteLine(" ************************************************");
                System.Console.WriteLine("  **********  ****  ****  ****  ****  **********  ");
                System.Console.WriteLine("   *********  ****  ****  ****  ****  *********  ");
                System.Console.WriteLine("    ********  ****  ****  ****  ****  ********  ");
                System.Console.WriteLine("    ********  ****  ****  ****  ****  *******  ");
                System.Console.WriteLine("_______________________________________________");
                System.Console.WriteLine("***   Select 1-2 Players");
                int cardsNeeded = 0;
                int Players = 0;

                Player player1 = new Player ("Temp");
                Player player2 = player1;
                Player EO = player1;

                while (Players == 0)
                {
                    Boop = Console.ReadLine();
                    Players = Int32.Parse(Boop);
                    if (Players == 1)
                    {
                        System.Console.WriteLine("*************************************************");
                        System.Console.WriteLine("Enter Your Name: ");
                        Boop = Console.ReadLine();
                        player1 = new Player(Boop);
                        cardsNeeded = 4;
                        EO = new Player("Evil Overlord", 150);
                    }
                    else if (Players == 2)
                    {
                        System.Console.WriteLine("*************************************************");
                        System.Console.WriteLine("***   Enter Player 1's Name: ");
                        Boop = Console.ReadLine();
                        player1 = new Player(Boop);
                        System.Console.WriteLine("*************************************************");
                        System.Console.WriteLine("***   Enter Player 2's Name: ");
                        Boop = Console.ReadLine();
                        player2 = new Player(Boop);
                        EO = new Player("Evil Overlord", 300);
                        cardsNeeded = 6;
                    }
                    else
                    {
                        Players = 0;
                    }
                    System.Console.WriteLine("Please type 1 or 2.");
                }

                int PlayersAlive = Players;

                //game loop
                while (PlayersAlive > 0 && EO.health > 0)//and boss health
                {
                    System.Console.WriteLine("*************************************************");
                    System.Console.WriteLine("***   {0} health is: {1}", player1.name, player1.health);
                    if (Players >1)
                    {
                    System.Console.WriteLine("***   {0} health is: {1}", player2.name, player2.health);
                    }
                    System.Console.WriteLine("***   Boss's health is: {0}", EO.health);
                    System.Console.WriteLine("*************************************************");

                    EO.Draw(GameDeck);
                    EO.Draw(GameDeck);

                    if ((Players>1 && player1.health >= 0) || Players == 1)
                    {
                    player1.Draw(GameDeck);
                    player1.Draw(GameDeck);
                    System.Console.WriteLine("***      {0}'s Turn", player1.name);
                    System.Console.WriteLine("*************************************************");
                    player1.DisplayHand();
                    System.Console.WriteLine("************************************************");
                    System.Console.WriteLine("***   Would you like to play the first card or the second card?");
                    System.Console.WriteLine("***   Type 'A' for the first card and 'B' for the second card.");

                    bool errorCheck = true;
                    while (errorCheck == true)
                    {
                    Boop = Console.ReadLine();
                    // System.Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                    // System.Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                    // System.Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");

                        if (Boop == "A" || Boop == "a")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            player1.Attack(player1.Discard(0), EO);
                            Console.ResetColor();
                            errorCheck = false;
                        }
                        else if(Boop == "B" || Boop == "b")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            player1.Attack(player1.Discard(1), EO);
                            Console.ResetColor();
                            errorCheck = false;
                        }
                        else
                        {
                            System.Console.WriteLine("Try writing 'a' or 'b' please.");
                        }
                        if (EO.health <= 0 && Players>1)
                        {
                            System.Console.WriteLine("You would win now but we need to work on that so just keep going.");
                        }
                    }

                    System.Console.WriteLine("*************************************************");
                    }

//player 2
                    if (Players>1 && player2.health >= 0)
                    {
                    System.Console.WriteLine("***   {0} health is: {1}", player1.name, player1.health);
                    if (Players >1)
                    {
                    System.Console.WriteLine("***   {0} health is: {1}", player2.name, player2.health);
                    }
                    System.Console.WriteLine("***   Boss's health is: {0}", EO.health);
                    System.Console.WriteLine("*************************************************");
                    player2.Draw(GameDeck);
                    player2.Draw(GameDeck);
                    // System.Console.WriteLine("You drew two cards.");
                    System.Console.WriteLine("***      {0}'s Turn", player2.name);
                    System.Console.WriteLine("*************************************************");
                    player2.DisplayHand();
                    System.Console.WriteLine("*************************************************");
                    System.Console.WriteLine("***   Would you like to play the first card or the second card?");
                    System.Console.WriteLine("***   Type 'A' for the first card and 'B' for the second card.");

                    bool errorCheck3 = true;
                    while (errorCheck3 == true)
                    {
                    Boop = Console.ReadLine();

                        if (Boop == "A" || Boop == "a")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            player2.Attack(player2.Discard(0), EO);
                            Console.ResetColor();
                            errorCheck3 = false;
                        }
                        else if(Boop == "B" || Boop == "b")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            player2.Attack(player2.Discard(1), EO);
                            Console.ResetColor();
                            errorCheck3 = false;
                        }
                        else
                        {
                            System.Console.WriteLine("Try writing 'a' or 'b' please.");
                        }
                    }
                    }

                    System.Console.WriteLine("*************************************************");
                    
                    // pick a player
                    Player chosenPlayer = player1;
                    if (Players > 1)
                    {
                    Random rand = new Random();
                    int x = rand.Next(1,3);
                    if (x == 2)
                    {
                        chosenPlayer = player2;
                    }
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    EO.Attack(EO.Discard(0), chosenPlayer);
                    Console.ResetColor();

                    System.Console.WriteLine("*************************************************");
                    
                    if (GameDeck.cards.Count < cardsNeeded)
                    {
                        System.Console.WriteLine("Re-Shuffling Deck");
                        GameDeck.Reset();
                    }

                    if (player1.health <=0)
                    {
                        System.Console.WriteLine("{0} has died", player1.name);
                        PlayersAlive--;
                    }
                    else if (player2.health <=0)
                    {
                        System.Console.WriteLine("{0} has died", player2.name);
                        PlayersAlive--;
                    }
                }

                // if someone won say who won
                if (EO.health <= 0)
                {
                    System.Console.WriteLine("***********************************");
                    System.Console.WriteLine("*    The Evil Overlord Is Dead    *");
                    System.Console.WriteLine("*     You Are The New Overlord    *");
                    System.Console.WriteLine("*         Destroy It All          *");
                    System.Console.WriteLine("***********************************");
                    // player who won?
                }
                else if (PlayersAlive <= 0)
                {
                    System.Console.WriteLine("You died. Very dead. Evil Wins Again.");
                }
                else
                {
                    System.Console.WriteLine("How the hell?");
                }

                System.Console.WriteLine("Type 'C' to play again and 'Q' to quit.");
                bool errorCheck1 = true;
                while (errorCheck1)
                {
                    Boop = Console.ReadLine();
                    if (Boop == "q" || Boop == "Q")
                    {
                        Game = false;
                        errorCheck1 = false;
                    }
                    else if (Boop == "c" || Boop == "C")
                    {
                        errorCheck1 = false;
                    }
                    else
                    {
                    System.Console.WriteLine("Type 'C' to play again and 'Q' to quit.");
                    }
                }
            }
        }
    }
}
