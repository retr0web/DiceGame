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
            
            Player playerOne = null;
            Player playerTwo = null;
            Player computer = null;
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
                string numberOfPlayersInput = Console.ReadLine();
                while (numberOfPlayersInput!="1" && numberOfPlayersInput!="2")
                {
                    Console.WriteLine("Greetings. How many players will play");
                    numberOfPlayersInput = Console.ReadLine();
                }
                Console.WriteLine("Player1 introduce yourself");
                playerOne=new Player(Console.ReadLine());
                
                if (numberOfPlayersInput=="2")
                {
                    twoPlayers = true;
                    Console.WriteLine("Player2 introduce yourself");
                    playerTwo=new Player(Console.ReadLine());
                    
                    GameForTwo();
                }
                else
                {
                    computer = new Player("Bobby Shmurda");
                    Console.WriteLine("abbba");
                    GameForOne();
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
                    RollDice(playerOne);
                    RollDice(playerTwo);
                    Result(playerOne, playerTwo);
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
                    RollDice(playerOne);
                    RollDice(computer);
                    Result(playerOne, computer);
                    AnotherRound();
                }

                else
                {
                    Console.WriteLine("Hahaha, you tried to hack the game");
                    ExitGame();
                }
            }

            // creates 2 random numbers and sum them
            void RollDice(Player player)
            {
                Console.WriteLine("///////////////////////////////////////////////////////");
                Random rnd = new Random();
                int diceOne = rnd.Next(1, 7);
                int diceTwo = rnd.Next(1, 7);
                int score = diceOne + diceTwo;
                player.Sum = score;
                Console.WriteLine($"Your score is {player.Sum}");
            }

            // checks who's got a bigger score
            void Result(Player player1,Player player2)
            {
                if (player1.Sum > player2.Sum)
                {
                    Console.WriteLine("///////////////////////////////////////////////////////");
                    Console.WriteLine($"{player1.Name} scored {player1.Sum}");
                    Console.WriteLine($"{player2.Name} scored {player2.Sum}");
                    Console.WriteLine($"The winner is {playerOne.Name}");
                    player1.Wins += 1;
                }
                
                else if (player1.Sum < player2.Sum)
                {
                    Console.WriteLine("///////////////////////////////////////////////////////");
                    Console.WriteLine($"{player1.Name} scored {player1.Sum}");
                    Console.WriteLine($"{player2.Name} scored {player2.Sum}");
                    Console.WriteLine($"The winner is {player2.Name}");
                    player2.Wins += 1;
                }
                
                else if (player1.Sum == player2.Sum)
                {
                    Console.WriteLine("///////////////////////////////////////////////////////");
                    Console.WriteLine($"{player1.Name} scored {player1.Sum}");
                    Console.WriteLine($"{player2.Name} scored {player2.Sum}");
                    Console.WriteLine($"DRAW");
                    player1.Wins += 1;
                    player2.Wins += 1;
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

// made by retr0web and SadSesh