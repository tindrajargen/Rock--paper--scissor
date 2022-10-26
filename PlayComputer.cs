using static Projekt.IPlay;

namespace Projekt
{
    class PlayComputer : IPlay
    {
        Player player1;
        Player? computer;

        public PlayComputer(Player player1)
        {
            this.player1 = player1;
        }

        public void RunningGame()
        {
            Turn turn = new Turn();

            GamePoint scoreCom = new GamePoint();
            PointKeeper scoreBoardCom = new PointKeeper(scoreCom);
            scoreCom.Add(scoreBoardCom);

            Player computer = new Player("Computer", scoreCom);
            this.computer = computer;

            List<int> highestPoint = turn.ReturnPoints(player1, computer);
            var count = 0;
            
            while(count < 1)
            {
                MakeMove(turn);
                turn.ChangeTurn();
                highestPoint = turn.ReturnPoints(player1, computer);
                count = highestPoint.Count( x => x==3 );
            }
            Winner winner = new Winner(player1, computer);
            Console.WriteLine(winner.declareWinner());
        }
        private string MakingMove(Player p)
        {
            Console.WriteLine($"\n{p.name} it is your turn, what move do you want to make?" +
            $"\n1.Rock\n2.Paper\n3.Scissors\n");
            string? move = Console.ReadLine();

            if(move is null)
            {
                throw new ArgumentNullException("The move is null.");
            }
            return move;
        }
        private string ComputerMove(Player computer)
        {
            Random random = new Random();
            int intMove = random.Next(1, 4);
            string move = intMove.ToString();
            return move;
        }
        private ICompareRPS SaveMove(string move, Player p)
        {
            Console.WriteLine($"\n{p.name}, you have made your move.\n");

            int intMove = int.Parse(move);
            ICompareRPS pMove = new Move(intMove);

            return pMove;
        }
        private void MakeMove(Turn turn)
        {
            ICompareRPS p1Move = new Move(0);
            ICompareRPS comMove = new Move(0);

            if(computer is null)
            {
                throw new ArgumentNullException("Computer is null.");
            }

            if (turn.CheckTurn(player1, computer) == player1)
            {
                string move = MakingMove(player1);
                switch (move)
                {
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
                move = ComputerMove(computer);
                switch (move)
                {
                    case "1":
                        comMove = SaveMove(move, computer);
                        break;

                    case "2":
                        comMove = SaveMove(move, computer);
                        break;

                    case "3":
                        comMove = SaveMove(move, computer);
                        break;

                    default:
                        Console.WriteLine("\nThat is not a possible move.");
                        break;
                }
            }
            else
            {
                string move = ComputerMove(computer);
                switch (move)
                {
                    case "1":
                        comMove = SaveMove(move, computer);

                        break;

                    case "2":
                        comMove = SaveMove(move, computer);
                        break;

                    case "3":
                        comMove = SaveMove(move, computer);
                        break;

                    default:
                        Console.WriteLine("That is not a possible move.");
                        break;
                }
                move = MakingMove(player1);
                switch (move)
                {
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
            ICompare<ICompareRPS> outcome = new Outcome(player1, computer);
            int winner = outcome.CheckOutcome(p1Move, comMove);

            if (winner == 1)
            {
                player1.PrintRoundWinnerMessage();
            }
            else if (winner == 2)
            {
                computer.PrintRoundWinnerMessage();
            }
            else
            {
                Console.WriteLine("You both made the same move, therefore no points are given");
            }

        }
    }
}