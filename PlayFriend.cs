using static Projekt.IPlay;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Projekt
{
    class PlayFriend : IPlay
    {
        Player player1;
        Player player2;

        public PlayFriend(Player player1, Player player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        public void RunningGame()
        {
            Turn turn = new Turn();

            List<int> highestPoint = turn.ReturnPoints(player1, player2);
            var count = 0;
            
            while(count < 1)
            {
                MakeMove(turn);
                turn.ChangeTurn();
                highestPoint = turn.ReturnPoints(player1, player2);
                count = highestPoint.Count( x => x==3 );
            }
            Winner winner = new Winner(player1, player2);
            Console.WriteLine(winner.declareWinner());
            Console.ResetColor();
        }
        private string MakingMove(Player p){

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\n{p.name} it is your turn," );
            Console.ResetColor();
            Console.WriteLine("\nwhat move do you want to make?\n1.Rock\n2.Paper\n3.Scissors\n");

            string? move = Console.ReadLine();

            if(move is null)
            {
                throw new ArgumentNullException("The move is null.");
            }

            return move;
        }
        private ICompareRPS SaveMove(string move, Player p){
            Console.WriteLine($"\n{p.name}, you have made your move.\n");
            
                int intMove = int.Parse(move);
                ICompareRPS pMove = new Move(intMove);
                return pMove;   
            



        }
        private void MakeMove(Turn turn){
            ICompareRPS p1Move = new Move(0);
            ICompareRPS p2Move = new Move(0);

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
                    Console.WriteLine("That is an invalid move.");
                    break;
                }
                move = MakingMove(player2);
                switch(move){
                    case "1":
                p2Move = SaveMove(move, player2);
                    break;

                    case "2":
                p2Move = SaveMove(move, player2);
                    break;

                    case "3":
                p2Move = SaveMove(move, player2);
                    break;

                    default:
                    Console.WriteLine("That is an invalid move.");
                    break;
                }
            }
            else{
                string move = MakingMove(player2);
                switch(move){
                    case "1":
                p2Move = SaveMove(move, player2);

                    break;

                    case "2":
                p2Move = SaveMove(move, player2);
                    break;

                    case "3":
                p2Move = SaveMove(move, player2);
                    break;

                    default:
                    Console.WriteLine("That is an invalid move.");
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
                    Console.WriteLine("That is an invalid move.");
                    break;
                }
                
            }
            ICompare<ICompareRPS> outcome = new Outcome(player1, player2);
            //ICompare<Move> outcome1 = outcome;
        
            int winner = outcome.CheckOutcome(p1Move, p2Move);
            if(winner == 1)
            {
               player1.PrintRoundWinnerMessage();
            }
            else if(winner == 2)
            {
               player2.PrintRoundWinnerMessage();
            }
            else
            {
               Console.WriteLine("You both made the same move, therefore no points are given");
            }




        }

    }
}