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

        public void RunningGame()
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
            Turn turn = new Turn();

            while(turn.CheckPoints(player1, player2) < 3)
            {
                MakeMove(turn);
                turn.ChangeTurn();
            }
            Console.WriteLine("SLUT");

            

            


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
        private int Choice(string choice, Player player1)
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
        private string MakingMove(Player p){
            Console.WriteLine($"\n{p.name} it is your turn, what move do you want to make?" +
            $"\n1.Rock\n2.Paper\n3.Scissors");
            string move = Console.ReadLine();
            return move;
        }
        private int SaveMove(string move, Player p){
            Console.WriteLine($"\n{p.name}, you have made your move.");
                int intMove = int.Parse(move);
                Move pMove = new Move(intMove);
                int madeMove = pMove.getMove(pMove);
                return madeMove;   
        }
        private void MakeMove(Turn turn){
            int p1Move = 0;
            int p2Move = 0;

            if(turn.CheckTurn(player1, player2) == player1){
                string move = MakingMove(player1);
                switch(move){
                    case "1":
                p1Move = SaveMove(move, player1);
                    break;

                    case "2":
                p1Move = SaveMove(move, player1);
                    break;

                    case "3":
                p1Move = SaveMove(move, player1);
                    break;

                    default:
                    Console.WriteLine("That is not a possible move.");
                    break;
                }
                move = MakingMove(player2);
                switch(move){
                    case "1":
                p2Move = SaveMove(move, player1);
                    break;

                    case "2":
                p2Move = SaveMove(move, player1);
                    break;

                    case "3":
                p2Move = SaveMove(move, player1);
                    break;

                    default:
                    Console.WriteLine("\nThat is not a possible move.");
                    break;
                }
            }
            else{
                string move = MakingMove(player2);
                switch(move){
                    case "1":
                p2Move = SaveMove(move, player1);

                    break;

                    case "2":
                p2Move = SaveMove(move, player1);
                    break;

                    case "3":
                p2Move = SaveMove(move, player1);
                    break;

                    default:
                    Console.WriteLine("That is not a possible move.");
                    break;
                }
                move = MakingMove(player1);
                switch(move){
                    case "1":
                p1Move = SaveMove(move, player1);
                    break;

                    case "2":
                p1Move = SaveMove(move, player1);
                    break;

                    case "3":
                p1Move = SaveMove(move, player1);
                    break;

                    default:
                    Console.WriteLine("That is not a possible move.");
                    break;
                }
                
            }
            Outcome outcome = new Outcome(p1Move, p2Move, player1, player2);
            Console.WriteLine(outcome.CheckOutcome());

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
