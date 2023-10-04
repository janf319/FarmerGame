using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jan_FarmerGame
{//enum in namespace outside of class scope otherwise it gives an error in UI
    enum Direction 
    { 
        North, 
        South
    }
    internal class Farmer
    {
        private Direction farmer;
        private List<string> northBank = new List<string>();
        private List<string> southBank = new List<string>();

        public Direction TheFarmer
        {
            get { return farmer; }  
        }
        public List<string> NorthBank 
        {
            get { return northBank; }
        }
        public List<string> SouthBank 
        {
            get { return southBank; } 
        }

        //loading North bank through constructor and placing farmer on North
        public Farmer()
        {
            northBank.Add("FOX");
            northBank.Add("CHICKEN");
            northBank.Add("GRAIN");
            farmer = Direction.North;
        }

        //This method assesses what kind of food animal ate and then adds up a temporary int
        //if fox eats the chicken it will hold 4 and that 4 get's translated through a string
        public string AnimalAteFood()
        {
            int tempInt = 0;
            string tempStr;
            if (farmer == Direction.North && southBank.Count > 1)
            {
                for (int i = 0; i < southBank.Count; i++)
                {
                    if (southBank[i] == "FOX") 
                    { //holding 1 if user says fox but if chicken
                      //is there it will hold 4 which will result in fox eating chicken
                        tempInt = tempInt + 1; 
                    }
                    if (southBank[i] == "CHICKEN") 
                    { 
                        tempInt = tempInt + 3;
                    }
                    if (southBank[i] == "GRAIN") 
                    { 
                        tempInt = tempInt + 5;
                    }
                }
            }
            else if (farmer == Direction.South && northBank.Count > 1)
            {
                for (int i = 0; i < northBank.Count; i++)
                {
                    if (northBank[i] == "FOX")
                    { 
                        tempInt = tempInt + 1;
                    }
                    if (northBank[i] == "CHICKEN")
                    { 
                        tempInt = tempInt + 3;
                    }
                    if (northBank[i] == "GRAIN")
                    { 
                        tempInt = tempInt + 5;
                    }
                }
            }
            // determinWin is returning true or false
            if (DetermineWin())
            {
                tempStr = "WIN";
            }
            else if (tempInt == 4)
            {
                tempStr = "FoxAteChicken";
            }
            else if (tempInt == 8) 
            {
                tempStr = "ChkenAteGrain";
            }
            else
            {// 0 is to keep the game running
                tempStr = "0";
            }
            return tempStr;
        }

       //if south bank has all 3 elements player wins
        public bool DetermineWin()
        {
            if (southBank.Count == 3 )
            { 
                return true;
            }
            else 
            { 
                return false;
            }
        }

        //Move takes in player's answer and asses it.
        //If farmer is at north it adds/remove player answer in Array List
        //then it runs AnimalAteFood() and returns it's string back to UI 
        public string Move(string item)
        {
            string selection;

            if (item == "")
            {
                if (farmer == Direction.North) 
                { 
                    farmer = Direction.South;
                }
                else if (farmer == Direction.South)
                { 
                    farmer = Direction.North;
                }
            }
            else if (farmer == Direction.North)
            {
                northBank.Remove(item.ToUpper());
                southBank.Add(item.ToUpper());
                farmer = Direction.South;
            }
            else if (farmer == Direction.South)
            {
                southBank.Remove(item.ToUpper());
                northBank.Add(item.ToUpper());
                farmer = Direction.North;
            }

            selection = AnimalAteFood();
            //added this here to restart the game in case player wins or loose
            if (selection == "ChkenAteGrain" || selection == "FoxAteChicken" || selection == "WIN")
            {
                northBank.Clear();
                southBank.Clear();
                farmer = Direction.North;
                northBank.Add("FOX");
                northBank.Add("CHICKEN");
                northBank.Add("GRAIN");
            }
            return selection;
        }
    }
}
