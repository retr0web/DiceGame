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
            Greetings();
        }

        // Choose with who you will play: Computer or a real person
        static void Greetings()
        {
            Console.WriteLine("Greetings, traveller! Did you brought a friend with you?");
            Console.WriteLine("Hint: answer must be yes or no");
            Console.WriteLine("Additional hint: if you want to exit, just type exit");
            
            string travellerAnswer = Console.ReadLine();
            
            if (travellerAnswer == "yes")
            {
                PlayerBroughtFriend();
            }
            
            else if (travellerAnswer == "no")
            {
                PlayerCameAlone();
            }
            
            else if (travellerAnswer == "exit")
            {
                ExitGame();
            }

            else
            {
                Console.WriteLine("You typed wrong answer! Let's try again");
                Greetings();
            }
        }
        
        // Play with real person
        static void PlayerBroughtFriend()
        {
            Console.WriteLine("You Brought a friend");
            Console.ReadLine();
        }
        
        // Single player
        static void PlayerCameAlone()
        {
            Console.WriteLine("Don't worry, we will find you buddy to play with!");
            Console.ReadLine();
        }
        
        // Stopping execution of game
        static void ExitGame()
        {
            Console.WriteLine("Your game has ended! Press enter to confirm exit");
            Console.ReadLine();
        }
            
    }
}