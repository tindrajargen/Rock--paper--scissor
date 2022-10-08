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
        public Play()
        {

        }

        public void startGame()
        {
            Player player1 = FirstPlayer();
            string choice = SecondPlayer();
            int result = Choice(choice, player1);
            while(result == 3)
            {
                choice = SecondPlayer();
                result = Choice(choice, player1);
            }
            Rules();

        }
        private Player FirstPlayer()
        {
            Console.WriteLine("Welcome to Rock, paper, scissors!\n" +
            "Please enter the first player's name:");
            Player player1 = new Player(Console.ReadLine());
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
        private int Choice(string choice, Player player1)
        {
            int returnValue;
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Please enter the second player's name:");
                    Player player2 = new Player(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine($"The game will now start between {player1.name}" +
                        $" and {player2.name}");

                    returnValue = 1;
                    return returnValue;

                case "2":
                    Console.WriteLine($"The game will now start between {player1.name}" +
                        $" and the computer!");

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

        }

    }

}
