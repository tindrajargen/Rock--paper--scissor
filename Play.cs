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
        Player? player1;
        Player? player2;

        public void StartGame()
        {
            Player player1 = FirstPlayer();
            string choice = SecondPlayer();
            int result = Choice(player1, choice);
            while (result == 3)
            {
                choice = SecondPlayer();
                result = Choice(player1, choice);
            }
            if (result == 1)
            {
                if(player2 == null)
                {
                    throw new ArgumentNullException("Player 2 is null");
                }
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

            GamePoint scoreP1 = new GamePoint();
            PointKeeper scoreBoardP1 = new PointKeeper(scoreP1);
            scoreP1.Add(scoreBoardP1);

            string? name = Console.ReadLine();

            if (name == null)
            {
                throw new ArgumentNullException("The name is null.");
            }

            Player player1 = new Player(name, scoreP1);
            this.player1 = player1;
            Console.WriteLine();
            return player1;
        }
        private string SecondPlayer()
        {
            Console.WriteLine("Do you want to play against another " +
            "player or against the computer?\n1: Another player\n" +
            "2: The computer");

            string? choice = Console.ReadLine();

            if (choice == null)
            {
                throw new ArgumentNullException("The name is null.");
            }
            return choice;
        }
        private int Choice(Player player1, string choice)
        {
            int returnValue;

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Please enter the second player's name:");

                    GamePoint scoreP2 = new GamePoint();
                    PointKeeper scoreBoardP2 = new PointKeeper(scoreP2);
                    scoreP2.Add(scoreBoardP2);

                    string? name = Console.ReadLine();

                    if (name == null)
                    {
                        throw new ArgumentNullException("The name is null.");
                    }

                    Player player2 = new Player(name, scoreP2);
                    this.player2 = player2;
                    Console.WriteLine();
                    Console.WriteLine($"The game will now start between {player1.name}" +
                        $" and {player2.name}!");
                    tellRules();

                    returnValue = 1;
                    return returnValue;

                case "2":
                    Console.WriteLine($"The game will now start between {player1.name}" +
                        $" and the computer!");
                    tellRules();

                    returnValue = 2;
                    return returnValue;

                default:
                    Console.WriteLine("Please choose an existing option.");

                    returnValue = 3;
                    return returnValue;
            }
        }

        delegate void Rules();
        Rules tellRules = () => Console.WriteLine(
         "\nThe outcome of the game is determined by 3 simple rules: " +
            "\n* Rock wins against scissors. " +
            "\n* Scissors win against paper. " +
            "\n* Paper wins against rock.\n" +
            "\nThe first playser to win three rounds wins the game!");

    }

}
