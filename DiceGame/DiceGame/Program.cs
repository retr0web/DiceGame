using System;
/*
 $$$$$$$\  $$$$$$\  $$$$$$\  $$$$$$$$\        $$$$$$\   $$$$$$\  $$\      $$\ $$$$$$$$\ 
$$  __$$\ \_$$  _|$$  __$$\ $$  _____|      $$  __$$\ $$  __$$\ $$$\    $$$ |$$  _____|
$$ |  $$ |  $$ |  $$ /  \__|$$ |            $$ /  \__|$$ /  $$ |$$$$\  $$$$ |$$ |      
$$ |  $$ |  $$ |  $$ |      $$$$$\          $$ |$$$$\ $$$$$$$$ |$$\$$\$$ $$ |$$$$$\    
$$ |  $$ |  $$ |  $$ |      $$  __|         $$ |\_$$ |$$  __$$ |$$ \$$$  $$ |$$  __|   
$$ |  $$ |  $$ |  $$ |  $$\ $$ |            $$ |  $$ |$$ |  $$ |$$ |\$  /$$ |$$ |      
$$$$$$$  |$$$$$$\ \$$$$$$  |$$$$$$$$\       \$$$$$$  |$$ |  $$ |$$ | \_/ $$ |$$$$$$$$\ 
\_______/ \______| \______/ \________|       \______/ \__|  \__|\__|     \__|\________|
 */
namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player playerOne = new Player();
            Player playerTwo = new Player();
            Player computer = new Player();
            computer.Name = "Bobby Shmurda";
            bool twoPlayers = false;
            
            
            Rules();
            HowManyPlayers();
            
            // explanation of the game
            void Rules()
            {
                Console.WriteLine("This is a simple ancient game called Dice");
                Console.WriteLine("Ok, now how it goes. You both roll 2 dices and the one who scores more wins!");
                Console.WriteLine(
                    "So after you rolled dices you get 2 random numbers (from 1 to 6) and the sum of them.");
                Console.WriteLine("And who got bigger sum wins a round");
                Console.WriteLine("You and your friend can have multiple rounds");
                Console.WriteLine("///////////////////////////////////////////////////////");
            }
            
            // decides to play coop or single player
            void HowManyPlayers()
            { 
                Console.WriteLine("///////////////////////////////////////////////////////");
                Console.WriteLine("Greetings. How many players will play");
               int numberOfPlayers = Convert.ToInt32(Console.ReadLine());

               if (numberOfPlayers == 2)
               {
                   twoPlayers = true;
                   Introduce(playerOne.Name);
                   Introduce(playerTwo.Name);
                   GameForTwo();
               }

               else if (numberOfPlayers == 1)
               {
                   Introduce(playerOne.Name);
                   GameForOne();
               }

               else
               {
                   Console.WriteLine("You entered a wrong number. Please try again");
                   HowManyPlayers();
               }
            }

            // giving a name to players
            void Introduce(string player)
            {
                Console.WriteLine("///////////////////////////////////////////////////////");
                Console.WriteLine("Player, enter your name");
                string nameOfPlayer = Console.ReadLine();

                if (nameOfPlayer == null)
                {
                    Console.WriteLine("You didn't enter a name. Let's try again");
                }
                
                else
                {
                    player = nameOfPlayer;
                    Console.WriteLine($"Greetings, {player}");  
                }
            }

            // game with a person
            void GameForTwo()
            {
                Console.WriteLine("///////////////////////////////////////////////////////");
                Console.WriteLine("Now each player will role dices");
                Console.WriteLine("To do so, type 'roll'");
                string command = Console.ReadLine();

                if (command == "roll")
                {
                    RollDice(playerOne.Sum);
                    RollDice(playerTwo.Sum);
                    Result(playerOne.Sum, playerTwo.Sum);
                    AnotherRound();
                }

                else
                {
                    Console.WriteLine("Hahaha, you tried to hack the game");
                    ExitGame();
                }
            }

            // game with computer
            void GameForOne()
            {
                Console.WriteLine("///////////////////////////////////////////////////////");
                Console.WriteLine("Now each player will role dices");
                Console.WriteLine("You will be playing with computer");
                Console.WriteLine("To do so, type 'roll'");
                string command = Console.ReadLine();

                if (command == "roll")
                {
                    RollDice(playerOne.Sum);
                    RollDice(computer.Sum);
                    Result(playerOne.Sum, computer.Sum);
                    AnotherRound();
                }

                else
                {
                    Console.WriteLine("Hahaha, you tried to hack the game");
                    ExitGame();
                }
            }

            // creates 2 random numbers and sum them
            void RollDice(int player)
            {
                Console.WriteLine("///////////////////////////////////////////////////////");
                Random rnd = new Random();
                int diceOne = rnd.Next(1, 7);
                int diceTwo = rnd.Next(1, 7);
                int score = diceOne + diceTwo;
                player = score;
                Console.WriteLine($"Your score is {player}");
            }

            // checks who's got a bigger score
            void Result(int firstSum, int secondSum)
            {
                if (firstSum > secondSum)
                {
                    Console.WriteLine("///////////////////////////////////////////////////////");
                    Console.WriteLine($"{playerOne.Name} scored {playerOne.Sum}");
                    Console.WriteLine($"{playerTwo.Name} scored {playerTwo.Sum}");
                    Console.WriteLine($"The winner is {playerOne.Name}");
                    playerOne.Wins += 1;
                }
                
                else if (firstSum < secondSum)
                {
                    Console.WriteLine("///////////////////////////////////////////////////////");
                    Console.WriteLine($"{playerOne.Name} scored {playerOne.Sum}");
                    Console.WriteLine($"{playerTwo.Name} scored {playerTwo.Sum}");
                    Console.WriteLine($"The winner is {playerTwo.Name}");
                    playerTwo.Wins += 1;
                }
                
                else if (firstSum == secondSum)
                {
                    Console.WriteLine("///////////////////////////////////////////////////////");
                    Console.WriteLine($"{playerOne.Name} scored {playerOne.Sum}");
                    Console.WriteLine($"{playerTwo.Name} scored {playerTwo.Sum}");
                    Console.WriteLine($"DRAW");
                    playerOne.Wins += 1;
                    playerTwo.Wins += 1;
                }
            }

            void AnotherRound()
            {
                Console.WriteLine("///////////////////////////////////////////////////////");
                Console.WriteLine("Would you like to play another round or see leaderboard?");
                string game = Console.ReadLine();

                if (game == "another round" && twoPlayers == true)
                {
                    GameForTwo();
                }

                if (game == "another round" && twoPlayers == false)
                {
                    GameForOne();
                }

                else if (game == "leaderboard" && twoPlayers == true)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine($"{playerOne.Name} won {playerOne.Wins} times");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine($"{playerTwo.Name} won {playerTwo.Wins} times");
                    Console.WriteLine("-----------------------");
                    AnotherRound();
                }
                
                else if (game == "leaderboard" && twoPlayers == false)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine($"{playerOne.Name} won {playerOne.Wins} times");
                    Console.WriteLine("-----------------------");
                    Console.WriteLine($"{computer.Name} won {computer.Wins} times");
                    Console.WriteLine("-----------------------");
                    AnotherRound();
                }
                
                else if (game == "exit")
                {
                    ExitGame();
                }

                else
                {
                    ExitGame();
                }
            }
            
            // Stopping execution of game
            void ExitGame()
            {
                Console.WriteLine("Your game has ended! Press enter to confirm exit");
                Console.ReadLine();
            }
        }
    }
}