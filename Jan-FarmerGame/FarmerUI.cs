using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Jan_FarmerGame
{
    internal class FarmerUI
    {//instantiating farmer object at class level not at method level since all methods are using farmer object
        Farmer theFarmer = new Farmer();

        public void Play()
        {// PromtForMove returns the controlled loop variable
            string playAgain = "Z";
            while (playAgain != "Q")
            {
                DisplayGameState(theFarmer);
                playAgain = PromptForMove();
            }
            WriteLine("\nYou decided to quit the game. Hope you had fun!");
        }

        public void PlayGame()
        {//only display's welcome in the beginning of game not again and again 
         // enter's method play that has the loop
            DisplayWelcome();
            Play();
        }
        public void DisplayGameState(Farmer theFarmer)
        {//method runs each time after prompt for move inside of play method
            DisplayNorthBank();
            DisplayRiver();
            DisplaySouthBank();
            WriteLine("\nThe farmer is on the {0} bank of the river.", theFarmer.TheFarmer);
        }

        public void DisplayNorthBank()
        {//added color for GUI purposes
            BackgroundColor = ConsoleColor.Green;
            ForegroundColor = ConsoleColor.DarkGreen;
            SetCursorPosition(0, 7);
            WriteLine("VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
            WriteLine("VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
            WriteLine("VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
            WriteLine("******************************* North Bank *************************************");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
            //displaying north bank array list
            for (int i = 0; i < theFarmer.NorthBank.Count; i++)
            {
                Write(theFarmer.NorthBank[i]);
                Write("  ");
            }
        }

        public void DisplayRiver()
        {
            BackgroundColor = ConsoleColor.Blue;
            ForegroundColor = ConsoleColor.DarkBlue;
            WriteLine("\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
        }

        public void DisplaySouthBank()
        {//displaying south bank array list
            for (int i = 0; i < theFarmer.SouthBank.Count; i++)
            {
                Write(theFarmer.SouthBank[i]);
                Write("  ");
            }
            BackgroundColor = ConsoleColor.Green;
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("\nVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
            WriteLine("VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
            WriteLine("VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV");
            WriteLine("******************************* South Bank *************************************");
            BackgroundColor = ConsoleColor.Black;
            ForegroundColor = ConsoleColor.White;
        }

        public void DisplayWelcome()
        {
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("\n\n\n\tThis is the Farmer Game.  The object of the game");
            WriteLine("\tis to get the farmer, fox, chicken, and grain to the other");
            WriteLine("\tside of the river.  But hold on, not so fast.  If the farmer");
            WriteLine("\tleaves the chicken and grain on either side of the river alone,");
            WriteLine("\tthe chicken will eat the grain and that is not good.  If the");
            WriteLine("\tfarmer leaves the fox and chicken on any side of the river alone,");
            WriteLine("\tthe fox will eat the chicken.  That is also not good.  In either case");
            WriteLine("\tyou lose the game.  If you get the farmer, the chicken,");
            WriteLine("\tthe fox, and the grain safely across the river and intact, you win");
            ForegroundColor = ConsoleColor.White;
            WriteLine("\n\n\nPress any key when you are ready to start this thought provoking game");
            ReadKey();
            Clear();
        }

        //PromptForMove takes in userAnswer. Assesses useranswer by passing it to Move and hold's the 
        //outcome in a string.
        //invalidAnswer makes sure if user added the correct name/makes sure
        //user didnt enter the same name again
        //tempString hold's the string that is being returned from this method, it also hold's user answer
        //when user decides to Play again or not
        public string PromptForMove()
        {
            string tempString = "";
            string userAnswer;
            bool invalidAnswer = true;
            string outcome = "0";

            Write("\nChoose next item for the farmer." +
                "  If you choose nothing, just hit the enter key ");
            userAnswer = ReadLine();
            if (userAnswer == "")
            {
                outcome = theFarmer.Move(userAnswer);
                invalidAnswer = false;
            }
            else if (theFarmer.TheFarmer == Direction.North)
            {// this method should have been in Farmer to make sure user doesn't enter
             // what is already inside the ArrayList but I couldn't compare user answer in Model. 
                for (int i = 0; i < theFarmer.NorthBank.Count; i++)
                {
                    if (userAnswer.ToUpper() == theFarmer.NorthBank[i])
                    {
                        outcome = theFarmer.Move(userAnswer.ToUpper());
                        invalidAnswer = false;
                        userAnswer = "";
                    }
                }
            }
            else if (theFarmer.TheFarmer == Direction.South)
            {
                for (int i = 0; i < theFarmer.SouthBank.Count; i++)
                {// this method should have been in Farmer but I failed to add it there
                 // userAnswer to make sure they dont enter what is already inside the ArrayList
                    if (userAnswer.ToUpper() == theFarmer.SouthBank[i])
                    {
                        outcome = theFarmer.Move(userAnswer.ToUpper());
                        invalidAnswer = false;
                        userAnswer = "";
                    }
                }
            }
            Clear();

            if (invalidAnswer)
            {
                WriteLine("\nThat item is not on this side of the river");
                WriteLine("Please try again");
                return tempString;
            }
            else if (outcome == "WIN")
            {
                WriteLine("\n\n\nYou have successfully completed the game!!");
                WriteLine("CONGRATULATIONS");
                Write("\n\n\nWould you like to play again? ");
                Write("\n\nEnter Yes to play Again or Q to quit ");
                tempString = ReadLine();
                Clear();
                return tempString;
            }
            else if (outcome == "FoxAteChicken")
            {
                WriteLine("\n\n\n\n\n\nOh No! The Fox Ate the Chicken!!");
                WriteLine("YOU LOSE");
                Write("\n\n\nWould you like to play again? ");
                Write("\n\nEnter Yes to continue or Q to quit ");
                tempString = ReadLine();
                Clear();
                return tempString;
            }
            else if (outcome == "ChkenAteGrain")
            {
                WriteLine("\n\n\n\n\n\nOh No! The Chicken Ate the Grain!!");
                WriteLine("YOU LOSE");
                Write("\n\n\nWould you like to play again? ");
                Write("\n\nEnter Yes to CONTINUE or Q to Quit ");
                tempString = ReadLine();
                Clear();
                return tempString;
            }//this last else is to keep the game continuing if string is empty
            else 
            { 
                return tempString;
            }
        }
    }
}
