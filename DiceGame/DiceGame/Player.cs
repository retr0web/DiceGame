using System;
using System.Reflection.Metadata.Ecma335;

namespace DiceGame
{
    class Player
    {
        public string Name
        {
            get; set;
        }
        public Player(string name)
        {
            Name = name;
        }
        // PROPERTIES
        
        public int Wins
        {
            get;
            set; 
        }
        public int Sum
        {
            get;
            set; 
        }
    }
}