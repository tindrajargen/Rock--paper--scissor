using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt
{
    class Play
    {
        Player player1;
        Player player2;
        public Play()
        {

        }
        public void StartGame()
        {
            Player player1 = FirstPlayer();
            string choice= SecondPlayer();
            int result = Choice(player1, choice);
            while(result == 3)
            {
                choice = SecondPlayer();
                result = Choice(player1, choice);
            }
            if(result == 1)
            {
                IPlay playFriend = new PlayFriend(player1, player2);
                playFriend.RunningGame();
            }
            else
            {
                IPlay playComputer = new PlayComputer(player1);
                playComputer.RunningGame();
            }

        }
         private Player FirstPlayer()
        {
            Console.WriteLine("Welcome to Rock, paper, scissors!\n" +
            "Please enter the first player's name:");
            Player player1 = new Player(Console.ReadLine());
            this.player1 = player1;
            Console.WriteLine();
            return player1;
        }
        private string SecondPlayer()
        {
            Console.WriteLine("Do you want to play against another " +
            "player or against the computer?\n1: Another player\n" +
            "2: The computer");

            string choice = Console.ReadLine();
            return choice;
        }
        private int Choice(Player player1, string choice)
        {
            int returnValue;

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Please enter the second player's name:");
                    Player player2 = new Player(Console.ReadLine());
                    this.player2 = player2;
                    Console.WriteLine();
                    Console.WriteLine($"The game will now start between {player1.name}" +
                        $" and {player2.name}!");
                    Rules();

                    returnValue = 1;
                    return returnValue;

                case "2":
                    Console.WriteLine($"The game will now start between {player1.name}" +
                        $" and the computer!");
                    Rules();

                    returnValue = 2;
                    return returnValue;

                default:
                    Console.WriteLine("Please choose an existing option.");

                    returnValue = 3;
                    return returnValue;
            }
        }

        private void Rules()
        {

            Console.WriteLine("\nThe outcome of the game is determined by 3 simple rules: " +
            "\n* Rock wins against scissors. " +
            "\n* Scissors win against paper. " +
            "\n* Paper wins against rock.\n" +
            "\nThe first playser to win three rounds wins the game!");
        }

    }

}
