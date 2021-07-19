using System;
using SimplifiedSnap.Enums;
using SimplifiedSnap.Model;
using SimplifiedSnap.Services;

namespace SimplifiedSnap
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welocme to Snap Game");
            Console.WriteLine("Please enter the number of decks you would like to play with (from 1 to N)");


            string decks = Console.ReadLine();

            int deckNumber;
            bool isNumeric = int.TryParse(decks, out deckNumber);

            if (!isNumeric)
            {
                Console.WriteLine("The number of decks should be a positive number from 1 to N");
                Console.ReadKey();
                return;
            }

            if (isNumeric)
            {
                if (deckNumber <= 0 )
                {
                    Console.WriteLine("The number of decks should be a positive number from 1 to N");
                    Console.ReadKey();
                    return;
                }
            }
           
            //check if deck is int

            Console.WriteLine("Choose the snap rules");
            Console.WriteLine("The 'Snap!' matching condition can be : ");
            Console.WriteLine(" 1. The Face value of the card (Please type 1)");
            Console.WriteLine(" 2. The Suit (Please type 2)");
            Console.WriteLine(" 3. Both (Please type 3)");

            // Create a string variable and get user input from the keyboard and store it in the variable
            string snapRule = Console.ReadLine();

            SnapConditions snapCondition = SnapConditions.UNDEFINED;

            switch (snapRule)
            {
                case "1":
                    {
                        snapCondition = SnapConditions.FACEVALUE;
                        Console.WriteLine($"You chose to play Snap! with {deckNumber} decks. The Snap rule is Face Value of the card should match");
                        break;
                    }
                case "2":
                    {
                        snapCondition = SnapConditions.SUIT;
                        Console.WriteLine($"You chose to play Snap! with {deckNumber} decks. The Snap rule is Rank of the card should match");
                        break;
                    }
                case "3":
                    {
                        snapCondition = SnapConditions.BOTH;
                        Console.WriteLine($"You chose to play Snap! with {deckNumber} decks. The Snap rule is Both Face Value and Rank of the card should match");
                        break;
                    }
            }
            
           
            Console.WriteLine($"To quit the game please start Q");
            Console.WriteLine($"To shout snap! press S");

            Console.WriteLine($"The game will be over once you or your opponent run out of cards");
            Console.WriteLine("The scores will be displayed in the end of the game");

            Console.WriteLine("Now let's start the game");

            DeckFactory factory = new DeckFactory();
            DeckManager manager = new DeckManager();
            //Call the start of the game
            GameController gameController = new GameController(factory, manager, deckNumber, snapCondition);
        }
    }
}
